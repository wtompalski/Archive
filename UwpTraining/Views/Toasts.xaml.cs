using Microsoft.QueryStringDotNET;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpTraining.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Toasts : Page
    {
        public Toasts()
        {
            this.InitializeComponent();
        }

        private void ShowToast_Click(object sender, RoutedEventArgs e)
        {
            string title = "Alice sends you a cat picture";
            string content = "Look at this cuttie!";
            string image = "http://placekitten.com/200/300";
            string logo = "ms-appdata:///local/kitten.jpg";

            var visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = title
                        },

                        new AdaptiveText()
                        {
                            Text = content
                        },

                        new AdaptiveImage()
                        {
                            Source = image
                        }
                    },

                    AppLogoOverride = new ToastGenericAppLogo()
                    {
                        Source = logo,
                        HintCrop = ToastGenericAppLogoCrop.Circle
                    }
                }
            };


            int conversationId = 384928;

            ToastActionsCustom actions = new ToastActionsCustom()
            {
                Inputs =
                {
                    new ToastTextBox("tbReply")
                    {
                        PlaceholderContent = "Type a response"
                    }
                },

                Buttons =
                {
                    new ToastButton("Reply", "action=reply")
                    {
                        ActivationType = ToastActivationType.Background,
                        ImageUri = "Assets/Reply.png",
 
                        // Reference the text box's ID in order to
                        // place this button next to the text box
                        TextBoxId = "tbReply"
                    },

                    new ToastButton("Like", "action=like")
                    {
                        ActivationType = ToastActivationType.Background
                    },

                    new ToastButton("View", "action=viewImage")
                }
            };


            ToastContent toastContent = new ToastContent()
            {
                Visual = visual,
                Actions = actions
            };

            var toast = new ToastNotification(toastContent.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
