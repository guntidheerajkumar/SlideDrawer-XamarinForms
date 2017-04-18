//
// AppDelegate.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace SampleAppTable.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			App.Height = UIScreen.MainScreen.Bounds.Height;
			App.Width = UIScreen.MainScreen.Bounds.Width;
			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
