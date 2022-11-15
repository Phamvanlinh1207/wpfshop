using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Data.Dao
{
    public interface OrderDetailDao
    {
        public void insert(OrderDetail orderDetail);
        public void update(OrderDetail orderDetail);
        public List<OrderDetail> findAll();
        public int count();
        public OrderDetail findById(int id);
        public void deleteById(int id);
    }
}
