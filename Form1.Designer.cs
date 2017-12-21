namespace Disservice
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonLoadServices = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.comboBoxNEName = new System.Windows.Forms.ComboBox();
            this.listBoxSlotPort = new System.Windows.Forms.ListBox();
            this.buttonAddPort = new System.Windows.Forms.Button();
            this.buttonAddAllPorts = new System.Windows.Forms.Button();
            this.listBoxBrokenPorts = new System.Windows.Forms.ListBox();
            this.buttonRemoveAllPorts = new System.Windows.Forms.Button();
            this.buttonRemovePort = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonSaveDB = new System.Windows.Forms.Button();
            this.buttonLoadDB = new System.Windows.Forms.Button();
            this.buttonCalc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControlTable = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonAddService4GBroken = new System.Windows.Forms.Button();
            this.buttonAddService3GBroken = new System.Windows.Forms.Button();
            this.buttonAddService2GBroken = new System.Windows.Forms.Button();
            this.buttonAddServiceInterBroken = new System.Windows.Forms.Button();
            this.buttonAddServiceFixBroken = new System.Windows.Forms.Button();
            this.richTextBoxBrokenExternal = new System.Windows.Forms.RichTextBox();
            this.buttonLoadFilter = new System.Windows.Forms.Button();
            this.buttonSaveFilter = new System.Windows.Forms.Button();
            this.labelBrokenMobile = new System.Windows.Forms.Label();
            this.labelBrokenInter = new System.Windows.Forms.Label();
            this.labelBrokenFix = new System.Windows.Forms.Label();
            this.textBoxBrokenInter = new System.Windows.Forms.TextBox();
            this.textBoxBrokenBS = new System.Windows.Forms.TextBox();
            this.textBoxBrokenFix = new System.Windows.Forms.TextBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.listBoxBrokenInter = new System.Windows.Forms.ListBox();
            this.listBoxBrokenBS = new System.Windows.Forms.ListBox();
            this.listBoxBrokenFix = new System.Windows.Forms.ListBox();
            this.listBoxBrokenService = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labelDamagedMobile = new System.Windows.Forms.Label();
            this.buttonAddService4GDamaged = new System.Windows.Forms.Button();
            this.buttonAddService3GDamaged = new System.Windows.Forms.Button();
            this.buttonAddService2GDamaged = new System.Windows.Forms.Button();
            this.buttonAddServiceInterDamaged = new System.Windows.Forms.Button();
            this.buttonAddServiceFixDamaged = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelDamagedInter = new System.Windows.Forms.Label();
            this.labelDamagedFix = new System.Windows.Forms.Label();
            this.listBoxDamagedInter = new System.Windows.Forms.ListBox();
            this.listBoxDamagedBS = new System.Windows.Forms.ListBox();
            this.listBoxDamagedFix = new System.Windows.Forms.ListBox();
            this.richTextBoxDamagedExternal = new System.Windows.Forms.RichTextBox();
            this.listBoxDamagedService = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxDamagedVPLS = new System.Windows.Forms.ListBox();
            this.listBoxBrokenVPLS = new System.Windows.Forms.ListBox();
            this.buttonCalculateVPLS = new System.Windows.Forms.Button();
            this.richTextBoxVPLS = new System.Windows.Forms.RichTextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tabControlTable.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonLoadServices
            // 
            this.buttonLoadServices.Location = new System.Drawing.Point(11, 8);
            this.buttonLoadServices.Name = "buttonLoadServices";
            this.buttonLoadServices.Size = new System.Drawing.Size(94, 23);
            this.buttonLoadServices.TabIndex = 1;
            this.buttonLoadServices.Text = "Load services";
            this.buttonLoadServices.UseVisualStyleBackColor = true;
            this.buttonLoadServices.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tunnels: 0 PG: 0 ETH: 0 CES: 0";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(11, 260);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(792, 202);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // comboBoxNEName
            // 
            this.comboBoxNEName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxNEName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxNEName.FormattingEnabled = true;
            this.comboBoxNEName.Location = new System.Drawing.Point(12, 52);
            this.comboBoxNEName.Name = "comboBoxNEName";
            this.comboBoxNEName.Size = new System.Drawing.Size(159, 21);
            this.comboBoxNEName.TabIndex = 6;
            this.comboBoxNEName.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listBoxSlotPort
            // 
            this.listBoxSlotPort.FormattingEnabled = true;
            this.listBoxSlotPort.Location = new System.Drawing.Point(177, 52);
            this.listBoxSlotPort.Name = "listBoxSlotPort";
            this.listBoxSlotPort.Size = new System.Drawing.Size(132, 173);
            this.listBoxSlotPort.TabIndex = 7;
            // 
            // buttonAddPort
            // 
            this.buttonAddPort.Location = new System.Drawing.Point(315, 83);
            this.buttonAddPort.Name = "buttonAddPort";
            this.buttonAddPort.Size = new System.Drawing.Size(38, 23);
            this.buttonAddPort.TabIndex = 8;
            this.buttonAddPort.Text = ">";
            this.buttonAddPort.UseVisualStyleBackColor = true;
            this.buttonAddPort.Click += new System.EventHandler(this.buttonAddPort_Click);
            // 
            // buttonAddAllPorts
            // 
            this.buttonAddAllPorts.Location = new System.Drawing.Point(315, 112);
            this.buttonAddAllPorts.Name = "buttonAddAllPorts";
            this.buttonAddAllPorts.Size = new System.Drawing.Size(38, 23);
            this.buttonAddAllPorts.TabIndex = 9;
            this.buttonAddAllPorts.Text = ">>";
            this.buttonAddAllPorts.UseVisualStyleBackColor = true;
            this.buttonAddAllPorts.Click += new System.EventHandler(this.buttonAddAllPorts_Click);
            // 
            // listBoxBrokenPorts
            // 
            this.listBoxBrokenPorts.FormattingEnabled = true;
            this.listBoxBrokenPorts.Location = new System.Drawing.Point(359, 52);
            this.listBoxBrokenPorts.Name = "listBoxBrokenPorts";
            this.listBoxBrokenPorts.Size = new System.Drawing.Size(151, 173);
            this.listBoxBrokenPorts.TabIndex = 10;
            // 
            // buttonRemoveAllPorts
            // 
            this.buttonRemoveAllPorts.Location = new System.Drawing.Point(315, 170);
            this.buttonRemoveAllPorts.Name = "buttonRemoveAllPorts";
            this.buttonRemoveAllPorts.Size = new System.Drawing.Size(38, 23);
            this.buttonRemoveAllPorts.TabIndex = 12;
            this.buttonRemoveAllPorts.Text = "<<";
            this.buttonRemoveAllPorts.UseVisualStyleBackColor = true;
            this.buttonRemoveAllPorts.Click += new System.EventHandler(this.buttonRemoveAllPorts_Click);
            // 
            // buttonRemovePort
            // 
            this.buttonRemovePort.Location = new System.Drawing.Point(315, 141);
            this.buttonRemovePort.Name = "buttonRemovePort";
            this.buttonRemovePort.Size = new System.Drawing.Size(38, 23);
            this.buttonRemovePort.TabIndex = 11;
            this.buttonRemovePort.Text = "<";
            this.buttonRemovePort.UseVisualStyleBackColor = true;
            this.buttonRemovePort.Click += new System.EventHandler(this.buttonRemovePort_Click);
            // 
            // buttonSaveDB
            // 
            this.buttonSaveDB.Location = new System.Drawing.Point(111, 8);
            this.buttonSaveDB.Name = "buttonSaveDB";
            this.buttonSaveDB.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveDB.TabIndex = 13;
            this.buttonSaveDB.Text = "Save DB";
            this.buttonSaveDB.UseVisualStyleBackColor = true;
            this.buttonSaveDB.Click += new System.EventHandler(this.buttonSaveDB_Click);
            // 
            // buttonLoadDB
            // 
            this.buttonLoadDB.Location = new System.Drawing.Point(192, 8);
            this.buttonLoadDB.Name = "buttonLoadDB";
            this.buttonLoadDB.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadDB.TabIndex = 14;
            this.buttonLoadDB.Text = "Load DB";
            this.buttonLoadDB.UseVisualStyleBackColor = true;
            this.buttonLoadDB.Click += new System.EventHandler(this.buttonLoadDB_Click);
            // 
            // buttonCalc
            // 
            this.buttonCalc.Location = new System.Drawing.Point(397, 231);
            this.buttonCalc.Name = "buttonCalc";
            this.buttonCalc.Size = new System.Drawing.Size(75, 23);
            this.buttonCalc.TabIndex = 15;
            this.buttonCalc.Text = "Calculate";
            this.buttonCalc.UseVisualStyleBackColor = true;
            this.buttonCalc.Click += new System.EventHandler(this.buttonCalc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "NE Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Broken ports";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "NE Slot/Port";
            this.label5.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "log";
            this.label6.Click += new System.EventHandler(this.label4_Click);
            // 
            // tabControlTable
            // 
            this.tabControlTable.Controls.Add(this.tabPage1);
            this.tabControlTable.Controls.Add(this.tabPage2);
            this.tabControlTable.Controls.Add(this.tabPage3);
            this.tabControlTable.Controls.Add(this.tabPage4);
            this.tabControlTable.Controls.Add(this.tabPage5);
            this.tabControlTable.Location = new System.Drawing.Point(-1, -1);
            this.tabControlTable.Name = "tabControlTable";
            this.tabControlTable.SelectedIndex = 0;
            this.tabControlTable.Size = new System.Drawing.Size(817, 500);
            this.tabControlTable.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonAddPort);
            this.tabPage1.Controls.Add(this.buttonLoadServices);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.richTextBox2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.comboBoxNEName);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.listBoxSlotPort);
            this.tabPage1.Controls.Add(this.buttonCalc);
            this.tabPage1.Controls.Add(this.buttonAddAllPorts);
            this.tabPage1.Controls.Add(this.buttonLoadDB);
            this.tabPage1.Controls.Add(this.listBoxBrokenPorts);
            this.tabPage1.Controls.Add(this.buttonSaveDB);
            this.tabPage1.Controls.Add(this.buttonRemovePort);
            this.tabPage1.Controls.Add(this.buttonRemoveAllPorts);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(809, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Get Service";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.buttonAddService4GBroken);
            this.tabPage2.Controls.Add(this.buttonAddService3GBroken);
            this.tabPage2.Controls.Add(this.buttonAddService2GBroken);
            this.tabPage2.Controls.Add(this.buttonAddServiceInterBroken);
            this.tabPage2.Controls.Add(this.buttonAddServiceFixBroken);
            this.tabPage2.Controls.Add(this.richTextBoxBrokenExternal);
            this.tabPage2.Controls.Add(this.buttonLoadFilter);
            this.tabPage2.Controls.Add(this.buttonSaveFilter);
            this.tabPage2.Controls.Add(this.labelBrokenMobile);
            this.tabPage2.Controls.Add(this.labelBrokenInter);
            this.tabPage2.Controls.Add(this.labelBrokenFix);
            this.tabPage2.Controls.Add(this.textBoxBrokenInter);
            this.tabPage2.Controls.Add(this.textBoxBrokenBS);
            this.tabPage2.Controls.Add(this.textBoxBrokenFix);
            this.tabPage2.Controls.Add(this.buttonExport);
            this.tabPage2.Controls.Add(this.buttonSort);
            this.tabPage2.Controls.Add(this.listBoxBrokenInter);
            this.tabPage2.Controls.Add(this.listBoxBrokenBS);
            this.tabPage2.Controls.Add(this.listBoxBrokenFix);
            this.tabPage2.Controls.Add(this.listBoxBrokenService);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(809, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Broken Service";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(309, 169);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Mobile";
            // 
            // buttonAddService4GBroken
            // 
            this.buttonAddService4GBroken.Location = new System.Drawing.Point(491, 172);
            this.buttonAddService4GBroken.Name = "buttonAddService4GBroken";
            this.buttonAddService4GBroken.Size = new System.Drawing.Size(45, 24);
            this.buttonAddService4GBroken.TabIndex = 8;
            this.buttonAddService4GBroken.Text = "4G ▼";
            this.buttonAddService4GBroken.UseVisualStyleBackColor = true;
            this.buttonAddService4GBroken.Click += new System.EventHandler(this.buttonAddService4G_Click);
            // 
            // buttonAddService3GBroken
            // 
            this.buttonAddService3GBroken.Location = new System.Drawing.Point(445, 172);
            this.buttonAddService3GBroken.Name = "buttonAddService3GBroken";
            this.buttonAddService3GBroken.Size = new System.Drawing.Size(45, 24);
            this.buttonAddService3GBroken.TabIndex = 8;
            this.buttonAddService3GBroken.Text = "3G ▼";
            this.buttonAddService3GBroken.UseVisualStyleBackColor = true;
            this.buttonAddService3GBroken.Click += new System.EventHandler(this.buttonAddService3G_Click);
            // 
            // buttonAddService2GBroken
            // 
            this.buttonAddService2GBroken.Location = new System.Drawing.Point(399, 172);
            this.buttonAddService2GBroken.Name = "buttonAddService2GBroken";
            this.buttonAddService2GBroken.Size = new System.Drawing.Size(45, 24);
            this.buttonAddService2GBroken.TabIndex = 8;
            this.buttonAddService2GBroken.Text = "2G ▼";
            this.buttonAddService2GBroken.UseVisualStyleBackColor = true;
            this.buttonAddService2GBroken.Click += new System.EventHandler(this.buttonAddService2G_Click);
            // 
            // buttonAddServiceInterBroken
            // 
            this.buttonAddServiceInterBroken.Location = new System.Drawing.Point(768, 172);
            this.buttonAddServiceInterBroken.Name = "buttonAddServiceInterBroken";
            this.buttonAddServiceInterBroken.Size = new System.Drawing.Size(28, 24);
            this.buttonAddServiceInterBroken.TabIndex = 8;
            this.buttonAddServiceInterBroken.Text = "▼";
            this.buttonAddServiceInterBroken.UseVisualStyleBackColor = true;
            this.buttonAddServiceInterBroken.Click += new System.EventHandler(this.buttonAddServiceInter_Click);
            // 
            // buttonAddServiceFixBroken
            // 
            this.buttonAddServiceFixBroken.Location = new System.Drawing.Point(228, 172);
            this.buttonAddServiceFixBroken.Name = "buttonAddServiceFixBroken";
            this.buttonAddServiceFixBroken.Size = new System.Drawing.Size(28, 24);
            this.buttonAddServiceFixBroken.TabIndex = 8;
            this.buttonAddServiceFixBroken.Text = "▼";
            this.buttonAddServiceFixBroken.UseVisualStyleBackColor = true;
            this.buttonAddServiceFixBroken.Click += new System.EventHandler(this.buttonAddFixSrv_Click);
            // 
            // richTextBoxBrokenExternal
            // 
            this.richTextBoxBrokenExternal.Location = new System.Drawing.Point(410, 6);
            this.richTextBoxBrokenExternal.Name = "richTextBoxBrokenExternal";
            this.richTextBoxBrokenExternal.Size = new System.Drawing.Size(386, 159);
            this.richTextBoxBrokenExternal.TabIndex = 7;
            this.richTextBoxBrokenExternal.Text = "";
            // 
            // buttonLoadFilter
            // 
            this.buttonLoadFilter.Location = new System.Drawing.Point(403, 446);
            this.buttonLoadFilter.Name = "buttonLoadFilter";
            this.buttonLoadFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadFilter.TabIndex = 6;
            this.buttonLoadFilter.Text = "Load Filter";
            this.buttonLoadFilter.UseVisualStyleBackColor = true;
            this.buttonLoadFilter.Click += new System.EventHandler(this.buttonLoadFilter_Click);
            // 
            // buttonSaveFilter
            // 
            this.buttonSaveFilter.Location = new System.Drawing.Point(322, 446);
            this.buttonSaveFilter.Name = "buttonSaveFilter";
            this.buttonSaveFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveFilter.TabIndex = 6;
            this.buttonSaveFilter.Text = "Save Filter";
            this.buttonSaveFilter.UseVisualStyleBackColor = true;
            this.buttonSaveFilter.Click += new System.EventHandler(this.buttonSaveFilter_Click);
            // 
            // labelBrokenMobile
            // 
            this.labelBrokenMobile.AutoSize = true;
            this.labelBrokenMobile.Location = new System.Drawing.Point(262, 183);
            this.labelBrokenMobile.Name = "labelBrokenMobile";
            this.labelBrokenMobile.Size = new System.Drawing.Size(112, 13);
            this.labelBrokenMobile.TabIndex = 5;
            this.labelBrokenMobile.Text = "2G - 0, 3G - 0, LTE - 0";
            this.labelBrokenMobile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBrokenInter
            // 
            this.labelBrokenInter.AutoSize = true;
            this.labelBrokenInter.Location = new System.Drawing.Point(539, 169);
            this.labelBrokenInter.Name = "labelBrokenInter";
            this.labelBrokenInter.Size = new System.Drawing.Size(28, 13);
            this.labelBrokenInter.TabIndex = 5;
            this.labelBrokenInter.Text = "Inter";
            this.labelBrokenInter.Click += new System.EventHandler(this.label7_Click);
            // 
            // labelBrokenFix
            // 
            this.labelBrokenFix.AutoSize = true;
            this.labelBrokenFix.Location = new System.Drawing.Point(9, 169);
            this.labelBrokenFix.Name = "labelBrokenFix";
            this.labelBrokenFix.Size = new System.Drawing.Size(20, 13);
            this.labelBrokenFix.TabIndex = 5;
            this.labelBrokenFix.Text = "Fix";
            this.labelBrokenFix.Click += new System.EventHandler(this.label7_Click);
            // 
            // textBoxBrokenInter
            // 
            this.textBoxBrokenInter.Location = new System.Drawing.Point(542, 202);
            this.textBoxBrokenInter.Name = "textBoxBrokenInter";
            this.textBoxBrokenInter.Size = new System.Drawing.Size(255, 20);
            this.textBoxBrokenInter.TabIndex = 4;
            this.textBoxBrokenInter.Text = "(?<GRP>(?i)_{0,1}1{0,1}9\\\\d\\\\d_.*|.*monitor.*|_{0,1}1{0,1}5\\\\d{2,3}_.*)";
            // 
            // textBoxBrokenBS
            // 
            this.textBoxBrokenBS.Location = new System.Drawing.Point(265, 202);
            this.textBoxBrokenBS.Name = "textBoxBrokenBS";
            this.textBoxBrokenBS.Size = new System.Drawing.Size(271, 20);
            this.textBoxBrokenBS.TabIndex = 4;
            this.textBoxBrokenBS.Text = "(?<GRP>(?i)^_?1?9\\d{2}_.*|.*monitor.*|^_?1?5\\d{2,3}_.*)";
            // 
            // textBoxBrokenFix
            // 
            this.textBoxBrokenFix.Location = new System.Drawing.Point(6, 202);
            this.textBoxBrokenFix.Name = "textBoxBrokenFix";
            this.textBoxBrokenFix.Size = new System.Drawing.Size(253, 20);
            this.textBoxBrokenFix.TabIndex = 4;
            this.textBoxBrokenFix.Text = "(?<GRP>(?i).*T\\d{7}.*|^_?1?7\\d{2,3}_.*|(?i).*klient.*|.*internet.*)";
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(709, 446);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(94, 23);
            this.buttonExport.TabIndex = 3;
            this.buttonExport.Text = "Export to Excel";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(9, 446);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(75, 23);
            this.buttonSort.TabIndex = 2;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // listBoxBrokenInter
            // 
            this.listBoxBrokenInter.FormattingEnabled = true;
            this.listBoxBrokenInter.HorizontalScrollbar = true;
            this.listBoxBrokenInter.Location = new System.Drawing.Point(542, 228);
            this.listBoxBrokenInter.Name = "listBoxBrokenInter";
            this.listBoxBrokenInter.Size = new System.Drawing.Size(255, 212);
            this.listBoxBrokenInter.TabIndex = 1;
            // 
            // listBoxBrokenBS
            // 
            this.listBoxBrokenBS.FormattingEnabled = true;
            this.listBoxBrokenBS.HorizontalScrollbar = true;
            this.listBoxBrokenBS.Location = new System.Drawing.Point(265, 228);
            this.listBoxBrokenBS.Name = "listBoxBrokenBS";
            this.listBoxBrokenBS.Size = new System.Drawing.Size(271, 212);
            this.listBoxBrokenBS.TabIndex = 1;
            // 
            // listBoxBrokenFix
            // 
            this.listBoxBrokenFix.FormattingEnabled = true;
            this.listBoxBrokenFix.HorizontalScrollbar = true;
            this.listBoxBrokenFix.Location = new System.Drawing.Point(6, 228);
            this.listBoxBrokenFix.Name = "listBoxBrokenFix";
            this.listBoxBrokenFix.Size = new System.Drawing.Size(253, 212);
            this.listBoxBrokenFix.TabIndex = 1;
            // 
            // listBoxBrokenService
            // 
            this.listBoxBrokenService.FormattingEnabled = true;
            this.listBoxBrokenService.Location = new System.Drawing.Point(6, 6);
            this.listBoxBrokenService.Name = "listBoxBrokenService";
            this.listBoxBrokenService.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxBrokenService.Size = new System.Drawing.Size(391, 160);
            this.listBoxBrokenService.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labelDamagedMobile);
            this.tabPage3.Controls.Add(this.buttonAddService4GDamaged);
            this.tabPage3.Controls.Add(this.buttonAddService3GDamaged);
            this.tabPage3.Controls.Add(this.buttonAddService2GDamaged);
            this.tabPage3.Controls.Add(this.buttonAddServiceInterDamaged);
            this.tabPage3.Controls.Add(this.buttonAddServiceFixDamaged);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.labelDamagedInter);
            this.tabPage3.Controls.Add(this.labelDamagedFix);
            this.tabPage3.Controls.Add(this.listBoxDamagedInter);
            this.tabPage3.Controls.Add(this.listBoxDamagedBS);
            this.tabPage3.Controls.Add(this.listBoxDamagedFix);
            this.tabPage3.Controls.Add(this.richTextBoxDamagedExternal);
            this.tabPage3.Controls.Add(this.listBoxDamagedService);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(809, 474);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Damaged Service";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // labelDamagedMobile
            // 
            this.labelDamagedMobile.AutoSize = true;
            this.labelDamagedMobile.Location = new System.Drawing.Point(270, 223);
            this.labelDamagedMobile.Name = "labelDamagedMobile";
            this.labelDamagedMobile.Size = new System.Drawing.Size(112, 13);
            this.labelDamagedMobile.TabIndex = 20;
            this.labelDamagedMobile.Text = "2G - 0, 3G - 0, LTE - 0";
            // 
            // buttonAddService4GDamaged
            // 
            this.buttonAddService4GDamaged.Location = new System.Drawing.Point(495, 210);
            this.buttonAddService4GDamaged.Name = "buttonAddService4GDamaged";
            this.buttonAddService4GDamaged.Size = new System.Drawing.Size(45, 24);
            this.buttonAddService4GDamaged.TabIndex = 15;
            this.buttonAddService4GDamaged.Text = "4G ▼";
            this.buttonAddService4GDamaged.UseVisualStyleBackColor = true;
            this.buttonAddService4GDamaged.Click += new System.EventHandler(this.buttonAddService4GDamaged_Click);
            // 
            // buttonAddService3GDamaged
            // 
            this.buttonAddService3GDamaged.Location = new System.Drawing.Point(449, 210);
            this.buttonAddService3GDamaged.Name = "buttonAddService3GDamaged";
            this.buttonAddService3GDamaged.Size = new System.Drawing.Size(45, 24);
            this.buttonAddService3GDamaged.TabIndex = 16;
            this.buttonAddService3GDamaged.Text = "3G ▼";
            this.buttonAddService3GDamaged.UseVisualStyleBackColor = true;
            this.buttonAddService3GDamaged.Click += new System.EventHandler(this.buttonAddService3GDamaged_Click);
            // 
            // buttonAddService2GDamaged
            // 
            this.buttonAddService2GDamaged.Location = new System.Drawing.Point(403, 210);
            this.buttonAddService2GDamaged.Name = "buttonAddService2GDamaged";
            this.buttonAddService2GDamaged.Size = new System.Drawing.Size(45, 24);
            this.buttonAddService2GDamaged.TabIndex = 17;
            this.buttonAddService2GDamaged.Text = "2G ▼";
            this.buttonAddService2GDamaged.UseVisualStyleBackColor = true;
            this.buttonAddService2GDamaged.Click += new System.EventHandler(this.buttonAddService2GDamaged_Click);
            // 
            // buttonAddServiceInterDamaged
            // 
            this.buttonAddServiceInterDamaged.Location = new System.Drawing.Point(772, 210);
            this.buttonAddServiceInterDamaged.Name = "buttonAddServiceInterDamaged";
            this.buttonAddServiceInterDamaged.Size = new System.Drawing.Size(28, 24);
            this.buttonAddServiceInterDamaged.TabIndex = 18;
            this.buttonAddServiceInterDamaged.Text = "▼";
            this.buttonAddServiceInterDamaged.UseVisualStyleBackColor = true;
            this.buttonAddServiceInterDamaged.Click += new System.EventHandler(this.buttonAddServiceInterDamaged_Click);
            // 
            // buttonAddServiceFixDamaged
            // 
            this.buttonAddServiceFixDamaged.Location = new System.Drawing.Point(232, 210);
            this.buttonAddServiceFixDamaged.Name = "buttonAddServiceFixDamaged";
            this.buttonAddServiceFixDamaged.Size = new System.Drawing.Size(28, 24);
            this.buttonAddServiceFixDamaged.TabIndex = 19;
            this.buttonAddServiceFixDamaged.Text = "▼";
            this.buttonAddServiceFixDamaged.UseVisualStyleBackColor = true;
            this.buttonAddServiceFixDamaged.Click += new System.EventHandler(this.button10_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mobile";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDamagedInter
            // 
            this.labelDamagedInter.AutoSize = true;
            this.labelDamagedInter.Location = new System.Drawing.Point(542, 210);
            this.labelDamagedInter.Name = "labelDamagedInter";
            this.labelDamagedInter.Size = new System.Drawing.Size(28, 13);
            this.labelDamagedInter.TabIndex = 13;
            this.labelDamagedInter.Text = "Inter";
            // 
            // labelDamagedFix
            // 
            this.labelDamagedFix.AutoSize = true;
            this.labelDamagedFix.Location = new System.Drawing.Point(9, 210);
            this.labelDamagedFix.Name = "labelDamagedFix";
            this.labelDamagedFix.Size = new System.Drawing.Size(20, 13);
            this.labelDamagedFix.TabIndex = 14;
            this.labelDamagedFix.Text = "Fix";
            // 
            // listBoxDamagedInter
            // 
            this.listBoxDamagedInter.FormattingEnabled = true;
            this.listBoxDamagedInter.HorizontalScrollbar = true;
            this.listBoxDamagedInter.Location = new System.Drawing.Point(545, 239);
            this.listBoxDamagedInter.Name = "listBoxDamagedInter";
            this.listBoxDamagedInter.Size = new System.Drawing.Size(255, 225);
            this.listBoxDamagedInter.TabIndex = 9;
            // 
            // listBoxDamagedBS
            // 
            this.listBoxDamagedBS.FormattingEnabled = true;
            this.listBoxDamagedBS.HorizontalScrollbar = true;
            this.listBoxDamagedBS.Location = new System.Drawing.Point(268, 239);
            this.listBoxDamagedBS.Name = "listBoxDamagedBS";
            this.listBoxDamagedBS.Size = new System.Drawing.Size(271, 225);
            this.listBoxDamagedBS.TabIndex = 10;
            // 
            // listBoxDamagedFix
            // 
            this.listBoxDamagedFix.FormattingEnabled = true;
            this.listBoxDamagedFix.HorizontalScrollbar = true;
            this.listBoxDamagedFix.Location = new System.Drawing.Point(9, 239);
            this.listBoxDamagedFix.Name = "listBoxDamagedFix";
            this.listBoxDamagedFix.Size = new System.Drawing.Size(253, 225);
            this.listBoxDamagedFix.TabIndex = 11;
            // 
            // richTextBoxDamagedExternal
            // 
            this.richTextBoxDamagedExternal.Location = new System.Drawing.Point(411, 3);
            this.richTextBoxDamagedExternal.Name = "richTextBoxDamagedExternal";
            this.richTextBoxDamagedExternal.Size = new System.Drawing.Size(386, 200);
            this.richTextBoxDamagedExternal.TabIndex = 8;
            this.richTextBoxDamagedExternal.Text = "";
            // 
            // listBoxDamagedService
            // 
            this.listBoxDamagedService.FormattingEnabled = true;
            this.listBoxDamagedService.Location = new System.Drawing.Point(9, 3);
            this.listBoxDamagedService.Name = "listBoxDamagedService";
            this.listBoxDamagedService.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxDamagedService.Size = new System.Drawing.Size(396, 199);
            this.listBoxDamagedService.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.listBoxDamagedVPLS);
            this.tabPage4.Controls.Add(this.listBoxBrokenVPLS);
            this.tabPage4.Controls.Add(this.buttonCalculateVPLS);
            this.tabPage4.Controls.Add(this.richTextBoxVPLS);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(809, 474);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "E-LAN";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(584, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Damaged";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Broken";
            // 
            // listBoxDamagedVPLS
            // 
            this.listBoxDamagedVPLS.FormattingEnabled = true;
            this.listBoxDamagedVPLS.HorizontalScrollbar = true;
            this.listBoxDamagedVPLS.Location = new System.Drawing.Point(405, 217);
            this.listBoxDamagedVPLS.Name = "listBoxDamagedVPLS";
            this.listBoxDamagedVPLS.Size = new System.Drawing.Size(398, 251);
            this.listBoxDamagedVPLS.TabIndex = 2;
            // 
            // listBoxBrokenVPLS
            // 
            this.listBoxBrokenVPLS.FormattingEnabled = true;
            this.listBoxBrokenVPLS.HorizontalScrollbar = true;
            this.listBoxBrokenVPLS.Location = new System.Drawing.Point(3, 217);
            this.listBoxBrokenVPLS.Name = "listBoxBrokenVPLS";
            this.listBoxBrokenVPLS.Size = new System.Drawing.Size(396, 251);
            this.listBoxBrokenVPLS.TabIndex = 2;
            // 
            // buttonCalculateVPLS
            // 
            this.buttonCalculateVPLS.Location = new System.Drawing.Point(359, 192);
            this.buttonCalculateVPLS.Name = "buttonCalculateVPLS";
            this.buttonCalculateVPLS.Size = new System.Drawing.Size(91, 19);
            this.buttonCalculateVPLS.TabIndex = 1;
            this.buttonCalculateVPLS.Text = "Calculate VPLS";
            this.buttonCalculateVPLS.UseVisualStyleBackColor = true;
            this.buttonCalculateVPLS.Click += new System.EventHandler(this.buttonCalculateVPLS_Click);
            // 
            // richTextBoxVPLS
            // 
            this.richTextBoxVPLS.Location = new System.Drawing.Point(2, 2);
            this.richTextBoxVPLS.Name = "richTextBoxVPLS";
            this.richTextBoxVPLS.Size = new System.Drawing.Size(804, 184);
            this.richTextBoxVPLS.TabIndex = 0;
            this.richTextBoxVPLS.Text = "";
            this.richTextBoxVPLS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGridView);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(809, 474);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Table";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(803, 468);
            this.dataGridView.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 497);
            this.Controls.Add(this.tabControlTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlTable.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonLoadServices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ComboBox comboBoxNEName;
        private System.Windows.Forms.ListBox listBoxSlotPort;
        private System.Windows.Forms.Button buttonAddPort;
        private System.Windows.Forms.Button buttonAddAllPorts;
        private System.Windows.Forms.ListBox listBoxBrokenPorts;
        private System.Windows.Forms.Button buttonRemoveAllPorts;
        private System.Windows.Forms.Button buttonRemovePort;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonSaveDB;
        private System.Windows.Forms.Button buttonLoadDB;
        private System.Windows.Forms.Button buttonCalc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControlTable;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.ListBox listBoxBrokenService;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listBoxDamagedService;
        private System.Windows.Forms.TextBox textBoxBrokenFix;
        private System.Windows.Forms.ListBox listBoxBrokenFix;
        private System.Windows.Forms.Label labelBrokenFix;
        private System.Windows.Forms.TextBox textBoxBrokenInter;
        private System.Windows.Forms.TextBox textBoxBrokenBS;
        private System.Windows.Forms.ListBox listBoxBrokenInter;
        private System.Windows.Forms.ListBox listBoxBrokenBS;
        private System.Windows.Forms.Label labelBrokenInter;
        private System.Windows.Forms.Label labelBrokenMobile;
        private System.Windows.Forms.Button buttonLoadFilter;
        private System.Windows.Forms.Button buttonSaveFilter;
        private System.Windows.Forms.RichTextBox richTextBoxBrokenExternal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelDamagedInter;
        private System.Windows.Forms.Label labelDamagedFix;
        private System.Windows.Forms.ListBox listBoxDamagedInter;
        private System.Windows.Forms.ListBox listBoxDamagedBS;
        private System.Windows.Forms.ListBox listBoxDamagedFix;
        private System.Windows.Forms.RichTextBox richTextBoxDamagedExternal;
        private System.Windows.Forms.Button buttonAddService4GBroken;
        private System.Windows.Forms.Button buttonAddService3GBroken;
        private System.Windows.Forms.Button buttonAddService2GBroken;
        private System.Windows.Forms.Button buttonAddServiceInterBroken;
        private System.Windows.Forms.Button buttonAddServiceFixBroken;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonAddService4GDamaged;
        private System.Windows.Forms.Button buttonAddService3GDamaged;
        private System.Windows.Forms.Button buttonAddService2GDamaged;
        private System.Windows.Forms.Button buttonAddServiceInterDamaged;
        private System.Windows.Forms.Button buttonAddServiceFixDamaged;
        private System.Windows.Forms.Label labelDamagedMobile;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox richTextBoxVPLS;
        private System.Windows.Forms.ListBox listBoxBrokenVPLS;
        private System.Windows.Forms.Button buttonCalculateVPLS;
        private System.Windows.Forms.ListBox listBoxDamagedVPLS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}

