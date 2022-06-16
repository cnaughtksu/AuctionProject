using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
namespace Bid501Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var wssv = new WebSocketServer(8001);
            // ClientUpdate update = serverCont.AddClient;
            wssv.AddWebSocketService<SocketMessage>("/SocketMessage");
            wssv.AddWebSocketService<ServerMessage>("/ServerMessage");
            wssv.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AuthenticationController authentication = new AuthenticationController();
            LoginInputHandler l = authentication.VerifyLogin;
            LoginView login = new LoginView(l);
            Application.Run(login);
            wssv.Stop();
        }
    }
}
