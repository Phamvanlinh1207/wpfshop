using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProject.Data.Dao;
using WpfProject.ViewModels;

namespace WpfProject.ViewModels
{
    public class CategoryViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

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

        public ICommand ShowCreateCategoryViewCommand { get; }
        public ICommand ShowEditCategoryViewCommand { get; }
        public ICommand DeleteCategoryCommand { get; }
        public CategoryViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            ShowCreateCategoryViewCommand = new ViewModelCommand(ExecuteShowCreateCategoryViewCommand);
            ShowEditCategoryViewCommand = new ViewModelCommand(ExecuteEditCategoryViewCommand);
            DeleteCategoryCommand = new ViewModelCommand(ExecuteDeleteCategoryCommand);
            InitData();
        }

        private void InitData()
        {
            CategoryDao categoryDao = DataDao.Instance().GetCategoryDao();
            List<Category> list = categoryDao.findAll();

            _categoryList = new ObservableCollection<Category>();
            foreach (Category category in list)
            {
                _categoryList.Add(category);
            }
        }
        private void ExecuteShowCreateCategoryViewCommand(object obj)
        {
            _mainViewModel.CurrentChildView = new CreateCategoryViewModel();
        }
        private void ExecuteEditCategoryViewCommand(object obj)
        {
            int Id = (int)obj;
            _mainViewModel.CurrentChildView = new EditCategoryViewModel(Id);
        }

        private void ExecuteDeleteCategoryCommand(object obj)
        {
            int Id = (int)obj;
            DataDao.Instance().GetCategoryDao().deleteById(Id);
        }

    }
}
