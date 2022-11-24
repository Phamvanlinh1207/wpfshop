using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WpfProject.Data.Dao;

namespace WpfProject.ViewModels
{
    public class CreateCategoryViewModel : ViewModelBase
    {
        private String _name;
        private String _description;

        public ICommand CreateCategoryCommand { get; }
        public CreateCategoryViewModel()
        {
            CreateCategoryCommand = new ViewModelCommand(ExecuteCreateCategoryCommand);
        }
        private void ExecuteCreateCategoryCommand(object obj)
        {
            Category category = new Category();
            category.Name = _name;
            category.Description = _description;

            CategoryDao categoryDao = DataDao.Instance().GetCategoryDao();
            categoryDao.insert(category);

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
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }
}
