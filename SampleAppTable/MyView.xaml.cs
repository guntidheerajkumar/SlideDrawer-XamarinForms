using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;

namespace SampleAppTable
{
	public partial class MyView : ContentView
	{
		public ICommand CloseTappedCommand { get { return new Command((obj) => OnCloseMenu()); } }

		public MyView()
		{
			InitializeComponent();
			var gestureRecognizer = new TapGestureRecognizer();
			gestureRecognizer.Command = CloseTappedCommand;
			CloseStack.GestureRecognizers.Add(gestureRecognizer);
		}

		public static readonly BindableProperty IsSlideOpenProperty =
			BindableProperty.Create("IsSlideOpen",
									typeof(bool),
									typeof(MyView),
									false,
									BindingMode.TwoWay,
									propertyChanged: SlideOpenClose);

		public static readonly BindableProperty DefaultHeightProperty =
			BindableProperty.Create("DefaultHeight",
									typeof(double),
									typeof(MyView),
									0.0D,
									BindingMode.TwoWay, null,
									propertyChanged: DefaultHeightChanged, propertyChanging: null, coerceValue: null, defaultValueCreator: null);

		public static readonly BindableProperty ItemTemplateProperty =
			BindableProperty.Create("ItemTemplate",
									typeof(StackLayout),
									typeof(MyView),
									null,
									BindingMode.TwoWay, null,
									propertyChanged: StackLayoutAdded, propertyChanging: null, coerceValue: null, defaultValueCreator: null);

		public bool IsSlideOpen {
			get { return (bool)GetValue(IsSlideOpenProperty); }
			set { SetValue(IsSlideOpenProperty, value); }
		}

		public StackLayout ItemTemplate {
			get { return (StackLayout)GetValue(ItemTemplateProperty); }
			set { SetValue(ItemTemplateProperty, value); }
		}

		public double DefaultHeight {
			get { return (double)GetValue(DefaultHeightProperty); }
			set { SetValue(DefaultHeightProperty, value); }
		}


		private static async void SlideOpenClose(BindableObject bindable, object oldValue, object newValue)
		{
			if ((bool)newValue) {
				(bindable as MyView).IsVisible = true;
				await (bindable as MyView).TranslateTo(0, 0, 250, Easing.SinInOut);
				newValue = false;
			} else {
				await (bindable as MyView).TranslateTo(0, App.Current.MainPage.Height, 250, Easing.SinInOut);
				(bindable as MyView).IsVisible = false;
				newValue = true;
			}
		}

		private static void StackLayoutAdded(BindableObject bindable, object oldValue, object newValue)
		{
			if ((StackLayout)newValue != null) {
				(bindable as MyView).ParentStackLayout.Children.Add((StackLayout)newValue);
			}
		}

		private static void DefaultHeightChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as MyView).IsVisible = false;
			(bindable as MyView).TranslationY = (double)newValue;
		}

		private void OnCloseMenu()
		{
			IsSlideOpen = false;
		}
	}
}
