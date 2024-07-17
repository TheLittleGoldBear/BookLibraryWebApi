namespace BookLibraryWebApi.Dto
{
    public class BookCreateDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
