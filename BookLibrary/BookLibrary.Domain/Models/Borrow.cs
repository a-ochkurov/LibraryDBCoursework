using System;

namespace BookLibrary.Domain.Models
{
    class Borrow
    {
        public int BorrowId { get; set; }

        public int ReaderId { get; set; }

        public int BookId { get; set; }

        public DateTime TakenDate { get; set; }

        public DateTime BroughtDate { get; set; }
    }
}
