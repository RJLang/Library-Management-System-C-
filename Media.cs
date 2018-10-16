using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System_C_
{ 
    enum TypeOfMedia
    {
        Book_Phys,
        Book_E,
        CD
    }

    enum Categories
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

    class Media
    {
        #region Properties

        /// <summary>
        /// Unique ID for media
        /// </summary>
        public uint ID { get; set; }

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
    }
}
