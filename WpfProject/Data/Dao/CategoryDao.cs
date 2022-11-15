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
        public void insert(Category category);
        public void update(Category category);
        public List<Category> findAll();
        public int count();
        public Category findById(int id);
        public void deleteById(int id);
    }
}
