﻿namespace ExpenseControlApp.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

    }
}
