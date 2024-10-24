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

namespace UI.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserImage.xaml
    /// </summary>
    public partial class UserImage : UserControl
    {
        public UserImage()
        {
            InitializeComponent();
            this.DataContext = this;
        }



        public string CustomStatus
        {
            get { return (string)GetValue(CustomStatusProperty); }
            set { SetValue(CustomStatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomStatusProperty =
            DependencyProperty.Register("CustomStatus", typeof(string), typeof(UserImage), new PropertyMetadata("Some status..."));



        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Username.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UsernameProperty =
            DependencyProperty.Register("Username", typeof(string), typeof(UserImage), new PropertyMetadata("Username#0000"));


        public ImageBrush Image
        {
            get { return (ImageBrush)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageBrush), typeof(UserImage), new PropertyMetadata(NON_IMAGE));



        private static ImageBrush NON_IMAGE = new ImageBrush(new BitmapImage(new Uri(NON_IMAGE_PATH)));
        private const string NON_IMAGE_PATH = "pack://application:,,,/UI;component/Assets/Icons/Controls/Patch/UserPatch.png";

    }
}
