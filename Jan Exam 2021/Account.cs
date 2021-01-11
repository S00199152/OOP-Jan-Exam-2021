using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jan_Exam_2021
{
    public abstract class Account : IComparable
    {
        //Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
        public DateTime InterestDate { get; set; }
        public int AccountNumber { get; set; }

        //Abstract method
        public abstract decimal CalculateInterest();

        //Mehtod to identify how object wil be sorted - in this case using AccountNumber
        public int  CompareTo(object obj)
        {
            Account that = obj as Account;
            return this.AccountNumber.CompareTo(that.AccountNumber);
        }

        public override string ToString()
        {
            return $"{AccountNumber}, {FirstName}, {LastName}";
        }
    }

    public class CurrentAccount : Account
    {
        //Additional property
        public decimal InterestRate { get; set; }

        //Implement abstract method
        public override decimal CalculateInterest()
        {
            return Balance * (decimal)0.03;
        }

        //Overide of ToString defined in abstract class
        public override string ToString()
        {
            return $"{base.ToString()} - Current Account";  //note reference to base class
        }
    }

    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        public override decimal CalculateInterest()
        {
            return Balance * (decimal)0.06;

            InterestDate = DateTime.Today;
        }

        //Overide of ToString defined in abstract class
        public override string ToString()
        {
            return $"{base.ToString()} - Savings Account";  //note reference to base class
        }
    }
}
