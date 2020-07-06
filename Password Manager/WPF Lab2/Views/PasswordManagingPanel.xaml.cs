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
    /// Interaction logic for PasswordManagingPanel.xaml
    /// </summary>
    public partial class PasswordManagingPanel : UserControl
    {
        public TreeViewPassword TreeViewPassword { get; set; }
        public PasswordManagingPanel(TreeViewPassword password)
        {
            InitializeComponent();
            TreeViewPassword = password;
        }

        private void AddNewPasswordToList(object sender, RoutedEventArgs e)
        {
            TreeViewPassword.AddNewProfile("AccountName", "", "Default login", "", "", "");
        }

        private void SelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            profilePanel.DataContext = passwordManagerListView;
            profilePanel.Content = new ProfileViewingScreen(this);
        }
    }
}
