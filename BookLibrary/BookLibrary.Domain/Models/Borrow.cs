using System;

namespace BookLibrary.Domain.Models
{
    public class Borrow : BaseModel
    {
        public int ReaderId { get; set; }

        public int BookId { get; set; }

        public DateTime TakenDate { get; set; }

        public DateTime BroughtDate { get; set; }
    }
}
