namespace Mission11_Harris.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
