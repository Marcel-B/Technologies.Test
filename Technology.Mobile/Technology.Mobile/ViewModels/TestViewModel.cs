using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Technology.Mobile.Models;
using Technology.Mobile.Services;
using Xamarin.Forms;

namespace Technology.Mobile.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private string _name;
        private IEnumerable<string> _slipways;
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CallApi { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public IEnumerable<string> Slipways
        {
            get => _slipways;
            set
            {
                _slipways = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Slipways"));
            }
        }

        public TestViewModel()
        {
            var http = new ApiClient();
            CallApi = new Command(async () =>
            {
                var cnt = 0;
                var response = await http.GetData();
                var data = JsonConvert.DeserializeObject<ApiResult>(response);
                Slipways = new List<string>();
                Slipways = data.Data.Slipways.Select(_ => $"{++cnt} {_.Name}");
            });
        }
    }
}
