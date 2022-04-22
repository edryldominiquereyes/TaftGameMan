using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Activitic.otf", Alias = "font1")]
[assembly: ExportFont("Lerty-Regular.otf", Alias = "font2")]
[assembly: ExportFont("Louis.ttf", Alias = "font3")]

namespace Finals
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TabbedPage1();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
