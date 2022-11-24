using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using WpfProject.Data.Dao;

namespace WpfProject.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

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
        

        public ICommand ShowCreateProductViewCommand { get; }
        public ICommand ShowEditProductViewCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand SearchCommand { get; }

        public ProductViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            ShowCreateProductViewCommand = new ViewModelCommand(ExecuteShowCreateProductViewCommand);
            ShowEditProductViewCommand = new ViewModelCommand(ExecuteEditProductViewCommand);
            DeleteProductCommand = new ViewModelCommand(ExecuteDeleteProductCommand);
            SearchCommand = new ViewModelCommand(ExecuteSearchCommand);

            InitData();
        }

        private void InitData()
        {
            

            _productList = new ObservableCollection<Product>();
            loadProductList();



        }
        private void loadProductList()
        {
            ProductDao productDao = DataDao.Instance().GetProductDao();
            List<Product> list = productDao.findAll();
            _productList.Clear();

            foreach (Product product in list)
            {
                _productList.Add(product);
            }


        }
        private void ExecuteShowCreateProductViewCommand(object obj)
        {
            _mainViewModel.CurrentChildView = new CreateProductViewModel();
        }

        private void ExecuteSearchCommand(object obj)
        {
            string name = (string)obj;
            searchByName(name);
        }
        private void searchByName(string name)
        {
            ProductDao productDao = DataDao.Instance().GetProductDao();
            List<Product> list = productDao.searchByName(name);
            _productList.Clear();
            foreach (Product product in list)
            { 
                _productList.Add(product); 
            }
        }

        private void ExecuteEditProductViewCommand(object obj)
        {
            int Id = (int)obj;
            _mainViewModel.CurrentChildView = new EditProductViewModel(Id);
        }

        private void ExecuteDeleteProductCommand(object obj)
        {
            int Id = (int)obj;
            DataDao.Instance().GetProductDao().deleteById(Id);
            loadProductList();

        }

    }
}
