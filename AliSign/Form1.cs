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
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;
using System.Globalization;
using System.Security.Policy;
using System.Reflection;
using Org.BouncyCastle.Cms;

namespace AliSign
{
    public partial class Form1 : Form
    {
        public const string REG_VALUE_APP_VERSION = "AppVersion";
        public const string APP_REGISTRY_VERSION = "0.1"; // change this will clear all registry of the project.

        public const string REG_VALUE_WORKING_PATH_LIST = "WorkingPathList";
        public const string REG_VALUE_WORKING_PATH_SELECTEDINDEX = "WorkingPathSelected";
        public const string REG_VALUE_SIGN_TAB_INDEX = "SignTabIndex";

        public const string REG_VALUE_IMAGE_BIOS_PATH = "ImageBiosPath";
        public const string REG_VALUE_IMAGE_SIGNED_BIOS_PATH = "ImageSignedBiosPath";
        public const string REG_VALUE_PRIVATE_KEY_PATH = "DsaPrivateKeyPath";
        public const string REG_VALUE_UBIOS_VERSION = "UbiosVersion";
        public const string REG_VALUE_UBIOS_PUBLIC_KEY_PATH = "UbiosPublickeyPath";
        public const string REG_VALUE_UBC_PUBLIC_KEY_PATH = "UbcPublicKeyPath";
        public const string REG_VALUE_BOOT_LOADER_PUBLIC_KEY_PATH = "BootLoaderPublicKeyPath";
        public const string REG_VALUE_HASH_PATH_LIST = "HashPathList";

        public const string REG_VALUE_IMAGE_DISK_PATH = "ImageDiskPath";
        public const string REG_VALUE_IMAGE_SIGNED_DISK_PATH = "ImageSignedDiskPath";

        public const string REG_VALUE_IMAGE_UBC_PATH = "ImageUbcPath";
        public const string REG_VALUE_IMAGE_SIGNED_UBC_PATH = "ImageSignedUbcPath";
        public const string REG_VALUE_UBIOS_VERSION_UBC = "UbiosVersionUbc";
        public const string REG_VALUE_UBC_VERSION = "UbcVersion";
        public const string REG_VALUE_HASH_PATH_LIST_UBC = "HashPathListUbc";

        public const int MAX_WORKING_FOLDER_SAVED = 5;

        public const int SIZE_DISK_SECTOR = 512;

        public const int HASH_SIZE = 20;
        public const int SIGNATURE_SIZE = 40;
        public const int RETRY_SIGN = 10;
        // TODO: confirm the size of the DSA private key
        public const int PRIVATE_KEY_SIZE = 684;
        public const int PRIVATE_KEY_SIZE_2 = 672;
        public const int PUBLIC_KEY_SIZE = 404;
        public const int SIZE_FILE_BIOS = 0x800000;

        public const int OFFSET_HASH_LIST_START = 0x37c;
        public const int OFFSET_HASH_LIST_END_PLUS1 = 0x10000;
        public const int OFFSET_UBC_PUBLIC_KEY = 0x3c;
        public const int OFFSET_BOOT_LOADER_PUBLIC_KEY = 0x1d0;
        public const int OFFSET_UBIOS_VERSION = 0x364;
        public const int OFFSET_UBIOS_PUBLIC_KEY = 0x7f8020;

        public const int MAX_HASH_PATH_COUNT = (OFFSET_HASH_LIST_END_PLUS1 - OFFSET_HASH_LIST_START) / HASH_SIZE;

        public const int SIZE_FILE_DISK = 0x100000;

        public const int SIZE_FILE_UBC = 0x8000;
        public const int OFFSET_HASH_LIST_START_UBC = 0x2000;
        public const int OFFSET_HASH_LIST_END_PLUS1_UBC = 0x4000;
        public const int OFFSET_UBIOS_VERSION_UBC = 0x7fa6;
        public const int OFFSET_UBC_VERSION = 0x7fbe;

        public string registryAppKey;
        public string registryAppSubKey;
        public string registryCompanyName;

        // Common encripto variables
        IDigest hashFunction;
        IDsa signer;
        // for BIOS sign
        public byte[] bytesImageBios;
        public int identificationAlignment = 16;
        public bool is1stTime = true;
        // for Disk sign
        public byte[] bytesImageDisk;
        // for UBC sign
        public byte[] bytesImageUbc;

        private void SaveComboSettings(RegistryKey appKey, string keyName, System.Windows.Forms.ComboBox comboBox, int maxCount)
        {
            RegistryKey subKey = appKey.OpenSubKey(keyName, true);
            if (subKey != null)
            {
                appKey.DeleteSubKeyTree(keyName);
            }
            subKey = appKey.CreateSubKey(keyName);
            var i = 0;
            foreach (var item in comboBox.Items)
            {
                subKey.SetValue(i++.ToString(), item);
            }
        }

        private void SaveListSettings(RegistryKey appKey, string keyName, System.Windows.Forms.ListBox listBox, int maxCount)
        {
            RegistryKey subKey = appKey.OpenSubKey(keyName, true);
            if (subKey != null)
            {
                appKey.DeleteSubKeyTree(keyName);
            }
            subKey = appKey.CreateSubKey(keyName);

            var i = 0;
            foreach (var hashfilepath in listBox.Items)
            {
                subKey.SetValue(i++.ToString(), hashfilepath);
            }

        }

        private void SaveSettings()
        {
            RegistryKey appKey = Registry.CurrentUser.CreateSubKey(registryAppSubKey);

            appKey.SetValue(REG_VALUE_WORKING_PATH_SELECTEDINDEX, comboBoxWorkingFolder.SelectedIndex);
            appKey.SetValue(REG_VALUE_SIGN_TAB_INDEX, tabControlSign.SelectedIndex);
            appKey.SetValue(REG_VALUE_IMAGE_BIOS_PATH, textBoxImageBios.Text);
            appKey.SetValue(REG_VALUE_IMAGE_SIGNED_BIOS_PATH, textBoxSignedImageBios.Text);
            appKey.SetValue(REG_VALUE_PRIVATE_KEY_PATH, textBoxDsaPrivateKey.Text);
            appKey.SetValue(REG_VALUE_UBIOS_VERSION, textBoxUbiosVersion.Text);
            appKey.SetValue(REG_VALUE_UBIOS_VERSION_UBC, textBoxUbiosVersionUbc.Text);
            appKey.SetValue(REG_VALUE_UBC_VERSION, textBoxUbcVersion.Text);
            appKey.SetValue(REG_VALUE_UBIOS_PUBLIC_KEY_PATH, textBoxUbiosPublicKey.Text);
            appKey.SetValue(REG_VALUE_UBC_PUBLIC_KEY_PATH, textBoxUbcPublicKey.Text);
            appKey.SetValue(REG_VALUE_BOOT_LOADER_PUBLIC_KEY_PATH, textBoxBootLoaderPublicKey.Text);
            //
            // Save comboBox Lists
            // 
            SaveComboSettings(appKey, REG_VALUE_WORKING_PATH_LIST, comboBoxWorkingFolder, MAX_WORKING_FOLDER_SAVED);
            SaveListSettings(appKey, REG_VALUE_HASH_PATH_LIST, listBoxHash, MAX_HASH_PATH_COUNT);
            SaveListSettings(appKey, REG_VALUE_HASH_PATH_LIST_UBC, listBoxHashUbc, MAX_HASH_PATH_COUNT);

            appKey.SetValue(REG_VALUE_IMAGE_DISK_PATH, textBoxImageDisk.Text);
            appKey.SetValue(REG_VALUE_IMAGE_SIGNED_DISK_PATH, textBoxSignedImageDisk.Text);

            appKey.SetValue(REG_VALUE_IMAGE_UBC_PATH, textBoxImageUbc.Text);
            appKey.SetValue(REG_VALUE_IMAGE_SIGNED_UBC_PATH, textBoxSignedImageUbc.Text);
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
            registryAppKey = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            registryCompanyName = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company;
            registryAppSubKey = "Software\\" + registryCompanyName + "\\" + registryAppKey;
            //
            // Retrieve Registry keys
            //
            RegistryKey appKey = Registry.CurrentUser.OpenSubKey(registryAppSubKey);
            if (appKey == null)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\" + registryAppSubKey, REG_VALUE_APP_VERSION, APP_REGISTRY_VERSION);
                return;
            }
            string Str = (string)appKey.GetValue(REG_VALUE_APP_VERSION, "0.0");
            if (String.Compare(APP_REGISTRY_VERSION, Str) != 0)
            {
                RegistryKey appFamilyKey = Registry.CurrentUser.OpenSubKey("Software\\" + registryCompanyName, true);
                if (appFamilyKey != null)
                {
                    appFamilyKey.DeleteSubKeyTree(registryAppKey);
                    Registry.SetValue("HKEY_CURRENT_USER\\" + registryAppSubKey, REG_VALUE_APP_VERSION, APP_REGISTRY_VERSION);
                }
                return;
            }
            //
            // Restore lists
            //
            RestoreComboSettings(appKey, REG_VALUE_WORKING_PATH_LIST, comboBoxWorkingFolder, MAX_WORKING_FOLDER_SAVED);
            RestoreListSettings(appKey, REG_VALUE_HASH_PATH_LIST, listBoxHash, MAX_HASH_PATH_COUNT);
            RestoreListSettings(appKey, REG_VALUE_HASH_PATH_LIST_UBC, listBoxHashUbc, MAX_HASH_PATH_COUNT);
            //
            // Restore controls
            //
            comboBoxWorkingFolder.SelectedIndex = (int)appKey.GetValue(REG_VALUE_WORKING_PATH_SELECTEDINDEX, 0);
            tabControlSign.SelectedIndex = (int)appKey.GetValue(REG_VALUE_SIGN_TAB_INDEX, 0);
            textBoxImageBios.Text = (string)appKey.GetValue(REG_VALUE_IMAGE_BIOS_PATH, "");
            textBoxSignedImageBios.Text = (string)appKey.GetValue(REG_VALUE_IMAGE_SIGNED_BIOS_PATH, "");
            textBoxDsaPrivateKey.Text = (string)appKey.GetValue(REG_VALUE_PRIVATE_KEY_PATH, "");
            textBoxUbiosVersion.Text = (string)appKey.GetValue(REG_VALUE_UBIOS_VERSION, "");
            textBoxUbiosVersionUbc.Text = (string)appKey.GetValue(REG_VALUE_UBIOS_VERSION_UBC, "");
            textBoxUbcVersion.Text = (string)appKey.GetValue(REG_VALUE_UBC_VERSION, "");
            textBoxUbiosPublicKey.Text = (string)appKey.GetValue(REG_VALUE_UBIOS_PUBLIC_KEY_PATH, "");
            textBoxUbcPublicKey.Text = (string)appKey.GetValue(REG_VALUE_UBC_PUBLIC_KEY_PATH, "");
            textBoxBootLoaderPublicKey.Text = (string)appKey.GetValue(REG_VALUE_BOOT_LOADER_PUBLIC_KEY_PATH, "");

            textBoxImageDisk.Text = (string)appKey.GetValue(REG_VALUE_IMAGE_DISK_PATH, "");
            textBoxSignedImageDisk.Text = (string)appKey.GetValue(REG_VALUE_IMAGE_SIGNED_DISK_PATH, "");

            textBoxImageUbc.Text = (string)appKey.GetValue(REG_VALUE_IMAGE_UBC_PATH, "");
            textBoxSignedImageUbc.Text = (string)appKey.GetValue(REG_VALUE_IMAGE_SIGNED_UBC_PATH, "");
        }

        public Form1()
        {
            InitializeComponent();
            RestoreSettings();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            if (bytesImageBios == null)
            {
                return -1;
            }
            var len = needle.Length;
            var limit = bytesImageBios.Length - len;
            for (var i = 0; i <= limit; i += identificationAlignment)
            {
                var k = 0;
                for (; k < len; k++)
                {
                    if (needle[k] != bytesImageBios[i + k]) break;
                }
                if (k == len) return i;
            }
            return -1;
        }

        private bool isValidImageBios()
        {
            //
            // Validation ADLink identifications
            //
            byte[] AdlinkBiosIdentification1 = Encoding.ASCII.GetBytes("BIOS_MADE_BY_ADLINK");
            //byte[] AdlinkBiosIdentification1 = Encoding.ASCII.GetBytes("BIOS_MADE_BY_ADLINX");
            var AdlinkBiosIdentification2 = new byte[] { 0x0e, 0x0e, 0x15, 0x23, 0x3e, 0x25, 0x1e, 0x5f, 0x04, 0x58, 0x01, 0x44, 0x57, 0x18, 0x14, 0x61 };
            //var AdlinkBiosIdentification2 = new byte[] { 0x0e, 0x0e, 0x15, 0x23, 0x3e, 0x25, 0x1e, 0x5f, 0x04, 0x58, 0x01, 0x44, 0x57, 0x18, 0x14, 0x60 };
            if (searchBytes(AdlinkBiosIdentification1) == -1)
            {
                //MessageBox.Show("This ROM image is not supported 1.");
                return false;
            }
            if (searchBytes(AdlinkBiosIdentification2) == -1)
            {
                //MessageBox.Show("This ROM image is not supported 2.");
                return false;
            }
            //
            // Validate signature 90 90 E9
            //
            byte[] validSignature = new byte[] { 0x90, 0x90, 0xe9 };
            //byte[] validSignature = new byte[] { 0x90, 0x90, 0xe8 };
            var len = validSignature.Length;
            var validSignarueOffset = bytesImageBios.Length - 16;
            var i = 0;
            for (; i < len; i++)
            {
                if (validSignature[i] != bytesImageBios[i + validSignarueOffset]) break;
            }
            if (i < len)
            {
                //MessageBox.Show("Incorrect file format: ROM Image not ended with 90 90 E9 ....");
                return false;
            }

            return true;
        }

        private void enableControlsBios(bool isValid)
        {
            textBoxSignedImageBios.Enabled = isValid;
            buttonSignedImageBios.Enabled = isValid;
            //textBoxDsaPrivateKey.Enabled = isValid;
            //buttonDsaPrivateKey.Enabled = isValid;
            textBoxUbiosVersion.Enabled = isValid;
            textBoxUbiosPublicKey.Enabled = isValid;
            buttonUbiosPublicKey.Enabled = isValid;
            textBoxUbcPublicKey.Enabled = isValid;
            buttonUbcPublicKey.Enabled = isValid;
            textBoxBootLoaderPublicKey.Enabled = isValid;
            buttonBootLoaderPublicKey.Enabled = isValid;
            buttonHashAdd.Enabled = isValid;
            buttonHashRemove.Enabled = isValid;
            listBoxHash.Enabled = isValid;
            buttonSignBios.Enabled = isValid;
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

            // update title text
            string assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string projectName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            this.Text = projectName + " " + assemblyVersion;
        }

        private void textBoxImageBios_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            string text = textBox.Text;

            if (File.Exists(text))
            {
                //
                // Read Image file to bytes[] bytesImageBios
                //
                bytesImageBios = File.ReadAllBytes(text);
                //
                // support old project which size is 4MB and the identification is not 16 bytes aligned
                //
                //if (bytesImageBios.Length >= 0x800000)
                //{
                //    identificationAlignment = 16;
                //}
                //else
                //{
                //    identificationAlignment = 1;
                //}
                if (textBoxSignedImageBios.Text.Length == 0)
                {
                    textBoxSignedImageBios.Text =  Path.GetDirectoryName(text) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(text) + "_signed" + Path.GetExtension(text); ;
                }
                resetInputFilesmageBios(sender, e);
                enableControlsBios(isValidImageBios());
            }
            else
            {
                enableControlsBios(false);
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
            textBoxImageBios.Text = buttonFilePath_Click(textBoxImageBios.Text);
        }

        private void buttonDsaPrivateKey_Click(object sender, EventArgs e)
        {
            textBoxDsaPrivateKey.Text = buttonFilePath_Click(textBoxDsaPrivateKey.Text);
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
            if (listBoxHash.Items.Count == 0)
            {
                var files = Directory.GetFiles(comboBoxWorkingFolder.Text, "*.*", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    var info = new FileInfo(file);
                    if (info.Length == HASH_SIZE)
                    {
                        listBoxHash.Items.Add(info.FullName);
                    }
                }
            }
            else
            {
                string hash_fp = "";
                hash_fp = buttonFilePath_Click(hash_fp);
                if (!String.IsNullOrEmpty(hash_fp))
                {
                    var info = new FileInfo(hash_fp);
                    if (info.Length == HASH_SIZE)
                    {
                        listBoxHash.Items.Add(hash_fp);
                    }
                    else
                    {
                        MessageBox.Show("Hash file size is limited to 20 bytes");
                    }
                }
            }
        }

        private void buttonHashRemove_Click(object sender, EventArgs e)
        {
            if (listBoxHash.SelectedItems.Count > 0)
            {
                while (listBoxHash.SelectedItems.Count > 0)
                {
                    listBoxHash.Items.Remove(listBoxHash.SelectedItems[0]);
                }
            }
        }

        private bool UpdateComboBox(System.Windows.Forms.ComboBox comboBox, string str, bool insert)
        {
            int index;
            if (!Directory.Exists(comboBoxWorkingFolder.Text))
            {
                return false;
            }
            if (insert)
            {
                index = comboBox.FindStringExact(str);
            }
            else
            {
                index = comboBox.FindString(str);
            }
            if (index == -1)
            {
                if (insert)
                {
                    comboBox.Items.Insert(0, str);
                    if (comboBox.Items.Count > MAX_WORKING_FOLDER_SAVED)
                    {
                        comboBox.Items.RemoveAt(MAX_WORKING_FOLDER_SAVED);
                    }
                    comboBox.SelectedIndex = 0;
                }
                else
                {
                    comboBox.Text = "";
                }
            }
            else
            {
                comboBox.SelectedIndex = index;
            }

            return (index == -1);
        }

        private void resetInputFiles(object sender, EventArgs e)
        {
            textBoxImageBios.Text = string.Empty;
            textBoxDsaPrivateKey.Text = string.Empty;
            textBoxUbcPublicKey.Text = string.Empty;
            textBoxBootLoaderPublicKey.Text = string.Empty;

            textBoxImageDisk.Text = string.Empty;

            textBoxImageUbc.Text = string.Empty;

            listBoxHash.Items.Clear();

            var files = Directory.GetFiles(comboBoxWorkingFolder.Text, "*.*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                var info = new FileInfo(file);
                if (info.Length == HASH_SIZE)
                {
                    listBoxHash.Items.Add(info.FullName);
                    continue;
                }
                // TODO: confirm the size of the private key
                if (info.Length == PRIVATE_KEY_SIZE || info.Length == PRIVATE_KEY_SIZE_2)
                {
                    textBoxDsaPrivateKey.Text = info.FullName;
                    continue;
                }
                if (info.Length == PUBLIC_KEY_SIZE)
                {
                    if (info.Name.Contains("UBC", StringComparison.OrdinalIgnoreCase))
                    {
                        textBoxUbcPublicKey.Text = info.FullName;
                        continue;
                    }
                    if (info.Name.Contains("UBIOS", StringComparison.OrdinalIgnoreCase))
                    {
                        textBoxUbiosPublicKey.Text = info.FullName;
                        continue;
                    }
                    if (info.Name.Contains("MBR", StringComparison.OrdinalIgnoreCase))
                    {
                        textBoxBootLoaderPublicKey.Text = info.FullName;
                        //continue;
                    }
                    continue;
                }
                if (info.Length == SIZE_FILE_BIOS && !info.Name.Contains("output", StringComparison.OrdinalIgnoreCase) && !info.Name.Contains("sign", StringComparison.OrdinalIgnoreCase))
                {
                    //bytesImageBios = File.ReadAllBytes(info.FullName);

                    //if (isValidImageBios())
                    //{
                    //    textBoxImageBios.Text = info.FullName;
                    //}
                    textBoxImageBios.Text = info.FullName;
                    continue;
                }
                if (info.Length == SIZE_FILE_DISK && !info.Name.Contains("output", StringComparison.OrdinalIgnoreCase))
                {
                    textBoxImageDisk.Text = info.FullName;
                    continue;
                }
                if (info.Length == SIZE_FILE_UBC && !info.Name.Contains("output", StringComparison.OrdinalIgnoreCase))
                {
                    textBoxImageUbc.Text = info.FullName;
                    continue;
                }
            }
        }

        private void resetInputFilesmageBios(object sender, EventArgs e)
        {
            //
            // retrueve version nubers from image
            //
            if (textBoxUbiosVersion.Text.Length == 0)
            {
                textBoxUbiosVersion.Text = System.Text.Encoding.UTF8.GetString(bytesImageBios[OFFSET_UBIOS_VERSION..(OFFSET_UBIOS_VERSION + textBoxUbiosVersion.MaxLength)]).Replace("\0", string.Empty);
            }
        }

        private void buttonWorkingFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(comboBoxWorkingFolder.Text))
            {
                folderBrowserDialog1.SelectedPath = comboBoxWorkingFolder.Text;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                comboBoxWorkingFolder.Text = folderBrowserDialog1.SelectedPath;
            }
            comboBoxWorkingFolder_Leave(sender, e);
        }

        private void comboBoxWorkingFolder_Leave(object sender, EventArgs e)
        {
            //if (comboBoxWorkingFolder.SelectedIndex== -1)
            {
                if (UpdateComboBox(comboBoxWorkingFolder, comboBoxWorkingFolder.Text, true))
                {
                    resetInputFiles(sender, e);
                }
            }
        }

        private void comboBoxWorkingFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (is1stTime)
            {
                is1stTime = false;
            }
            else
            {
                resetInputFiles(sender, e);
            }
        }

        private void enableControlsDsa(bool isValid)
        {
            textBoxImageBios.Enabled = isValid;
            buttonImageBios.Enabled = isValid;
            enableControlsBios(isValid);
            textBoxImageDisk.Enabled = isValid;
            buttonImageDisk.Enabled = isValid;
            enableControlsDisk(isValid);
            textBoxImageUbc.Enabled = isValid;
            buttonImageUbc.Enabled = isValid;
            enableControlsUbc(isValid);
        }
        
        private void textBoxDsaPrivateKey_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            string text = textBox.Text;

            if (File.Exists(text))
            {
                string pem = File.ReadAllText(text);

                // Create a PemReader to parse the PEM file
                var reader = new PemReader(new StringReader(pem));

                // Read the private key from the PEM file
                AsymmetricCipherKeyPair keyPair = (AsymmetricCipherKeyPair)reader.ReadObject();

                if (keyPair == null)
                {
                    enableControlsDsa(false);
                    return;
                }

                // Get the DSA private key from the key pair
                DsaPrivateKeyParameters dsaPrivateKey = (DsaPrivateKeyParameters)keyPair.Private;

                // Create a SHA1 hash function
                hashFunction = new Sha1Digest();

                // Create a DSA signer object
                signer = new DsaSigner();

                // Initialize the signer with the DSA private key
                signer.Init(true, dsaPrivateKey);

                enableControlsDsa(true);
            }
            else
            {
                enableControlsDsa(false);
            }
        }

        private byte[] bigIntegersToBytes(Org.BouncyCastle.Math.BigInteger[] bigIntArray)
        {
            byte[][] byteArrays = new byte[bigIntArray.Length][];
            for (int i = 0; i < bigIntArray.Length; i++)
            {
                byteArrays[i] = bigIntArray[i].ToByteArray();
            }

            int totalLength = byteArrays.Sum(x => x.Length);
            byte[] mergedArray = new byte[totalLength];

            int currentIndex = 0;
            foreach (byte[] array in byteArrays)
            {
                Buffer.BlockCopy(array, 0, mergedArray, currentIndex, array.Length);
                currentIndex += array.Length;
            }

            return mergedArray;
        }

        private void buttonSignBios_Click(object sender, EventArgs e)
        {
            //
            // 1. patch UBC Public key @ 0x3c (Length 0x194)
            //
            byte[] UbcPublicKey;
            if (!File.Exists(textBoxUbcPublicKey.Text)) { return; }
            UbcPublicKey = File.ReadAllBytes(textBoxUbcPublicKey.Text);
            Buffer.BlockCopy(UbcPublicKey, 0, bytesImageBios, OFFSET_UBC_PUBLIC_KEY, UbcPublicKey.Length);
            //
            // 2. patch MBR_GPT_BL_PUBLIC_KEY Public key @ 0x1d0 (Length 0x194)
            //
            byte[] BootLoaderPublicKey;
            if (!File.Exists(textBoxBootLoaderPublicKey.Text)) { return; }
            BootLoaderPublicKey = File.ReadAllBytes(textBoxBootLoaderPublicKey.Text);
            Buffer.BlockCopy(BootLoaderPublicKey, 0, bytesImageBios, OFFSET_BOOT_LOADER_PUBLIC_KEY, BootLoaderPublicKey.Length);
            //
            // 3. patch UBIOS version string @ OFFSET_UBIOS_VERSION (length 0x18)
            //
            byte[] VersionString = new byte[0x18];
            byte[] VersionStringInput = Encoding.ASCII.GetBytes(textBoxUbiosVersion.Text);
            // copy input to target array
            Buffer.BlockCopy(VersionStringInput, 0, VersionString, 0, VersionStringInput.Length);
            // override to Image buffer
            Buffer.BlockCopy(VersionString, 0, bytesImageBios, OFFSET_UBIOS_VERSION, VersionString.Length);
            //
            // 4. patch Hash list @OFFSET_HASH_LIST_START ~ OFFSET_HASH_LIST_END_PLUS1)
            //
            Array.Clear(bytesImageBios, OFFSET_HASH_LIST_START, OFFSET_HASH_LIST_END_PLUS1 - OFFSET_HASH_LIST_START);
            byte[] hash;
            int offsetRomImage = OFFSET_HASH_LIST_START;
            foreach (string hashFile in listBoxHash.Items)
            {
                if (!File.Exists(hashFile)) { return; }
                hash = File.ReadAllBytes(hashFile);
                Buffer.BlockCopy(hash, 0, bytesImageBios, offsetRomImage, hash.Length);
                offsetRomImage += hash.Length;
                // ignore hash files after offset OFFSET_HASH_LIST_END_PLUS1
                if (offsetRomImage > OFFSET_HASH_LIST_END_PLUS1 - hash.Length) { break; }
            }
            //
            // 5. patch UBIOS public key and it's double word - byte checksum to OFFSET_UBIOS_PUBLIC_KEY
            //
            byte[] UbiosPublicKey;
            int checksum = 0;
            if (!File.Exists(textBoxUbiosPublicKey.Text)) { return; }
            UbiosPublicKey = File.ReadAllBytes(textBoxUbiosPublicKey.Text);
            for (int i = 0; i < UbiosPublicKey.Length; i++)
            {
                bytesImageBios[OFFSET_UBIOS_PUBLIC_KEY + i] = UbiosPublicKey[i];
                checksum += UbiosPublicKey[i];
            }
            // override checksum after UBIOS Public key
            byte[] bytes = BitConverter.GetBytes(checksum);
            Buffer.BlockCopy(bytes, 0, bytesImageBios, OFFSET_UBIOS_PUBLIC_KEY + UbiosPublicKey.Length, sizeof(int));
            //
            // 6. get hash and sign the blob from offset 0x3c~EOF of the image.
            //
            // Dotnet's DSA class doesn't support loading DSA private keys refer to: https://www.reddit.com/r/dotnetcore/comments/tg5pqg/creating_dsa_signature_with_private_key/
            // Switch to BouncyCastle library

            // Compute the hash of the blob
            hashFunction.BlockUpdate(bytesImageBios, 0x3c, bytesImageBios.Length - 0x3c);
            hash = new byte[hashFunction.GetDigestSize()];
            hashFunction.DoFinal(hash, 0);

            // Convert the signature to an byte array
            byte[] signature = bigIntegersToBytes(signer.GenerateSignature(hash));

            // patch signature & hash to the head of ROM Image
            Buffer.BlockCopy(signature, 0, bytesImageBios, 0, signature.Length); // length = 0x28
            Buffer.BlockCopy(hash, 0, bytesImageBios, signature.Length, hash.Length); // length = 0x14
            //
            //  7. Write to output file
            //
            try
            {
                MessageBox.Show("Write to " + textBoxSignedImageBios.Text);
                File.WriteAllBytes(textBoxSignedImageBios.Text, bytesImageBios);
            }
            catch (IOException ex)
            {
                MessageBox.Show("An error occurred while writing to the file: " + ex.Message);
            }
        }

        private void buttonImageDisk_Click(object sender, EventArgs e)
        {
            textBoxImageDisk.Text = buttonFilePath_Click(textBoxImageDisk.Text);
        }

        private void buttonSignedImageDisk_Click(object sender, EventArgs e)
        {
            textBoxSignedImageDisk.Text = buttonFilePath_Click(textBoxSignedImageDisk.Text);
        }
        //
        // constants for singing disk
        //

        private void enableControlsDisk(bool isValid)
        {
            textBoxSignedImageDisk.Enabled = isValid;
            buttonSignedImageDisk.Enabled = isValid;
            buttonSignDisk.Enabled = isValid;
        }

        private bool isValidImageDisk()
        {
            ////
            //// is it a sectors snapshot?
            ////
            //if (bytesImageDisk.Length % SIZE_DISK_SECTOR != 0)
            //{
            //    MessageBox.Show("Not a valid disk sectors' image.");
            //    return false;
            //}
            return true;
        }

        private void textBoxImageDisk_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            string text = textBox.Text;

            if (!File.Exists(textBoxImageDisk.Text))
            {
                enableControlsDisk(false);
                return;
            }

            //
            // Read Image file to bytes[] bytesImageDisk
            //
            bytesImageDisk = File.ReadAllBytes(textBoxImageDisk.Text);

            if (bytesImageDisk.Length != SIZE_FILE_DISK)
            {
                enableControlsDisk(false);
                return;
            }

            //
            // set the default output image file name
            //
            if (textBoxSignedImageDisk.Text.Length == 0)
            {
                textBoxSignedImageDisk.Text =  Path.GetDirectoryName(text) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(text) + "_signed" + Path.GetExtension(text); ;
            }
            enableControlsDisk(isValidImageDisk());
        }

        // Verify:
        //  a) 0x000 to 0x177 : (MBR Code, GRUB Stage 1)
        //  b) 0x1B4 to 0x1FF : (Boot Loader Sectors, Partition Table and Disk Signature)
        // No Verification: 
        //  a) 0x178 to 0x1B3 : Hash data and signature area

        private void buttonSignDisk_Click(object sender, EventArgs e)
        {
            byte[] signature;
            byte[] hash;
            int retryCount;

            //
            // 1. sign MBR
            // 
            short BL_Ss = 1; // GRUB Boot Loader Start Sector; 
            Buffer.BlockCopy(BitConverter.GetBytes(BL_Ss), 0, bytesImageDisk, 0x1b4, sizeof(short));

            short BL_Si = (short)(BitConverter.ToInt16(bytesImageDisk, 0x1c6) - 2); // BL Si = GRUB Boot Loader Sector Size
            Buffer.BlockCopy(BitConverter.GetBytes(BL_Si), 0, bytesImageDisk, 0x1b6, sizeof(short));

            // assemble a blobMbr
            byte[] blobMbr = bytesImageDisk[0..0x178].Concat(bytesImageDisk[0x1b4..SIZE_DISK_SECTOR]).ToArray();

            // Compute the hash of the blobMbr
            hashFunction.BlockUpdate(blobMbr, 0, blobMbr.Length);
            hash = new byte[hashFunction.GetDigestSize()];
            hashFunction.DoFinal(hash, 0);
            // Convert the signature to an byte array
            retryCount = 0;
            do
            {
                signature = bigIntegersToBytes(signer.GenerateSignature(hash));
                retryCount++;
            } while (signature.Length != 40 && retryCount < RETRY_SIGN);
            if (retryCount >= RETRY_SIGN) { return; }

            // patch signature & hash
            Buffer.BlockCopy(signature, 0, bytesImageDisk, 0x178, signature.Length); // length = 0x28
            Buffer.BlockCopy(hash, 0, bytesImageDisk, 0x178 + signature.Length, hash.Length); // length = 0x14
            //
            // 2. sign GRUB
            //
            byte[] blobGrub = bytesImageDisk[SIZE_DISK_SECTOR..(bytesImageDisk.Length - SIZE_DISK_SECTOR)]; // 2nd~eof-1 sector sectors

            // Compute the hash of the blobGrub
            hashFunction.BlockUpdate(blobGrub, 0, blobGrub.Length);
            hashFunction.DoFinal(hash, 0);
            // Convert the signature to an byte array
            retryCount = 0;
            do
            {
                signature = bigIntegersToBytes(signer.GenerateSignature(hash));
                retryCount++;
            } while (signature.Length != 40 && retryCount < RETRY_SIGN);
            if (retryCount >= RETRY_SIGN ) { return; }

            // patch signature & hash
            Buffer.BlockCopy(hash, 0, bytesImageDisk, bytesImageDisk.Length - SIZE_DISK_SECTOR, hash.Length); // length = 0x14
            Buffer.BlockCopy(signature, 0, bytesImageDisk, bytesImageDisk.Length - SIZE_DISK_SECTOR + hash.Length, signature.Length); // length = 0x28
            //
            //  3. Write to output file
            //
            try
            {
                MessageBox.Show("Write to " + textBoxSignedImageDisk.Text);
                File.WriteAllBytes(textBoxSignedImageDisk.Text, bytesImageDisk);
            }
            catch (IOException ex)
            {
                MessageBox.Show("An error occurred while writing to the file: " + ex.Message);
            }
        }

        private void buttonImageUbc_Click(object sender, EventArgs e)
        {
            textBoxImageUbc.Text = buttonFilePath_Click(textBoxImageUbc.Text);
        }

        private void buttonSignedImageUbc_Click(object sender, EventArgs e)
        {
            textBoxSignedImageUbc.Text = buttonFilePath_Click(textBoxSignedImageUbc.Text);
        }

        private bool isValidImageUbc()
        {
            return true;
        }

        private void enableControlsUbc(bool isValid)
        {
            textBoxSignedImageUbc.Enabled = isValid;
            buttonSignedImageUbc.Enabled = isValid;
            textBoxUbiosVersionUbc.Enabled = isValid;
            textBoxUbcVersion.Enabled = isValid;
            buttonHashAddUbc.Enabled = isValid;
            buttonHashRemoveUbc.Enabled = isValid;
            listBoxHashUbc.Enabled = isValid;
            buttonSignUbc.Enabled = isValid;
        }

        private void textBoxImageUbc_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            string text = textBox.Text;

            if (!File.Exists(text))
            {
                enableControlsUbc(false);
                return;
            }
            //
            // Read Image file to bytes[] bytesImageUbc
            //
            bytesImageUbc = File.ReadAllBytes(text);
            if (bytesImageUbc.Length != SIZE_FILE_UBC)
            {
                enableControlsUbc(false);
                return;
            }
            //
            // default output file name
            //
            if (textBoxSignedImageUbc.Text.Length == 0)
            {
                textBoxSignedImageUbc.Text = Path.GetDirectoryName(text) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(text) + "_signed" + Path.GetExtension(text); ;
            }
            //
            // retrueve version nubers from image
            //
            if (textBoxUbiosVersionUbc.Text.Length == 0)
            {
                byte[] bytesUbiosVersion = bytesImageUbc[OFFSET_UBIOS_VERSION_UBC..(OFFSET_UBIOS_VERSION_UBC + textBoxUbiosVersionUbc.MaxLength)];

                bool all0xff = true;
                foreach (byte b in bytesUbiosVersion)
                {
                    if (b != 0xff)
                    {
                        all0xff = false;
                        break;
                    }
                }

                if (all0xff)
                {
                    textBoxUbiosVersionUbc.Text = textBoxUbiosVersion.Text;
                }
                else
                {
                    textBoxUbiosVersionUbc.Text = System.Text.Encoding.UTF8.GetString(bytesUbiosVersion).Replace("\0", string.Empty);
                }
            }
            if (textBoxUbcVersion.Text.Length == 0)
            {
                textBoxUbcVersion.Text = System.Text.Encoding.UTF8.GetString(bytesImageUbc[OFFSET_UBC_VERSION..(OFFSET_UBC_VERSION + 6)]).Replace("\0", string.Empty);
            }

            enableControlsUbc(isValidImageUbc());
        }

        private void buttonSignUbc_Click(object sender, EventArgs e)
        {
            //
            // 0. clear 
            //
            Array.Clear(bytesImageUbc, OFFSET_HASH_LIST_START_UBC, OFFSET_UBIOS_VERSION_UBC - OFFSET_HASH_LIST_START_UBC);
                        //
            // 1. hash list
            //
            byte[] hash;
            int offsetRomImage = OFFSET_HASH_LIST_START_UBC;
            foreach (string hashFile in listBoxHashUbc.Items)
            {
                if (!File.Exists(hashFile)) { return; }
                hash = File.ReadAllBytes(hashFile);
                Buffer.BlockCopy(hash, 0, bytesImageUbc, offsetRomImage, hash.Length);
                offsetRomImage += hash.Length;
                // ignore hash files after offset OFFSET_HASH_LIST_END_PLUS1_UBC
                if (offsetRomImage > OFFSET_HASH_LIST_END_PLUS1_UBC - hash.Length) { break; }
            }
            //
            // 2.  patch UBIOS version string @ OFFSET_UBIOS_VERSION_UBC (length 0x18)
            //
            byte[] VersionString = new byte[0x18];
            byte[] VersionStringInput = Encoding.ASCII.GetBytes(textBoxUbiosVersionUbc.Text);
            // copy input to target array
            Buffer.BlockCopy(VersionStringInput, 0, VersionString, 0, VersionStringInput.Length);
            // override to Image buffer
            Buffer.BlockCopy(VersionString, 0, bytesImageUbc, OFFSET_UBIOS_VERSION_UBC, VersionString.Length);
            //
            // 3. patch UBC version string @ OFFSET_UBC_VERSION (length 0x18)
            //
            byte[] VersionStringUbc = new byte[6];
            byte[] VersionStringInputUbc = Encoding.ASCII.GetBytes(textBoxUbcVersion.Text);
            // copy input to target array
            Buffer.BlockCopy(VersionStringInputUbc, 0, VersionStringUbc, 0, VersionStringInputUbc.Length);
            // override to Image buffer
            Buffer.BlockCopy(VersionStringUbc, 0, bytesImageUbc, OFFSET_UBC_VERSION, VersionStringUbc.Length);
            //
            // 4. Hash & Sign
            //
            byte[] blobUbc = bytesImageUbc[0..(bytesImageUbc.Length-(HASH_SIZE+SIGNATURE_SIZE))];

            // Compute the hash of the blobUbc
            hashFunction.BlockUpdate(blobUbc, 0, blobUbc.Length);
            hash = new byte[hashFunction.GetDigestSize()];
            hashFunction.DoFinal(hash, 0);
            // Convert the signature to an byte array
            byte[] signature;
            int retryCount = 0;
            do
            {
                signature = bigIntegersToBytes(signer.GenerateSignature(hash));
                retryCount++;
            } while (signature.Length != 40 && retryCount < RETRY_SIGN);
            if (retryCount >= RETRY_SIGN) { return; }

            // patch signature & hash
            Buffer.BlockCopy(hash, 0, bytesImageUbc, bytesImageUbc.Length - (hash.Length + signature.Length), hash.Length); // length = 0x14
            Buffer.BlockCopy(signature, 0, bytesImageUbc, bytesImageUbc.Length - signature.Length, signature.Length); // length = 0x28
            //
            //  3. Write to output file
            //
            try
            {
                MessageBox.Show("Write to " + textBoxSignedImageUbc.Text);
                File.WriteAllBytes(textBoxSignedImageUbc.Text, bytesImageUbc);
            }
            catch (IOException ex)
            {
                MessageBox.Show("An error occurred while writing to the file: " + ex.Message);
            }
        }

        private void comboBoxWorkingFolder_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.ComboBox  comboBox = (System.Windows.Forms.ComboBox)sender;
            string text = comboBox.Text;

            // Check if the specified folder exists
            if (!Directory.Exists(text))
            {
                // If the folder does not exist, display an error message and keep the focus on the TextBox
                //errorProvider1.SetError(textBox, "The specified folder does not exist");
                e.Cancel = true;
            }
            else
            {
                // If the folder exists, clear the error message and allow the focus to be moved away from the TextBox
                //errorProvider1.SetError(textBox, "");
                e.Cancel = false;
            }

        }

        private void buttonHashAddUbc_Click(object sender, EventArgs e)
        {
            if (listBoxHashUbc.Items.Count == 0)
            {
                var files = Directory.GetFiles(comboBoxWorkingFolder.Text, "*.*", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    var info = new FileInfo(file);
                    if (info.Length == HASH_SIZE)
                    {
                        listBoxHashUbc.Items.Add(info.FullName);
                    }
                }
            }
            else
            {
                string hash_fp = "";
                hash_fp = buttonFilePath_Click(hash_fp);
                if (!String.IsNullOrEmpty(hash_fp))
                {
                    var info = new FileInfo(hash_fp);
                    if (info.Length == HASH_SIZE)
                    {
                        listBoxHashUbc.Items.Add(hash_fp);
                    }
                    else
                    {
                        MessageBox.Show("Hash file size is limited to 20 bytes");
                    }
                }
            }

        }

        private void buttonHashRemoveUbc_Click(object sender, EventArgs e)
        {
            if (listBoxHashUbc.SelectedItems.Count > 0)
            {
                while (listBoxHashUbc.SelectedItems.Count > 0)
                {
                    listBoxHashUbc.Items.Remove(listBoxHashUbc.SelectedItems[0]);
                }
            }
        }

        private void buttonSignedImageBios_Click(object sender, EventArgs e)
        {
            textBoxSignedImageBios.Text = buttonFilePath_Click(textBoxSignedImageBios.Text);
        }
    }
}