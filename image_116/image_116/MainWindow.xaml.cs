using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace image_116 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      Title = "Show My Face";
      Uri uri = new Uri("https://www.google.co.kr/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png");

      BitmapImage bitmap = new BitmapImage(uri);
      Image img = new Image();
      img.Source = bitmap;
      Content = img;
    }
  }
}