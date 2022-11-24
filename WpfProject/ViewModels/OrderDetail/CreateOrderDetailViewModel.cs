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
    public class CreateOrderDetailViewModel : ViewModelBase
    {
        private decimal _price;
        private int _quantity;
        private int _productId;
        private int _orderId;
        private Product _product;
        private Order _order;


        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }

        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }
        public ObservableCollection<Product> _productList;

        public ObservableCollection<Product> ProductList
        {
            get { return _productList; }

            set
            {
                _productList = value;
                OnPropertyChanged(nameof(ProductList));
            }
        }


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


        public ICommand CreateOrderDetailCommand { get; }

        public CreateOrderDetailViewModel()
        {
            ProductDao productDao = DataDao.Instance().GetProductDao();
            ProductList = new ObservableCollection<Product>(productDao.findAll());

            OrderDao orderDao = DataDao.Instance().GetOrderDao();
            OrderList = new ObservableCollection<Order>(orderDao.findAll());

            CreateOrderDetailCommand = new ViewModelCommand(ExecuteCreateOrderDetailCommand);
        }
        private void ExecuteCreateOrderDetailCommand(object obj)
        {
            OrderDetail orderDetail = new OrderDetail();

            orderDetail.ProductId = Product.Id;
            orderDetail.Price = _price;
            orderDetail.Quantity = _quantity;
            orderDetail.OrderId = Order.Id;

            OrderDetailDao orderDetailDao = DataDao.Instance().GetOrderDetailDao();
            orderDetailDao.insert(orderDetail);



            OrderDao orderDao = DataDao.Instance().GetOrderDao();
            bool isEmpty = orderDao.checkEmpty(Order.Id);

            if (isEmpty)
                _order.Status = Order.ORDER_STATUS_EMPTY;
            else
                _order.Status = Order.ORDER_STATUS_NOT_EMPTY;

            orderDao.update(_order);


        }
        public int ProductId
        {
            get => _productId;
            set
            {
                _productId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public int OrderId
        {
            get => _orderId;
            set
            {
                _orderId = value;
                OnPropertyChanged(nameof(OrderId));
            }
        }
    }
}
