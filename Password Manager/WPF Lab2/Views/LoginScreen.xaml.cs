using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
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
using WPF_Project;

namespace WPF_Lab2.Views
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : UserControl
    {
        private readonly MainWindow window;
        public LoginScreen(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void UnlockButtonClicked(object sender, RoutedEventArgs e)
        {
            string password = passwordTextBox.Password;
            List<TreeViewNode> list = null;

            //if(File.Exists("passwords.bin"))
            //{
            //    using (var memoryStream = new MemoryStream())
            //    using (var fileStream = File.OpenRead("passwords.bin"))
            //    {
            //        list = new List<TreeViewNode>();
            //        // This resets the memory stream position for the following read operation
            //        fileStream.Seek(0, SeekOrigin.Begin);

            //        // Get the bytes
            //        var bytes = new byte[memoryStream.Length];
            //        fileStream.Read(bytes, 0, (int)fileStream.Length);

            //        // Encrypt your bytes with your chosen encryption method, and write the result instead of the source bytes
            //        var decryptedBytes = DataEncryption.Decrypt(password, bytes);

            //        if (decryptedBytes == null)
            //        {
            //            MessageBox.Show("Invalid password.");
            //            window.Close();
            //        }

            //        memoryStream.Write(decryptedBytes, 0, decryptedBytes.Length);

            //        // Serialize to memory instead of to file
            //        var formatter = new BinaryFormatter();
            //        list = (List<TreeViewNode>)formatter.Deserialize(memoryStream);
            //    }
            //}

            window.userControl.Content = new MainScreen(window, list, password);
        }
    }
}
