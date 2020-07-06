using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Lab2.Models
{
    public class TreeViewPassword : TreeViewFile
    {
        public ObservableCollection<Profile> Profiles { get; set; } = new ObservableCollection<Profile>();
        public TreeViewPassword(string name) : base(name) { }
        public void AddNewProfile(string name, string mail, string login, string password, string website, string notes)
        {
            Profiles.Add(
                new Profile
                {
                    Name = name,
                    Mail = mail,
                    Login = login,
                    Password = password,
                    Website = website,
                    Notes = notes,
                    Image = new System.Windows.Controls.Image(),
                    CreationTime = DateTime.Now,
                    EditTime = DateTime.Now, 
                    ClipboardCommand = new ClipboardCopyCommand(CopyToClipboard)
                });
        }
        public void CopyToClipboard(string copy)
        {
            Clipboard.SetText(copy);
        }
    }
}
