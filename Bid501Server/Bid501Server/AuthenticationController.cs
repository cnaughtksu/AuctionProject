using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bid501Server
{

    public class AuthenticationController
    {
        private List<Database.Client> clients;
        public AuthenticationController(){
            using (StreamReader r = new StreamReader("clients.json"))
            {
                string json = r.ReadToEnd();
                clients = JsonSerializer.Deserialize<List<Database.Client>>(json);
            }
        }
        public bool VerifyLogin(string username, string password)
        {
            //TEST CONDITION
            //TEST CONDITION
            bool result = false;

                bool nameCheck = false;
                foreach (Database.Client c in clients)
                {
                    if (username == c.Name)
                    {
                        nameCheck = true;
                        //client found and logged in
                        if (password == c.Password)
                        {
                            if(c.ClientType == Database.ClientType.Admin)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                            
                        }
                        //client found and wrong password
                        else
                        {
                            result = false;
                        }
                    }
                }
                if (!nameCheck)
                {
                    var tempClient = CreateClient(username, password);
                    clients.Add(tempClient);
                    string fileName = "clients.json";
                    string jsonString = JsonSerializer.Serialize(clients);
                    using (StreamWriter sr = new StreamWriter(fileName, true))
                    {
                        sr.Write(jsonString);
                    }
                    result = true;
                }
            
            if (result)
            {
                ServerController serverCont = new ServerController();

                InitProduct initProd = serverCont.InitializeProducts;
                InitClients initClient = serverCont.InitializeClients;
                OpenAddProduct openAddProduct = serverCont.OpenAddProduct;
                ServerView server = new ServerView(initProd, initClient, openAddProduct);
                //serverCont.AddObserver(sock)
                serverCont.AddObserver(server.UpdateView);
                server.Show();
            }
            return result;
        }
        public Database.Client CreateClient(string username, string password)
        {

            return new Database.Client(Database.ClientType.Admin, username, password);
        }
    }
    
}
