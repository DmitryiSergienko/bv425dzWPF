using System.Windows;
using System.Windows.Controls;

namespace WpfControlLibrary;

/// <summary>
/// Interaction logic for ImageWithText.xaml
/// </summary>
public partial class ImageWithText : UserControl
{
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(ImageWithText),
            new PropertyMetadata(default(string)));

    public static readonly DependencyProperty ImgSourceProperty =
        DependencyProperty.Register(
            nameof(ImgSource),
            typeof(System.Windows.Media.ImageSource),
            typeof(ImageWithText),
            new PropertyMetadata(default(System.Windows.Media.ImageSource)));

    public ImageWithText()
    {
        InitializeComponent();
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public System.Windows.Media.ImageSource ImgSource
    {
        get => (System.Windows.Media.ImageSource)GetValue(ImgSourceProperty);
        set => SetValue(ImgSourceProperty, value);
    }
}