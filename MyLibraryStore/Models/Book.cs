using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryStore.Models
{
    public class Book
    {
       
            public int Id { get; set; }
            public string BookName { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
            public DateTime PublishedDate { get; set; }
           
    }
}
