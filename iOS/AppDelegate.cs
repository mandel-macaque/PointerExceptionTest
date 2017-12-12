using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using PointerExceptionTest.Services;

namespace PointerExceptionTest.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			WebApiFactory.CreateHttpHandler = () => new AuthenticatedHttpClientHandler();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}
