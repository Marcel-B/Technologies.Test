using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Technology.Mobile.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private string _name;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get
            {
                    return _name;
            }
            set
            {
                _name = value;
                Console.WriteLine(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

    }
}
