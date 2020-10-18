using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Observer
{
    public class ProgNotify
    {
        public static void Run(string[] args)
        {
            var video = new Video();
            video.SetTitle("Instructions for making cream puffs");
            video.SetAuthor("Vu Duc Viet");
            video.SetDescription("Instructions for preparing ingredients and baking!");

            var emailNotifier = new EmailNotifier(video);
            var smsNotifier = new SMSNotifier(video);
            var youtubeNotifier = new YoutubeNotifier(video);

            bool showMenu = true;

            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("                   MENU                 ");
                Console.WriteLine("========================================");
                Console.WriteLine(" 1. Change 'Title' of video");
                Console.WriteLine(" 2. Change 'Author' of video");
                Console.WriteLine(" 3. Change 'Description' of video");
                Console.WriteLine(" 4. Add Notify");
                Console.WriteLine(" 5. Remove Notify");
                Console.WriteLine(" 6. Exit");
                Console.WriteLine("========================================");
                Console.WriteLine("\n\n");

                Console.Write("Please enter your request (by number): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        string newTitle = "";
                        do
                        {
                            Console.Write("Please enter a new title: ");
                            newTitle = Console.ReadLine();
                        }
                        while (string.IsNullOrWhiteSpace(newTitle));

                        Console.Clear();

                        video.SetTitle(newTitle);

                        Console.ReadKey();
                        showMenu = true;
                        break;
                    case "2":
                        Console.Clear();
                        string newAuthor = "";
                        do
                        {
                            Console.Write("Please enter a new author: ");
                            newAuthor = Console.ReadLine();
                        }
                        while (string.IsNullOrWhiteSpace(newAuthor));

                        video.SetAuthor(newAuthor);

                        Console.ReadKey();

                        showMenu = true;
                        break;
                    case "3":

                        Console.Clear();
                        string newDescription = "";
                        do
                        {
                            Console.Write("Please enter a new description: ");
                            newDescription = Console.ReadLine();
                        }
                        while (string.IsNullOrWhiteSpace(newDescription));

                        Console.Clear();

                        video.SetDescription(newDescription);

                        Console.ReadKey();

                        showMenu = true;
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("=====================================");
                        Console.WriteLine("[1]. Turn on email notifications");
                        Console.WriteLine("[2]. Turn on sms notifications");
                        Console.WriteLine("[3]. Turn on youtube notifications");
                        Console.WriteLine("[4]. Exit");
                        Console.WriteLine("=====================================\n\n");

                        string[] getListObserver = video.GetListObserver().Split(' ');

                        bool showOption = true;
                        while(showOption)
                        {
                            Console.Write("Please enter your request (by number): ");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    int countEmail = 0;
                                    for(var i = 0; i < getListObserver.Length; i++)
                                    {
                                        if(getListObserver[i] == "Observer.EmailNotifier")
                                        {
                                            countEmail++;
                                        }
                                    }

                                    if(countEmail == 0)
                                    {
                                        video.AttachObserver(emailNotifier);
                                        Console.WriteLine("Turn on EMAIL notification successfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("EMAIL notification has been activated before");
                                    }
                                    Console.WriteLine("Pls click enter to back...");
                                    Console.ReadKey();
                                    showOption = false;
                                    showMenu = true;
                                    break;
                                case "2":
                                    int countSMS = 0;
                                    for (var i = 0; i < getListObserver.Length; i++)
                                    {
                                        if (getListObserver[i] == "Observer.SMSNotifier")
                                        {
                                            countSMS++;
                                        }
                                    }

                                    if (countSMS == 0)
                                    {
                                        video.AttachObserver(smsNotifier);
                                        Console.WriteLine("Turn on SMS notification successfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("SMS notification has been activated before");
                                    }
                                    Console.WriteLine("Pls click enter to back...");
                                    Console.ReadKey();
                                    showOption = false;
                                    showMenu = true;
                                    break;
                                case "3":
                                    int countYoutube = 0;
                                    for (var i = 0; i < getListObserver.Length; i++)
                                    {
                                        if (getListObserver[i] == "Observer.YoutubeNotifier")
                                        {
                                            countYoutube++;
                                        }
                                    }

                                    if (countYoutube == 0)
                                    {
                                        video.AttachObserver(youtubeNotifier);
                                        Console.WriteLine("Turn on YOUTUBE notification successfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("YOUTUBE notification has been activated before");
                                    }
                                    Console.WriteLine("Pls click enter to back...");
                                    Console.ReadKey();
                                    showOption = false;
                                    showMenu = true;
                                    break;
                                case "4":
                                    showOption = false;
                                    break;
                                default:
                                    showOption = true;
                                    break;
                            }

                        }
                        showMenu = true;
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("=====================================");
                        Console.WriteLine("[1]. Turn off email notifications");
                        Console.WriteLine("[2]. Turn off sms notifications");
                        Console.WriteLine("[3]. Turn off youtube notifications");
                        Console.WriteLine("[4]. Exit");
                        Console.WriteLine("=====================================\n\n");

                        string[] getListObserverExit = video.GetListObserver().Split(' ');

                        bool showOptionRemove = true;
                        
                        while(showOptionRemove)
                        {
                            Console.Write("Please enter your request (by number): ");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    int countEmail = 0;
                                    for(var i = 0; i < getListObserverExit.Length; i++)
                                    {
                                        if(getListObserverExit[i] == "Observer.EmailNotifier")
                                        {
                                            countEmail++;
                                        }
                                    }
                                    if(countEmail == 0)
                                    {
                                        Console.WriteLine("");
                                    }
                                    if(countEmail == 1)
                                    {
                                        video.DetachObserver(emailNotifier);
                                        Console.WriteLine("Successfully turned off EMAIL notifications");
                                    }
                                    if(countEmail > 1)
                                    {
                                        Console.WriteLine("System have something error");
                                    }
                                    Console.WriteLine("Pls click enter to back...");
                                    Console.ReadKey();
                                    showOptionRemove = false;
                                    showMenu = true;
                                    break;
                                case "2":
                                    int countSMS = 0;
                                    for (var i = 0; i < getListObserverExit.Length; i++)
                                    {
                                        if (getListObserverExit[i] == "Observer.SMSNotifier")
                                        {
                                            countSMS++;
                                        }
                                    }
                                    if (countSMS == 0)
                                    {
                                        Console.WriteLine("");
                                    }
                                    if (countSMS == 1)
                                    {
                                        video.DetachObserver(smsNotifier);
                                        Console.WriteLine("Successfully turned off SMS notifications");
                                    }
                                    if (countSMS > 1)
                                    {
                                        Console.WriteLine("System have something error");
                                    }
                                    Console.WriteLine("Pls click enter to back...");
                                    Console.ReadKey();
                                    showOptionRemove = false;
                                    showMenu = true;
                                    break;
                                case "3":
                                    int countYoutube = 0;
                                    for (var i = 0; i < getListObserverExit.Length; i++)
                                    {
                                        if (getListObserverExit[i] == "Observer.YoutubeNotifier")
                                        {
                                            countYoutube++;
                                        }
                                    }
                                    if (countYoutube == 0)
                                    {
                                        Console.WriteLine("");
                                    }
                                    if (countYoutube == 1)
                                    {
                                        video.DetachObserver(youtubeNotifier);
                                        Console.WriteLine("Successfully turned off Youtube notifications");
                                    }
                                    if (countYoutube > 1)
                                    {
                                        Console.WriteLine("System have something error");
                                    }
                                    Console.WriteLine("Pls click enter to back...");
                                    Console.ReadKey();
                                    showOptionRemove = false;
                                    showMenu = true;
                                    break;
                                case "4":
                                    showOptionRemove = false;
                                    showMenu = true;
                                    break;
                                default:
                                    showOptionRemove = true;
                                    break;
                            }
                        }
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Good bye sir!");
                        showMenu = false;
                        break;
                    default:
                        showMenu = true;
                        break;

                }
            }
        }

    }
}
