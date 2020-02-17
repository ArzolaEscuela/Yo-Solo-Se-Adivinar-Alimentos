using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_1
{
    /// <summary>
    /// Interaction logic for YesNoWindow.xaml
    /// </summary>
    public partial class YesNoWindow : Window
    {
        public YesNoButtonWindowContents Contents { get; set; }

        public YesNoWindow(string title, string yesButtonText, string noButtonText, Action onYesButtonClicked, Action onNoButtonClicked, string subtitle = "")
        {
            InitializeComponent();
            Contents = new YesNoButtonWindowContents()
            {
                Title = title,
                YesButtonText = yesButtonText,
                NoButtonText = noButtonText,
                Subtitle = subtitle,
                OnNoButtonClicked = onNoButtonClicked,
                OnYesButtonClicked = onYesButtonClicked
            };
            ApplyTemplate();
            DataContext = this;
        }

        public class YesNoButtonWindowContents
        {
            public string Color { get; set; }
            public string Title { get; set; }
            public string Subtitle { get; set; }
            public string YesButtonText { get; set; }
            public string NoButtonText { get; set; }
            public Action OnYesButtonClicked { get; set; }
            public Action OnNoButtonClicked { get; set; }

            public YesNoButtonWindowContents() { Color = ProjectStrings.Colors.RandomColor; }
        }

        private void YesButton_OnClick(object sender, RoutedEventArgs e)
        {
            Contents.OnYesButtonClicked();
        }

        private void NoButton_OnClick(object sender, RoutedEventArgs e)
        {
            Contents.OnNoButtonClicked();
        }
    }
}
