using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleAppTable
{
	public partial class MyView : ContentView
	{
		public MyView()
		{
			InitializeComponent();
		}

		public static readonly BindableProperty EasingFunctionProperty =
  			BindableProperty.Create<MyView, string>(p => p.EasingFunction, "SinIn", BindingMode.TwoWay, propertyChanged: OnEasingFunctionChanged);


		public static readonly BindableProperty DefaultHeightProperty =
			BindableProperty.Create<MyView, double>(p => p.DefaultHeight, 0, BindingMode.TwoWay, propertyChanged: DefaultHeightChanged);

		public static readonly BindableProperty IsSlideOpenProperty =
			BindableProperty.Create<MyView, bool>(p => p.IsSlideOpen, false, BindingMode.TwoWay, propertyChanged: SlideOpenClose);

		private Easing _easingFunction;
		public string EasingFunction {
			get { return (string)GetValue(EasingFunctionProperty); }
			set { SetValue(EasingFunctionProperty, value); }
		}

		public double DefaultHeight {
			get { return (double)GetValue(DefaultHeightProperty); }
			set { SetValue(DefaultHeightProperty, value); }
		}

		public bool IsSlideOpen {
			get { return (bool)GetValue(IsSlideOpenProperty); }
			set { SetValue(IsSlideOpenProperty, value); }
		}

		private static Easing GetEasing(string easingName)
		{
			switch (easingName) {
				case "BounceIn": return Easing.BounceIn;
				case "BounceOut": return Easing.BounceOut;
				case "CubicInOut": return Easing.CubicInOut;
				case "CubicOut": return Easing.CubicOut;
				case "Linear": return Easing.Linear;
				case "SinIn": return Easing.SinIn;
				case "SinInOut": return Easing.SinInOut;
				case "SinOut": return Easing.SinOut;
				case "SpringIn": return Easing.SpringIn;
				case "SpringOut": return Easing.SpringOut;
				default: throw new ArgumentException(easingName + " is not valid");
			}
		}

		private static void DefaultHeightChanged(BindableObject bindable, double oldValue, double newValue)
		{
			(bindable as MyView).IsVisible = false;
			(bindable as MyView).TranslationY = newValue;
		}

		private static void OnEasingFunctionChanged(BindableObject bindable, string oldvalue, string newvalue)
		{
			(bindable as MyView).EasingFunction = newvalue;
			(bindable as MyView)._easingFunction = GetEasing(newvalue);
		}

		private static async void SlideOpenClose(BindableObject bindable, bool oldValue, bool newValue)
		{
			if (newValue) {
				(bindable as MyView).IsVisible = true;
				await (bindable as MyView).TranslateTo(0, App.Current.MainPage.Height - 400, 250, Easing.SinInOut);
				newValue = false;
			} else {
				await (bindable as MyView).TranslateTo(0, App.Current.MainPage.Height, 250, Easing.SinInOut);
				(bindable as MyView).IsVisible = false;
				newValue = true;
			}
		}
	}
}
