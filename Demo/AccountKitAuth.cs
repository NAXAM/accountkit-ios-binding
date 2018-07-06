using System;
using System.Threading.Tasks;
using UIKit;
using Foundation;
using Acr.Support.iOS;
using Facebook.Accountkit;

namespace Demo
{
    partial class ViewController : IAKFViewControllerDelegate
    {
        AKFAccountKit accountKit;
        UIViewController pendingLoginViewController;

        public Task<IAKFAccount> GetCurrentAccount(AKFResponseType responseType)
        {
            var taskCompletionSource = new TaskCompletionSource<IAKFAccount>();

            InitAK(responseType);

            Task.Delay(100).ContinueWith(delegate
            {
                accountKit.RequestAccount((obj, error) =>
                {
                    if (error != null)
                    {
                        taskCompletionSource.SetException(new NSErrorException(error));
                        return;
                    }

                    var account = obj as IAKFAccount;

                    if (obj == null) return;

                    taskCompletionSource.SetResult(account);
                });
            });

            return taskCompletionSource.Task;
        }

        public Task<string> LoginWithAccountKit(AKFLoginType type, AKFResponseType responseType)
        {
            InitAK(responseType);

            loginTaskCompletionSource?.TrySetCanceled();
            loginTaskCompletionSource = new TaskCompletionSource<string>();
            pendingLoginViewController = type == AKFLoginType.Phone
                                                             ? accountKit.ViewControllerForPhoneLogin()
                                                             : accountKit.ViewControllerForEmailLogin();

            var loginViewController = (pendingLoginViewController as IAKFViewController);

            if (loginViewController != null)
            {
                loginViewController.WeakDelegate = this;
                loginViewController.EnableSendToFacebook = true;
            }

            NSOperationQueue.MainQueue.BeginInvokeOnMainThread(() =>
            {
                var vcInContext = GetTopMostController();

                vcInContext.PresentViewController(pendingLoginViewController, true, null);
            });

            return loginTaskCompletionSource.Task;
        }

        UIViewController GetTopMostController()
        {
            var vc = this;

            //if (vc is AKFViewController) {
            //	vc = vc.PresentingViewController;
            //}

            return vc;
        }

        void InitAK(AKFResponseType responseType, bool forced = false)
        {
            if (accountKit == null || forced)
            {
                accountKit = new AKFAccountKit(responseType);
            }
        }

        TaskCompletionSource<string> loginTaskCompletionSource;

        [Export("viewControllerDidCancel:")]
        public void DidCancel(UIViewController viewController)
        {
            loginTaskCompletionSource?.SetResult(null);
            loginTaskCompletionSource = null;
        }

        [Export("viewController:didCompleteLoginWithAuthorizationCode:state:")]
        public void DidCompleteLoginWithAuthorizationCode(UIViewController viewController, string code, string state)
        {
            loginTaskCompletionSource?.SetResult(code);
            loginTaskCompletionSource = null;
        }

        [Export("viewController:didCompleteLoginWithAccessToken:state:")]
        public void DidCompleteLoginWithAccessToken(UIViewController viewController, IAKFAccessToken accessToken, string state)
        {
            var x = accessToken as IAKFAccessToken;

            loginTaskCompletionSource?.SetResult(x.GetTokenString());
            loginTaskCompletionSource = null;
        }

        [Export("viewController:didFailWithError:")]
        public void DidFailWithError(UIViewController viewController, NSError error)
        {
            loginTaskCompletionSource?.SetResult(null);
            loginTaskCompletionSource = null;
        }
    }
}