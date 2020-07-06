using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_Lab2.Models
{
    public class TreeViewImage : TreeViewFile
    {
        public Image Image { get; }
        public TreeViewImage(string name, Image image) : base(name)
        {
            Image = image;
        }
    }
}
