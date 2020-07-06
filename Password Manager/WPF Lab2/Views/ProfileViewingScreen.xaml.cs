using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Xml.Serialization;
using WPF_Lab2.Models;

namespace WPF_Lab2.Views
{
    /// <summary>
    /// Interaction logic for ProfileViewingScreen.xaml
    /// </summary>
    public partial class ProfileViewingScreen : UserControl
    {
        public PasswordManagingPanel ParentPanel { get; set; }
        public ProfileViewingScreen(PasswordManagingPanel parent)
        {
            InitializeComponent();
            ParentPanel = parent;
        }

        private void EditProfile(object sender, RoutedEventArgs e)
        {
            ParentPanel.profilePanel.Content = new ProfileEditingScreen(ParentPanel);
        }

        private void DeleteProfile(object sender, RoutedEventArgs e)
        {
            ParentPanel.TreeViewPassword.Profiles.Remove(ParentPanel.passwordManagerListView.SelectedItem as Profile);

            ICollectionView view = CollectionViewSource.GetDefaultView(ParentPanel.passwordManagerListView.ItemsSource);
            view.Refresh();

            ParentPanel.profilePanel.Content = null;
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid address");
            }

            e.Handled = true;
        }
    }
}
