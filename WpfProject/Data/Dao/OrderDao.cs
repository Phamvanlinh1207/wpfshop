using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Data.Dao
{
    public interface OrderDao
    {
          void insert(Order order);
          void update(Order order);
          List<Order> findAll();
          int count();
          Order findById(int id);
          void deleteById(int id);

        bool checkEmpty(int id);
    }
}
