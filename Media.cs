using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System_C_
{ 
    public enum TypeOfMedia
    {
        Book_Phys,
        Book_E,
        CD
    }

    public enum Categories
    {
        ActionAdventure,
        Adventure,
        Drama,
        Fantasy,
        Horror,
        Music,
        Mystery,
        Mythology,
        Romance,
        Satire,
        Sciencefiction,
        Tragedy,
        TragicComedy
    }



    public class Media
    {
        //private static uint lastID = 0;

        #region Properties

        /// <summary>
        /// Unique ID for media
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Title for media
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Total copies of media owned
        /// </summary>
        public int TotalCopies { get; set; }

        /// <summary>
        /// Numer of copies available to loan
        /// </summary>
        public int AvailableCopies { get; set; }

        /// <summary>
        /// Number of holds currently against the media
        /// </summary>
       // public int HoldCount { get; set; }

        /// <summary>
        /// Type of media (e.g. book, e-book, CD..._
        /// </summary>
        public TypeOfMedia Type { get; set; }

        /// <summary>
        /// Genres-Category of media
        /// </summary>

        public Categories Category { get; set; }

        /// <summary>
        /// Author of media piece
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Creation/publish date
        /// </summary>
        public DateTime OrginDate { get; set; }


        #endregion

        #region Methods

        /// <summary>
        /// Take out media copy from available count
        /// </summary>
        /// <param name="availableCopies"></param>
        public void Checkout(/*int availableCopies*/)
        {
            AvailableCopies -= 1;
        }

        /// <summary>
        /// Add media copy back to availability count
        /// </summary>
        /// <param name="availableCopies"></param>
        public void CheckIn(/*int availableCopies*/)
        {
            AvailableCopies += 1;
        }

        //public void PlaceHold ()
        //{
        //   HoldCount += 1;
        //}
        #endregion

        #region Constructor

        /* public Media()
         {
             ID = ++lastID;
         }*/

        #endregion

        #region Methods

        public  void Loan()
        {
            if (AvailableCopies < 1)
            {
                //throw
            }
            AvailableCopies -= 1;
        }

        public void Return ()
        {
            if (TotalCopies >= AvailableCopies)
            {
                //throw
            } 
            AvailableCopies += 1;
        }

        #endregion
    }
}
