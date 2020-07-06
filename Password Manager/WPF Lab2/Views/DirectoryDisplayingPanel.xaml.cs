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
using WPF_Lab2.Models;

namespace WPF_Lab2.Views
{
    /// <summary>
    /// Interaction logic for DirectoryDisplayingPanel.xaml
    /// </summary>
    public partial class DirectoryDisplayingPanel : UserControl
    {
        public TreeViewDirectory TreeViewDirectory { get; set; }
        public DirectoryDisplayingPanel(TreeViewDirectory treeViewDirectory)
        {
            InitializeComponent();
            TreeViewDirectory = treeViewDirectory;
        }
    }
}
