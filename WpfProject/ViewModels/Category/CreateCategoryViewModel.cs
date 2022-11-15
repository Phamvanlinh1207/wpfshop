using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WpfProject.ViewModels
{
    public class CreateCategoryViewModel : ViewModelBase
    {
        private String _email;
        private String _password;
        public ICommand CreateCategoryCommand { get; }

        public CreateCategoryViewModel()
        {
            CreateCategoryCommand = new ViewModelCommand(ExecuteCreateCategoryCommand);
        }

        private void ExecuteCreateCategoryCommand(object obj)
        {
            MessageBox.Show(Email);
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }
}
