using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfProject.Data.Dao;

namespace WpfProject.ViewModels
{
    public class EditProductViewModel : ViewModelBase
    {
        private String _name;
        private decimal _price;
        private int _quantity;
        private String _description;
        private int _categoryId;
        private Category _category;
        public int Id { get; set; }

        public Category Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        public ObservableCollection<Category> _categoryList;

        public ObservableCollection<Category> CategoryList
        {
            get { return _categoryList; }

            set
            {
                _categoryList = value;
                OnPropertyChanged(nameof(CategoryList));
            }
        }
        public ICommand UpdateProductCommand { get; }

        public EditProductViewModel(int id)
        {
            this.Id = id;
            CategoryDao categoryDao = DataDao.Instance().GetCategoryDao();
            CategoryList = new ObservableCollection<Category>(categoryDao.findAll());
            UpdateProductCommand = new ViewModelCommand(ExecuteUpdateProductCommand);
            InitData();
        }
        private void ExecuteUpdateProductCommand(object obj)
        {
            ProductDao productDao = DataDao.Instance().GetProductDao();
            int productId = (int)obj;

            Product product = productDao.findById(productId);

            product.Name = _name;
            product.Price = _price;
            product.Quantity = _quantity;
            product.Description = _description;
            product.CategoryId = Category.Id;

            productDao.update(product);

        }

        private void InitData()
        {
            ProductDao productDao = DataDao.Instance().GetProductDao();
            Product product = productDao.findById(Id);

            Name = product.Name;
            Price = product.Price;
            Quantity = product.Quantity;
            Description = product.Description;
            CategoryId = product.Category.Id;

            CategoryDao categoryDao = DataDao.Instance().GetCategoryDao();
            Category = categoryDao.findById(CategoryId);
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
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
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public int CategoryId
        {
            get => _categoryId;
            set
            {
                _categoryId = value;
                OnPropertyChanged(nameof(CategoryId));
            }
        }
    }
}
