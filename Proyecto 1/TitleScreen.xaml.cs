using System;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto_1
{
    public enum EDirection
    {
        Left = 0,
        Right = 1
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TitleScreen : Window
    {
        public class TitleScreenContents
        {
            public string Title { get; set; }
            public string Subtitle { get; set; }
            public string StartButton { get; set; }
        }

        public TitleScreenContents Contents { get; }

        public TitleScreen()
        {
            InitializeComponent();
            Contents = new TitleScreenContents()
            {
                Title = ProjectStrings.TitleScreen.Title,
                Subtitle = ProjectStrings.TitleScreen.Subtitle,
                StartButton = ProjectStrings.TitleScreen.ButtonText
            };
            ApplyTemplate();
            DataContext = this;
        }
        
        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Create the initial window
            CreateNewSingleWindow(this, ProjectStrings.StartScreen.Title, ProjectStrings.StartScreen.ButtonText,
                () => Console.WriteLine("Do Nothing"), ProjectStrings.StartScreen.Subtitle, ProjectStrings.Colors.MAIN);
        }

        #region Window Creators

        private Window CreateNewSingleWindow(Window toClose, string title, string buttonText, Action onButtonClicked, string subtitle = "", string color = "")
        {
            SingleButtonWindow newPage = new SingleButtonWindow(title, buttonText, onButtonClicked, subtitle, color);
            newPage.Show();
            toClose.Close();
            return newPage;
        }

        private Window CreateYesNoWindow(Window toClose, string title, string yesButtonText, string noButtonText, Action onYesPressed, Action onNoPressed, string subtitle = "")
        {
            YesNoWindow newPage = new YesNoWindow(title, yesButtonText, noButtonText, onYesPressed, onNoPressed, subtitle);
            newPage.Show();
            toClose.Close();
            return newPage;
        }

        private Window CreateTextCaptureWindow(Window toClose, string title, string continueButtonText, string placeholderText, Action onValidContinuePressed, string subtitle = "")
        {
            TextCaptureWindow newPage = new TextCaptureWindow(title, continueButtonText, placeholderText,
                onValidContinuePressed, input => !string.IsNullOrEmpty(input), subtitle);
            newPage.Show();
            toClose.Close();
            return newPage;
        }

        #endregion Window Creators
    }
}
