using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPF_Lab2.Models;

namespace WPF_Lab2.Views
{
    /// <summary>
    /// Interaction logic for ProfileEditingScreen.xaml
    /// </summary>
    public partial class ProfileEditingScreen : UserControl
    {
        public PasswordManagingPanel ParentPanel { get; set; }
        public ListView PasswordList { get; set; }
        public Profile CopyProfile { get; set; }
        public ProfileEditingScreen(PasswordManagingPanel parent)
        {
            InitializeComponent();
            ParentPanel = parent;
            Profile profile = parent.passwordManagerListView.SelectedItem as Profile;
            PasswordList = ParentPanel.passwordManagerListView;

            CopyProfile = new Profile
            {
                Name = profile.Name,
                Mail = profile.Mail,
                Login = profile.Login,
                Password = profile.Password,
                Website = profile.Website,
                Notes = profile.Notes,
                CreationTime = profile.CreationTime,
                EditTime = profile.EditTime,
                Image = new Image
                {
                    Source = profile.Image.Source?.Clone()
                }
            };

            DataContext = this;
        }

        private void ApplyChanges(object sender, RoutedEventArgs e)
        {
            Profile profile = ParentPanel.passwordManagerListView.SelectedItem as Profile;

            profile.Name = CopyProfile.Name;
            profile.Mail = CopyProfile.Mail;
            profile.Login = CopyProfile.Login;
            profile.Password = CopyProfile.Password;
            profile.Website = CopyProfile.Website;
            profile.Notes = CopyProfile.Notes;
            profile.CreationTime = CopyProfile.CreationTime;
            profile.EditTime = DateTime.Now;

            if(CopyProfile.Image != null) profile.Image = CopyProfile.Image;

            ParentPanel.profilePanel.Content = new ProfileViewingScreen(ParentPanel);

            ICollectionView view = CollectionViewSource.GetDefaultView(ParentPanel.passwordManagerListView.ItemsSource);
            view.Refresh();
        }

        private void CancelChanges(object sender, RoutedEventArgs e)
        {
            ParentPanel.profilePanel.Content = new ProfileViewingScreen(ParentPanel);
        }

        private void AddPhotoToProfile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                BitmapImage source = new BitmapImage(new Uri(op.FileName));

                CopyProfile.Image.Source = source;
            }
        }
    }
}
