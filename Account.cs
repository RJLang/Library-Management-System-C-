using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System_C_
{
    class Account
    {
        private static int lastAccountNumber = 111110;

        #region Properties

        /// <summary>
        /// Unuique ID for user
        /// </summary>
        public int AccountNumber { get; }    

        /// <summary>
        /// Contact address for user and login
        /// </summary>
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
        public List<Media> Holds { get; set; }

        /// <summary>
        /// List of active loans for a user
        /// </summary>
        public List<Media> Loans { get; set; }

        /// <summary>
        /// User fees for lost damaged goods
        /// </summary>
        public int Fees { get; set; }


        #endregion


        #region Constructor

        public Account()
        {
            AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.Now;
        }


        #endregion


        #region Methods
        /// <summary>
        /// Check out media and add to personal loans
        /// </summary>
        /// <param name="id"></param>
        public void CheckOut (uint id)
        {
            //Loans.Add(Convert.ToString(id));
        }

        /// <summary>
        /// Check in media and remove from personal loans
        /// </summary>
        /// <param name="id"></param>
        public void CheckIn (uint id, List<Media> loans)
        {
            //Loans.Remove(Convert.ToString(id));
        }

        public void PlaceHold (uint ID)
        {
            //Holds.Add(Convert.ToString(id));
        }

        #endregion
    }

}
