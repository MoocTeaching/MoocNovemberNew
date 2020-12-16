using Mooc.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.DataAccess.Context
{
    public class DataContextProvider : IDataContextProvider, IDependency, IDisposable
    {
        private DataContext _dataContext;
        public DataContextProvider(string connectString = "")
        {
            _dataContext = new DataContext(connectString);
        }


        public void Dispose()
        {
            Dispose(true);
        }
        public void Dispose(bool isDispose)
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
                _dataContext = null;
            }
        }

        public DataContext GetDataContext()
        {
            return this._dataContext;
        }
    }
}
