using System;

using Benoit.YBS.App.Views;
using Benoit.YBS.App.Services;
using Xamarin.Forms;
using Benoit.YBS.App.Interfaces;

namespace Benoit.YBS.App
{
	public partial class App : Application
	{
		public static bool UseMockDataStore = false;
        

        public App ()
		{
			InitializeComponent();

			//if (UseMockDataStore)
			//	DependencyService.Register<MockDataStore>();
			//else
				DependencyService.Register<EntityDataStore>();

            MainPage = new NavigationPage(new InvoiceListPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
