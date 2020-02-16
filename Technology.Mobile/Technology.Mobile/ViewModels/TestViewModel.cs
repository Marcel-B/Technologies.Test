using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Technology.Mobile.Services;
using Xamarin.Forms;

namespace Technology.Mobile.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private string _name;
        private ApiClient http;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CallApi { get; set; }

        public TestViewModel()
        {
            http = new ApiClient();
            CallApi = new Command(async () =>
            {
                var response = await http.GetData();
                Name = response;
            });
        }

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
