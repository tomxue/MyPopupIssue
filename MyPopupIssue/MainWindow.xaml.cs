using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyPopupIssue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyUserControl userControl = new MyUserControl(MyGrid);
            MyGrid.Children.Add(userControl);
            MyUserControl.ETestButtonMouseClick += MyUserControl_ETestButtonMouseClick;
        }

        private void MyUserControl_ETestButtonMouseClick(UIElement target)
        {
            Application.Current.Dispatcher.InvokeAsync(new Action(() =>
            {
                Popup popup = new Popup();
                popup.AllowsTransparency = true;
                popup.PlacementTarget = target;
                popup.HorizontalOffset = 10;
                popup.VerticalOffset = 41;
                popup.Placement = PlacementMode.Left;
                popup.StaysOpen = false;

                TextBlock myTextBlock = new TextBlock();
                myTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                myTextBlock.VerticalAlignment = VerticalAlignment.Center;
                myTextBlock.Width = 166;
                myTextBlock.Height = 170;
                myTextBlock.Text = "Just a test.";
                myTextBlock.FontSize = 22;
                myTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                myTextBlock.Background = new SolidColorBrush(Colors.Yellow);
                popup.Child = myTextBlock;
                popup.IsOpen = true;
            }));
        }
    }
}
