using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Carumbana_FileEncryptorApp

{
    public partial class Form1 : Form
    {
        private readonly byte[] key = Encoding.UTF8.GetBytes("1234567890123456"); // 16-byte key
        private readonly byte[] iv = Encoding.UTF8.GetBytes("6543210987654321");  // 16-byte IV

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                EncryptFile(openFileDialog.FileName);
                MessageBox.Show("File Encrypted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DecryptFile(openFileDialog.FileName);
                MessageBox.Show("File Decrypted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EncryptFile(string filePath)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to save the encrypted file";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath; // Get chosen folder
                    string fileName = Path.GetFileName(filePath);
                    string newFilePath = Path.Combine(selectedFolder, "Encrypted_" + fileName);

                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    using (System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create())
                    {
                        aes.Key = key;
                        aes.IV = iv;
                        using (MemoryStream ms = new MemoryStream())
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(fileBytes, 0, fileBytes.Length);
                            cs.FlushFinalBlock();
                            File.WriteAllBytes(newFilePath, ms.ToArray());

                            MessageBox.Show($"Encrypted file saved to:\n{newFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }



        private void DecryptFile(string filePath)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to save the decrypted file";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath; // Get chosen folder
                    string fileName = Path.GetFileName(filePath);
                    string newFilePath = Path.Combine(selectedFolder, "Decrypted_" + fileName);

                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    using (System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create())
                    {
                        aes.Key = key;
                        aes.IV = iv;
                        using (MemoryStream ms = new MemoryStream())
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(fileBytes, 0, fileBytes.Length);
                            cs.FlushFinalBlock();
                            File.WriteAllBytes(newFilePath, ms.ToArray());

                            MessageBox.Show($"Decrypted file saved to:\n{newFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }


    }
}