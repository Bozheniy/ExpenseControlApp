using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ExpenseControlApp.Commands;
using ExpenseControlApp.Models;
using ExpenseControlApp.Data;
using ExpenseControlApp.Views;


namespace ExpenseControlApp.ViewModels
{
    public class MainWindowsViewsModel : BaseViewModel
    {      
        private List<Categories> allCategories = DataWorker.GetAllCategories();
        public List<Categories> AllCategories
        {
            get { return allCategories; }
            set
            {
                allCategories = value;
                OnPropertyChanged("AllCategories");
            }
        }

        private List<Expenses> allExpenses = DataWorker.GetAllExpenses();
        public List<Expenses> AllExpenses
        {
            get
            {
                return allExpenses;
            }
            private set
            {
                allExpenses = value;
               OnPropertyChanged("AllExpenses");
            }
        }
        public CategoriesViewModel CategoriesViewModel { get; set; }
        public ExpensesViewModel ExpensesViewModel { get; set; }

        /*private string _categoriesName;
        public string CategoriesName
        {
            get { return _categoriesName; }
            set 
            { 
                _categoriesName = value;
                OnPropertyChanged("CategoriesName");
            }
        }      
        public static string ExpensesComment { get; set; }
        public static double ExpensesSum { get; set; }
        public static DateTime ExpensesDateTime { get; set; } = DateTime.Now;
        public static Categories ExpensesCategories { get; set; }*/

        public TabItem SelectedTabItem { get; set; }
        public static Categories SelectedCategoriesItem { get; set; }
        public static Expenses SelectedExpensesItem { get; set; }

        public MainWindowsViewsModel()
        {
            CategoriesViewModel = new CategoriesViewModel();
            ExpensesViewModel = new ExpensesViewModel();
            OpenNewCategoriesEntryPage = new LambdaCommand(OnOpenCategoriesEntryPage);
            OpenNewExpenseEntryPage = new LambdaCommand(OnOpenExpenseEntryPage);
            CreateCategoryCommand = new LambdaCommand(OnCreateCategoryCommand);
            CreateExpensesCommand = new LambdaCommand(OnCreateExpensesCommand);
            DeleteCategoryCommand = new LambdaCommand(OnDeleteCategoryCommand);
            DeleteExpensesCommand = new LambdaCommand(OnDeleteExpensesCommand);
            EditCategoryCommand = new LambdaCommand(OnEditCategoryCommand);
            EditExpensesCommand = new LambdaCommand(OnEditExpensesCommand);            
            ExitAppCommand = new LambdaCommand(OnExitAppCommand);
        }


        #region Commands to open edit pages 
        public ICommand OpenNewCategoriesEntryPage { get; }
        public void OnOpenCategoriesEntryPage(object obj)
        {
            if(SelectedCategoriesItem != null)
            {
                CategoriesEntryPage categoriesEntryPage = new CategoriesEntryPage();
                SetCenterPositionAndOpen(categoriesEntryPage);
                UpdateAllView();
            }
        }

        public ICommand OpenNewExpenseEntryPage { get; }
        private void OnOpenExpenseEntryPage(object obj)
        {
            if(SelectedExpensesItem != null)
            {
                ExpenseEntryPage expenseEntryPage = new ExpenseEntryPage();
                SetCenterPositionAndOpen(expenseEntryPage);
                UpdateAllView();
            }
        }
        #endregion

        #region Commands to add categories and expenses
        public ICommand CreateCategoryCommand { get; }
        private void OnCreateCategoryCommand(object obj)
        {
            #region
            /* if(CategoriesName != null)
             {
                 DataWorker.CreateCategories(CategoriesName);
                 CategoriesName = "";
                 Update();
             }*/
            #endregion
            if(CategoriesViewModel.Name != null && CategoriesViewModel.Name != "")
            {
                DataWorker.CreateCategories(CategoriesViewModel.Name);
                ClearField();
                UpdateAllView();
            }
            
        }

        public ICommand CreateExpensesCommand { get; }
        private void OnCreateExpensesCommand(object obj)
        {
            #region
            /*if(ExpensesCategories != null && ExpensesSum != 0)
            {
                DataWorker.CreateExpenses(ExpensesComment, ExpensesSum, ExpensesDateTime, ExpensesCategories);               
                Update();
            }*/
            #endregion
            if (ExpensesViewModel.Categories != null && ExpensesViewModel.Sum != 0)
            {
                DataWorker.CreateExpenses(ExpensesViewModel.Comment, ExpensesViewModel.Sum, ExpensesViewModel.DateTime, ExpensesViewModel.Categories);
                ClearField();
                UpdateAllView();
            }
        }
        #endregion

        #region Commands to delete
        public ICommand DeleteCategoryCommand { get; }

        private void OnDeleteCategoryCommand(object obj)
        {
            DataWorker.DeleteCategories(SelectedCategoriesItem);
            UpdateAllView();
        }

        public ICommand DeleteExpensesCommand { get; }

        private void OnDeleteExpensesCommand(object obj)
        {
            DataWorker.DeleteExpenses(SelectedExpensesItem);
            UpdateAllView();
        }
        #endregion

        #region Commands to edit
        public ICommand EditCategoryCommand { get; }

        private void OnEditCategoryCommand(object obj)
        {
            #region
            /*if(CategoriesName != null)
            {
                Window window = obj as Window;
                DataWorker.EditCategories(SelectedCategories, CategoriesName);
                window.Close();
            }*/
            #endregion
            if(CategoriesViewModel.Name != null)
            {
                Window window = obj as Window;
                DataWorker.EditCategories(SelectedCategoriesItem, CategoriesViewModel.Name);
                window.Close();
            }

        }

        public ICommand EditExpensesCommand { get; }

        private void OnEditExpensesCommand(object obj)
        {
            #region
            /*if (ExpensesCategories != null && ExpensesSum != 0)
            {
                Window window = obj as Window;
                DataWorker.EditExpenses(SelectedExpenses, ExpensesComment, ExpensesSum, ExpensesDateTime, ExpensesCategories);
                window.Close();
            }*/
            #endregion
            if (ExpensesViewModel.Categories != null && ExpensesViewModel.Sum != 0)
            {
                Window window = obj as Window;
                DataWorker.EditExpenses(SelectedExpensesItem, ExpensesViewModel.Comment, ExpensesViewModel.Sum, ExpensesViewModel.DateTime, ExpensesViewModel.Categories);
                window.Close();
            }
            
        }
        #endregion

        #region Basic commands
        public ICommand ExitAppCommand { get; }
        private void OnExitAppCommand(object obj)
        {
            Application.Current.Shutdown();
        }
        #endregion
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void UpdateAllView()
        {
            AllCategories = DataWorker.GetAllCategories();
            AllExpenses = DataWorker.GetAllExpenses();
        }

        private void ClearField()
        {
            CategoriesViewModel.Name = "";
            ExpensesViewModel.Comment = "";
            ExpensesViewModel.Sum = 0;
            ExpensesViewModel.DateTime = DateTime.Now;
            ExpensesViewModel.Categories = null;
            
        }
    }
}
