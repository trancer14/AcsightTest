using AcSight.Core.Common.Abstract;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AcSight.Core.Common.Concrete
{
    public class ServiceResponse : IServiceResponse, IDisposable
    {
        public List<string> Message { get; set; }
        public int Status { get; set; }
        public bool IsSuccessful { get; set; }

        public ServiceResponse()
        {
            Message = new List<string>();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

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
