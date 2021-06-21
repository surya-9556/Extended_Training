using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCusingDPR.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int AuthorId { get; set; }
        public double BookPrice { get; set; }
    }
}