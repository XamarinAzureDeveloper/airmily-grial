using Foundation;
using UIKit;
using Xamarin.Forms;
using HockeyApp.iOS;
using airmily.iOS;
using airmily.Interfaces;

[assembly: Dependency(typeof(Feedback))]
namespace airmily.iOS
{
    public class Feedback : IFeedback
    {
        public void feedback()
        {
            var feedbackManager = BITHockeyManager.SharedHockeyManager.FeedbackManager;
            // Show current feedback list (which has option to send new feedback)
            feedbackManager.ShowFeedbackListView();
            // Send new feedback
            //feedbackManager.ShowFeedbackComposeView();
        }
    }
}