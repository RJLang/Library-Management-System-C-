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
        private static List<Media> medias = new List<Media>();

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
        public static void CheckOut(int accountNumber, uint mediaID, int copies /*,int holds*/)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                //throw not found
                return;
            }
            var id = ids.SingleOrDefault(a => a.ID == mediaID);
            if (id == null)
            {
                //throw not found
                return;
            }

            if (copies > 0 )
            {
                /*if (holds > 0){*/
                    account.CheckOut(mediaID);
                    id.Checkout(/*id.AvailableCopies*/);
                /*}*/
            }
            else
            {
                //throw not enough copies
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
                //throw not found
                return;
            }
            var id = ids.SingleOrDefault(a => a.ID == mediaID);
            if (id == null)
            {
                //throw not founf
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
            id.CheckIn(/*id.AvailableCopies*/);
            return;
        }



        /// <summary>
        /// Place a temporary hold on an item
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="mediaID"></param>
        /*public static void PlaceHold(int accountNumber, uint mediaID)
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

            id.PlaceHold();

            return;
        }*/




        //media details (author, date, copies, holds)
        public static Media CheckMedia(uint mediaID)
        {
            var id = ids.SingleOrDefault(a => a.ID == mediaID);
            if (id == null)
            {
                //throw not found
                return null;
            }
            return id;
        }
        //Check personal holds/loans
        /*public static Media holdsInfo (int accountNumber)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                //throw not found
                return null;
            }
            List<Media> holds = account.Holds;
            return holds;
        }*/

        //Inventory_Add
        public static Media AddInv (/*uint id,*/ string title, int totalCopies, TypeOfMedia type, Categories category, string author, DateTime orginDate)
        {
            var newMedia = new Media
            {
                //ID = id,
                Title = title,
                TotalCopies = totalCopies,
                Type = type,
                Category = category,
                Author = author,
                OrginDate = orginDate
            };

            medias.Add(newMedia);

            return newMedia;
        }
        //Inventory_remove
        /*
        public static Media removeInv ()
        {

        }*/

        public static Account AccountLookup(int accountNumber)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            return account;
        }
        #endregion

    }
}
