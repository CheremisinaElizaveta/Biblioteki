using SerializationLibrary;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using ThemeLibrary;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private TestObject _testObject;
        private DispatcherTimer _timer;
        private bool _isImageFromWeb;
        private string _localImageUri = "/WpfApp1;component/test.jpg";
        private string _webImageUri = "https://via.placeholder.com/300";
        public MainWindow()
        {
            InitializeComponent();
            // Инициализация объекта.
            ThemeManager.ApplyLightTheme();

            _testObject = new TestObject
            {
                Name = "Test",
                Value = 100
            };

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += ChangeImage;
            _timer.Start();

            MyImage.Source = new BitmapImage(new Uri(_webImageUri));
        }

        private void ChangeImage(object sender, EventArgs e)
        {
            _isImageFromWeb = !_isImageFromWeb;

            if (_isImageFromWeb)
            {
                MyImage.Source = new BitmapImage(new Uri(_webImageUri));
            }
            else
            {
                MyImage.Source = new BitmapImage(new Uri(_localImageUri, UriKind.Relative));
            }
        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            // Десериализация объекта из строки.
            this._testObject = Serializer.Deserialize<TestObject>(JsonTextBlock.Text);

            // Отображение свойств объекта.
            NameTextBlock.Text = _testObject.Name;
            ValueTextBlock.Text = _testObject.Value.ToString();
        }

        private void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            // Сериализация объекта в строку.
            _testObject.Name = InputTextBoxName.Text;
            _testObject.Value = int.Parse(InputTextBoxVal.Text);
            var jsonString = Serializer.Serialize(_testObject);

            // Отображение сериализованной строки в текстовом блоке.
            JsonTextBlock.Text = jsonString;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBoxName.Text = "";
            InputTextBoxVal.Text = "";
            JsonTextBlock.Text = "";
            NameTextBlock.Text = "";
            ValueTextBlock.Text = "";
        }

        private void DarkThemeButton_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ApplyDarkTheme();
        }

        public class TestObject
        {
            public string? Name { get; set; }
            public int Value { get; set; }
        }

        private void LightThemeButton_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ApplyLightTheme();
        }
    }
}
