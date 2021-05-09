using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPS_GIBDD.EF
{
    using System;
    using System.Collections.Generic;

    public partial class UserTransportVehicle
    {
        public string PhotoPathIn
        {
            get
            {
                return $"/{PhotoPath}";
            }
        }


    }
}
