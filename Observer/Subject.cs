using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class Subject
    {
        private readonly List<Observer> _observer = new List<Observer>();

        public void AttachObserver(Observer observer)
        {
            _observer.Add(observer);
        }

        public void DetachObserver(Observer observer)
        {
            _observer.Remove(observer);
        }

        public void Notify()
        {
            _observer.ForEach((observer) => observer.Notify());
        }

        public string GetListObserver()
        {
            string listObserver = "";
            _observer.ForEach((observer) =>
            {
                listObserver = listObserver + observer + " ";
            });


            return listObserver;
        }
    }
}
