using AcSight.Core.Common.Abstract;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AcSight.Core.Common.Concrete
{
    public class ServiceDataResponse<T> : IServiceDataResponse<T>, IDisposable
    {
        public IList<T> DataList { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public bool IsSuccessful { get; set; }

        #region Disposing
        
        bool disposed = false;
       
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
              
            }

            disposed = true;
        }
        #endregion
    }
}
