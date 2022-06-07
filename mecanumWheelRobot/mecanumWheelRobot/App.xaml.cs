using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mecanumWheelRobot
{
    public partial class App : Application
    {

        
        public App()
        {
            InitializeComponent();

            MainPage = new mecanumWheelRobot.Views.MainPage();
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
