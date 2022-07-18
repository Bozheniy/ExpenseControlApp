using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseControlApp.Models;

namespace ExpenseControlApp.Data
{
    public static class DataWorker
    {
        public static List<Categories> GetAllCategories()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Categories.ToList();
                return result;
            }
        }
        
        public static List<Expenses> GetAllExpenses()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Expenses.ToList();
                return result;
            }
        }

        public static void  CreateCategories(string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                
                bool checkIsExist = db.Categories.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    Categories newDepartment = new Categories { Name = name };
                    db.Categories.Add(newDepartment);
                    db.SaveChanges();                 
                }
            }
        }
     
        public static void CreateExpenses(string comment, double sum, DateTime dateTime, Categories categories)
        {          
            using (ApplicationContext db = new ApplicationContext())
            {
                Expenses newPosition = new Expenses
                {
                    Comment = comment,
                    Sum = sum,
                    DateTime = dateTime,
                    CategoriesId = categories.Id
                };
                db.Expenses.Add(newPosition);
                db.SaveChanges();
            }
        }

        public static void DeleteCategories(Categories categories)
        {
           using (ApplicationContext db = new ApplicationContext())
            {
                db.Categories.Remove(categories);
                db.SaveChanges();              
            }    
        }
       
        public static void DeleteExpenses(Expenses expenses)
        {
            using (ApplicationContext db = new ApplicationContext())
            {     
                db.Expenses.Remove(expenses);
                db.SaveChanges();
            }
        }

        public static void EditCategories(Categories oldCategories, string newName)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Categories categories = db.Categories.FirstOrDefault(d => d.Id == oldCategories.Id);
                categories.Name = newName;
                db.SaveChanges();     
            }
        }
       
        public static void EditExpenses(Expenses oldExpenses, string newComment, double newSum, DateTime newDateTime, Categories newCategories)
        {       
            using (ApplicationContext db = new ApplicationContext())
            {
                Expenses expenses = db.Expenses.FirstOrDefault(p => p.Id == oldExpenses.Id);
                expenses.Comment = newComment;
                expenses.Sum = newSum;
                expenses.DateTime = newDateTime;
                expenses.CategoriesId = newCategories.Id;
                db.SaveChanges();
                
            }
        }
        public static Categories GetCategoriesById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Categories pos = db.Categories.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        
    }
}
