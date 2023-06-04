using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext orderDb;

        public OrderController(OrderContext context)
        {
            this.orderDb = context;
        }


        //查询订单
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
           var order= orderDb.Orders.Include("Details").Include("Customer").Include("Details.GoodsItem")
                .FirstOrDefault(t=>t.OrderId == id); 
            if(order == null)
            {
                return NotFound();
            }
            return order;
        }

         [HttpGet]
         public ActionResult<List<Order>> GetOrders(string? customername,string ?goodname,double ?amount)
         {
            var query = buildQuery(customername, goodname, amount);
            return query.ToList();
         }

        private IQueryable<Order> buildQuery(string? customername, string? goodname, double? amount)
        {

            IQueryable<Order> query = orderDb.Orders.//Include(o => o.Customer).Include(o => o.Details).ThenInclude(i => i.Id).
                                        Where(o => o.OrderId != null);
            if (customername != null)
            {
                query = query//.Include(o => o.Customer).Include(o => o.Details)//.ThenInclude(i => i.Id).
                            .Where(o => o.Customer.Name==customername);
            }

            if(goodname != null)
            {
                query = query.//Include(o => o.Customer).Include(o => o.Details).//ThenInclude(i => i.Id).
                            Where(o => o.Details.Any(d=>d.GoodsItem.Name==goodname));
            }
            if(amount != null)
            {
                query = query.//Include(o => o.Customer).Include(o => o.Details).//ThenInclude(i => i.Id).
                            Where(o => o.Details.Sum(d=>d.Quantity*d.GoodsItem.Price)>amount);
            }
            return query;
        }

        //分页
        [HttpGet("pageQuery")]
        public ActionResult<List<Order>> queryOrderItems(string ?customername,string ?goodname,double? amount,int skip,int take)
        {
            var query = buildQuery(customername, goodname, amount).Skip(skip).Take(take);
            return query.ToList();
        }


        //增加订单
        [HttpPost]
        public ActionResult<Order> PostOrderItem(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return order;
        }

        //避免级联添加或者修改Customer和goods
        private void FixOrder(Order neworder)
        {
            neworder.CustomerId = neworder.Customer.Id;
            neworder.Customer = null;
            
            
            neworder.Details.ForEach(d =>
            {
             
                d.GoodsId = d.GoodsItem.Id;
                d.GoodsItem = null;
                
            });
        }

        //修改订单
        [HttpPut("{id}")]
        public ActionResult<Order> PutOrder(Order order)
        {
            /*try
            {
                DeleteOrder(neworder.OrderId);
                PostOrderItem(neworder);
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                if (ex.InnerException != null) error = ex.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();*/
           
           
            try
            {
                DeleteOrder(order.OrderId);
                //FixOrder(order);
                order.Details.ForEach(d =>
                {

                    d.GoodsId = d.GoodsItem.Id;
                    d.GoodsItem = null;

                });
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
                //PostOrderItem(order);



            }
           catch(Exception ex)
            {
                string error = ex.Message;
                if (ex.InnerException != null) error = ex.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        //删除订单
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id)
        {
            try
            {
                var order=orderDb.Orders.Include("Details")
                    .SingleOrDefault(o=>o.OrderId == id);
                if(order== null) return NoContent();
                orderDb.OrderDetails.RemoveRange(order.Details);
                orderDb.Orders.Remove(order);
                orderDb.SaveChanges();
                /*var order=orderDb.Orders.FirstOrDefault(o=>o.OrderId==id);
                if(order!=null)
                {
                    orderDb.Remove(order);
                    orderDb.SaveChanges();
                }*/
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return NoContent();
        }
        



}
}
