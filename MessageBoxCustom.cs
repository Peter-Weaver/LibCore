using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibCore
{
    public class MessageBoxCustom
    {
        string DefaultHeader { get; set; }
        MessageBoxButtons DefaultMessageBoxButtons { get; set; }

        public MessageBoxCustom(string defaultHeader, MessageBoxButtons messageBoxButtons)
        {
            this.DefaultHeader = defaultHeader;
            this.DefaultMessageBoxButtons = messageBoxButtons;
        }

        // Show
        public DialogResult Show(string message)
        {
            return Show(message, DefaultHeader, DefaultMessageBoxButtons);
        }

        public DialogResult Show(string message, string header)
        {
            return Show(message, header, DefaultMessageBoxButtons);
        }

        public DialogResult Show(string message, string header, MessageBoxButtons messageBoxButtons)
        {
            return MessageBox.Show(message, header, messageBoxButtons);
        }

        public DialogResult Show(string message, MessageBoxButtons messageBoxButtons)
        {
            return MessageBox.Show(message, DefaultHeader, messageBoxButtons);
        }

        // Show With Icon
        public DialogResult ShowWithIcon(string message, MessageBoxIcon messageBoxIcon)
        {
            return MessageBox.Show(message, DefaultHeader, DefaultMessageBoxButtons, messageBoxIcon);
        }

        public DialogResult ShowWithIcon(string message, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            return MessageBox.Show(message, DefaultHeader, messageBoxButtons, messageBoxIcon);
        }
    }
}