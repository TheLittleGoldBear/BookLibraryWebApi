using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebApi.Model
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
