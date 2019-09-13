using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtKey_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtKey.Text))
                errorProvider1.SetError(txtKey, "Key is required.");
        }

        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValue.Text))
                errorProvider1.SetError(txtValue, "Value is required.");
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIV.Text))
                    txtResult.Text = EncryptProvider.AESEncrypt(txtValue.Text.Trim(), txtKey.Text.Trim());
                else
                    txtResult.Text = EncryptProvider.AESEncrypt(txtValue.Text.Trim(), txtKey.Text.Trim(), txtIV.Text.Trim());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIV.Text))
                    txtResult.Text = EncryptProvider.AESDecrypt(txtValue.Text.Trim(), txtKey.Text.Trim());
                else
                    txtResult.Text = EncryptProvider.AESDecrypt(txtValue.Text.Trim(), txtKey.Text.Trim(), txtIV.Text.Trim());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void txtResult_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtResult.Text))
            {
                Clipboard.SetText(txtResult.Text.Trim());
                txtResult.SelectAll();
                txtResult.Focus();
            }
        }
    }
}
