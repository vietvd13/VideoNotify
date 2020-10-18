using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public abstract class Observer
    {
        protected Subject Subject;
        public abstract void Notify();
    }
}
