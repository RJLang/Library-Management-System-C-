using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library_Management_System_C_
{
    public class Loans
    {

        public enum LoanType
        {
            Loan,
            Hold
        }

        #region Properties
        [ForeignKey("Account")]
        public int AccountNumber { get; set; }
        [ForeignKey("Media")]
        public uint ID { get; set; }

        public LoanType TypeOfLoan { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactinID { get; set; }

        public Loans()
        {
            TransactionDate = DateTime.Now;
        }

        #endregion
    }
}
