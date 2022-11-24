using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WpfProject.Data.Dao;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace WpfProject.ViewModels
{
    public class CreateProductViewModel : ViewModelBase
    {
        private String _name;
        private decimal _price;
        private int _quantity;
        private String _description;

        private int _categoryId;
        private Category _category;

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
        public ICommand CreateProductCommand { get; }

        public CreateProductViewModel()
        {
            CategoryDao categoryDao = DataDao.Instance().GetCategoryDao();
            CategoryList = new ObservableCollection<Category>(categoryDao.findAll());
            CreateProductCommand = new ViewModelCommand(ExecuteCreateProductCommand);
        }
        private void ExecuteCreateProductCommand(object obj)
        {
            Product product = new Product();
            product.Name = _name;
            product.Price = _price;
            product.Quantity = _quantity;
            product.Description = _description;
            product.CategoryId = Category.Id;

            ProductDao productDao = DataDao.Instance().GetProductDao();
     
                    
            productDao.insert(product);

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
