using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CAPTCHA
{
    public partial class MainWindow : Window
    {
        private string captchaText;
        private int incorrectAttempts = 0;

        public MainWindow()
        {
            InitializeComponent();
            GenerateCaptcha();
        }

        private void GenerateCaptcha()
        {
            Random random = new Random();
            captchaText = GenerateRandomText(6);

            Bitmap bitmap = new Bitmap(150, 50);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(System.Drawing.Color.White);
                using (System.Drawing.Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black))
                {
                    // Add glitch lines
                    for (int i = 0; i < 20; i++)
                    {
                        int x1 = random.Next(0, 150);
                        int y1 = random.Next(0, 50);
                        int x2 = random.Next(0, 150);
                        int y2 = random.Next(0, 50);
                        graphics.DrawLine(new Pen(System.Drawing.Color.Black), x1, y1, x2, y2);
                    }

                    // Add captcha text
                    graphics.DrawString(captchaText, new Font("Arial", 20), brush, 10, 10);
                }
            }

            MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, ImageFormat.Png);
            memoryStream.Position = 0;
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();

            CaptchaImage.Source = bitmapImage;
        }

        private string GenerateRandomText(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] captchaChars = new char[length];

            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                captchaChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(captchaChars);
        }

      

        private void CheckCaptcha_click_1(object sender, RoutedEventArgs e)
        {

            if (UserInput.Text.Equals(captchaText, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Правильно!");
                GenerateCaptcha();
                incorrectAttempts = 0;
            }
            else
            {
                MessageBox.Show("А вот и нет");
                incorrectAttempts++;

                if (incorrectAttempts == 3)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    GenerateCaptcha();
                }
            }

        }
    }
}