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
        public class CreateOrderViewModel : ViewModelBase
        {
            private String _code;
            private String _status;
            private int _userId;
        private User _user;

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

        public ICommand CreateOrderCommand { get; }

            public CreateOrderViewModel()

        {
            UserDao userDao = DataDao.Instance().GetUserDao();
            UserList = new ObservableCollection<User>(userDao.findAll());

            CreateOrderCommand = new ViewModelCommand(ExecuteCreateOrderCommand);
            }

            private void ExecuteCreateOrderCommand(object obj)
            {
            Order user = new Order();
                user.Code = Code;
                user.Status = Status;
                user.UserId = User.Id;


            OrderDao orderDao = DataDao.Instance().GetOrderDao();
            orderDao.insert(user);
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
                get { return _userId; }
                set
                {
                _userId = value;
                    OnPropertyChanged(nameof(UserId));
                }
            }
            
        }
    
}
