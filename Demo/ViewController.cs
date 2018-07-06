using System;

using UIKit;
using Facebook.Accountkit;

namespace Demo
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		async partial void UIButton3_TouchUpInside(UIButton sender)
		{
            var result = await this.LoginWithAccountKit(AKFLoginType.Phone, AKFResponseType.AccessToken);

            System.Diagnostics.Debug.WriteLine($"Result: {result}");

            var account = await this.GetCurrentAccount(AKFResponseType.AccessToken);

            System.Diagnostics.Debug.WriteLine($"Account: {account?.EmailAddress ?? account?.PhoneNumber?.PhoneNumber ?? "NO ACCOUNT"}");
		}
	}
}
