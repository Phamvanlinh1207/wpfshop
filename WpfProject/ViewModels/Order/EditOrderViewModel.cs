using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProject.Data.Dao;

namespace WpfProject.ViewModels
{
    public class EditOrderViewModel : ViewModelBase
    {
        private String _code;
        private String _status;
        private int _userId;
        private User _user;
        public int Id { get; set; }

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public ObservableCollection<User> _userList;

        public ObservableCollection<User> UserList
        {
            get { return _userList; }

            set
            {
                _userList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }
        public ICommand UpdateOrderCommand { get; }

        public EditOrderViewModel(int id)
        {
            this.Id = id;
            UserDao userDao = DataDao.Instance().GetUserDao();
            UserList = new ObservableCollection<User>(userDao.findAll());
            UpdateOrderCommand = new ViewModelCommand(ExecuteUpdateOrderCommand);
            InitData();
        }
        private void ExecuteUpdateOrderCommand(object obj)
        {
            OrderDao orderDao = DataDao.Instance().GetOrderDao();

            int userId = (int)obj;
            Order order = orderDao.findById(userId);

            order.Code = _code;
            order.Status = _status;
            order.UserId = User.Id;

            orderDao.update(order);

        }

        private void InitData()
        {
            OrderDao orderDao = DataDao.Instance().GetOrderDao();
            Order order = orderDao.findById(Id);

            Code = order.Code;
            Status = order.Status;
            UserId = order.User.Id;

            UserDao userDao = DataDao.Instance().GetUserDao();
            User = userDao.findById(UserId);
        }

        public string Code
        {
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged(nameof(Code));
            }
        }
        
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }
    }
}
