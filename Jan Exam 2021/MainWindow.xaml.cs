using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jan_Exam_2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Account> accounts; //contains all accounts
        public List<Account> filteredAccounts; //used to filter accounts

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Initialise collections
            accounts = new List<Account>();
            filteredAccounts = new List<Account>();

            //Create two current and two savings accounts
            CurrentAccount current1 = new CurrentAccount() { FirstName = "John", LastName = "Smith", AccountNumber = 1, Balance = 2500m };
            CurrentAccount current2 = new CurrentAccount() { FirstName = "Jane", LastName = "Jones", AccountNumber = 2, Balance = 3500m };
            SavingsAccount savings1 = new SavingsAccount() { FirstName = "Joe", LastName = "Murphy", AccountNumber = 3, Balance = 5000m };
            SavingsAccount savings2 = new SavingsAccount() { FirstName = "Jess", LastName = "Walsh", AccountNumber = 4, Balance = 7500m };

            //Add all accounts to main collection
            accounts.Add(current1);
            accounts.Add(current2);
            accounts.Add(savings1);
            accounts.Add(savings2);

            //Set initial values on checkboxes
            ChbxCurrentAccounts.IsChecked = true;
            ChbxSavingsAccounts.IsChecked = true;
        }

        //Filters current and savings accounts
        private void Chbx_Click(object sender, RoutedEventArgs e)
        {
            //all accounts
            if ((ChbxCurrentAccounts.IsChecked == true) && (ChbxSavingsAccounts.IsChecked == true))
            {
                UpdateListBox(accounts);
            }

            //no accounts
            else if ((ChbxCurrentAccounts.IsChecked == false) && (ChbxSavingsAccounts.IsChecked == false))
            {
                LbxAccounts.ItemsSource = null;
            }

            //Current Accounts
            else if ((ChbxCurrentAccounts.IsChecked == true) && (ChbxSavingsAccounts.IsChecked == false))
            {
                filteredAccounts.Clear();

                foreach (Account account in accounts)
                {
                    if (account is CurrentAccount)
                    {
                        filteredAccounts.Add(account);
                    }
                }

                UpdateListBox(filteredAccounts);
            }

            //Savings Accounts
            else if ((ChbxCurrentAccounts.IsChecked == false) && (ChbxSavingsAccounts.IsChecked == true))
            {
                filteredAccounts.Clear();

                foreach (Account account in accounts)
                {
                    if (account is SavingsAccount)
                    {
                        filteredAccounts.Add(account);
                    }
                }

                UpdateListBox(filteredAccounts);
            }
        }

        //Updates fields when an account is selected from the list
        private void LbxAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account selected = LbxAccounts.SelectedItem as Account;

            if (selected != null)
            {
                TblkFirstNameInput.Text = selected.FirstName;
                TblkLastNameInput.Text = selected.LastName;

                if (selected is CurrentAccount)
                {
                    CurrentAccount current = selected as CurrentAccount;
                    TblkAccountTypeInput = current;
                    TblkBalanceInput = current.Balance.ToString();
                }

                if (selected is SavingsAccount)
                {
                    SavingsAccount savings = selected as SavingsAccount;
                    TblkAccountTypeInput.Text = savings;
                }
            }
        }

        //Method to update the listbox with the details of the list passed to it
        private void UpdateListBox(List<Account> accounts)
        {
            accounts.Sort();//sorts the list using the CompareTo method in the class

            //Refreshes the display
            LbxAccounts.ItemsSource = null;
            LbxAccounts.ItemsSource = accounts;
        }
    }
}
