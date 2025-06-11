using System.Windows.Controls;

namespace UserControlForms.UserControls;

/// <summary>
/// Логика взаимодействия для UserForm.xaml
/// </summary>
public partial class UserForm : UserControl
{
    public string Title {  get; set; }
    public int MaxLength { get; set; }

    public UserForm()
    {
        InitializeComponent();
        DataContext = this;
    }
}
