namespace Service.Contracts
{
    public interface IServiceManager
    {
        IBookService BookService { get; }
        IAuthorService AuthorService { get; }
    }
}
