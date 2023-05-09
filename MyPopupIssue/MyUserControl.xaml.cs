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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyPopupIssue
{
    /// <summary>
    /// Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class MyUserControl : UserControl
    {
        UIElement Parent = null;
        public delegate void TestButtonMouseClick(UIElement target);
        public static event TestButtonMouseClick ETestButtonMouseClick;

        public MyUserControl(UIElement parent)
        {
            InitializeComponent();
            this.Parent = parent;
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            ETestButtonMouseClick?.Invoke(Parent);
        }
    }
}
