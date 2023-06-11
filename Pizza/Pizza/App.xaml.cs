using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pizza
{
    public partial class App : Application
    {
        public static DatabaseHelper Database { get; private set; }
        public App()
        {
            InitializeComponent();

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "pizza.db");

            Database = new DatabaseHelper(databasePath);

            MainPage = new NavigationPage(new MainPage());
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
