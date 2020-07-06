using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_Lab2.Models
{
    public class Profile
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }
        public Image Image { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EditTime { get; set; }
        public ICommand ClipboardCommand { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
