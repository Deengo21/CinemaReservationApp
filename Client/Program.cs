
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic.FileIO;



namespace Client
{
    public class SocketClient
    {
        String host;
        int socketNo;

        public SocketClient(String _host, int _socketNo)
        {
            host = _host;
            socketNo = _socketNo;
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors)
            {
                // we allow self signed certificates - unsecure!!!
                return true;
            }

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }


        public bool Connect()
        {

            TcpClient client = new TcpClient();
            try
            {
                client.Connect(new IPEndPoint(Dns.GetHostEntry(host).AddressList[0], socketNo));
                NetworkStream nstr = client.GetStream();

                SslStream sslStream = new SslStream(nstr, false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);

                sslStream.AuthenticateAsClient(host);

                StreamReader sr = new StreamReader(new BufferedStream(sslStream), Encoding.UTF8);
                StreamWriter sw = new StreamWriter(sslStream, Encoding.UTF8);


                //try
                //{
                //    Option message = new Option();
                //    OptionView.ClientSetGrettings(ref message);
                //    do
                //    {
                //        if (message.code.CompareTo("greetings") == 0)
                //        {
                //            sw.WriteLine(message.Serialize());
                //            sw.Flush();
                //            message.Deserialize(sr.ReadLine());
                //            OptionView.ClientDisplayAcknowledgment(message);
                //        }
                //        else if (message.code.CompareTo("login") == 0)
                //        {
                //            Login login = new Login();
                //            LoginView.ClientGetUserName(ref login);
                //            sw.WriteLine(login.Serialize());
                //            sw.Flush();
                //            login.Deserialize(sr.ReadLine());
                //            LoginView.ClientDisplayLogin(login);
                //            message = login;
                //        }
                //        else if (message.code.CompareTo("password") == 0)
                //        {
                //            Password password = new Password();
                //            PasswordView.ClientGetPassword(ref password);
                //            sw.WriteLine(password.Serialize());
                //            sw.Flush();
                //            password.Deserialize(sr.ReadLine());
                //            PasswordView.ClientDisplayPassword(password);
                //            message = password;
                //        }
                //        else if (message.code.CompareTo("menu") == 0)
                //        {
                //            Menu menu = new Menu();
                //            MenuView.ClientDisplayMenu(menu);
                //            MenuView.ClientGetMenuEntry(ref menu);
                //            sw.WriteLine(menu.Serialize());
                //            sw.Flush();
                //            menu.Deserialize(sr.ReadLine());
                //            OptionView.ClientDisplayAcknowledgment(message);
                //            message = menu;
                //        }
                //        else
                //        {
                //            OptionView.ClientDisplayAcknowledgment(message);
                //            break;
                //        }
                //    } while (message.error.CompareTo("ok") == 0);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e.ToString());
                //}
                sslStream.Close();
                nstr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            client.Close();
            return true;
        }
    }

    class Client
    {
        static void Main(string[] args)
        {
            int socketNo = 32000;
            string host = "localhost";

            if (args.Length > 1)
            {
                host = args[1];
            }

            if (args.Length > 2)
            {
                socketNo = Int16.Parse(args[1]);
            }

            int i = 5;
        repeat:
            SocketClient client = new SocketClient(host, socketNo);
            if (client.Connect() == false)
            {
                Thread.Sleep(10000);
                if (i-- > 0)
                    goto repeat;
            }
            Console.WriteLine("Application exited!");

        }
    }
}
