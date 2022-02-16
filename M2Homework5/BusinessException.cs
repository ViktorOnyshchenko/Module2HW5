using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace M2Homework5
{
    public class BusinessException : Exception
    {
        public BusinessException(string? message) : base(message)
        {
        }
    }
}
