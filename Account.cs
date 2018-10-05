using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System_C_
{
    class Account
    {
        private static int lastAccountNumber = 0;

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
        public Array Holds { get; set; }

        /// <summary>
        /// List of active loans for a user
        /// </summary>
        public Array Loans { get; set; }

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

    }

}
