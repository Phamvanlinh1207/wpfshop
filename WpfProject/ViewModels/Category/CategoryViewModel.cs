using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProject.ViewModels;

namespace WpfProject.ViewModels
{
    public class CategoryViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

        public ICommand ShowCreateCategoryViewCommand { get; }
        public CategoryViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            ShowCreateCategoryViewCommand = new ViewModelCommand(ExecuteShowCreateCategoryViewCommand);
        }
        private void ExecuteShowCreateCategoryViewCommand(object obj)
        {
            _mainViewModel.CurrentChildView = new CreateCategoryViewModel();
            //_mainViewModel.Caption = "Create Users";
            //_mainViewModel.Icon = IconChar.User;
        }
    }
}
