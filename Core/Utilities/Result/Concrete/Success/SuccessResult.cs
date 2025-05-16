using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result.Concrete.Success
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(success, message)
        {
        }
        public SuccessResult():base(true)
        {

        }
    }
}
