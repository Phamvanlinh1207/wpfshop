using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfProject.Data.Dao;

namespace WpfProject.ViewModels
{
    public class OrderDetailViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

        private int _orderId;


        public ObservableCollection<OrderDetail> _orderDetailList;
        public ObservableCollection<OrderDetail> OrderDetailList
        {
            get { return _orderDetailList; }
            set
            {
                _orderDetailList = value;
                OnPropertyChanged(nameof(OrderDetailList));
            }
        }




        public ICommand ShowCreateOrderDetailViewCommand { get; }
        public ICommand ShowEditOrderDetailViewCommand { get; }
        public ICommand DeleteOrderDetailCommand { get; }
        public OrderDetailViewModel(MainViewModel mainViewModel, int orderId)
        {
            _orderId = orderId;
            _mainViewModel = mainViewModel;
            ShowCreateOrderDetailViewCommand = new ViewModelCommand(ExecuteShowCreateOrderDetailViewCommand);
            ShowEditOrderDetailViewCommand = new ViewModelCommand(ExecuteEditOrderDetailViewCommand);
            DeleteOrderDetailCommand = new ViewModelCommand(ExecuteDeleteOrderDetailCommand);
            InitData(orderId);
            

        }

        private void InitData(int orderId)
        {

            OrderDetailDao orderDetailDao = DataDao.Instance().GetOrderDetailDao();
            List<OrderDetail> list = orderDetailDao.findByOrder(orderId);

            _orderDetailList = new ObservableCollection<OrderDetail>();
            foreach (OrderDetail orderDetail in list)
            {
                _orderDetailList.Add(orderDetail);
            }

        }
        private void InitData()
        {

            OrderDetailDao orderDetailDao = DataDao.Instance().GetOrderDetailDao();
            List<OrderDetail> list = orderDetailDao.findAll();

            _orderDetailList = new ObservableCollection<OrderDetail>();
            foreach (OrderDetail orderDetail in list)
            {
                _orderDetailList.Add(orderDetail);
            }

        }
        private void ExecuteShowCreateOrderDetailViewCommand(object obj)
        {
            _mainViewModel.CurrentChildView = new CreateOrderDetailViewModel();
        }
        private void ExecuteEditOrderDetailViewCommand(object obj)
        {
            int Id = (int)obj;
            _mainViewModel.CurrentChildView = new EditOrderDetailViewModel(Id);
        }

        private void ExecuteDeleteOrderDetailCommand(object obj)
        {
            int Id = (int)obj;
            OrderDetailDao orderDetailDao = DataDao.Instance().GetOrderDetailDao();
            OrderDetail orderDetail = orderDetailDao.findById(Id);
            int orderId = (int) orderDetail.OrderId;

            DataDao.Instance().GetOrderDetailDao().deleteById(Id);

            OrderDao orderDao = DataDao.Instance().GetOrderDao();
            Order order = orderDao.findById(orderId);

            bool isEmpty = orderDao.checkEmpty(orderId);

            if (isEmpty)
                order.Status = Order.ORDER_STATUS_EMPTY;
            else
                order.Status = Order.ORDER_STATUS_NOT_EMPTY;

            orderDao.update(order);


        }
    }
}
