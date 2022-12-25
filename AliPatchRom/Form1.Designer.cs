namespace AliPatchRom
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
            this.labelRomImage = new System.Windows.Forms.Label();
            this.textBoxInputImage = new System.Windows.Forms.TextBox();
            this.buttonRomImage = new System.Windows.Forms.Button();
            this.labelPrivateKey = new System.Windows.Forms.Label();
            this.textBoxPrivateKey = new System.Windows.Forms.TextBox();
            this.buttonPrivateKey = new System.Windows.Forms.Button();
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOutputImage = new System.Windows.Forms.Button();
            this.textBoxOutputImage = new System.Windows.Forms.TextBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxUbcPublicKey = new System.Windows.Forms.TextBox();
            this.buttonUbcPublicKey = new System.Windows.Forms.Button();
            this.labelUbcPublicKey = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
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
            this.labelWorkingFolder.Location = new System.Drawing.Point(53, 17);
            this.labelWorkingFolder.Name = "labelWorkingFolder";
            this.labelWorkingFolder.Size = new System.Drawing.Size(94, 15);
            this.labelWorkingFolder.TabIndex = 0;
            this.labelWorkingFolder.Text = "Working Folder";
            // 
            // comboBoxWorkingFolder
            // 
            this.comboBoxWorkingFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWorkingFolder.FormattingEnabled = true;
            this.comboBoxWorkingFolder.Location = new System.Drawing.Point(153, 13);
            this.comboBoxWorkingFolder.Name = "comboBoxWorkingFolder";
            this.comboBoxWorkingFolder.Size = new System.Drawing.Size(215, 23);
            this.comboBoxWorkingFolder.TabIndex = 1;
            // 
            // buttonWorkingFolder
            // 
            this.buttonWorkingFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonWorkingFolder.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonWorkingFolder.Location = new System.Drawing.Point(374, 3);
            this.buttonWorkingFolder.Name = "buttonWorkingFolder";
            this.buttonWorkingFolder.Size = new System.Drawing.Size(74, 44);
            this.buttonWorkingFolder.TabIndex = 2;
            this.buttonWorkingFolder.Text = "...";
            this.buttonWorkingFolder.UseVisualStyleBackColor = true;
            this.buttonWorkingFolder.Click += new System.EventHandler(this.buttonWorkingFolder_Click);
            // 
            // labelRomImage
            // 
            this.labelRomImage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelRomImage.AutoSize = true;
            this.labelRomImage.Location = new System.Drawing.Point(72, 67);
            this.labelRomImage.Name = "labelRomImage";
            this.labelRomImage.Size = new System.Drawing.Size(75, 15);
            this.labelRomImage.TabIndex = 3;
            this.labelRomImage.Text = "Input Image";
            // 
            // textBoxInputImage
            // 
            this.textBoxInputImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInputImage.Location = new System.Drawing.Point(153, 63);
            this.textBoxInputImage.Name = "textBoxInputImage";
            this.textBoxInputImage.Size = new System.Drawing.Size(215, 23);
            this.textBoxInputImage.TabIndex = 4;
            this.textBoxInputImage.TextChanged += new System.EventHandler(this.textBoxInputImage_TextChanged);
            // 
            // buttonRomImage
            // 
            this.buttonRomImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRomImage.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRomImage.Location = new System.Drawing.Point(374, 53);
            this.buttonRomImage.Name = "buttonRomImage";
            this.buttonRomImage.Size = new System.Drawing.Size(74, 44);
            this.buttonRomImage.TabIndex = 5;
            this.buttonRomImage.Text = "...";
            this.buttonRomImage.UseVisualStyleBackColor = true;
            this.buttonRomImage.Click += new System.EventHandler(this.buttonRomImage_Click);
            // 
            // labelPrivateKey
            // 
            this.labelPrivateKey.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPrivateKey.AutoSize = true;
            this.labelPrivateKey.Location = new System.Drawing.Point(79, 217);
            this.labelPrivateKey.Name = "labelPrivateKey";
            this.labelPrivateKey.Size = new System.Drawing.Size(68, 15);
            this.labelPrivateKey.TabIndex = 11;
            this.labelPrivateKey.Text = "Private Key";
            // 
            // textBoxPrivateKey
            // 
            this.textBoxPrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrivateKey.Enabled = false;
            this.textBoxPrivateKey.Location = new System.Drawing.Point(153, 213);
            this.textBoxPrivateKey.Name = "textBoxPrivateKey";
            this.textBoxPrivateKey.Size = new System.Drawing.Size(215, 23);
            this.textBoxPrivateKey.TabIndex = 12;
            // 
            // buttonPrivateKey
            // 
            this.buttonPrivateKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrivateKey.Enabled = false;
            this.buttonPrivateKey.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPrivateKey.Location = new System.Drawing.Point(374, 203);
            this.buttonPrivateKey.Name = "buttonPrivateKey";
            this.buttonPrivateKey.Size = new System.Drawing.Size(74, 44);
            this.buttonPrivateKey.TabIndex = 13;
            this.buttonPrivateKey.Text = "...";
            this.buttonPrivateKey.UseVisualStyleBackColor = true;
            this.buttonPrivateKey.Click += new System.EventHandler(this.buttonPrivateKey_Click);
            // 
            // labelUbiosVersion
            // 
            this.labelUbiosVersion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelUbiosVersion.AutoSize = true;
            this.labelUbiosVersion.Location = new System.Drawing.Point(59, 167);
            this.labelUbiosVersion.Name = "labelUbiosVersion";
            this.labelUbiosVersion.Size = new System.Drawing.Size(88, 15);
            this.labelUbiosVersion.TabIndex = 9;
            this.labelUbiosVersion.Text = "UBIOS Version";
            // 
            // textBoxUbiosVersion
            // 
            this.textBoxUbiosVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUbiosVersion.Enabled = false;
            this.textBoxUbiosVersion.Location = new System.Drawing.Point(153, 163);
            this.textBoxUbiosVersion.Name = "textBoxUbiosVersion";
            this.textBoxUbiosVersion.Size = new System.Drawing.Size(215, 23);
            this.textBoxUbiosVersion.TabIndex = 10;
            // 
            // labelUbiosPublicKey
            // 
            this.labelUbiosPublicKey.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelUbiosPublicKey.AutoSize = true;
            this.labelUbiosPublicKey.Location = new System.Drawing.Point(44, 267);
            this.labelUbiosPublicKey.Name = "labelUbiosPublicKey";
            this.labelUbiosPublicKey.Size = new System.Drawing.Size(103, 15);
            this.labelUbiosPublicKey.TabIndex = 14;
            this.labelUbiosPublicKey.Text = "UBIOS Public Key";
            // 
            // textBoxUbiosPublicKey
            // 
            this.textBoxUbiosPublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUbiosPublicKey.Enabled = false;
            this.textBoxUbiosPublicKey.Location = new System.Drawing.Point(153, 263);
            this.textBoxUbiosPublicKey.Name = "textBoxUbiosPublicKey";
            this.textBoxUbiosPublicKey.Size = new System.Drawing.Size(215, 23);
            this.textBoxUbiosPublicKey.TabIndex = 15;
            // 
            // buttonUbiosPublicKey
            // 
            this.buttonUbiosPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUbiosPublicKey.Enabled = false;
            this.buttonUbiosPublicKey.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUbiosPublicKey.Location = new System.Drawing.Point(374, 253);
            this.buttonUbiosPublicKey.Name = "buttonUbiosPublicKey";
            this.buttonUbiosPublicKey.Size = new System.Drawing.Size(74, 44);
            this.buttonUbiosPublicKey.TabIndex = 16;
            this.buttonUbiosPublicKey.Text = "...";
            this.buttonUbiosPublicKey.UseVisualStyleBackColor = true;
            this.buttonUbiosPublicKey.Click += new System.EventHandler(this.buttonUbiosPublicKey_Click);
            // 
            // labelBootLoaderPublicKey
            // 
            this.labelBootLoaderPublicKey.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelBootLoaderPublicKey.AutoSize = true;
            this.labelBootLoaderPublicKey.Location = new System.Drawing.Point(10, 367);
            this.labelBootLoaderPublicKey.Name = "labelBootLoaderPublicKey";
            this.labelBootLoaderPublicKey.Size = new System.Drawing.Size(137, 15);
            this.labelBootLoaderPublicKey.TabIndex = 20;
            this.labelBootLoaderPublicKey.Text = "Boot Loader Public Key";
            // 
            // textBoxBootLoaderPublicKey
            // 
            this.textBoxBootLoaderPublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBootLoaderPublicKey.Enabled = false;
            this.textBoxBootLoaderPublicKey.Location = new System.Drawing.Point(153, 363);
            this.textBoxBootLoaderPublicKey.Name = "textBoxBootLoaderPublicKey";
            this.textBoxBootLoaderPublicKey.Size = new System.Drawing.Size(215, 23);
            this.textBoxBootLoaderPublicKey.TabIndex = 21;
            // 
            // buttonBootLoaderPublicKey
            // 
            this.buttonBootLoaderPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBootLoaderPublicKey.Enabled = false;
            this.buttonBootLoaderPublicKey.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBootLoaderPublicKey.Location = new System.Drawing.Point(374, 353);
            this.buttonBootLoaderPublicKey.Name = "buttonBootLoaderPublicKey";
            this.buttonBootLoaderPublicKey.Size = new System.Drawing.Size(74, 44);
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
            this.listBoxHash.Size = new System.Drawing.Size(289, 394);
            this.listBoxHash.TabIndex = 0;
            // 
            // buttonHashAdd
            // 
            this.buttonHashAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHashAdd.Enabled = false;
            this.buttonHashAdd.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonHashAdd.Location = new System.Drawing.Point(3, 33);
            this.buttonHashAdd.Name = "buttonHashAdd";
            this.buttonHashAdd.Size = new System.Drawing.Size(68, 176);
            this.buttonHashAdd.TabIndex = 0;
            this.buttonHashAdd.Text = "+";
            this.buttonHashAdd.UseVisualStyleBackColor = true;
            this.buttonHashAdd.Click += new System.EventHandler(this.buttonHashAdd_Click);
            // 
            // buttonHashRemove
            // 
            this.buttonHashRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHashRemove.Enabled = false;
            this.buttonHashRemove.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonHashRemove.Location = new System.Drawing.Point(3, 215);
            this.buttonHashRemove.Name = "buttonHashRemove";
            this.buttonHashRemove.Size = new System.Drawing.Size(68, 176);
            this.buttonHashRemove.TabIndex = 1;
            this.buttonHashRemove.Text = "-";
            this.buttonHashRemove.UseVisualStyleBackColor = true;
            this.buttonHashRemove.Click += new System.EventHandler(this.buttonHashRemove_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Output Image";
            // 
            // buttonOutputImage
            // 
            this.buttonOutputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOutputImage.Enabled = false;
            this.buttonOutputImage.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonOutputImage.Location = new System.Drawing.Point(374, 103);
            this.buttonOutputImage.Name = "buttonOutputImage";
            this.buttonOutputImage.Size = new System.Drawing.Size(74, 44);
            this.buttonOutputImage.TabIndex = 8;
            this.buttonOutputImage.Text = "...";
            this.buttonOutputImage.UseVisualStyleBackColor = true;
            // 
            // textBoxOutputImage
            // 
            this.textBoxOutputImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputImage.Enabled = false;
            this.textBoxOutputImage.Location = new System.Drawing.Point(153, 113);
            this.textBoxOutputImage.Name = "textBoxOutputImage";
            this.textBoxOutputImage.Size = new System.Drawing.Size(215, 23);
            this.textBoxOutputImage.TabIndex = 7;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGenerate.Enabled = false;
            this.buttonGenerate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGenerate.Location = new System.Drawing.Point(3, 415);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(838, 97);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonGenerate, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(844, 515);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(838, 406);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.Controls.Add(this.labelWorkingFolder, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelRomImage, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonOutputImage, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.textBoxOutputImage, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.buttonBootLoaderPublicKey, 2, 7);
            this.tableLayoutPanel3.Controls.Add(this.labelPrivateKey, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.buttonPrivateKey, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.textBoxBootLoaderPublicKey, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.labelBootLoaderPublicKey, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxWorkingFolder, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonRomImage, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonWorkingFolder, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxInputImage, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxPrivateKey, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.labelUbiosVersion, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.textBoxUbiosVersion, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelUbiosPublicKey, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.textBoxUbiosPublicKey, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.buttonUbiosPublicKey, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.textBoxUbcPublicKey, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.buttonUbcPublicKey, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.labelUbcPublicKey, 0, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(451, 400);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // textBoxUbcPublicKey
            // 
            this.textBoxUbcPublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUbcPublicKey.Enabled = false;
            this.textBoxUbcPublicKey.Location = new System.Drawing.Point(153, 313);
            this.textBoxUbcPublicKey.Name = "textBoxUbcPublicKey";
            this.textBoxUbcPublicKey.Size = new System.Drawing.Size(215, 23);
            this.textBoxUbcPublicKey.TabIndex = 18;
            // 
            // buttonUbcPublicKey
            // 
            this.buttonUbcPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUbcPublicKey.Enabled = false;
            this.buttonUbcPublicKey.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUbcPublicKey.Location = new System.Drawing.Point(374, 303);
            this.buttonUbcPublicKey.Name = "buttonUbcPublicKey";
            this.buttonUbcPublicKey.Size = new System.Drawing.Size(74, 44);
            this.buttonUbcPublicKey.TabIndex = 19;
            this.buttonUbcPublicKey.Text = "...";
            this.buttonUbcPublicKey.UseVisualStyleBackColor = true;
            this.buttonUbcPublicKey.Click += new System.EventHandler(this.buttonUbcPublicKey_Click);
            // 
            // labelUbcPublicKey
            // 
            this.labelUbcPublicKey.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelUbcPublicKey.AutoSize = true;
            this.labelUbcPublicKey.Location = new System.Drawing.Point(56, 317);
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(460, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(375, 400);
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
            this.tableLayoutPanel5.Size = new System.Drawing.Size(74, 394);
            this.tableLayoutPanel5.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 515);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(860, 400);
            this.Name = "Form1";
            this.Text = "ROM Image Patch 0.1 build 20221223";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private ToolTip toolTip1;
        private OpenFileDialog openFileDialog1;
        private Label labelWorkingFolder;
        private ComboBox comboBoxWorkingFolder;
        private Button buttonWorkingFolder;
        private Label labelRomImage;
        private TextBox textBoxInputImage;
        private Button buttonRomImage;
        private Label labelPrivateKey;
        private TextBox textBoxPrivateKey;
        private Button buttonPrivateKey;
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
        private Label label1;
        private Button buttonOutputImage;
        private TextBox textBoxOutputImage;
        private Button buttonGenerate;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private TextBox textBoxUbcPublicKey;
        private Button buttonUbcPublicKey;
        private Label labelUbcPublicKey;
    }
}