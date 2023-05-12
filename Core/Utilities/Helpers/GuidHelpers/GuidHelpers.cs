using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.GuidHelpers
{
    public class GuidHelpers
    {
        public static string CreatGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
