using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IAuthorService> _authorService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger)
        {
            _bookService = new Lazy<IBookService>(() => new
            BookService(repositoryManager, logger));

            _authorService = new Lazy<IAuthorService>(() => new
            AuthorService(repositoryManager, logger));
        }
        public IBookService BookService => _bookService.Value;
        public IAuthorService AuthorService => _authorService.Value;
    }

}