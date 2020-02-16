using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technology.Mobile.ViewModels;
using Xamarin.Forms;

namespace Technology.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        int cnt = 0;

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button btn)
                btn.Text = $"Clicked {++cnt} times";
        }
    }
}
