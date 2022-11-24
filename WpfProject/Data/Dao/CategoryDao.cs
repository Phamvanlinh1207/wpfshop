using WpfProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Data.Dao
{
    public interface CategoryDao
    {
         void insert(Category category);
         void update(Category category);
         List<Category> findAll();
         int count();
         Category findById(int id);
         void deleteById(int id);
    }
}
