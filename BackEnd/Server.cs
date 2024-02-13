/**
 * Radosław Ziembiński WSB (laboratory example)
 * */

using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class SocketServer
    {
        int socketNo;
        TcpListener listener;
        bool endFlag = true;
        Task mainLoopTask;
        string host;
        X509Certificate2 serverCertificate = null;


        public SocketServer(string _host, int _socketNo)
        {
            socketNo = _socketNo;
            host = _host;
            string certFile = "C:\\Users\\WSB\\source\\repos\\ExampleSocketSSL\\certificate\\localhost.pfx";
            string password = "mytopsecretpasswd";
            serverCertificate = new X509Certificate2(certFile, password, X509KeyStorageFlags.MachineKeySet);
        }

        public void Initialize()
        {
            listener = new TcpListener(IPAddress.IPv6Any, socketNo);//Dns.GetHostEntry(host).AddressList[0], socketNo);
            listener.Server.DualMode = true;
            listener.Start();
        }


        public void AcceptsRequests()
        {
            mainLoopTask = Task.Factory.StartNew(() =>
            {
                while (endFlag)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            NetworkStream nstr = client.GetStream();
                            SslStream sslStream = new SslStream(nstr, false);

                            sslStream.AuthenticateAsServer(serverCertificate, false, true);

                            StreamReader sr = new StreamReader(new BufferedStream(sslStream), Encoding.UTF8);
                            StreamWriter sw = new StreamWriter(sslStream, Encoding.UTF8);

                            int threadId = Thread.CurrentThread.ManagedThreadId;
                            while (endFlag)
                            {
                                try
                                {
                                    string message = sr.ReadLine();
                                    string response = message.ToUpper().Trim();
                                    sw.WriteLine(response);
                                    sw.Flush();
                                    Console.WriteLine("Thread: " + threadId + " receive: " + message + " send: " + response);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.ToString());
                                    break;
                                }
                            }
                            sslStream.Close();
                            nstr.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        client.Close();
                    });
                }
            });

            while (true)
            {
                try
                {
                    string data;
                    Console.Write("Enter text (q - exits): ");
                    data = Console.ReadLine();

                    if (data.CompareTo("q") == 0)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    break;
                }
            }
        }

        public void Close()
        {
            endFlag = false;
            listener.Stop();
            Task.WaitAll(mainLoopTask);
        }

    }

    class Server
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
                socketNo = short.Parse(args[1]);
            }


            SocketServer server = new SocketServer(host, socketNo);
            server.Initialize();
            server.AcceptsRequests();
            server.Close();

            Console.WriteLine("Application exited!");
        }
    }
}
