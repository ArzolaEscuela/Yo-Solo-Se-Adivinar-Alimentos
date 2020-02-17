using System;
using System.Windows;

namespace Proyecto_1
{
    /// <summary>
    /// Interaction logic for SingleButton.xaml
    /// </summary>
    public partial class SingleButtonWindow : Window
    {
        public SingleButtonWindowContents Contents { get; set; }

        public SingleButtonWindow(string title, string buttonText, Action onButtonClicked, string subtitle = "", string color = "")
        {
            InitializeComponent();
            Contents = new SingleButtonWindowContents() { Title = title, ButtonText = buttonText, Subtitle = subtitle, OnButtonClicked = onButtonClicked };
            if (!string.IsNullOrEmpty(color)) { Contents.Color = color; }
            ApplyTemplate();
            DataContext = this;
        }

        public class SingleButtonWindowContents
        {
            public string Color { get; set; }
            public string Title { get; set; }
            public string Subtitle { get; set; }
            public string ButtonText { get; set; }
            public Action OnButtonClicked { get; set; }

            public SingleButtonWindowContents() { Color = ProjectStrings.Colors.RandomColor; }
        }

        private void SingleButton_OnClick(object sender, RoutedEventArgs e)
        {
            Contents.OnButtonClicked();
        }
    }
}
