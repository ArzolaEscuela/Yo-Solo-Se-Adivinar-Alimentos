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
    /// Interaction logic for TextCaptureWindow.xaml
    /// </summary>
    public partial class TextCaptureWindow : Window
    {
        private string _currentInput;
        public TextCaptureWindowContents Contents { get; set; }

        public TextCaptureWindow(string title, string continueButtonText, string placeholderText, Action<string> onValidContinuePressed, Func<string, bool> inputValidator, string subtitle = "")
        {
            ApplyTemplate();

            _currentInput = string.Empty;
            InitializeComponent();

            Contents = new TextCaptureWindowContents()
            {
                Title = title,
                Subtitle = subtitle,
                PlaceholderText = placeholderText,
                ContinueButtonText = continueButtonText,
                OnValidContinuePressed = onValidContinuePressed,
                InputValidator = inputValidator
            };
            DataContext = this;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            InputText.Text = Contents.PlaceholderText;
            InputText.Opacity = 0.5f;
        }

        public class TextCaptureWindowContents
        {
            public string Color { get; set; }
            public string Title { get; set; }
            public string Subtitle { get; set; }
            public string PlaceholderText { get; set; }
            public string ContinueButtonText { get; set; }
            public Action<string> OnValidContinuePressed { get; set; }

            public Func<string, bool> InputValidator { get; set; }

            public TextCaptureWindowContents() { Color = ProjectStrings.Colors.RandomColor; }
        }

        private void ContinueButton_OnClick(object sender, RoutedEventArgs e)
        {
            bool isValid = Contents.InputValidator(_currentInput);
            if (!isValid) { return; }

            Contents.OnValidContinuePressed(_currentInput);
        }

        private void TextInput_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _currentInput = ((TextBox)sender).Text;
            if (_currentInput.Equals(Contents.PlaceholderText)) { _currentInput = string.Empty; }
            bool isValidInput = Contents.InputValidator(_currentInput);
            ErrorPopup.IsOpen = !isValidInput;
        }

        private void InputText_OnGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = ((TextBox)sender);
            if (box.Text.Equals(Contents.PlaceholderText))
            {
                box.Text = string.Empty;
                box.Opacity = 1f;
            }
        }
    }
}
