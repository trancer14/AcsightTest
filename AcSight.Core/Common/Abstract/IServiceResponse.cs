using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcSight.Core.Common.Abstract
{
    public interface IServiceResponse
    {
        List<string> Message { get; set; }
        int Status { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
