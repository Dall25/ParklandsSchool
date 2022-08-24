using System;
namespace Models
{
    public class Paging
    {
        public Paging()
        { }

        public int RecordsToSkip { get; set; }
        public int RecordsToSelect { get; set; }
        public int RecordCount { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}

