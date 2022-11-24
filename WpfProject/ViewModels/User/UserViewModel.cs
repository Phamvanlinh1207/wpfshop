using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfProject.Data.Dao;
using WpfProject.ViewModels;
using WpfProject;
using System.Xml.Linq;

namespace WpfProject.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

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

        public ICommand ShowCreateUserViewCommand { get; }
        public ICommand ShowEditUserViewCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public UserViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            ShowCreateUserViewCommand = new ViewModelCommand(ExecuteShowCreateUserViewCommand);
            ShowEditUserViewCommand = new ViewModelCommand(ExecuteEditUserViewCommand);
            DeleteUserCommand = new ViewModelCommand(ExecuteDeleteUserCommand);
            InitData();
        }

        private void InitData()
        {
            UserDao userDao = DataDao.Instance().GetUserDao();
            List<User> list = userDao.findAll();

            _userList = new ObservableCollection<User>();
            foreach (User user in list)
            {
                _userList.Add(user);
            }
        }
        private void ExecuteShowCreateUserViewCommand(object obj)
        {
            _mainViewModel.CurrentChildView = new CreateUserViewModel();
        }
        private void ExecuteEditUserViewCommand(object obj)
        {
            int Id = (int)obj;
            _mainViewModel.CurrentChildView = new EditUserViewModel(Id);
        }

        private void ExecuteDeleteUserCommand(object obj)
        {
            int Id = (int)obj;
            DataDao.Instance().GetUserDao().deleteById(Id);
            
        }

    }
}
