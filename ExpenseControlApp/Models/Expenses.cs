using System;
using System.ComponentModel.DataAnnotations.Schema;
using ExpenseControlApp.Data;

namespace ExpenseControlApp.Models
{
    public class Expenses
    { 
        public int Id { get; set; }
        public string Comment { get; set; }
        public double Sum { get; set; }
        public DateTime DateTime { get; set; }
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
        [NotMapped]
        public Categories ExpensesCategory
        {
            get
            {
                return DataWorker.GetCategoriesById(CategoriesId);
            }
        }
    }
}
