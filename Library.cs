using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Library_Management_System_C_
{
    class Library
    {

        private static List<Account> accounts = new List<Account>();
        private static List<Media> ids = new List<Media>();
        private static List<Media> loans = new List<Media>();

        #region Methods

        /// <summary>
        /// Create an account in the Library
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Account CreateAccount(string emailAddress, string name)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentException(emailAddress, "E-Mail address is required");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(name, "Name is required");
            }

            var account = new Account
            {
                EmailAddress = emailAddress,
                Name = name
            };

            accounts.Add(account);

            return account;
        }

       /// <summary>
       /// Check out book and add to account's loan list
       /// </summary>
       /// <param name="accountNumber"></param>
       /// <param name="mediaID"></param>
       /// <param name="copies"></param>
        public static void CheckOut(int accountNumber, uint mediaID, int copies)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                //throw
                return;
            }
            var id = ids.SingleOrDefault(a => a.ID == mediaID);
            if (id == null)
            {
                //throw
                return;
            }

            if (copies > 0 )
            {
                account.CheckOut(mediaID);
                id.Checkout(id.AvailableCopies);
                 
            }
            return;
        }

        /// <summary>
        /// Return book from account's loan
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="mediaID"></param>
        /// <param name="copies"></param>
        /// <param name="loans"></param>
        public static void CheckIn(int accountNumber, uint mediaID, int copies, List<Media> loans)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                //throw
                return;
            }
            var id = ids.SingleOrDefault(a => a.ID == mediaID);
            if (id == null)
            {
                //throw
                return;
            }

            /*var loan = loans.SingleOrDefault(a => a.ID == loans);
            if (loan == null)
            {
                //throw cant return what you don't have
                return;
            }
            */

            account.CheckIn(mediaID, loans);
            id.CheckIn(id.AvailableCopies);
            return;
        }

        //place hold
        //return
        //media details (author, date, copies, holds)

        //Check personal holds/loans

        //Inventory_Add
        //Inventory_remove

        #endregion

    }
}
