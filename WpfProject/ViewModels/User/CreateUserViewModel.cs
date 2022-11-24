using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WpfProject.Data.Dao;

namespace WpfProject.ViewModels
{
    public class CreateUserViewModel : ViewModelBase
    {
        private String _name;
        private String _phone;
        private String _password;
        private String _role;

        public ICommand CreateUserCommand { get; }

        public CreateUserViewModel()
        {
            CreateUserCommand = new ViewModelCommand(ExecuteCreateUserCommand);
        }

        private void ExecuteCreateUserCommand(object obj)
        {
            User user = new User();
            user.Name = Name;
            user.Phone = Phone;
            user.Password = Password;
            user.Role = Role;


            UserDao userDao = DataDao.Instance().GetUserDao();
            userDao.insert(user);
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Role
        {
            get => _role;
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }
    }
}
