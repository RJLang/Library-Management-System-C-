using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Library_Management_System_C_
{
    public static class Library
    {
        private static LibraryModel db = new LibraryModel();

        //Moved to DB
        //private static List<Account> accounts = new List<Account>();
        //private static List<Media> ids = new List<Media>();
        //private static List<Media> loans = new List<Media>();
        //private static List<Media> medias = new List<Media>();

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

            db.Accounts.Add(account);
            db.SaveChanges();

            return account;
        }

        /// <summary>
        /// Check out book and add to account's loan list
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="mediaID"></param>
        /// <param name="copies"></param>
        public static void CheckOut(int accountNumber, uint mediaID/*, int copies,int holds*/)
        {
            //var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber);

            if (account == null)
            {
                //throw not found
                return;
            }

            var media = db.Media.FirstOrDefault(a => a.ID == mediaID);
            if (media == null)
            {
                //throw not found
                return;
            }

            //Validate media's available to be checked out
            if (media.AvailableCopies > 0)
            {
                //if (holds > 0){*/
                var tranaction = new Loans
                {
                    TypeOfLoan = Loans.LoanType.Loan,
                    AccountNumber = accountNumber,
                    ID = mediaID
                };
                //Record loan
                db.Loans.Add(tranaction);

                //Remove media from active inventory
                media.Loan();
                db.Update(media);


                db.SaveChanges();

                //account.CheckOut(mediaID);
                //id.Checkout(/*id.AvailableCopies*/);
                //}
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
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                //throw not found
                return;
            }
            var id = db.Media.Where(a => a.ID == mediaID);
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

            //ForeignKey table
            // account.CheckIn(mediaID, loans);
            // id.CheckIn(/*id.AvailableCopies*/);
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
        public static IEnumerable<Media> CheckMedia(uint mediaID)
        {
            //var id = ids.SingleOrDefault(a => a.ID == mediaID);
            var id = db.Media.Where(a => a.ID == mediaID);
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
        public static Media AddInv(/*uint id,*/ string title, int totalCopies, TypeOfMedia type, Categories category, string author, DateTime orginDate)
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

            db.Media.Add(newMedia);
            db.SaveChanges();

            return newMedia;
        }
        //Inventory_remove
   
        public static void RemoveInv (uint id)
        {
            var media = Library.GetMediaDetails(id);
            db.Media.Remove(media);
            db.SaveChanges();
        }

        public static IEnumerable<Account> AccountLookup(string emailAddress)
        {
            //var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
        }
        public static Account AccountLookupName(string name)
        {
            //var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            return db.Accounts.SingleOrDefault(a => a.Name == name);
        }


        //#################8888888888888888888888888888888888888          -TESTING
        public static int AccountConversionLookup(string emailAddress)
        {
            var netuser = db.AspNetUsers.SingleOrDefault(a => a.EmailAddress == emailAddress);
            try
            {
                var user = db.Accounts.SingleOrDefault(a => a.EmailAddress == netuser.EmailAddress);
                return user.AccountNumber;
            }
            catch
            {
                throw new ArgumentNullException ("User not found in local DB" );
            }
            
        }

        public static Account GetAccountDetails(int accountNumber)
        {
            return db.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public static Media GetMediaDetails(uint mediaID)
        {
            return db.Media.FirstOrDefault(a => a.ID == mediaID);
        }

        public static IEnumerable<Media> GetAllMedia()
        {
            return db.Set<Media>();
        }

        public static IEnumerable<Loans> GetAllLoan(int accountNumber)
        {
            return db.Loans.Where(a => a.AccountNumber == accountNumber);
        }

        public static IEnumerable<Loans> GetAllLoansbyUser(string emailAddress)
        {
            var account = db.Accounts.FirstOrDefault(a => a.EmailAddress == emailAddress);
            return db.Loans.Where(a => a.AccountNumber == account.AccountNumber);

        }

        public static Loans GetLoanDetails(int transactionID)
        {
            return db.Loans.FirstOrDefault(a => a.TransactinID == transactionID);
        }

        /// <summary>
        /// Method to return media back to inventory and remove record of loan
        /// </summary>
        /// <param name="loan"></param>
        public static void Return (Loans loan)
        {

            var oldMedia = Library.GetMediaDetails(loan.ID);
            oldMedia.Return();
            db.Update(oldMedia);

            var oldLoan = Library.GetLoanDetails(loan.AccountNumber);
            oldLoan.returns();
            db.Update(oldLoan);           
            

            db.SaveChanges();
        }

        public static void EditAccount (Account account)
        {
            var oldAccount = Library.GetAccountDetails(account.AccountNumber);
            oldAccount.Name = account.Name;
            oldAccount.EmailAddress = account.EmailAddress;
            db.Update(oldAccount);
            db.SaveChanges();
        }

        public static void EditMedia( Media media)
        {
            var oldMedia = Library.GetMediaDetails((uint)media.ID);
            oldMedia.TotalCopies = media.TotalCopies;
            oldMedia.Title = media.Title;
            oldMedia.OrginDate = media.OrginDate;
            oldMedia.Author = media.Author;
            oldMedia.AvailableCopies = media.AvailableCopies;
            oldMedia.Category = media.Category;
            oldMedia.Type = media.Type;
            db.Update(oldMedia);
            db.SaveChanges();
        }

        public static bool AccountExists(int id)
        {
            return db.Accounts.Any(a => a.AccountNumber == id);
        }


        public static bool MediaExists(uint id)
        {
            return db.Media.Any(e => e.ID == id);
        }
        
        
        #endregion
    }
}
