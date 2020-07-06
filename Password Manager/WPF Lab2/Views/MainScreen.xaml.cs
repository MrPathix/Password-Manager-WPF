using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
using WPF_Lab2.ViewModels;
using WPF_Project;

namespace WPF_Lab2.Views
{
    /// <summary>
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : UserControl
    {
        private readonly MainWindow window;
        private string password;
        private int directory = 0;
        private int images = 0;
        private int passwords = 0;

        public MainScreen(MainWindow window, List<TreeViewNode> treeViewNodes, string password)
        {
            InitializeComponent();
            this.window = window;
            this.password = password;

            if (treeViewNodes != null)
            {
                foreach (var item in treeViewNodes)
                {
                    filesTreeView.Items.Add(item);
                }
            }
        }

        private void AddDirectory(object sender, RoutedEventArgs e)
        {
            directory++;
            TreeViewDirectory dir = new TreeViewDirectory($"New Directory {directory}");

            dir.DataContext = dir;
            dir.ContextMenu = (ContextMenu)filesTreeView.Resources["directoryContextMenu"];

            filesTreeView.Items.Add(dir);
        }
        private void AddPassword(object sender, RoutedEventArgs e)
        {
            passwords++;
            TreeViewPassword treeViewPassword = new TreeViewPassword($"New Passwords {passwords}");
            treeViewPassword.ContextMenu = (ContextMenu)filesTreeView.Resources["fileContextMenu"];
            treeViewPassword.DataContext = treeViewPassword;

            TreeViewNode node = (TreeViewNode)(sender as MenuItem).DataContext;

            if (node is null)
            {
                filesTreeView.Items.Add(treeViewPassword);
            }
            else
            {
                node.Items.Add(treeViewPassword);
            }
        }
        private void AddImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(op.FileName));

                images++;
                TreeViewImage treeViewImage = new TreeViewImage($"New Images {images}", image);
                treeViewImage.ContextMenu = (ContextMenu)filesTreeView.Resources["fileContextMenu"];
                treeViewImage.DataContext = treeViewImage;

                TreeViewNode node = (TreeViewNode)(sender as MenuItem).DataContext;

                if (node is null)
                {
                    filesTreeView.Items.Add(treeViewImage);
                }
                else
                {
                    node.Items.Add(treeViewImage);
                }
            }
            else
            {
                MessageBox.Show("Image not selected.");
            }
        }

        private void LogoutClicked(object sender, RoutedEventArgs e)
        {
            window.userControl.Content = new LoginScreen(window);
        }

        private void AddNestedDirectory(object sender, RoutedEventArgs e)
        {
            TreeViewNode treeViewItem = (TreeViewNode)(sender as MenuItem).DataContext;

            directory++;
            TreeViewDirectory dir = new TreeViewDirectory($"New Directory {directory}");

            dir.DataContext = dir;
            dir.ContextMenu = (ContextMenu)filesTreeView.Resources["directoryContextMenu"];

            treeViewItem.Items.Add(dir);
        }

        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            TreeViewNode node = (TreeViewNode)(sender as MenuItem).DataContext;

            if (!(node.Parent is TreeViewNode nodeParent))
            {
                filesTreeView.Items.Remove(node);
            }
            else
            {
                nodeParent.Items.Remove(node);
            }
        }

        private void RenameItem(object sender, RoutedEventArgs e)
        {
            TreeViewNode node = (TreeViewNode)(sender as MenuItem).DataContext;

            node.IsRenamed = true;
        }

        private void SaveClicked(object sender, RoutedEventArgs e)
        {
            //using (var fileStream = File.OpenWrite("passwords.bin"))
            //using (var memoryStream = new MemoryStream())
            //{
            //    // Serialize to memory instead of to file
            //    var formatter = new BinaryFormatter();
            //    formatter.Serialize(memoryStream, filesTreeView.Items.Cast<TreeViewNode>().ToList());

            //    // This resets the memory stream position for the following read operation
            //    memoryStream.Seek(0, SeekOrigin.Begin);

            //    // Get the bytes
            //    var bytes = new byte[memoryStream.Length];
            //    memoryStream.Read(bytes, 0, (int)memoryStream.Length);

            //    // Encrypt your bytes with your chosen encryption method, and write the result instead of the source bytes
            //    var encryptedBytes = DataEncryption.Encrypt(password, bytes);
            //    fileStream.Write(encryptedBytes, 0, encryptedBytes.Length);
            //}

            //MessageBox.Show("Saved.");
        }
    }
}
