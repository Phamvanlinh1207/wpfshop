using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Data.Dao
{
    public interface ProductDao
    {
          void insert(Product product);
          void update(Product product);
          List<Product> findAll();
        List<Product> searchByName(String name);

        int count();
          Product findById(int id);

          void deleteById(int id);
    }
}
