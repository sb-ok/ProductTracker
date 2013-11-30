using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker
{
    public class Connection
    {
        protected string ConnectionString;

        public Connection()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["PrimaryConnectionString"].ConnectionString;
        }
    }
}
