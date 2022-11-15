using WpfProject.Data.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Data.Dao
{
    public class SqlServerDataDao : DataDao
    {
        public override CategoryDao GetCategoryDao()
        {
            return new CategoryDaoImpl();
        }

        public override ProductDao GetProductDao()
        {
            return new ProductDaoImpl();
        }

        public override UserDao GetUserDao()
        {
            return new UserDaoImpl();
        }
    }
}
