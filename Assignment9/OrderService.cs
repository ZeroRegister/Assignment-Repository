using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Assignment9.Models {

    /**
     * The service class to manage orders
     * */
    public class OrderService {

        OrderDbContext dbContext;

        public OrderService(OrderDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public List<Order> GetAllOrders() {
            return dbContext.Orders
                .Include(o => o.Details)
                .ThenInclude(d => d.GoodsItem)
                .Include(o => o.Customer)
                .ToList<Order>();
        }

        public Order GetOrder(string id) {
            return dbContext.Orders
                .Include(o => o.Details)
                .ThenInclude(d => d.GoodsItem)
                .Include(o => o.Customer)
                .SingleOrDefault(o => o.OrderId == id);
        }

        public void AddOrder(Order order) {
            FixOrder(order);
            dbContext.Entry(order).State = EntityState.Added;
            dbContext.SaveChanges();
        }

        public void RemoveOrder(string orderId) {
            var order = dbContext.Orders
                .Include(o => o.Details)
                .SingleOrDefault(o => o.OrderId == orderId);
            if (order == null) return;
            dbContext.OrderDetails.RemoveRange(order.Details);
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();
        }

        public List<Order> QueryOrdersByGoodsName(string goodsName) {
            var query = dbContext.Orders
                .Include(o => o.Details)
                .ThenInclude(d => d.GoodsItem)
                .Include(o=> o.Customer)
                .Where(order => order.Details.Any(item => item.GoodsItem.Name == goodsName));
            return query.ToList();
        }

        public List<Order> QueryOrdersByCustomerName(string customerName) {
            return dbContext.Orders
                .Include(o => o.Details)
                .ThenInclude(d => d.GoodsItem)
                .Include("Customer")
              .Where(order => order.Customer.Name == customerName)
              .ToList();
        }

        public void UpdateOrder(Order newOrder) {
            RemoveOrder(newOrder.OrderId);
            AddOrder(newOrder);
        }

        //避免级联添加或修改Customer和Goods
        private static void FixOrder(Order newOrder) {
            if (newOrder.Customer != null) {
                newOrder.CustomerId = newOrder.Customer.Id;
            }
            newOrder.Customer = null;
            newOrder.Details.ForEach(d => {
                if (d.GoodsItem != null) {
                    d.GoodsId = d.GoodsItem.Id;
                }
                d.GoodsItem = null;
            });
        }

        public void Export(String fileName) {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
                xs.Serialize(fs, GetAllOrders());
            }
        }

        public void Import(string path) {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open)) {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order => {
                    if (dbContext.Orders.SingleOrDefault(o => o.OrderId == order.OrderId) == null) {
                        FixOrder(order);
                        dbContext.Orders.Add(order);
                    }
                });
                dbContext.SaveChanges();
            }
        }

        public object QueryByTotalAmount(float amout) {
            return dbContext.Orders.Include(o => o.Details).ThenInclude(d => d.GoodsItem).Include("Customer")
            .Where(order => order.Details.Sum(d => d.Quantity * d.GoodsItem.Price) > amout)
            .ToList();
        }
    }
}
