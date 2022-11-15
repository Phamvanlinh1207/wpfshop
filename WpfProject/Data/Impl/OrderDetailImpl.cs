using WpfProject.Data.Dao;
using WpfProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfProject.Data.Impl
{
    public class OrderDetailImpl : OrderDetailDao
    {
        private DBDataContext db;
        public OrderDetailImpl()
        {
            db = new DBDataContext(Constants.DB_CONNECT_STRING);
        }

        public int count()
        {
            var query = from order in db.GetTable<OrderDetail>() select order;
            List<OrderDetail> orderList = query.ToList<OrderDetail>();
            return orderList.Count();
        }

        public void deleteById(int id)
        {
            OrderDetail find = db.OrderDetails.Single(us => us.Id == id);
            db.OrderDetails.DeleteOnSubmit(find);
            db.SubmitChanges();
        }

        public List<OrderDetail> findAll()
        {
            var query = from orderDetail in db.GetTable<OrderDetail>() select orderDetail;
            List<OrderDetail> orderDetailList = query.ToList<OrderDetail>();
            return orderDetailList;
        }

        public OrderDetail findById(int id)
        {
            return db.OrderDetails.Single(us => us.Id == id);
        }

        public void insert(OrderDetail orderDetail)
        {
            db.OrderDetails.InsertOnSubmit(orderDetail);
            db.SubmitChanges();
        }

        public void update(OrderDetail orderDetail)
        {
            OrderDetail find = db.OrderDetails.Single(us => us.Id == orderDetail.Id);
            find.OrderCode = orderDetail.OrderCode;
            find.ProductId = orderDetail.ProductId;
            find.Quantity = orderDetail.Quantity;
            find.Price = orderDetail.Price;
            db.SubmitChanges();
        }
    }
}
