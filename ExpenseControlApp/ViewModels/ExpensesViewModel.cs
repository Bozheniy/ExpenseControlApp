using System;
using ExpenseControlApp.Models;

namespace ExpenseControlApp.ViewModels
{
    public class ExpensesViewModel : BaseViewModel
    {
        private string comment;
        private double sum;
        private DateTime dateTime = DateTime.Now;
        private Categories categories;

        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                OnPropertyChanged("Comment");
            }
        }
        public double Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                OnPropertyChanged("Sum");
            }
        }
        public  DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged("DateTime");
            }
        }
        public  Categories Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }
    }
}
