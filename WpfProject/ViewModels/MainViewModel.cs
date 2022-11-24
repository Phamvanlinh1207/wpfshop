using System.Windows;
using System.Windows.Input;
using WpfProject.Data.Dao;
using WpfProject.Views;

namespace WpfProject.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        public ICommand LoginCommand { get; }
        private Visibility _IsVisible;
        public Visibility IsVisible
        {
            get { return _IsVisible; }
            set
            {
                _IsVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }



        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowUserViewCommand { get; }
        public ICommand ShowProductViewCommand { get; }
        public ICommand ShowCategoryViewCommand { get; }
        public ICommand ShowOrderViewCommand { get; }
        public ICommand ShowOrderDetailViewCommand { get; }

        public MainViewModel()
        {
            ShowUserViewCommand = new ViewModelCommand(ExecuteShowUserViewCommand);
            ShowCategoryViewCommand = new ViewModelCommand(ExecuteShowCategoryViewCommand);
            ShowProductViewCommand = new ViewModelCommand(ExecuteShowProductViewCommand);
            ShowOrderViewCommand = new ViewModelCommand(ExecuteShowOrderViewCommand);
            //ShowOrderDetailViewCommand = new ViewModelCommand(ExecuteShowOrderDetailViewCommand);
            LoginCommand = new RelayCommand<object>(CanExecuteLogOutCommand, ExecuteLogOutCommand);

            //Default view
            ExecuteShowUserViewCommand(null);
            ExecuteShowCategoryViewCommand(null);
            ExecuteShowProductViewCommand(null);
            ExecuteShowOrderViewCommand(null);
            //ExecuteShowOrderDetailViewCommand(null);




        }
        private void ExecuteLogOutCommand(object obj)
        {
                LoginView mainWindow = new LoginView();
                mainWindow.Show();
                IsVisible = Visibility.Hidden;    
        }
        private bool CanExecuteLogOutCommand(object obj)
        {
            return true;
        }
        private void ExecuteShowUserViewCommand(object obj)
        {
            CurrentChildView = new UserViewModel(this);
        }
        private void ExecuteShowCategoryViewCommand(object obj)
        {
            CurrentChildView = new CategoryViewModel(this);
        }
        private void ExecuteShowProductViewCommand(object obj)
        {
            CurrentChildView = new ProductViewModel(this);
        }
        private void ExecuteShowOrderViewCommand(object obj)
        {
            CurrentChildView = new OrderViewModel(this);
        }
        //private void ExecuteShowOrderDetailViewCommand(object obj)
        //{
        //    CurrentChildView = new OrderDetailViewModel(this);
        //}

    }
}
