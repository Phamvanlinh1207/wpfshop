using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Data.Dao
{
    public interface UserDao
    {
        public void insert(User user);
        public void update(User user);
        public List<User> findAll();
        public int count();
        public User findById(int id);
        public void deleteById(int id);

        public User find(string phone, string password);
    }
}
