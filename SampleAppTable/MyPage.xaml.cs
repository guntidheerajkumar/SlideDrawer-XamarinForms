using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleAppTable
{
	public partial class MyPage : ContentPage
	{
		public MyPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			this.BindingContext = new MainViewModel();
		}
	}
}
