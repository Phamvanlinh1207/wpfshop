using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfProject.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

        public ICommand ShowCreateProductViewCommand { get; }
        public ProductViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            ShowCreateProductViewCommand = new ViewModelCommand(ExecuteShowCreateProductViewCommand);
        }
        private void ExecuteShowCreateProductViewCommand(object obj)
        {
            _mainViewModel.CurrentChildView = new CreateProductViewModel();
            //_mainViewModel.Caption = "Create Users";
            //_mainViewModel.Icon = IconChar.User;
        }
    }
}
