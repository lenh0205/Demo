using Main.Infrastructure.AppDbContext;

namespace Main.Application.DendencyInjection
{
    public interface IRepositoryDependencies
    {
        public IApplicationDbContext ApplicationDbContext { get; }
    }

    public class RepositoryDependencies : IRepositoryDependencies
    {
        public IApplicationDbContext ApplicationDbContext { get; }

        public RepositoryDependencies(IApplicationDbContext applicationDbContext) 
        {
            ApplicationDbContext = applicationDbContext;
        }
    }
}
