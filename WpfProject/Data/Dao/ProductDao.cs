using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Data.Dao
{
    public interface ProductDao
    {
        public void insert(Product product);
        public void update(Product product);
        public List<Product> findAll();
        public int count();
        public Product findById(int id);
        public void deleteById(int id);
    }
}
