using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    class SMSNotifier : Observer
    {
        public SMSNotifier(Subject subject)
        {
            Subject = subject;
            Subject.AttachObserver(this);
        }

        public override void Notify()
        {
            if (Subject is Video video)
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("//                SMS Notifier              //");
                Console.WriteLine("==============================================");
                Console.WriteLine("Sender: vietvd13");
                Console.WriteLine("System: localhost:8000");
                Console.WriteLine("Dear sir,");
                Console.WriteLine("Information of the video is updated!");
                Console.WriteLine("Updated information:");
                Console.WriteLine("=> Title: {0}", video.GetTitle());
                Console.WriteLine("=> Author: {0}", video.GetAuthor());
                Console.WriteLine("=> Description: {0}", video.GetDescription());
                Console.WriteLine("==============================================");
                Console.WriteLine("\n\n");
            }
        }
    }
}
