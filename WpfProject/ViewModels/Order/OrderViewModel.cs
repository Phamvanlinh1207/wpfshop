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
using WpfProject;

namespace WpfProject.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

        public ObservableCollection<Order> _orderList;
        public ObservableCollection<Order> OrderList
        {
            get { return _orderList; }
            set
            {
                _orderList = value;
                OnPropertyChanged(nameof(OrderList));
            }
        }

        public ICommand ShowCreateOrderViewCommand { get; }
        public ICommand ShowEditOrderViewCommand { get; }
        public ICommand DeleteOrderCommand { get; }
        public ICommand ShowOrderDetailCommand { get; }

        public OrderViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            ShowCreateOrderViewCommand = new ViewModelCommand(ExecuteShowCreateOrderViewCommand);
            ShowEditOrderViewCommand = new ViewModelCommand(ExecuteEditOrderViewCommand);
            DeleteOrderCommand = new ViewModelCommand(ExecuteDeleteOrderCommand);
            ShowOrderDetailCommand = new ViewModelCommand(ExecuteShowOrderDetailViewCommand);
            InitData();
        }

        private void InitData()
        {
            OrderDao orderDao = DataDao.Instance().GetOrderDao();
            List<Order> list = orderDao.findAll();

            _orderList = new ObservableCollection<Order>();
            foreach (Order order in list)
            {
                _orderList.Add(order);
            }
        }
        private void ExecuteShowOrderDetailViewCommand(object obj)
        {
            int Id = (int)obj;
            _mainViewModel.CurrentChildView = new OrderDetailViewModel(_mainViewModel, Id);
        }
        private void ExecuteShowCreateOrderViewCommand(object obj)
        {
            _mainViewModel.CurrentChildView = new CreateOrderViewModel();
        }
        private void ExecuteEditOrderViewCommand(object obj)
        {
            int Id = (int)obj;
            _mainViewModel.CurrentChildView = new EditOrderViewModel(Id);
        }

        private void ExecuteDeleteOrderCommand(object obj)
        {
            int Id = (int)obj;
            DataDao.Instance().GetUserDao().deleteById(Id);
        }

    }
}
