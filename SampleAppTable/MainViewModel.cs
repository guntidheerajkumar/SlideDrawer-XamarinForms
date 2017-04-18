using System;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace SampleAppTable
{
	[ImplementPropertyChanged]
	public class MainViewModel
	{
		public ICommand TappedCommand { get; set; }
		public ICommand SlideOpenCommand { get; set; }
		public double DefaultHeight { get; set; }
		public double DefaultWidth { get; set; }

		public bool IsSlide { get; set; }

		public MainViewModel()
		{
			TappedCommand = new Command(CloseMenu);
			SlideOpenCommand = new Command(SlideOpen);
			DefaultHeight = App.Height;
			DefaultWidth = App.Width;
			IsSlide = false;
		}

		private void CloseMenu()
		{
			IsSlide = false;
		}

		private void SlideOpen()
		{
			if (IsSlide) {
				IsSlide = false;
			} else {
				IsSlide = true;
			}
		}
	}
}
