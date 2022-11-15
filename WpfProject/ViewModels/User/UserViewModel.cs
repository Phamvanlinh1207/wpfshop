using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProject.ViewModels;

namespace WpfProject.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

        public ICommand ShowCreateUserViewCommand { get; }
        public UserViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            ShowCreateUserViewCommand = new ViewModelCommand(ExecuteShowCreateUserViewCommand);
        }
        private void ExecuteShowCreateUserViewCommand(object obj)
        {
            _mainViewModel.CurrentChildView = new CreateUserViewModel();
            //_mainViewModel.Caption = "Create Users";
            //_mainViewModel.Icon = IconChar.User;
        }
    }
}
