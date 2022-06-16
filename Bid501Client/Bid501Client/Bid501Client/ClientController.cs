using System;
using System.Windows.Forms;
using Bid501Server.Database;
namespace Bid501Client
{
    class ClientController
    {
        private Status state;

        private AuthenticationController authControl;
        private AuctionController auctionControl;

        private ClientView auction;
        private LoginView login;
        private Client client;

        public ClientController() {

            authControl = new AuthenticationController(LoginSuccess);
            client = null;
            login = new LoginView(authControl.VerifyLogin);
            Application.Run(login);
            ChangeState(Status.LoggingIn);
        }

        private void ChangeState(Status newState)
        {
            state = newState;
            switch (newState)
            {
                case Status.LoggingIn: 
                    login.Show();
                    break;
                case Status.OpenBidding:
                    auctionControl = new AuctionController(NewBid, FinishedAuction, LoadClient);
                    auction = new ClientView(auctionControl.InitializeAuction, auctionControl.BidHandle, auctionControl.handleTimer,auctionControl.FinalSaleHandle);
                    auctionControl.AddObserver(auction.UpdateProducts);
                    auction.Show();
                    break;
                case Status.SuccessfulBid:
                    Console.WriteLine("Successful bid");
                    auctionControl.RefreshProducts();
                    break;
                case Status.FailedBid:
                    Console.WriteLine("Failed bid"); 
                    break;
                case Status.CompletedAuction:
                    Console.WriteLine("Completed auction");
                    break;
            }
        }
        private string LoadClient()
        {
            return client.Name;
        }
        private void NewBid()
        {
            ChangeState(Status.SuccessfulBid);
           
        }
        private void FinishedAuction()
        {
            ChangeState(Status.CompletedAuction);
        }
        private void LoginSuccess(Client client)
        {
            this.client = client;
            ChangeState(Status.OpenBidding);
           
        }
    }
}
