using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    class Video:Subject
    {
        private string title;
        private string author;
        private string description;

        public string GetTitle()
        {
            return title;
        }

        public void SetTitle(string value)
        {
            title = value;
            ChangeDataVideo();
        }

        public string GetAuthor()
        {
            return author;
        }

        public void SetAuthor(string value)
        {
            author = value;
            ChangeDataVideo();
        }

        public string GetDescription()
        {
            return description;
        }

        public void SetDescription(string value)
        {
            description = value;
            ChangeDataVideo();
        }

        private void ChangeDataVideo()
        {
            Notify();
        }

    }
}
