using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jan_Exam_2021
{
    public abstract class Account
    {
        //Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
        public DateTime InterestDate { get; set; }

        //Abstract method
        public abstract decimal CalculateInterest();

        public override string ToString()
        {
            return $""
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
    }

    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        public override decimal CalculateInterest()
        {
            return Balance * (decimal)0.06;

            
        }
    }
}
