using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Data.Dao
{
    public interface UserDao
    {
          void insert(User user);
          void update(User user);
          List<User> findAll();
          int count();
          User findById(int id);
          void deleteById(int id);

          User find(string phone, string password);
        //User find(string name, string phone, string password, string role);
    }
}
