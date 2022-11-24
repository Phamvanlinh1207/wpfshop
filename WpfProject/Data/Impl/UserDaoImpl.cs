using WpfProject.Data.Dao;
using WpfProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Data.Impl
{
    public class UserDaoImpl : UserDao
    {
        private DBDataContext db;
        public UserDaoImpl()
        {
            db = new DBDataContext(Constants.DB_CONNECT_STRING);
        }

        public int count()
        {
            var query = from user in db.GetTable<User>() select user;
            List<User> userList = query.ToList<User>();
            return userList.Count();
        }

        public void deleteById(int id)
        {
            User find = db.Users.Single(us => us.Id == id);
            db.Users.DeleteOnSubmit(find);
            db.SubmitChanges();
        }

        public User find(string phone, string password)
        {
            try
            {
               return db.Users.Single(us => us.Phone == phone && us.Password == password);
            }
            catch (Exception ex) { }
            return null;
        }
 

        public List<User> findAll()
        {
            var all = from user in db.GetTable<User>() select user;
            var userList = all.ToList();
            return userList;
        }

        public User findById(int id)
        {
            return db.Users.Single(us => us.Id == id);
        }

        public void insert(User user)
        {
            db.Users.InsertOnSubmit(user);
            db.SubmitChanges();
        }

        public void update(User user)
        {
            User find = db.Users.Single(us => us.Id == user.Id);
            find.Name = user.Name;
            find.Phone = user.Phone;
            find.Password  = user.Password;
            find.Role = user.Role;
            db.SubmitChanges();
        }
    }
}
