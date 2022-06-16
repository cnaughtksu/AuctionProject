using System;
using System.Collections.Generic;
//using Bid501Server.Database;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using WebSocketSharp;
//using Proxy;
using Bid501Server.Database;

namespace Bid501Client
{

    public delegate void LoggedIn(Client client);

    class AuthenticationController
    {
        
        private List<Client> clients;
        private WebSocket ws;
        private LoggedIn loggedIn;
        public event Message message;
        //private List<string> temp;

        public AuthenticationController(LoggedIn loggedIn)
        {
            this.loggedIn = loggedIn;

            //TEST CONDITION
           
            //TEST CONDITION
            
            clients = new List<Client>();
            ws = new WebSocket("ws://192.168.0.18:8001/SocketMessage");
            ws.OnMessage += (sender, e) => loadClient(e.Data);
            ws.Connect();
            /*  try
              {
                  string fileName = @"D:\K-State\CIS501\TeamRepo\Team-12-B-Fall2021\FinalProject\Bid501Client\Bid501Client\Bid501Client\clients.json";
                  using (StreamReader r = new StreamReader(fileName))
                  {
                      string json = r.ReadToEnd();
                      string[] splitJson = Regex.Split(json, "({})");
                      foreach (string s in splitJson)
                      {
                          Client temp = JsonSerializer.Deserialize<Client>(s);
                          clients.Add(temp);
                      }
                  }
              }
              catch(Exception e)
              {
                  Console.WriteLine(e.Message);
              }*/
        }
        public void loadClient(string name)
        {
            if(name != null)
            {
                string[] temp = name.Split(',');
                if (String.Compare(temp[0], "User") == 0)
                {
                    clients.Add(new Client(ClientType.User, temp[1], temp[2]));
                }
            }
        }

        public bool VerifyLogin(string username, string password)
        {
            //TEST CONDITION
            //TEST CONDITION
            bool result = false;
            /*
            if (clients == null)
            {
                var tempClient = CreateClient(ClientType.User, username, password);
                string fileName = @"D:\K-State\CIS501\TeamRepo\Team-12-B-Fall2021\FinalProject\Bid501Client\Bid501Client\Bid501Client\clients.json";
                string jsonString = JsonSerializer.Serialize(tempClient);
                using (StreamWriter sr = new StreamWriter(fileName, true))
                {
                    sr.Write(jsonString);
                }
                result = true;
            }
            else
            {*/
            Client temp = null;
                foreach(Client c in clients)
                {
                    if(username == c.Name)
                    {
                        //client found and logged in
                        if(password == c.Password)
                        {
                            result = true;
                            temp = c;
                            ws.Send(username +"," + password);
                            break;
                        }
                        //client found and wrong password
                        else
                        {
                            result = false;
                            break;
                        }
                    }/*
                    else
                    {
                        //create the client
                        var tempClient = CreateClient(ClientType.User, username, password);
                        string fileName = "clients.json";
                        string jsonString = JsonSerializer.Serialize(tempClient);
                        using(StreamWriter sr = new StreamWriter(fileName, true))
                        {
                            sr.Write(jsonString);
                        }
                        result = true;
                    }*/
                }
           // }
            if (result)
            {
                loggedIn(temp);
            }
            return result;
        }

        public Client CreateClient(ClientType type, string username, string password)
        {
            
            return new Client(type, username, password);
        }
    }
}
