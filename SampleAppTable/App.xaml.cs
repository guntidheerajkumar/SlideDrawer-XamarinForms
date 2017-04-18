//
// App.xaml.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using Xamarin.Forms;

namespace SampleAppTable
{
	public partial class App : Application
	{
		public static double Height { get; set; }
		public static double Width { get; set; }

		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MyPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
