using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader.Helpers
{
    internal class CustomException: ApplicationException
    {
        public CustomException(string message) :base(message) { }
        public CustomException(string message, Exception e) : base(message, e) { }  
    }
}
