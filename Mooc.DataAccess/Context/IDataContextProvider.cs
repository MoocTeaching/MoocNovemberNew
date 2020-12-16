using Mooc.Core.IDependency;

namespace Mooc.DataAccess.Context
{
    public interface IDataContextProvider : IDependency
    {
        DataContext GetDataContext();
    }
}
