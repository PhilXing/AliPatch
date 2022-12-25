using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.DirectoryServices.ActiveDirectory;

namespace AliPatchRom
{
    public partial class Form1 : Form
    {
        public const string APP_KEY = "AliPatchROM";
        public const string APP_VERSION_VALUE = "AppVersion";
        public const string APP_REGISTRY_VERSION = "0.1";
        private const string APP_SUBKAY = "Software\\" + COMPANY_NAME + "\\" + APP_KEY;
        public const string COMPANY_NAME = "ADLink";

        public const string VALUE_WORKING_PATH_LIST = "WorkingPathList";
        public const string VALUE_WORKING_PATH = "WorkingPath";
        public const string VALUE_ROM_IMAGE_PATH = "RomImagePath";
        public const string VALUE_PRIVATE_KEY_PATH = "PrivateKeyPath";
        public const string VALUE_UBIOS_VERSION = "UBiosVersion";
        public const string VALUE_UBIOS_PUBLIC_KEY_PATH = "UBiosPublickeyPath";
        public const string VALUE_UBC_PUBLIC_KEY_PATH = "UbcPublicKeyPath";
        public const string VALUE_BOOT_LOADER_PUBLIC_KEY_PATH = "BootLoaderPublicKeyPath";
        public const string VALUE_HASH_PATH_LIST = "HashPathList";

        public const int MAX_WORKING_FOLDER_SAVED = 5;
        public const int MAX_HASH_PATH_COUNT = 2000; // roughly available count

        public byte[] RomImage;
        public int identificationAlignment;

        private void SaveComboSettings(RegistryKey appKey, string keyName, System.Windows.Forms.ComboBox comboBox, int maxCount)
        {
            string keyNameIndex = keyName + "_Index";
            RegistryKey subKey = appKey.OpenSubKey(keyName, true);
            if (subKey != null)
            {
                appKey.DeleteSubKeyTree(keyName);
            }
            subKey = appKey.CreateSubKey(keyName);
            for (int i = 0; i < comboBox.Items.Count && i < maxCount; i++)
            {
                comboBox.SelectedIndex = i;
                subKey.SetValue(i.ToString(), comboBox.Text);
            }
        }

        private void SaveListSettings(RegistryKey appKey, string keyName, System.Windows.Forms.ListBox listBox, int maxCount)
        {
            string keyNameIndex = keyName + "_Index";
            RegistryKey subKey = appKey.OpenSubKey(keyName, true);
            if (subKey != null)
            {
                appKey.DeleteSubKeyTree(keyName);
            }
            subKey = appKey.CreateSubKey(keyName);
            for (int i = 0; i < listBox.Items.Count && i < maxCount; i++)
            {
                listBox.SelectedIndex = i;
                subKey.SetValue(i.ToString(), listBox.Text);
            }
        }

        private void SaveSettings()
        {
            RegistryKey appKey = Registry.CurrentUser.CreateSubKey("Software\\" + COMPANY_NAME + "\\" + APP_KEY);

            appKey.SetValue(VALUE_WORKING_PATH, comboBoxWorkingFolder.Text);
            appKey.SetValue(VALUE_ROM_IMAGE_PATH, textBoxInputImage.Text);
            appKey.SetValue(VALUE_PRIVATE_KEY_PATH, textBoxPrivateKey.Text);
            appKey.SetValue(VALUE_UBIOS_VERSION, textBoxUbiosVersion.Text);
            appKey.SetValue(VALUE_UBIOS_PUBLIC_KEY_PATH, textBoxUbiosPublicKey.Text);
            appKey.SetValue(VALUE_UBC_PUBLIC_KEY_PATH, textBoxUbcPublicKey.Text);
            appKey.SetValue(VALUE_BOOT_LOADER_PUBLIC_KEY_PATH, textBoxBootLoaderPublicKey.Text);
            //
            // Save comboBox Lists
            // 
            SaveComboSettings(appKey, VALUE_WORKING_PATH_LIST, comboBoxWorkingFolder, MAX_WORKING_FOLDER_SAVED);
            SaveListSettings(appKey, VALUE_HASH_PATH_LIST, listBoxHash, MAX_HASH_PATH_COUNT);
        }

        private void RestoreComboSettings(RegistryKey appKey, string keyName, System.Windows.Forms.ComboBox comboBox, int maxCount)
        {
            RegistryKey subKey = appKey.OpenSubKey(keyName);
            if (subKey != null)
            {
                for (int i = 0; i < maxCount; i++)
                {
                    string PathName = (string)subKey.GetValue(i.ToString());
                    if (String.IsNullOrEmpty(PathName)) break;
                    comboBox.Items.Add(PathName);
                }
            }
        }

        private void RestoreListSettings(RegistryKey appKey, string keyName, System.Windows.Forms.ListBox listBox, int maxCount)
        {
            RegistryKey subKey = appKey.OpenSubKey(keyName);
            if (subKey != null)
            {
                for (int i = 0; i < maxCount; i++)
                {
                    string PathName = (string)subKey.GetValue(i.ToString());
                    if (String.IsNullOrEmpty(PathName)) break;
                    listBox.Items.Add(PathName);
                }
            }
        }

        private void RestoreSettings()
        {
            //
            // Retrieve Registry keys
            //
            RegistryKey appKey = Registry.CurrentUser.OpenSubKey("Software\\" + COMPANY_NAME + "\\" + APP_KEY);
            if (appKey == null)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\" + COMPANY_NAME + "\\" + APP_KEY, APP_VERSION_VALUE, APP_REGISTRY_VERSION);
                return;
            }
            string Str = (string)appKey.GetValue(APP_VERSION_VALUE, "0.0");
            if (String.Compare(APP_REGISTRY_VERSION, Str) != 0)
            {
                RegistryKey appFamilyKey = Registry.CurrentUser.OpenSubKey("Software\\" + COMPANY_NAME, true);
                appFamilyKey.DeleteSubKeyTree(APP_KEY);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\" + COMPANY_NAME + "\\" + APP_KEY, APP_VERSION_VALUE, APP_REGISTRY_VERSION);
                return;
            }
            //
            // Restore controls
            //
            comboBoxWorkingFolder.Text = (string)appKey.GetValue(VALUE_WORKING_PATH, "");
            textBoxInputImage.Text = (string)appKey.GetValue(VALUE_ROM_IMAGE_PATH, "");
            textBoxPrivateKey.Text = (string)appKey.GetValue(VALUE_PRIVATE_KEY_PATH, "");
            textBoxUbiosVersion.Text = (string)appKey.GetValue(VALUE_UBIOS_VERSION, "");
            textBoxUbiosPublicKey.Text = (string)appKey.GetValue(VALUE_UBIOS_PUBLIC_KEY_PATH, "");
            textBoxUbcPublicKey.Text = (string)appKey.GetValue(VALUE_UBC_PUBLIC_KEY_PATH, "");
            textBoxBootLoaderPublicKey.Text = (string)appKey.GetValue(VALUE_BOOT_LOADER_PUBLIC_KEY_PATH, "");
            //
            // Restore hash list
            //
            RestoreComboSettings(appKey, VALUE_WORKING_PATH_LIST, comboBoxWorkingFolder, MAX_WORKING_FOLDER_SAVED);
            RestoreListSettings(appKey, VALUE_HASH_PATH_LIST, listBoxHash, MAX_HASH_PATH_COUNT);

        }

        public Form1()
        {
            InitializeComponent();
            RestoreSettings();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Properties.Settings.Default.F1State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                Properties.Settings.Default.F1Location = this.Location;
                Properties.Settings.Default.F1Size = this.Size;
            }
            else
            {
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.F1Location = this.RestoreBounds.Location;
                Properties.Settings.Default.F1Size = this.RestoreBounds.Size;
            }

            // don't forget to save the settings
            Properties.Settings.Default.Save();

            SaveSettings();
        }

        private long searchBytes(byte[] needle)
        {
            var len = needle.Length;
            var limit = RomImage.Length - len;
            for (var i = 0; i <= limit; i+=identificationAlignment)
            {
                var k = 0;
                for (; k < len; k++)
                {
                    if (needle[k] != RomImage[i + k]) break;
                }
                if (k == len) return i;
            }
            return -1;
        }

        private bool isValidImage()
        {
            var isValidRomImage = true;
            //
            // Validation ADLink identifications
            //
            byte[] AdlinkBiosIdentification1 = Encoding.ASCII.GetBytes("BIOS_MADE_BY_ADLINK");
            //byte[] AdlinkBiosIdentification1 = Encoding.ASCII.GetBytes("BIOS_MADE_BY_ADLINX");
            var AdlinkBiosIdentification2 = new byte[] { 0x0e, 0x0e, 0x15, 0x23, 0x3e, 0x25, 0x1e, 0x5f, 0x04, 0x58, 0x01, 0x44, 0x57, 0x18, 0x14, 0x61 };
            //var AdlinkBiosIdentification2 = new byte[] { 0x0e, 0x0e, 0x15, 0x23, 0x3e, 0x25, 0x1e, 0x5f, 0x04, 0x58, 0x01, 0x44, 0x57, 0x18, 0x14, 0x60 };
            if (searchBytes(AdlinkBiosIdentification1) == -1)
            {
                MessageBox.Show("This ROM image is not supported.");
                isValidRomImage = false;
            }
            if (searchBytes(AdlinkBiosIdentification2) == -1)
            {
                MessageBox.Show("This ROM image is not supported.");
                isValidRomImage = false;
            }
            //
            // Validate signature 90 90 E9
            //
            byte[] validSignature = new byte[] { 0x90, 0x90, 0xe9 };
            //byte[] validSignature = new byte[] { 0x90, 0x90, 0xe8 };
            var len = validSignature.Length;
            var validSignarueOffset = RomImage.Length - 16;
            var i = 0;
            for (; i < len; i++)
            {
                if (validSignature[i] != RomImage[i + validSignarueOffset]) break;
            }
            if (i < len) 
            {
                MessageBox.Show("Incorrect file format: ROM Image not ended with 90 90 E9 ....");
                isValidRomImage = false;
            }

            return isValidRomImage;
        }

        private void enableControls(bool isValid)
        {
            textBoxOutputImage.Enabled = isValid;
            buttonOutputImage.Enabled = isValid;
            textBoxPrivateKey.Enabled = isValid;
            buttonPrivateKey.Enabled = isValid;
            textBoxUbiosVersion.Enabled = isValid;
            textBoxUbiosPublicKey.Enabled = isValid;
            buttonUbiosPublicKey.Enabled = isValid;
            textBoxUbcPublicKey.Enabled = isValid;
            buttonUbcPublicKey.Enabled = isValid;
            textBoxBootLoaderPublicKey.Enabled = isValid;
            buttonBootLoaderPublicKey.Enabled = isValid;
            buttonHashAdd.Enabled = isValid;
            buttonHashRemove.Enabled = isValid;
            listBoxHash.Enabled= isValid;
            buttonGenerate.Enabled = isValid;
        }



        private void buttonWorkingFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(comboBoxWorkingFolder.Text))
            {
                this.folderBrowserDialog1.SelectedPath = comboBoxWorkingFolder.Text;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                comboBoxWorkingFolder.Text = folderBrowserDialog1.SelectedPath;
                int index = comboBoxWorkingFolder.FindStringExact(comboBoxWorkingFolder.Text);
                if (index == -1)
                {
                    comboBoxWorkingFolder.Items.Insert(0, folderBrowserDialog1.SelectedPath);
                    if (comboBoxWorkingFolder.Items.Count > MAX_WORKING_FOLDER_SAVED)
                    {
                        comboBoxWorkingFolder.Items.RemoveAt(0);
                    }
                    comboBoxWorkingFolder.SelectedIndex = comboBoxWorkingFolder.FindStringExact(comboBoxWorkingFolder.Text);
                }
                else
                {
                    comboBoxWorkingFolder.SelectedIndex = index;
                    comboBoxWorkingFolder.Items.Insert(0, comboBoxWorkingFolder.SelectedItem);
                    comboBoxWorkingFolder.Items.RemoveAt(comboBoxWorkingFolder.SelectedIndex);
                    comboBoxWorkingFolder.SelectedIndex = 0;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.F1Size.Width == 0 || Properties.Settings.Default.F1Size.Height == 0)
            {
                // first start
                // optional: add default values
            }
            else
            {
                //this.WindowState = Properties.Settings.Default.F1State;

                // we don't want a minimized window at startup
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;

                this.Location = Properties.Settings.Default.F1Location;
                this.Size = Properties.Settings.Default.F1Size;
            }
        }

        private void textBoxInputImage_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(textBoxInputImage.Text))
            {
                //
                // Read Image file to bytes[] RomImage
                //
                RomImage = File.ReadAllBytes(textBoxInputImage.Text);
                //
                // support old project which size is 4MB and the identification is not 16 bytes aligned
                //
                if (RomImage.Length >= 0x800000)
                {
                    identificationAlignment = 16;
                }
                else
                {
                    identificationAlignment = 1;
                }
                if (textBoxOutputImage.Text.Length == 0)
                {
                    textBoxOutputImage.Text = textBoxInputImage.Text;
                }
                enableControls(isValidImage());
            }
        }

        private string buttonFilePath_Click(string filePath)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = this.openFileDialog1.FileName;
            }
            return filePath;
        }

        private void buttonRomImage_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = comboBoxWorkingFolder.Text;
            textBoxInputImage.Text = buttonFilePath_Click(textBoxInputImage.Text);
        }
        
        private void buttonPrivateKey_Click(object sender, EventArgs e)
        {
            textBoxPrivateKey.Text = buttonFilePath_Click(textBoxPrivateKey.Text);
        }

        private void buttonUbiosPublicKey_Click(object sender, EventArgs e)
        {
            textBoxUbiosPublicKey.Text = buttonFilePath_Click(textBoxUbiosPublicKey.Text);
        }

        private void buttonUbcPublicKey_Click(object sender, EventArgs e)
        {
            textBoxUbcPublicKey.Text = buttonFilePath_Click(textBoxUbcPublicKey.Text);
        }

        private void buttonBootLoaderPublicKey_Click(object sender, EventArgs e)
        {
            textBoxBootLoaderPublicKey.Text = buttonFilePath_Click(textBoxBootLoaderPublicKey.Text);
        }

        private void buttonHashAdd_Click(object sender, EventArgs e)
        {
            string hash_fp = "";
            hash_fp = buttonFilePath_Click(hash_fp);
            if (hash_fp.Length > 0)
            {
                listBoxHash.Items.Add(hash_fp);
            }
        }

        private void buttonHashRemove_Click(object sender, EventArgs e)
        {
            listBoxHash.Items.Remove(listBoxHash.Items[listBoxHash.SelectedIndex]);
        }

    }
}