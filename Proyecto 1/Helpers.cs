using System;
using System.Windows;

namespace Proyecto_1
{
    public static class Helpers
    {
        public static Window CreateSingleButtonWindow(Window toClose, string title, string buttonText,
            Action onButtonClicked, string subtitle = "", bool closeSelfOnClick = false, string color = "")
        {
            SingleButtonWindow newPage = new SingleButtonWindow(title, buttonText, onButtonClicked, subtitle, color);
            if (closeSelfOnClick)
            {
                newPage.Contents.OnButtonClicked = () =>
                {
                    onButtonClicked();
                    newPage.Close();
                };
            }
            newPage.Show();
            toClose.Close();
            return newPage;
        }

        public static Window CreateYesNoWindow(Window toClose, string title, string yesButtonText, string noButtonText, Action onYesPressed, Action onNoPressed, string subtitle = "")
        {
            YesNoWindow newPage = new YesNoWindow(title, yesButtonText, noButtonText, onYesPressed, onNoPressed, subtitle);
            newPage.Show();
            toClose.Close();
            return newPage;
        }

        public static Window CreateTextCaptureWindow(Window toClose, string title, string continueButtonText, string placeholderText, Action<string> onValidContinuePressed, string subtitle = "")
        {
            TextCaptureWindow newPage = new TextCaptureWindow(title, continueButtonText, placeholderText,
                onValidContinuePressed, input => !string.IsNullOrEmpty(input), subtitle);
            newPage.Show();
            toClose.Close();
            return newPage;
        }
    }
}