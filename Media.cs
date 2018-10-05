using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System_C_
{
    class Media
    {
        #region Properties

        /// <summary>
        /// Unique ID for media
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Total copies of media owned
        /// </summary>
        public int TotalCopies { get; set; }

        /// <summary>
        /// Numer of copies available to loan
        /// </summary>
        public int AvailableCopies { get; set; }

        /// <summary>
        /// Type of media (e.g. book, e-book, CD..._
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Genres-Category of media
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Author of media piece
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Creation/publish date
        /// </summary>
        public string OrginDate { get; set; }
    
        
        #endregion
    }
}
