using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProject.Data.Dao;

namespace WpfProject.ViewModels
{
    public class EditCategoryViewModel : ViewModelBase
    {
        private String _name;
        private String _description;
        public ICommand UpdateCategoryCommand { get; }
        public int Id { get; set; }
        public EditCategoryViewModel(int id)
        {
            this.Id = id;
            UpdateCategoryCommand = new ViewModelCommand(ExecuteUpdateCategoryCommand);
            InitData();
        }

        private void InitData()
        {
            CategoryDao categoryDao = DataDao.Instance().GetCategoryDao();
            Category category = categoryDao.findById(Id);
            Name = category.Name;
            Description = category.Description;
        }
        private void ExecuteUpdateCategoryCommand(object obj)
        {
            CategoryDao categoryDao = DataDao.Instance().GetCategoryDao();
            Category category = categoryDao.findById(Id);
            category.Name = _name;
            category.Description = _description;

            categoryDao.update(category);
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
