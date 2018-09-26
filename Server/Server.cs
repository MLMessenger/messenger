using MessengerLibrary;
using MessengerLibrary.ConnectionDirector.Parsers;
using MessengerLibrary.DataReceivers.DataDecoder;
namespace Server
{
    class Server
    {
        private readonly IXMLParser parser;
        public void Run()
        {

        }
        private void HandleEvent(byte[] bytes)
        {
            IDataDecoder decoder = new DataDecoder();
            var xml = decoder.Decode(bytes);
            switch (parser.GetRequestType(xml))
            {
                case MessengerLibrary.DataSenders.Data.RequestType.Connect:
                    HandleConnectReuqest(parser.GetUser(xml));
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.CreateNewChat:
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.InviteUserToChat:
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.RegisterNewUser:
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.SendMessage:
                    break;
                default:
                    break;
            }
        }
        private void HandleConnectReuqest(User user)
        { }
    }
}
