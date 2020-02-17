using System;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto_1
{
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
            Logic.Initialize();
        }

        public static void StartGame(Window toClose)
        {
            // Create the initial window
            Helpers.CreateSingleButtonWindow(toClose, ProjectStrings.StartScreen.Title, ProjectStrings.StartScreen.ButtonText,
                () => Logic.StartNewRun(toClose), ProjectStrings.StartScreen.Subtitle, true, ProjectStrings.Colors.MAIN);
        }

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            StartGame(this);
        }
    }
}
