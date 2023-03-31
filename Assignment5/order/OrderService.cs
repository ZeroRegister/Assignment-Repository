using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp {

    public class OrderService {


        private readonly List<Order> orders = new List<Order>();

        public OrderService() {
        }

        //添加订单
        public void AddOrder(Order order) {
            if (orders.Contains(order)) {
                throw new ApplicationException($"the order {order.Id} already exists!");
            }
            orders.Add(order);
        }

        //更新订单
        public void Update(Order order) {
            int idx = orders.FindIndex(o => o.Id == order.Id);
            if (idx < 0) {
                throw new ApplicationException($"the order {order.Id} doesn't exist!");
            }
            orders.RemoveAt(idx);
            orders.Add(order);
        }

        //根据Id查询订单
        public Order GetById(int orderId) {
            return orders.FirstOrDefault(o => o.Id == orderId);
        }

        //根据Id删除订单
        public void RemoveOrder(int orderId) {
            int idx=orders.FindIndex(o => o.Id == orderId);
            if (idx >= 0) {
                orders.RemoveAt(idx);
            }
            /**
            orders.RemoveAll(o => o.Id == orderId);
            */
        }

        //查询所有订单
        public List<Order> QueryAll() {
            return orders;
        }

        //根据客户名查询
        public List<Order> QueryByCustomerName(string customerName) {
            var query = orders
                .Where(o => o.Customer.Name == customerName)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        //根据货物名查询
        public List<Order> QueryByGoodsName(string goodsName) {
            var query = orders.Where(
              o => o.Details.Any(d => d.Goods.Name == goodsName))
                .OrderBy(o => o.TotalPrice);
            return query.ToList();

            /** 其他方法
            var query2 = orders.Where(
              o => o.Details.Exists(d => d.Goods.Name == goodsName))
                .OrderBy(o => o.TotalPrice);

            var query3 = orders.Where(
             o => o.Details.Where(d => d.Goods.Name == goodsName).Count()>0)
               .OrderBy(o => o.TotalPrice);

            var query4 = orders.Where(
             o => HasGoods(o,goodsName)) //写一个HasGoods方法，来检查o中是否包含名为goodName的货物
               .OrderBy(o => o.TotalPrice); 
            **/
        }

        //根据总价查询
        public List<Order> QueryByTotalPrice(float totalPrice) {
            var query = orders.Where(o => o.TotalPrice >= totalPrice)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }


        //对orders中的数据进行排序
        public void Sort(Comparison<Order> comparison) {
            orders.Sort(comparison);
        }

        //根据传入的条件进行查询
        public IEnumerable<Order> Query(Predicate<Order> condition) {
            return orders.Where(o => condition(o)).OrderBy(o=>o.TotalPrice);
        }

    }
}
