using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System_C_
{
    public class Account
    {
        //private static int lastAccountNumber = 111110;
        //private static List<Media> loans = new List<Media>();

        #region Properties

        /// <summary>
        /// Unuique ID for user
        /// </summary>
        public int AccountNumber { get;  set; }    

        /// <summary>
        /// Contact address for user and login
        /// </summary>
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Friendly name of a user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creation date of user's account
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// List of pending holds for a user
        /// </summary>
        //public List<Media> Holds { get; set; } = new List<Media>();

        /// <summary>
        /// List of active loans for a user
        /// </summary>
        //public List<Media> Loans { get; set; } = new List<Media>();

        /// <summary>
        /// User fees for lost damaged goods
        /// </summary>
        public int Fees { get; set; }


        #endregion


        #region Constructor

        public Account()
        {
            //AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.Now;
        }


        #endregion


        #region Methods
        /// <summary>
        /// Check out media and add to personal loans
        /// </summary>
        /// <param name="id"></param>
        /* public void CheckOut (uint id)
         {
             var newLoan = new Loans
             {
                 TypeOfLoan = Loans.LoanType.Loan,
                 AccountNumber = a
             }
             //var mediaLoan = Loans.SingleOrDefault(a => a.ID == id);
             //Loans.Add(mediaLoan);

             //Loans.Add(Convert.ToString(id));
         }*/

        /// <summary>
        /// Check in media and remove from personal loans
        /// </summary>
        /// <param name="id"></param>
        /*
        public void CheckIn (uint id, List<Media> loans)
        {
            var mediaLoan = Loans.SingleOrDefault(a => a.ID == id);
            Loans.Remove(mediaLoan);
            //Loans.Remove(Convert.ToString(id));
        }
   
        public void PlaceHold (uint ID)
        {
            //Holds.Add(Convert.ToString(id));
        }
        */

        #endregion
    }

}
