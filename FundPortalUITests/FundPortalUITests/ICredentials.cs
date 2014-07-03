using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundPortalUITests
{
    interface ICredentials
    {
        string GetPid();
        string GetWordPass();
    }
}
