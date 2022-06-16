using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501Server.Database
{
    public class Client
    {
        public ClientType ClientType { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }

        public Client(ClientType clientType, string name, string password)
        {
            this.ClientType = clientType;
            this.Name = name;
            this.Password = password;
        }
    }
}
