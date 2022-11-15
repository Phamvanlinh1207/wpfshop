using WpfProject.Data.Dao;
using WpfProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Data.Impl
{
    public class ProductDaoImpl : ProductDao
    {
        private DBDataContext db;
        public ProductDaoImpl()
        {
            db = new DBDataContext(Constants.DB_CONNECT_STRING);
        }
        public int count()
        {
            var ProductList = (List<Product>)from Product in db.GetTable<Product>() select Product;
            return ProductList.Count();
        }

        public void deleteById(int id)
        {
            Product find = db.Products.Single(p => p.Id == id);
            db.Products.DeleteOnSubmit(find);
            db.SubmitChanges();
        }

        public List<Product> findAll()
        {
            var query = from Product in db.GetTable<Product>() select Product;
            List<Product> productList = query.ToList<Product>();
            return productList;
        }

        public Product findById(int id)
        {
            return db.Products.Single(p => p.Id == id);
        }

        public void insert(Product Product)
        {
            db.Products.InsertOnSubmit(Product);
            db.SubmitChanges();
        }

        public void update(Product Product)
        {
            Product find = db.Products.Single(p => p.Id == Product.Id);
            find.Name = Product.Name;
            find.Price = Product.Price;
            find.Quantity = Product.Quantity;
            find.Category = Product.Category;
            db.SubmitChanges();
        }
    }
}
