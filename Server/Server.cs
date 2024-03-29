﻿
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DataEngine;

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
        CinemaContext cinemaContext;

        public SocketServer(string _host, int _socketNo)
        {
            socketNo = _socketNo;
            host = _host;
            string certFile = "C:\\Windows\\System32\\certificate.pfx";
            string password = "a";
            serverCertificate = new X509Certificate2(certFile, password, X509KeyStorageFlags.MachineKeySet);
            
            // connect to database
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=C:\\USERS\\KAROL\\DESKTOP\\CINEMARESERVATIONAPP\\CINEMARESERVATIONAPP\\DATAENGINE\\BD123.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
           
            cinemaContext = new CinemaContext(builder.Options);
            //cinemaContext.Database.EnsureDeleted();
            cinemaContext.Database.EnsureCreated();

            //populate
            DataSchema.Movie x = new DataSchema.Movie()
            {
               
                Title = "Terminator",
                Director = "RandomGuy",
                Length = 120,
                FilmGenre = "Thriller",
                IsAvailable = true
            };
            DataSchema.Movie zz = new DataSchema.Movie()
            {

                Title = "Terminator",
                Director = "RandomGuy",
                Length = 120,
                FilmGenre = "Thriller",
                IsAvailable = true
            };
            DataSchema.Movie zzs = new DataSchema.Movie()
            {

                Title = "Terminator",
                Director = "RandomGuy",
                Length = 120,
                FilmGenre = "Thriller",
                IsAvailable = true
            };
            DataSchema.Customer y = new DataSchema.Customer()
            {
                Username = "a",
                Email = "a",
                Password = "a",
                PasswordHash = "a",
                IsVerified = true,


            };
            cinemaContext.Add(x);
            cinemaContext.Add(y);
            cinemaContext.Add(zz);
            cinemaContext.Add(zzs);
            cinemaContext.SaveChanges();

            return;
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
