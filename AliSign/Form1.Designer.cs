namespace AliSign
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelWorkingFolder = new System.Windows.Forms.Label();
            this.comboBoxWorkingFolder = new System.Windows.Forms.ComboBox();
            this.buttonWorkingFolder = new System.Windows.Forms.Button();
            this.labelImageBios = new System.Windows.Forms.Label();
            this.textBoxImageBios = new System.Windows.Forms.TextBox();
            this.buttonImageBios = new System.Windows.Forms.Button();
            this.labelDsaPrivateKey = new System.Windows.Forms.Label();
            this.textBoxDsaPrivateKey = new System.Windows.Forms.TextBox();
            this.buttonDsaPrivateKey = new System.Windows.Forms.Button();
            this.labelUbiosVersion = new System.Windows.Forms.Label();
            this.textBoxUbiosVersion = new System.Windows.Forms.TextBox();
            this.labelUbiosPublicKey = new System.Windows.Forms.Label();
            this.textBoxUbiosPublicKey = new System.Windows.Forms.TextBox();
            this.buttonUbiosPublicKey = new System.Windows.Forms.Button();
            this.labelBootLoaderPublicKey = new System.Windows.Forms.Label();
            this.textBoxBootLoaderPublicKey = new System.Windows.Forms.TextBox();
            this.buttonBootLoaderPublicKey = new System.Windows.Forms.Button();
            this.labelHashList = new System.Windows.Forms.Label();
            this.listBoxHash = new System.Windows.Forms.ListBox();
            this.buttonHashAdd = new System.Windows.Forms.Button();
            this.buttonHashRemove = new System.Windows.Forms.Button();
            this.labelOutputImageBios = new System.Windows.Forms.Label();
            this.buttonOutputImageBios = new System.Windows.Forms.Button();
            this.textBoxOutputImageBios = new System.Windows.Forms.TextBox();
            this.buttonSignBios = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxUbcPublicKey = new System.Windows.Forms.TextBox();
            this.buttonUbcPublicKey = new System.Windows.Forms.Button();
            this.labelUbcPublicKey = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlSign = new System.Windows.Forms.TabControl();
            this.tabPageBios = new System.Windows.Forms.TabPage();
            this.tabPageDisk = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.labelImageDisk = new System.Windows.Forms.Label();
            this.textBoxImageDisk = new System.Windows.Forms.TextBox();
            this.buttonImageDisk = new System.Windows.Forms.Button();
            this.labelOutputImageDisk = new System.Windows.Forms.Label();
            this.textBoxOutputImageDisk = new System.Windows.Forms.TextBox();
            this.buttonOutputImageDisk = new System.Windows.Forms.Button();
            this.buttonSignDisk = new System.Windows.Forms.Button();
            this.tabPageUbc = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.labelImageUbc = new System.Windows.Forms.Label();
            this.textBoxImageUbc = new System.Windows.Forms.TextBox();
            this.buttonImageUbc = new System.Windows.Forms.Button();
            this.labelOutputImageUbc = new System.Windows.Forms.Label();
            this.textBoxOutputImageUbc = new System.Windows.Forms.TextBox();
            this.buttonOutputImageUbc = new System.Windows.Forms.Button();
            this.buttonSignUbc = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabControlSign.SuspendLayout();
            this.tabPageBios.SuspendLayout();
            this.tabPageDisk.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tabPageUbc.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelWorkingFolder
            // 
            this.labelWorkingFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelWorkingFolder.AutoSize = true;
            this.labelWorkingFolder.Location = new System.Drawing.Point(23, 11);
            this.labelWorkingFolder.Name = "labelWorkingFolder";
            this.labelWorkingFolder.Size = new System.Drawing.Size(94, 15);
            this.labelWorkingFolder.TabIndex = 0;
            this.labelWorkingFolder.Text = "Working Folder";
            // 
            // comboBoxWorkingFolder
            // 
            this.comboBoxWorkingFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWorkingFolder.FormattingEnabled = true;
            this.comboBoxWorkingFolder.Location = new System.Drawing.Point(123, 7);
            this.comboBoxWorkingFolder.Name = "comboBoxWorkingFolder";
            this.comboBoxWorkingFolder.Size = new System.Drawing.Size(572, 23);
            this.comboBoxWorkingFolder.TabIndex = 1;
            this.comboBoxWorkingFolder.SelectedIndexChanged += new System.EventHandler(this.comboBoxWorkingFolder_SelectedIndexChanged);
            this.comboBoxWorkingFolder.Leave += new System.EventHandler(this.comboBoxWorkingFolder_Leave);
            // 
            // buttonWorkingFolder
            // 
            this.buttonWorkingFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonWorkingFolder.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonWorkingFolder.Location = new System.Drawing.Point(701, 3);
            this.buttonWorkingFolder.Name = "buttonWorkingFolder";
            this.buttonWorkingFolder.Size = new System.Drawing.Size(74, 31);
            this.buttonWorkingFolder.TabIndex = 2;
            this.buttonWorkingFolder.Text = "...";
            this.buttonWorkingFolder.UseVisualStyleBackColor = true;
            this.buttonWorkingFolder.Click += new System.EventHandler(this.buttonWorkingFolder_Click);
            // 
            // labelImageBios
            // 
            this.labelImageBios.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelImageBios.AutoSize = true;
            this.labelImageBios.Location = new System.Drawing.Point(74, 14);
            this.labelImageBios.Name = "labelImageBios";
            this.labelImageBios.Size = new System.Drawing.Size(73, 15);
            this.labelImageBios.TabIndex = 3;
            this.labelImageBios.Text = "BIOS Image";
            // 
            // textBoxImageBios
            // 
            this.textBoxImageBios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxImageBios.Location = new System.Drawing.Point(153, 10);
            this.textBoxImageBios.Name = "textBoxImageBios";
            this.textBoxImageBios.Size = new System.Drawing.Size(171, 23);
            this.textBoxImageBios.TabIndex = 4;
            this.textBoxImageBios.TextChanged += new System.EventHandler(this.textBoxImageBios_TextChanged);
            // 
            // buttonImageBios
            // 
            this.buttonImageBios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonImageBios.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonImageBios.Location = new System.Drawing.Point(330, 3);
            this.buttonImageBios.Name = "buttonImageBios";
            this.buttonImageBios.Size = new System.Drawing.Size(74, 37);
            this.buttonImageBios.TabIndex = 5;
            this.buttonImageBios.Text = "...";
            this.buttonImageBios.UseVisualStyleBackColor = true;
            this.buttonImageBios.Click += new System.EventHandler(this.buttonRomImage_Click);
            // 
            // labelDsaPrivateKey
            // 
            this.labelDsaPrivateKey.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDsaPrivateKey.AutoSize = true;
            this.labelDsaPrivateKey.Location = new System.Drawing.Point(22, 48);
            this.labelDsaPrivateKey.Name = "labelDsaPrivateKey";
            this.labelDsaPrivateKey.Size = new System.Drawing.Size(95, 15);
            this.labelDsaPrivateKey.TabIndex = 11;
            this.labelDsaPrivateKey.Text = "DSA Private Key";
            // 
            // textBoxDsaPrivateKey
            // 
            this.textBoxDsaPrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDsaPrivateKey.Enabled = false;
            this.textBoxDsaPrivateKey.Location = new System.Drawing.Point(123, 44);
            this.textBoxDsaPrivateKey.Name = "textBoxDsaPrivateKey";
            this.textBoxDsaPrivateKey.Size = new System.Drawing.Size(572, 23);
            this.textBoxDsaPrivateKey.TabIndex = 12;
            this.textBoxDsaPrivateKey.TextChanged += new System.EventHandler(this.textBoxDsaPrivateKey_TextChanged);
            // 
            // buttonDsaPrivateKey
            // 
            this.buttonDsaPrivateKey.Enabled = false;
            this.buttonDsaPrivateKey.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDsaPrivateKey.Location = new System.Drawing.Point(701, 40);
            this.buttonDsaPrivateKey.Name = "buttonDsaPrivateKey";
            this.buttonDsaPrivateKey.Size = new System.Drawing.Size(74, 28);
            this.buttonDsaPrivateKey.TabIndex = 13;
            this.buttonDsaPrivateKey.Text = "...";
            this.buttonDsaPrivateKey.UseVisualStyleBackColor = true;
            this.buttonDsaPrivateKey.Click += new System.EventHandler(this.buttonDsaPrivateKey_Click);
            // 
            // labelUbiosVersion
            // 
            this.labelUbiosVersion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelUbiosVersion.AutoSize = true;
            this.labelUbiosVersion.Location = new System.Drawing.Point(59, 100);
            this.labelUbiosVersion.Name = "labelUbiosVersion";
            this.labelUbiosVersion.Size = new System.Drawing.Size(88, 15);
            this.labelUbiosVersion.TabIndex = 9;
            this.labelUbiosVersion.Text = "UBIOS Version";
            // 
            // textBoxUbiosVersion
            // 
            this.textBoxUbiosVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUbiosVersion.Enabled = false;
            this.textBoxUbiosVersion.Location = new System.Drawing.Point(153, 96);
            this.textBoxUbiosVersion.Name = "textBoxUbiosVersion";
            this.textBoxUbiosVersion.Size = new System.Drawing.Size(171, 23);
            this.textBoxUbiosVersion.TabIndex = 10;
            // 
            // labelUbiosPublicKey
            // 
            this.labelUbiosPublicKey.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelUbiosPublicKey.AutoSize = true;
            this.labelUbiosPublicKey.Location = new System.Drawing.Point(44, 143);
            this.labelUbiosPublicKey.Name = "labelUbiosPublicKey";
            this.labelUbiosPublicKey.Size = new System.Drawing.Size(103, 15);
            this.labelUbiosPublicKey.TabIndex = 14;
            this.labelUbiosPublicKey.Text = "UBIOS Public Key";
            // 
            // textBoxUbiosPublicKey
            // 
            this.textBoxUbiosPublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUbiosPublicKey.Enabled = false;
            this.textBoxUbiosPublicKey.Location = new System.Drawing.Point(153, 139);
            this.textBoxUbiosPublicKey.Name = "textBoxUbiosPublicKey";
            this.textBoxUbiosPublicKey.Size = new System.Drawing.Size(171, 23);
            this.textBoxUbiosPublicKey.TabIndex = 15;
            // 
            // buttonUbiosPublicKey
            // 
            this.buttonUbiosPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUbiosPublicKey.Enabled = false;
            this.buttonUbiosPublicKey.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUbiosPublicKey.Location = new System.Drawing.Point(330, 132);
            this.buttonUbiosPublicKey.Name = "buttonUbiosPublicKey";
            this.buttonUbiosPublicKey.Size = new System.Drawing.Size(74, 37);
            this.buttonUbiosPublicKey.TabIndex = 16;
            this.buttonUbiosPublicKey.Text = "...";
            this.buttonUbiosPublicKey.UseVisualStyleBackColor = true;
            this.buttonUbiosPublicKey.Click += new System.EventHandler(this.buttonUbiosPublicKey_Click);
            // 
            // labelBootLoaderPublicKey
            // 
            this.labelBootLoaderPublicKey.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelBootLoaderPublicKey.AutoSize = true;
            this.labelBootLoaderPublicKey.Location = new System.Drawing.Point(10, 230);
            this.labelBootLoaderPublicKey.Name = "labelBootLoaderPublicKey";
            this.labelBootLoaderPublicKey.Size = new System.Drawing.Size(137, 15);
            this.labelBootLoaderPublicKey.TabIndex = 20;
            this.labelBootLoaderPublicKey.Text = "Boot Loader Public Key";
            // 
            // textBoxBootLoaderPublicKey
            // 
            this.textBoxBootLoaderPublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBootLoaderPublicKey.Enabled = false;
            this.textBoxBootLoaderPublicKey.Location = new System.Drawing.Point(153, 226);
            this.textBoxBootLoaderPublicKey.Name = "textBoxBootLoaderPublicKey";
            this.textBoxBootLoaderPublicKey.Size = new System.Drawing.Size(171, 23);
            this.textBoxBootLoaderPublicKey.TabIndex = 21;
            // 
            // buttonBootLoaderPublicKey
            // 
            this.buttonBootLoaderPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBootLoaderPublicKey.Enabled = false;
            this.buttonBootLoaderPublicKey.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBootLoaderPublicKey.Location = new System.Drawing.Point(330, 218);
            this.buttonBootLoaderPublicKey.Name = "buttonBootLoaderPublicKey";
            this.buttonBootLoaderPublicKey.Size = new System.Drawing.Size(74, 39);
            this.buttonBootLoaderPublicKey.TabIndex = 22;
            this.buttonBootLoaderPublicKey.Text = "...";
            this.buttonBootLoaderPublicKey.UseVisualStyleBackColor = true;
            this.buttonBootLoaderPublicKey.Click += new System.EventHandler(this.buttonBootLoaderPublicKey_Click);
            // 
            // labelHashList
            // 
            this.labelHashList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelHashList.AutoSize = true;
            this.labelHashList.Location = new System.Drawing.Point(15, 7);
            this.labelHashList.Name = "labelHashList";
            this.labelHashList.Size = new System.Drawing.Size(56, 15);
            this.labelHashList.TabIndex = 0;
            this.labelHashList.Text = "Hash List";
            // 
            // listBoxHash
            // 
            this.listBoxHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxHash.Enabled = false;
            this.listBoxHash.FormattingEnabled = true;
            this.listBoxHash.ItemHeight = 15;
            this.listBoxHash.Location = new System.Drawing.Point(83, 3);
            this.listBoxHash.Name = "listBoxHash";
            this.listBoxHash.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxHash.Size = new System.Drawing.Size(253, 254);
            this.listBoxHash.TabIndex = 0;
            // 
            // buttonHashAdd
            // 
            this.buttonHashAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHashAdd.Enabled = false;
            this.buttonHashAdd.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonHashAdd.Location = new System.Drawing.Point(3, 33);
            this.buttonHashAdd.Name = "buttonHashAdd";
            this.buttonHashAdd.Size = new System.Drawing.Size(68, 106);
            this.buttonHashAdd.TabIndex = 0;
            this.buttonHashAdd.Text = "+";
            this.buttonHashAdd.UseVisualStyleBackColor = true;
            this.buttonHashAdd.Click += new System.EventHandler(this.buttonHashAdd_Click);
            // 
            // buttonHashRemove
            // 
            this.buttonHashRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHashRemove.Enabled = false;
            this.buttonHashRemove.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonHashRemove.Location = new System.Drawing.Point(3, 145);
            this.buttonHashRemove.Name = "buttonHashRemove";
            this.buttonHashRemove.Size = new System.Drawing.Size(68, 106);
            this.buttonHashRemove.TabIndex = 1;
            this.buttonHashRemove.Text = "-";
            this.buttonHashRemove.UseVisualStyleBackColor = true;
            this.buttonHashRemove.Click += new System.EventHandler(this.buttonHashRemove_Click);
            // 
            // labelOutputImageBios
            // 
            this.labelOutputImageBios.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelOutputImageBios.AutoSize = true;
            this.labelOutputImageBios.Location = new System.Drawing.Point(61, 57);
            this.labelOutputImageBios.Name = "labelOutputImageBios";
            this.labelOutputImageBios.Size = new System.Drawing.Size(86, 15);
            this.labelOutputImageBios.TabIndex = 6;
            this.labelOutputImageBios.Text = "Output Image";
            // 
            // buttonOutputImageBios
            // 
            this.buttonOutputImageBios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOutputImageBios.Enabled = false;
            this.buttonOutputImageBios.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonOutputImageBios.Location = new System.Drawing.Point(330, 46);
            this.buttonOutputImageBios.Name = "buttonOutputImageBios";
            this.buttonOutputImageBios.Size = new System.Drawing.Size(74, 37);
            this.buttonOutputImageBios.TabIndex = 8;
            this.buttonOutputImageBios.Text = "...";
            this.buttonOutputImageBios.UseVisualStyleBackColor = true;
            // 
            // textBoxOutputImageBios
            // 
            this.textBoxOutputImageBios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputImageBios.Enabled = false;
            this.textBoxOutputImageBios.Location = new System.Drawing.Point(153, 53);
            this.textBoxOutputImageBios.Name = "textBoxOutputImageBios";
            this.textBoxOutputImageBios.Size = new System.Drawing.Size(171, 23);
            this.textBoxOutputImageBios.TabIndex = 7;
            // 
            // buttonSignBios
            // 
            this.buttonSignBios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSignBios.Enabled = false;
            this.buttonSignBios.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSignBios.Location = new System.Drawing.Point(3, 275);
            this.buttonSignBios.Name = "buttonSignBios";
            this.buttonSignBios.Size = new System.Drawing.Size(758, 63);
            this.buttonSignBios.TabIndex = 0;
            this.buttonSignBios.Text = "Sign";
            this.buttonSignBios.UseVisualStyleBackColor = true;
            this.buttonSignBios.Click += new System.EventHandler(this.buttonSignBios_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSignBios, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 341);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.53745F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.46255F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(758, 266);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.Controls.Add(this.labelImageBios, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonOutputImageBios, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelOutputImageBios, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxOutputImageBios, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonBootLoaderPublicKey, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.textBoxBootLoaderPublicKey, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.labelBootLoaderPublicKey, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.buttonImageBios, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxImageBios, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelUbiosVersion, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.textBoxUbiosVersion, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelUbiosPublicKey, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.textBoxUbiosPublicKey, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.buttonUbiosPublicKey, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.textBoxUbcPublicKey, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.buttonUbcPublicKey, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.labelUbcPublicKey, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(407, 260);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // textBoxUbcPublicKey
            // 
            this.textBoxUbcPublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUbcPublicKey.Enabled = false;
            this.textBoxUbcPublicKey.Location = new System.Drawing.Point(153, 182);
            this.textBoxUbcPublicKey.Name = "textBoxUbcPublicKey";
            this.textBoxUbcPublicKey.Size = new System.Drawing.Size(171, 23);
            this.textBoxUbcPublicKey.TabIndex = 18;
            // 
            // buttonUbcPublicKey
            // 
            this.buttonUbcPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUbcPublicKey.Enabled = false;
            this.buttonUbcPublicKey.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUbcPublicKey.Location = new System.Drawing.Point(330, 175);
            this.buttonUbcPublicKey.Name = "buttonUbcPublicKey";
            this.buttonUbcPublicKey.Size = new System.Drawing.Size(74, 37);
            this.buttonUbcPublicKey.TabIndex = 19;
            this.buttonUbcPublicKey.Text = "...";
            this.buttonUbcPublicKey.UseVisualStyleBackColor = true;
            this.buttonUbcPublicKey.Click += new System.EventHandler(this.buttonUbcPublicKey_Click);
            // 
            // labelUbcPublicKey
            // 
            this.labelUbcPublicKey.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelUbcPublicKey.AutoSize = true;
            this.labelUbcPublicKey.Location = new System.Drawing.Point(56, 186);
            this.labelUbcPublicKey.Name = "labelUbcPublicKey";
            this.labelUbcPublicKey.Size = new System.Drawing.Size(91, 15);
            this.labelUbcPublicKey.TabIndex = 17;
            this.labelUbcPublicKey.Text = "UBC Public Key";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.listBoxHash, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(416, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(339, 260);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.labelHashList, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonHashRemove, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.buttonHashAdd, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(74, 254);
            this.tableLayoutPanel5.TabIndex = 20;
            // 
            // tabControlSign
            // 
            this.tabControlSign.Controls.Add(this.tabPageBios);
            this.tabControlSign.Controls.Add(this.tabPageDisk);
            this.tabControlSign.Controls.Add(this.tabPageUbc);
            this.tabControlSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSign.Location = new System.Drawing.Point(3, 83);
            this.tabControlSign.Name = "tabControlSign";
            this.tabControlSign.SelectedIndex = 0;
            this.tabControlSign.Size = new System.Drawing.Size(778, 375);
            this.tabControlSign.TabIndex = 28;
            this.tabControlSign.Tag = "";
            // 
            // tabPageBios
            // 
            this.tabPageBios.Controls.Add(this.tableLayoutPanel1);
            this.tabPageBios.Location = new System.Drawing.Point(4, 24);
            this.tabPageBios.Name = "tabPageBios";
            this.tabPageBios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBios.Size = new System.Drawing.Size(770, 347);
            this.tabPageBios.TabIndex = 0;
            this.tabPageBios.Text = "BIOS";
            this.tabPageBios.UseVisualStyleBackColor = true;
            // 
            // tabPageDisk
            // 
            this.tabPageDisk.Controls.Add(this.tableLayoutPanel8);
            this.tabPageDisk.Location = new System.Drawing.Point(4, 24);
            this.tabPageDisk.Name = "tabPageDisk";
            this.tabPageDisk.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDisk.Size = new System.Drawing.Size(770, 347);
            this.tabPageDisk.TabIndex = 1;
            this.tabPageDisk.Text = "Disk";
            this.tabPageDisk.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.buttonSignDisk, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(764, 341);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel9.Controls.Add(this.labelImageDisk, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.textBoxImageDisk, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.buttonImageDisk, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.labelOutputImageDisk, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.textBoxOutputImageDisk, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.buttonOutputImageDisk, 2, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(758, 84);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // labelImageDisk
            // 
            this.labelImageDisk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelImageDisk.AutoSize = true;
            this.labelImageDisk.Location = new System.Drawing.Point(48, 12);
            this.labelImageDisk.Name = "labelImageDisk";
            this.labelImageDisk.Size = new System.Drawing.Size(69, 15);
            this.labelImageDisk.TabIndex = 0;
            this.labelImageDisk.Text = "Disk Image";
            // 
            // textBoxImageDisk
            // 
            this.textBoxImageDisk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxImageDisk.Location = new System.Drawing.Point(123, 8);
            this.textBoxImageDisk.Name = "textBoxImageDisk";
            this.textBoxImageDisk.Size = new System.Drawing.Size(552, 23);
            this.textBoxImageDisk.TabIndex = 1;
            this.textBoxImageDisk.TextChanged += new System.EventHandler(this.textBoxImageDisk_TextChanged);
            // 
            // buttonImageDisk
            // 
            this.buttonImageDisk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonImageDisk.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonImageDisk.Location = new System.Drawing.Point(681, 3);
            this.buttonImageDisk.Name = "buttonImageDisk";
            this.buttonImageDisk.Size = new System.Drawing.Size(74, 34);
            this.buttonImageDisk.TabIndex = 2;
            this.buttonImageDisk.Text = "...";
            this.buttonImageDisk.UseVisualStyleBackColor = true;
            this.buttonImageDisk.Click += new System.EventHandler(this.buttonImageDisk_Click);
            // 
            // labelOutputImageDisk
            // 
            this.labelOutputImageDisk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelOutputImageDisk.AutoSize = true;
            this.labelOutputImageDisk.Location = new System.Drawing.Point(31, 54);
            this.labelOutputImageDisk.Name = "labelOutputImageDisk";
            this.labelOutputImageDisk.Size = new System.Drawing.Size(86, 15);
            this.labelOutputImageDisk.TabIndex = 3;
            this.labelOutputImageDisk.Text = "Output Image";
            // 
            // textBoxOutputImageDisk
            // 
            this.textBoxOutputImageDisk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputImageDisk.Location = new System.Drawing.Point(123, 50);
            this.textBoxOutputImageDisk.Name = "textBoxOutputImageDisk";
            this.textBoxOutputImageDisk.Size = new System.Drawing.Size(552, 23);
            this.textBoxOutputImageDisk.TabIndex = 4;
            // 
            // buttonOutputImageDisk
            // 
            this.buttonOutputImageDisk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOutputImageDisk.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonOutputImageDisk.Location = new System.Drawing.Point(681, 43);
            this.buttonOutputImageDisk.Name = "buttonOutputImageDisk";
            this.buttonOutputImageDisk.Size = new System.Drawing.Size(74, 38);
            this.buttonOutputImageDisk.TabIndex = 5;
            this.buttonOutputImageDisk.Text = "...";
            this.buttonOutputImageDisk.UseVisualStyleBackColor = true;
            this.buttonOutputImageDisk.Click += new System.EventHandler(this.buttonOutputImageDisk_Click);
            // 
            // buttonSignDisk
            // 
            this.buttonSignDisk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSignDisk.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSignDisk.Location = new System.Drawing.Point(3, 93);
            this.buttonSignDisk.Name = "buttonSignDisk";
            this.buttonSignDisk.Size = new System.Drawing.Size(758, 245);
            this.buttonSignDisk.TabIndex = 1;
            this.buttonSignDisk.Text = "Sign";
            this.buttonSignDisk.UseVisualStyleBackColor = true;
            this.buttonSignDisk.Click += new System.EventHandler(this.buttonSignDisk_Click);
            // 
            // tabPageUbc
            // 
            this.tabPageUbc.Controls.Add(this.tableLayoutPanel10);
            this.tabPageUbc.Location = new System.Drawing.Point(4, 24);
            this.tabPageUbc.Name = "tabPageUbc";
            this.tabPageUbc.Size = new System.Drawing.Size(770, 347);
            this.tabPageUbc.TabIndex = 2;
            this.tabPageUbc.Text = "UBC";
            this.tabPageUbc.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.buttonSignUbc, 0, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(770, 347);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 3;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel11.Controls.Add(this.labelImageUbc, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.textBoxImageUbc, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.buttonImageUbc, 2, 0);
            this.tableLayoutPanel11.Controls.Add(this.labelOutputImageUbc, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.textBoxOutputImageUbc, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.buttonOutputImageUbc, 2, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(764, 84);
            this.tableLayoutPanel11.TabIndex = 0;
            // 
            // labelImageUbc
            // 
            this.labelImageUbc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelImageUbc.AutoSize = true;
            this.labelImageUbc.Location = new System.Drawing.Point(47, 12);
            this.labelImageUbc.Name = "labelImageUbc";
            this.labelImageUbc.Size = new System.Drawing.Size(70, 15);
            this.labelImageUbc.TabIndex = 0;
            this.labelImageUbc.Text = "UBC Image";
            // 
            // textBoxImageUbc
            // 
            this.textBoxImageUbc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxImageUbc.Location = new System.Drawing.Point(123, 8);
            this.textBoxImageUbc.Name = "textBoxImageUbc";
            this.textBoxImageUbc.Size = new System.Drawing.Size(558, 23);
            this.textBoxImageUbc.TabIndex = 1;
            this.textBoxImageUbc.TextChanged += new System.EventHandler(this.textBoxImageUbc_TextChanged);
            // 
            // buttonImageUbc
            // 
            this.buttonImageUbc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonImageUbc.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonImageUbc.Location = new System.Drawing.Point(687, 3);
            this.buttonImageUbc.Name = "buttonImageUbc";
            this.buttonImageUbc.Size = new System.Drawing.Size(74, 34);
            this.buttonImageUbc.TabIndex = 2;
            this.buttonImageUbc.Text = "...";
            this.buttonImageUbc.UseVisualStyleBackColor = true;
            this.buttonImageUbc.Click += new System.EventHandler(this.buttonImageUbc_Click);
            // 
            // labelOutputImageUbc
            // 
            this.labelOutputImageUbc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelOutputImageUbc.AutoSize = true;
            this.labelOutputImageUbc.Location = new System.Drawing.Point(31, 54);
            this.labelOutputImageUbc.Name = "labelOutputImageUbc";
            this.labelOutputImageUbc.Size = new System.Drawing.Size(86, 15);
            this.labelOutputImageUbc.TabIndex = 3;
            this.labelOutputImageUbc.Text = "Output Image";
            // 
            // textBoxOutputImageUbc
            // 
            this.textBoxOutputImageUbc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputImageUbc.Location = new System.Drawing.Point(123, 50);
            this.textBoxOutputImageUbc.Name = "textBoxOutputImageUbc";
            this.textBoxOutputImageUbc.Size = new System.Drawing.Size(558, 23);
            this.textBoxOutputImageUbc.TabIndex = 4;
            // 
            // buttonOutputImageUbc
            // 
            this.buttonOutputImageUbc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOutputImageUbc.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonOutputImageUbc.Location = new System.Drawing.Point(687, 43);
            this.buttonOutputImageUbc.Name = "buttonOutputImageUbc";
            this.buttonOutputImageUbc.Size = new System.Drawing.Size(74, 38);
            this.buttonOutputImageUbc.TabIndex = 5;
            this.buttonOutputImageUbc.Text = "...";
            this.buttonOutputImageUbc.UseVisualStyleBackColor = true;
            this.buttonOutputImageUbc.Click += new System.EventHandler(this.buttonOutputImageUbc_Click);
            // 
            // buttonSignUbc
            // 
            this.buttonSignUbc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSignUbc.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSignUbc.Location = new System.Drawing.Point(3, 93);
            this.buttonSignUbc.Name = "buttonSignUbc";
            this.buttonSignUbc.Size = new System.Drawing.Size(764, 251);
            this.buttonSignUbc.TabIndex = 1;
            this.buttonSignUbc.Text = "Sign";
            this.buttonSignUbc.UseVisualStyleBackColor = true;
            this.buttonSignUbc.Click += new System.EventHandler(this.buttonSignUbc_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.tabControlSign, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(784, 461);
            this.tableLayoutPanel6.TabIndex = 29;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel7.Controls.Add(this.labelWorkingFolder, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.comboBoxWorkingFolder, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.buttonWorkingFolder, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.labelDsaPrivateKey, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.textBoxDsaPrivateKey, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.buttonDsaPrivateKey, 2, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(778, 74);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tabControlSign.ResumeLayout(false);
            this.tabPageBios.ResumeLayout(false);
            this.tabPageDisk.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tabPageUbc.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private ToolTip toolTip1;
        private OpenFileDialog openFileDialog1;
        private Label labelWorkingFolder;
        private ComboBox comboBoxWorkingFolder;
        private Button buttonWorkingFolder;
        private Label labelImageBios;
        private TextBox textBoxImageBios;
        private Button buttonImageBios;
        private Label labelDsaPrivateKey;
        private TextBox textBoxDsaPrivateKey;
        private Button buttonDsaPrivateKey;
        private Label labelUbiosVersion;
        private TextBox textBoxUbiosVersion;
        private Label labelUbiosPublicKey;
        private TextBox textBoxUbiosPublicKey;
        private Button buttonUbiosPublicKey;
        private Label labelBootLoaderPublicKey;
        private TextBox textBoxBootLoaderPublicKey;
        private Button buttonBootLoaderPublicKey;
        private Label labelHashList;
        private ListBox listBoxHash;
        private Button buttonHashAdd;
        private Button buttonHashRemove;
        private Label labelOutputImageBios;
        private Button buttonOutputImageBios;
        private TextBox textBoxOutputImageBios;
        private Button buttonSignBios;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private TextBox textBoxUbcPublicKey;
        private Button buttonUbcPublicKey;
        private Label labelUbcPublicKey;
        private TabControl tabControlSign;
        private TabPage tabPageBios;
        private TabPage tabPageDisk;
        private TabPage tabPageUbc;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel10;
        private TableLayoutPanel tableLayoutPanel11;
        private Label labelImageUbc;
        private TextBox textBoxImageUbc;
        private Button buttonImageUbc;
        private Label labelOutputImageUbc;
        private TextBox textBoxOutputImageUbc;
        private Button buttonOutputImageUbc;
        private Button buttonSignUbc;
        private TableLayoutPanel tableLayoutPanel8;
        private TableLayoutPanel tableLayoutPanel9;
        private Label labelImageDisk;
        private TextBox textBoxImageDisk;
        private Button buttonImageDisk;
        private Label labelOutputImageDisk;
        private TextBox textBoxOutputImageDisk;
        private Button buttonOutputImageDisk;
        private Button buttonSignDisk;
    }
}