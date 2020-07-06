using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using WPF_Project;

namespace WPF_Lab2.Views
{
    /// <summary>
    /// Interaction logic for ImageDisplayingPanel.xaml
    /// </summary>
    public partial class ImageDisplayingPanel : UserControl
    {
        public TreeViewImage TreeViewImage { get; set; }
        public ImageDisplayingPanel(TreeViewImage image)
        {
            InitializeComponent();
            TreeViewImage = image;
        }

        private void SaveImage(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png";
            saveFileDialog.Title = "Save an Image File";
            
            if(saveFileDialog.ShowDialog() == true)
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(TreeViewImage.Image.Source as BitmapImage));

                using (var filestream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    encoder.Save(filestream);

                MessageBox.Show("File saved.");
            }
            else
            {
                MessageBox.Show("File couldn't be saved.");
            }
        }
    }
}
