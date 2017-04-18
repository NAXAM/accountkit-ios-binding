using System;

using UIKit;
using Facebook.Accountkit;

namespace Demo
{
	public partial class ViewController : UIViewController
	{
		AccountKitAuth auth;

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			var theme = AKFTheme.ThemeWithPrimaryColor(
				UIColor.Purple,
				UIColor.White,
				UIColor.Magenta,
				UIColor.Purple,
				UIStatusBarStyle.LightContent
			);
			theme.BackgroundColor = UIColor.Yellow;

			auth = new AccountKitAuth(theme);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void UIButton3_TouchUpInside(UIButton sender)
		{
			auth.LoginWithAccountKit(AKFLoginType.Phone, AKFResponseType.AuthorizationCode);
		}
	}
}
