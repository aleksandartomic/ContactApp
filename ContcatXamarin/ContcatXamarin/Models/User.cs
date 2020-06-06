using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ContcatXamarin.Models
{
    public class User : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string ImageUrl { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", Name, LastName);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
