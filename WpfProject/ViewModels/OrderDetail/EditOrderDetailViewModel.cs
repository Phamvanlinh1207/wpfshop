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
    public class EditOrderDetailViewModel : ViewModelBase
    {
        private decimal _price;
        private int _quantity;
        private int _productId;
        private int _orderId;
        private Product _product;
        private Order _order;

        public int Id { get; set; }

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
        public ICommand UpdateOrderDetailCommand { get; }

        public EditOrderDetailViewModel(int id)
        {
            this.Id = id;
            ProductDao productDao = DataDao.Instance().GetProductDao();
            ProductList = new ObservableCollection<Product>(productDao.findAll());

            OrderDao orderDao = DataDao.Instance().GetOrderDao();
            OrderList = new ObservableCollection<Order>(orderDao.findAll());

            UpdateOrderDetailCommand = new ViewModelCommand(ExecuteUpdateOrderDetailCommand);
            InitData();
        }
        private void ExecuteUpdateOrderDetailCommand(object obj)
        {
            OrderDetailDao orderDetailDao = DataDao.Instance().GetOrderDetailDao();

            int orderDetailId = (int)obj;
            OrderDetail orderDetail = orderDetailDao.findById(orderDetailId);
                
            orderDetail.Price = _price;
            orderDetail.Quantity = _quantity;
            orderDetail.ProductId = Product.Id;
            orderDetail.OrderId = Order.Id;

            orderDetailDao.update(orderDetail);

        }

        private void InitData()
        {
            OrderDetailDao orderDetailDao = DataDao.Instance().GetOrderDetailDao();
            OrderDetail order = orderDetailDao.findById(Id);

            Price = order.Price;
            Quantity = order.Quantity;
            ProductId = order.Product.Id;
            OrderId = order.Order.Id;

            ProductDao productDao = DataDao.Instance().GetProductDao();
            Product = productDao.findById(ProductId);

            OrderDao orderDao = DataDao.Instance().GetOrderDao();
            Order = orderDao.findById(OrderId);
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
        public int ProductId
        {
            get => _productId;
            set
            {
                _productId = value;
                OnPropertyChanged(nameof(ProductId));
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
