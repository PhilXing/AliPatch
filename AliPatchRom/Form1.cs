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
        public const string VALUE_WORKING_PATH_SELECTEDINDEX = "WorkingPathSelected";
        public const string VALUE_ROM_IMAGE_INPUT_PATH = "RomImageInputPath";
        public const string VALUE_ROM_IMAGE_OUTPUT_PATH = "RomImageOutputPath";
        public const string VALUE_PRIVATE_KEY_PATH = "DsaPrivateKeyPath";
        public const string VALUE_UBIOS_VERSION = "UbiosVersion";
        public const string VALUE_UBIOS_PUBLIC_KEY_PATH = "UbiosPublickeyPath";
        public const string VALUE_UBC_PUBLIC_KEY_PATH = "UbcPublicKeyPath";
        public const string VALUE_BOOT_LOADER_PUBLIC_KEY_PATH = "BootLoaderPublicKeyPath";
        public const string VALUE_HASH_PATH_LIST = "HashPathList";

        public const int MAX_WORKING_FOLDER_SAVED = 5;

        public const int HASH_FILE_SIZE = 20;
        public const int PRIVATE_KEY_SIZE = 684;
        public const int PUBLIC_KEY_SIZE = 404;
        public const int ROM_FILE_SIZE = 0x800000;

        public const int OFFSET_HASH_LIST_START = 0x37c;
        public const int OFFSET_HASH_LIST_END_PLUS1 = 0x10000;
        public const int OFFSET_UBC_PUBLIC_KEY = 0x03c;
        public const int OFFSET_BOOT_LOADER_PUBLIC_KEY = 0x01d0;
        public const int OFFSET_UBIOS_VERSION = 0x0364;
        public const int OFFSET_UBIOS_PUBLIC_KEY = 0x7f8020;

        public const int MAX_HASH_PATH_COUNT = (OFFSET_HASH_LIST_END_PLUS1 - OFFSET_HASH_LIST_START) / HASH_FILE_SIZE;

        public byte[] RomImage;
        public int identificationAlignment = 16;
        public bool is1stTime = true;

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
            RegistryKey appKey = Registry.CurrentUser.CreateSubKey("Software\\" + COMPANY_NAME + "\\" + APP_KEY);

            //appKey.SetValue(VALUE_WORKING_PATH, comboBoxWorkingFolder.Text);
            appKey.SetValue(VALUE_WORKING_PATH_SELECTEDINDEX, comboBoxWorkingFolder.SelectedIndex);
            appKey.SetValue(VALUE_ROM_IMAGE_INPUT_PATH, textBoxInputImage.Text);
            appKey.SetValue(VALUE_ROM_IMAGE_OUTPUT_PATH, textBoxOutputImage.Text);
            appKey.SetValue(VALUE_PRIVATE_KEY_PATH, textBoxDsaPrivateKey.Text);
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
                if (appFamilyKey != null)
                {
                    appFamilyKey.DeleteSubKeyTree(APP_KEY);
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\" + COMPANY_NAME + "\\" + APP_KEY, APP_VERSION_VALUE, APP_REGISTRY_VERSION);
                }
                return;
            }
            //
            // Restore lists
            //
            RestoreComboSettings(appKey, VALUE_WORKING_PATH_LIST, comboBoxWorkingFolder, MAX_WORKING_FOLDER_SAVED);
            RestoreListSettings(appKey, VALUE_HASH_PATH_LIST, listBoxHash, MAX_HASH_PATH_COUNT);
            //
            // Restore controls
            //
            //comboBoxWorkingFolder.Text = (string)appKey.GetValue(VALUE_WORKING_PATH, "");
            comboBoxWorkingFolder.SelectedIndex = (int)appKey.GetValue(VALUE_WORKING_PATH_SELECTEDINDEX, 0);
            textBoxInputImage.Text = (string)appKey.GetValue(VALUE_ROM_IMAGE_INPUT_PATH, "");
            textBoxOutputImage.Text = (string)appKey.GetValue(VALUE_ROM_IMAGE_OUTPUT_PATH, "");
            textBoxDsaPrivateKey.Text = (string)appKey.GetValue(VALUE_PRIVATE_KEY_PATH, "");
            textBoxUbiosVersion.Text = (string)appKey.GetValue(VALUE_UBIOS_VERSION, "");
            textBoxUbiosPublicKey.Text = (string)appKey.GetValue(VALUE_UBIOS_PUBLIC_KEY_PATH, "");
            textBoxUbcPublicKey.Text = (string)appKey.GetValue(VALUE_UBC_PUBLIC_KEY_PATH, "");
            textBoxBootLoaderPublicKey.Text = (string)appKey.GetValue(VALUE_BOOT_LOADER_PUBLIC_KEY_PATH, "");
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
            if (RomImage==null)
            {
                return -1;
            }
            var len = needle.Length;
            var limit = RomImage.Length - len;
            for (var i = 0; i <= limit; i += identificationAlignment)
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
            var validSignarueOffset = RomImage.Length - 16;
            var i = 0;
            for (; i < len; i++)
            {
                if (validSignature[i] != RomImage[i + validSignarueOffset]) break;
            }
            if (i < len)
            {
                //MessageBox.Show("Incorrect file format: ROM Image not ended with 90 90 E9 ....");
                return false;
            }

            return true;
        }

        private void enableControls(bool isValid)
        {
            textBoxOutputImage.Enabled = isValid;
            buttonOutputImage.Enabled = isValid;
            textBoxDsaPrivateKey.Enabled = isValid;
            buttonDsaPrivateKey.Enabled = isValid;
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
            buttonGenerate.Enabled = isValid;
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
                //if (RomImage.Length >= 0x800000)
                //{
                //    identificationAlignment = 16;
                //}
                //else
                //{
                //    identificationAlignment = 1;
                //}
                if (textBoxOutputImage.Text.Length == 0)
                {
                    textBoxOutputImage.Text = textBoxInputImage.Text;
                }
                enableControls(isValidImage());
            }
            else
            {
                enableControls(false);
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
                    if (info.Length == HASH_FILE_SIZE)
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
                    if (info.Length == HASH_FILE_SIZE)
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

            return (index==-1);
        }

        private void resetInputFiles(object sender, EventArgs e)
        {
            var inputImageSelected = false;
            textBoxInputImage.Text = string.Empty;
            textBoxOutputImage.Text = string.Empty;
            textBoxDsaPrivateKey.Text = string.Empty;
            textBoxUbcPublicKey.Text = string.Empty;
            textBoxBootLoaderPublicKey.Text = string.Empty;

            listBoxHash.Items.Clear();

            var files = Directory.GetFiles(comboBoxWorkingFolder.Text, "*.*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                var info = new FileInfo(file);
                if (info.Length == HASH_FILE_SIZE)
                {
                    listBoxHash.Items.Add(info.FullName);
                    continue;
                }
                if (info.Length == PRIVATE_KEY_SIZE)
                {
                    if (String.IsNullOrEmpty(textBoxDsaPrivateKey.Text))
                    {
                        textBoxDsaPrivateKey.Text = info.FullName;
                    }
                    continue;
                }
                if (info.Length == PUBLIC_KEY_SIZE)
                {
                    if (string.IsNullOrEmpty(textBoxUbcPublicKey.Text) && info.Name.Contains("UBC", StringComparison.OrdinalIgnoreCase))
                    {
                        textBoxUbcPublicKey.Text += info.FullName;
                        continue;
                    }
                    if (string.IsNullOrEmpty(textBoxUbiosPublicKey.Text) && info.Name.Contains("UBIOS", StringComparison.OrdinalIgnoreCase))
                    {
                        textBoxUbiosPublicKey.Text += info.FullName;
                        continue;
                    }
                    if (string.IsNullOrEmpty(textBoxBootLoaderPublicKey.Text) && info.Name.Contains("MBR", StringComparison.OrdinalIgnoreCase))
                    {
                        textBoxBootLoaderPublicKey.Text += info.FullName;
                        //continue;
                    }
                    continue;
                }
                if (!inputImageSelected && info.Length == ROM_FILE_SIZE)
                {
                    RomImage = File.ReadAllBytes(info.FullName);

                    if (isValidImage())
                    {
                        textBoxInputImage.Text = info.FullName;
                        inputImageSelected = true;
                    }
                    continue;
                }
            }
            enableControls(inputImageSelected);

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
            if (comboBoxWorkingFolder.SelectedIndex== -1)
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

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            //
            // 1. patch UBC Public key @ 0x3c (Length 0x194)
            //
            byte[] UbcPublicKey;
            if (!File.Exists(textBoxUbcPublicKey.Text)) { return; }
            UbcPublicKey = File.ReadAllBytes(textBoxUbcPublicKey.Text);
            Buffer.BlockCopy(UbcPublicKey, 0, RomImage, OFFSET_UBC_PUBLIC_KEY, UbcPublicKey.Length);
            //
            // 2. patch MBR_GPT_BL_PUBLIC_KEY Public key @ 0x1d0 (Length 0x194)
            //
            byte[] BootLoaderPublicKey;
            if (!File.Exists(textBoxBootLoaderPublicKey.Text)) { return; }
            BootLoaderPublicKey = File.ReadAllBytes(textBoxBootLoaderPublicKey.Text);
            Buffer.BlockCopy(BootLoaderPublicKey, 0, RomImage, OFFSET_BOOT_LOADER_PUBLIC_KEY, BootLoaderPublicKey.Length);
            //
            // 3. patch UBIOS version string @ 0x364 (length 0x18)
            //
            byte[] VersionString = new byte[0x18];
            byte[] VersionStringInput = Encoding.ASCII.GetBytes(textBoxUbiosVersion.Text);
            // copy input to target array
            Buffer.BlockCopy(VersionStringInput, 0, VersionString, 0, VersionStringInput.Length);
            // override to Image buffer
            Buffer.BlockCopy(VersionString, 0, RomImage, OFFSET_UBIOS_VERSION, VersionString.Length);
            //
            // 4. patch Hash list @OFFSET_HASH_LIST_START ~ OFFSET_HASH_LIST_END_PLUS1)
            //
            Array.Clear(RomImage, OFFSET_HASH_LIST_START, OFFSET_HASH_LIST_END_PLUS1 - OFFSET_HASH_LIST_START);
            byte[] hash;
            int offsetRomImage = OFFSET_HASH_LIST_START;
            foreach (string hashFile in listBoxHash.Items)
            {
                if (!File.Exists(hashFile)) { return; }
                hash = File.ReadAllBytes(hashFile);
                Buffer.BlockCopy(hash, 0, RomImage, offsetRomImage, hash.Length);
                offsetRomImage+= hash.Length;
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
                RomImage[OFFSET_UBIOS_PUBLIC_KEY + i] = UbiosPublicKey[i];
                checksum += UbiosPublicKey[i];
            }
            // override checksum after UBIOS Public key
            byte[] bytes = BitConverter.GetBytes(checksum);
            Buffer.BlockCopy(bytes, 0, RomImage, OFFSET_UBIOS_PUBLIC_KEY + UbiosPublicKey.Length, sizeof(int));
            //
            // 6. get hash and sign the blob from offset 0x3c~EOF of the image.
            //
            // Dotnet's DSA class doesn't support loading DSA private keys refer to: https://www.reddit.com/r/dotnetcore/comments/tg5pqg/creating_dsa_signature_with_private_key/
            // Switch to BouncyCastle library
            //
            // Generate a new DSA private key

            // Read the PEM file into a string
            string pem = File.ReadAllText(textBoxDsaPrivateKey.Text);

            // Create a PemReader to parse the PEM file
            var reader = new PemReader(new StringReader(pem));

            // Read the private key from the PEM file
            AsymmetricCipherKeyPair keyPair = (AsymmetricCipherKeyPair)reader.ReadObject();

            // Get the DSA private key from the key pair
            DsaPrivateKeyParameters dsaPrivateKey = (DsaPrivateKeyParameters)keyPair.Private;

            // Create a SHA1 hash function
            IDigest hashFunction = new Sha1Digest();

            // Compute the hash of the blob
            hashFunction.BlockUpdate(RomImage, 0x3c, RomImage.Length - 0x3c);
            hash = new byte[hashFunction.GetDigestSize()];
            hashFunction.DoFinal(hash, 0);

            // Create a DSA signer object
            IDsa signer = new DsaSigner();

            // Initialize the signer with the DSA private key
            signer.Init(true, dsaPrivateKey);

            // Compute the signature for the hash
            Org.BouncyCastle.Math.BigInteger[] bigIntArray = signer.GenerateSignature(hash);

            // Convert the signature to an byte array
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

            // patch signature & hash to the head of ROM Image
            Buffer.BlockCopy(mergedArray, 0, RomImage, 0, mergedArray.Length); // length = 0x28
            Buffer.BlockCopy(hash, 0, RomImage, mergedArray.Length, hash.Length); // length = 0x14
            //
            //  7. Write to output file
            //
            try
            {
                MessageBox.Show("Write to " + textBoxOutputImage.Text);
                File.WriteAllBytes(textBoxOutputImage.Text, RomImage);
            }
            catch( IOException ex)
            {
                MessageBox.Show("An error occurred while writing to the file: " + ex.Message);
            }
        }

    }

}