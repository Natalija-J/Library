using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library_Logic.DB
{
    public partial class UserBooks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
    }
}
