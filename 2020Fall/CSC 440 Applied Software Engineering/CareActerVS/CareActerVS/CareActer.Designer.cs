namespace CareActerVS
{
    partial class CareActer
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
            this.mainList = new System.Windows.Forms.ListBox();
            this.itemPanel = new System.Windows.Forms.Panel();
            this.itemSelect = new System.Windows.Forms.ListBox();
            this.itemInfo = new System.Windows.Forms.GroupBox();
            this.itemSave = new System.Windows.Forms.Button();
            this.itemDescLabel = new System.Windows.Forms.Label();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.itemDescBox = new System.Windows.Forms.TextBox();
            this.itemNameBox = new System.Windows.Forms.TextBox();
            this.skillPanel = new System.Windows.Forms.Panel();
            this.skillInfo = new System.Windows.Forms.GroupBox();
            this.skillSave = new System.Windows.Forms.Button();
            this.skillDescLabel = new System.Windows.Forms.Label();
            this.skillNameLabel = new System.Windows.Forms.Label();
            this.skillDescBox = new System.Windows.Forms.TextBox();
            this.skillNameBox = new System.Windows.Forms.TextBox();
            this.skillSelect = new System.Windows.Forms.ListBox();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.statsSave = new System.Windows.Forms.Button();
            this.statsAlign = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.statsSpeed = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.statsHP = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.statsAC = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.statsRandom = new System.Windows.Forms.Button();
            this.AttributesGroup = new System.Windows.Forms.GroupBox();
            this.statsCHA = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.statsCON = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.statsWIS = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.statsDEX = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.statsINT = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.statsSTR = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.statsLvl = new System.Windows.Forms.NumericUpDown();
            this.statsBack = new System.Windows.Forms.TextBox();
            this.statsClass = new System.Windows.Forms.TextBox();
            this.statsRace = new System.Windows.Forms.TextBox();
            this.statsName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.diePanel = new System.Windows.Forms.Panel();
            this.dieTotal = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dieRoll = new System.Windows.Forms.Button();
            this.dieSides = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.dieAmount = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.curCharDrop = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.itemPanel.SuspendLayout();
            this.itemInfo.SuspendLayout();
            this.skillPanel.SuspendLayout();
            this.skillInfo.SuspendLayout();
            this.statsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statsSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsAC)).BeginInit();
            this.AttributesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statsCHA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsCON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsWIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsDEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsINT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsSTR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsLvl)).BeginInit();
            this.diePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dieSides)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dieAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // mainList
            // 
            this.mainList.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.mainList.FormattingEnabled = true;
            this.mainList.ItemHeight = 16;
            this.mainList.Items.AddRange(new object[] {
            "Stats",
            "Items",
            "Skills",
            "Die Roll"});
            this.mainList.Location = new System.Drawing.Point(11, 50);
            this.mainList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainList.Name = "mainList";
            this.mainList.Size = new System.Drawing.Size(159, 420);
            this.mainList.TabIndex = 0;
            this.mainList.SelectedIndexChanged += new System.EventHandler(this.mainListBox_SelectedIndexChanged);
            // 
            // itemPanel
            // 
            this.itemPanel.BackColor = System.Drawing.Color.Red;
            this.itemPanel.Controls.Add(this.itemSelect);
            this.itemPanel.Controls.Add(this.itemInfo);
            this.itemPanel.Location = new System.Drawing.Point(169, 50);
            this.itemPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(779, 420);
            this.itemPanel.TabIndex = 1;
            this.itemPanel.Visible = false;
            this.itemPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // itemSelect
            // 
            this.itemSelect.FormattingEnabled = true;
            this.itemSelect.HorizontalScrollbar = true;
            this.itemSelect.ItemHeight = 16;
            this.itemSelect.Location = new System.Drawing.Point(0, 0);
            this.itemSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemSelect.Name = "itemSelect";
            this.itemSelect.Size = new System.Drawing.Size(159, 420);
            this.itemSelect.TabIndex = 2;
            this.itemSelect.SelectedIndexChanged += new System.EventHandler(this.itemListBox_SelectedIndexChanged_1);
            // 
            // itemInfo
            // 
            this.itemInfo.Controls.Add(this.itemSave);
            this.itemInfo.Controls.Add(this.itemDescLabel);
            this.itemInfo.Controls.Add(this.itemNameLabel);
            this.itemInfo.Controls.Add(this.itemDescBox);
            this.itemInfo.Controls.Add(this.itemNameBox);
            this.itemInfo.Location = new System.Drawing.Point(165, 2);
            this.itemInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemInfo.Name = "itemInfo";
            this.itemInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemInfo.Size = new System.Drawing.Size(611, 414);
            this.itemInfo.TabIndex = 2;
            this.itemInfo.TabStop = false;
            this.itemInfo.Text = "Item Information";
            this.itemInfo.Visible = false;
            // 
            // itemSave
            // 
            this.itemSave.Location = new System.Drawing.Point(512, 372);
            this.itemSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemSave.Name = "itemSave";
            this.itemSave.Size = new System.Drawing.Size(92, 36);
            this.itemSave.TabIndex = 33;
            this.itemSave.Text = "SAVE";
            this.itemSave.UseVisualStyleBackColor = true;
            this.itemSave.Visible = false;
            this.itemSave.Click += new System.EventHandler(this.itemSave_Click);
            // 
            // itemDescLabel
            // 
            this.itemDescLabel.AutoSize = true;
            this.itemDescLabel.Location = new System.Drawing.Point(9, 78);
            this.itemDescLabel.Name = "itemDescLabel";
            this.itemDescLabel.Size = new System.Drawing.Size(79, 17);
            this.itemDescLabel.TabIndex = 3;
            this.itemDescLabel.Text = "Description";
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.Location = new System.Drawing.Point(9, 22);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(45, 17);
            this.itemNameLabel.TabIndex = 2;
            this.itemNameLabel.Text = "Name";
            // 
            // itemDescBox
            // 
            this.itemDescBox.Enabled = false;
            this.itemDescBox.Location = new System.Drawing.Point(5, 97);
            this.itemDescBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemDescBox.Multiline = true;
            this.itemDescBox.Name = "itemDescBox";
            this.itemDescBox.Size = new System.Drawing.Size(599, 258);
            this.itemDescBox.TabIndex = 1;
            this.itemDescBox.Text = "Item Name Ex";
            this.itemDescBox.TextChanged += new System.EventHandler(this.itemDescBox_TextChanged);
            // 
            // itemNameBox
            // 
            this.itemNameBox.Enabled = false;
            this.itemNameBox.Location = new System.Drawing.Point(5, 42);
            this.itemNameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemNameBox.Name = "itemNameBox";
            this.itemNameBox.Size = new System.Drawing.Size(599, 22);
            this.itemNameBox.TabIndex = 0;
            this.itemNameBox.Text = "Item Name Ex";
            // 
            // skillPanel
            // 
            this.skillPanel.BackColor = System.Drawing.Color.Lime;
            this.skillPanel.Controls.Add(this.skillInfo);
            this.skillPanel.Controls.Add(this.skillSelect);
            this.skillPanel.Location = new System.Drawing.Point(169, 517);
            this.skillPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skillPanel.Name = "skillPanel";
            this.skillPanel.Size = new System.Drawing.Size(779, 420);
            this.skillPanel.TabIndex = 2;
            this.skillPanel.Visible = false;
            // 
            // skillInfo
            // 
            this.skillInfo.Controls.Add(this.skillSave);
            this.skillInfo.Controls.Add(this.skillDescLabel);
            this.skillInfo.Controls.Add(this.skillNameLabel);
            this.skillInfo.Controls.Add(this.skillDescBox);
            this.skillInfo.Controls.Add(this.skillNameBox);
            this.skillInfo.Location = new System.Drawing.Point(165, 2);
            this.skillInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skillInfo.Name = "skillInfo";
            this.skillInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skillInfo.Size = new System.Drawing.Size(611, 414);
            this.skillInfo.TabIndex = 2;
            this.skillInfo.TabStop = false;
            this.skillInfo.Text = "Skill Information";
            this.skillInfo.Visible = false;
            this.skillInfo.Enter += new System.EventHandler(this.skillInfo_Enter);
            // 
            // skillSave
            // 
            this.skillSave.Location = new System.Drawing.Point(512, 372);
            this.skillSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skillSave.Name = "skillSave";
            this.skillSave.Size = new System.Drawing.Size(92, 36);
            this.skillSave.TabIndex = 33;
            this.skillSave.Text = "SAVE";
            this.skillSave.UseVisualStyleBackColor = true;
            this.skillSave.Visible = false;
            this.skillSave.Click += new System.EventHandler(this.skillSave_Click);
            // 
            // skillDescLabel
            // 
            this.skillDescLabel.AutoSize = true;
            this.skillDescLabel.Location = new System.Drawing.Point(5, 84);
            this.skillDescLabel.Name = "skillDescLabel";
            this.skillDescLabel.Size = new System.Drawing.Size(79, 17);
            this.skillDescLabel.TabIndex = 4;
            this.skillDescLabel.Text = "Description";
            // 
            // skillNameLabel
            // 
            this.skillNameLabel.AutoSize = true;
            this.skillNameLabel.Location = new System.Drawing.Point(5, 21);
            this.skillNameLabel.Name = "skillNameLabel";
            this.skillNameLabel.Size = new System.Drawing.Size(45, 17);
            this.skillNameLabel.TabIndex = 3;
            this.skillNameLabel.Text = "Name";
            // 
            // skillDescBox
            // 
            this.skillDescBox.Enabled = false;
            this.skillDescBox.Location = new System.Drawing.Point(5, 103);
            this.skillDescBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skillDescBox.Multiline = true;
            this.skillDescBox.Name = "skillDescBox";
            this.skillDescBox.Size = new System.Drawing.Size(599, 258);
            this.skillDescBox.TabIndex = 1;
            this.skillDescBox.Text = "Skill Description Example";
            // 
            // skillNameBox
            // 
            this.skillNameBox.Enabled = false;
            this.skillNameBox.Location = new System.Drawing.Point(5, 41);
            this.skillNameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skillNameBox.Name = "skillNameBox";
            this.skillNameBox.Size = new System.Drawing.Size(599, 22);
            this.skillNameBox.TabIndex = 0;
            this.skillNameBox.Text = "Skill Name Ex";
            // 
            // skillSelect
            // 
            this.skillSelect.FormattingEnabled = true;
            this.skillSelect.HorizontalScrollbar = true;
            this.skillSelect.ItemHeight = 16;
            this.skillSelect.Location = new System.Drawing.Point(0, 0);
            this.skillSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skillSelect.Name = "skillSelect";
            this.skillSelect.Size = new System.Drawing.Size(159, 420);
            this.skillSelect.TabIndex = 2;
            this.skillSelect.SelectedIndexChanged += new System.EventHandler(this.skillSelect_SelectedIndexChanged);
            // 
            // statsPanel
            // 
            this.statsPanel.BackColor = System.Drawing.Color.Cyan;
            this.statsPanel.Controls.Add(this.statsSave);
            this.statsPanel.Controls.Add(this.statsAlign);
            this.statsPanel.Controls.Add(this.label15);
            this.statsPanel.Controls.Add(this.statsSpeed);
            this.statsPanel.Controls.Add(this.label14);
            this.statsPanel.Controls.Add(this.statsHP);
            this.statsPanel.Controls.Add(this.label13);
            this.statsPanel.Controls.Add(this.statsAC);
            this.statsPanel.Controls.Add(this.label12);
            this.statsPanel.Controls.Add(this.statsRandom);
            this.statsPanel.Controls.Add(this.AttributesGroup);
            this.statsPanel.Controls.Add(this.statsLvl);
            this.statsPanel.Controls.Add(this.statsBack);
            this.statsPanel.Controls.Add(this.statsClass);
            this.statsPanel.Controls.Add(this.statsRace);
            this.statsPanel.Controls.Add(this.statsName);
            this.statsPanel.Controls.Add(this.label5);
            this.statsPanel.Controls.Add(this.label4);
            this.statsPanel.Controls.Add(this.label3);
            this.statsPanel.Controls.Add(this.label2);
            this.statsPanel.Controls.Add(this.label1);
            this.statsPanel.Location = new System.Drawing.Point(976, 53);
            this.statsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(779, 420);
            this.statsPanel.TabIndex = 3;
            this.statsPanel.Visible = false;
            // 
            // statsSave
            // 
            this.statsSave.Location = new System.Drawing.Point(680, 377);
            this.statsSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsSave.Name = "statsSave";
            this.statsSave.Size = new System.Drawing.Size(92, 36);
            this.statsSave.TabIndex = 32;
            this.statsSave.Text = "SAVE";
            this.statsSave.UseVisualStyleBackColor = true;
            this.statsSave.Visible = false;
            this.statsSave.Click += new System.EventHandler(this.statsSave_Click);
            // 
            // statsAlign
            // 
            this.statsAlign.Enabled = false;
            this.statsAlign.Location = new System.Drawing.Point(95, 133);
            this.statsAlign.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsAlign.Name = "statsAlign";
            this.statsAlign.Size = new System.Drawing.Size(217, 22);
            this.statsAlign.TabIndex = 31;
            this.statsAlign.Text = "Alignment Ex";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 135);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 17);
            this.label15.TabIndex = 30;
            this.label15.Text = "Alignment:";
            // 
            // statsSpeed
            // 
            this.statsSpeed.Enabled = false;
            this.statsSpeed.Location = new System.Drawing.Point(664, 231);
            this.statsSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsSpeed.Name = "statsSpeed";
            this.statsSpeed.Size = new System.Drawing.Size(43, 22);
            this.statsSpeed.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(613, 235);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 17);
            this.label14.TabIndex = 28;
            this.label14.Text = "Speed:";
            // 
            // statsHP
            // 
            this.statsHP.Enabled = false;
            this.statsHP.Location = new System.Drawing.Point(533, 233);
            this.statsHP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsHP.Name = "statsHP";
            this.statsHP.Size = new System.Drawing.Size(43, 22);
            this.statsHP.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(475, 236);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 17);
            this.label13.TabIndex = 26;
            this.label13.Text = "Max HP:";
            // 
            // statsAC
            // 
            this.statsAC.Enabled = false;
            this.statsAC.Location = new System.Drawing.Point(392, 233);
            this.statsAC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsAC.Name = "statsAC";
            this.statsAC.Size = new System.Drawing.Size(43, 22);
            this.statsAC.TabIndex = 25;
            this.statsAC.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(365, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "AC:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // statsRandom
            // 
            this.statsRandom.Location = new System.Drawing.Point(627, 194);
            this.statsRandom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsRandom.Name = "statsRandom";
            this.statsRandom.Size = new System.Drawing.Size(101, 23);
            this.statsRandom.TabIndex = 23;
            this.statsRandom.Text = "RANDOMIZE";
            this.statsRandom.UseVisualStyleBackColor = true;
            this.statsRandom.Visible = false;
            // 
            // AttributesGroup
            // 
            this.AttributesGroup.Controls.Add(this.statsCHA);
            this.AttributesGroup.Controls.Add(this.label11);
            this.AttributesGroup.Controls.Add(this.statsCON);
            this.AttributesGroup.Controls.Add(this.label10);
            this.AttributesGroup.Controls.Add(this.statsWIS);
            this.AttributesGroup.Controls.Add(this.label9);
            this.AttributesGroup.Controls.Add(this.statsDEX);
            this.AttributesGroup.Controls.Add(this.label8);
            this.AttributesGroup.Controls.Add(this.statsINT);
            this.AttributesGroup.Controls.Add(this.label7);
            this.AttributesGroup.Controls.Add(this.statsSTR);
            this.AttributesGroup.Controls.Add(this.label6);
            this.AttributesGroup.Location = new System.Drawing.Point(357, 17);
            this.AttributesGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AttributesGroup.Name = "AttributesGroup";
            this.AttributesGroup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AttributesGroup.Size = new System.Drawing.Size(371, 172);
            this.AttributesGroup.TabIndex = 22;
            this.AttributesGroup.TabStop = false;
            this.AttributesGroup.Text = "Attributes";
            // 
            // statsCHA
            // 
            this.statsCHA.Enabled = false;
            this.statsCHA.Location = new System.Drawing.Point(311, 139);
            this.statsCHA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsCHA.Name = "statsCHA";
            this.statsCHA.Size = new System.Drawing.Size(43, 22);
            this.statsCHA.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(275, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "CHA:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // statsCON
            // 
            this.statsCON.Enabled = false;
            this.statsCON.Location = new System.Drawing.Point(63, 139);
            this.statsCON.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsCON.Name = "statsCON";
            this.statsCON.Size = new System.Drawing.Size(43, 22);
            this.statsCON.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "CON:";
            // 
            // statsWIS
            // 
            this.statsWIS.Enabled = false;
            this.statsWIS.Location = new System.Drawing.Point(311, 82);
            this.statsWIS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsWIS.Name = "statsWIS";
            this.statsWIS.Size = new System.Drawing.Size(43, 22);
            this.statsWIS.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "WIS:";
            // 
            // statsDEX
            // 
            this.statsDEX.Enabled = false;
            this.statsDEX.Location = new System.Drawing.Point(63, 82);
            this.statsDEX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsDEX.Name = "statsDEX";
            this.statsDEX.Size = new System.Drawing.Size(43, 22);
            this.statsDEX.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "DEX:";
            // 
            // statsINT
            // 
            this.statsINT.Enabled = false;
            this.statsINT.Location = new System.Drawing.Point(311, 27);
            this.statsINT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsINT.Name = "statsINT";
            this.statsINT.Size = new System.Drawing.Size(43, 22);
            this.statsINT.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "INT:";
            // 
            // statsSTR
            // 
            this.statsSTR.Enabled = false;
            this.statsSTR.Location = new System.Drawing.Point(63, 27);
            this.statsSTR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsSTR.Name = "statsSTR";
            this.statsSTR.Size = new System.Drawing.Size(43, 22);
            this.statsSTR.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "STR:";
            // 
            // statsLvl
            // 
            this.statsLvl.Enabled = false;
            this.statsLvl.Location = new System.Drawing.Point(269, 98);
            this.statsLvl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsLvl.Name = "statsLvl";
            this.statsLvl.Size = new System.Drawing.Size(43, 22);
            this.statsLvl.TabIndex = 9;
            // 
            // statsBack
            // 
            this.statsBack.Enabled = false;
            this.statsBack.Location = new System.Drawing.Point(19, 194);
            this.statsBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsBack.Multiline = true;
            this.statsBack.Name = "statsBack";
            this.statsBack.Size = new System.Drawing.Size(295, 201);
            this.statsBack.TabIndex = 8;
            this.statsBack.Text = "Background  Ex";
            // 
            // statsClass
            // 
            this.statsClass.Enabled = false;
            this.statsClass.Location = new System.Drawing.Point(71, 96);
            this.statsClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsClass.Name = "statsClass";
            this.statsClass.Size = new System.Drawing.Size(156, 22);
            this.statsClass.TabIndex = 7;
            this.statsClass.Text = "Class Ex";
            // 
            // statsRace
            // 
            this.statsRace.Enabled = false;
            this.statsRace.Location = new System.Drawing.Point(71, 55);
            this.statsRace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsRace.Name = "statsRace";
            this.statsRace.Size = new System.Drawing.Size(241, 22);
            this.statsRace.TabIndex = 6;
            this.statsRace.Text = "Race Ex";
            // 
            // statsName
            // 
            this.statsName.Enabled = false;
            this.statsName.Location = new System.Drawing.Point(71, 14);
            this.statsName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsName.Name = "statsName";
            this.statsName.Size = new System.Drawing.Size(241, 22);
            this.statsName.TabIndex = 5;
            this.statsName.Text = "Name Ex";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Background";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lvl:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Class:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Race:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // diePanel
            // 
            this.diePanel.BackColor = System.Drawing.Color.Salmon;
            this.diePanel.Controls.Add(this.dieTotal);
            this.diePanel.Controls.Add(this.label19);
            this.diePanel.Controls.Add(this.dieRoll);
            this.diePanel.Controls.Add(this.dieSides);
            this.diePanel.Controls.Add(this.label18);
            this.diePanel.Controls.Add(this.dieAmount);
            this.diePanel.Controls.Add(this.label17);
            this.diePanel.Controls.Add(this.label16);
            this.diePanel.Location = new System.Drawing.Point(1035, 508);
            this.diePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.diePanel.Name = "diePanel";
            this.diePanel.Size = new System.Drawing.Size(779, 420);
            this.diePanel.TabIndex = 4;
            this.diePanel.Visible = false;
            // 
            // dieTotal
            // 
            this.dieTotal.Enabled = false;
            this.dieTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieTotal.Location = new System.Drawing.Point(337, 350);
            this.dieTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dieTotal.Name = "dieTotal";
            this.dieTotal.Size = new System.Drawing.Size(87, 34);
            this.dieTotal.TabIndex = 26;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(347, 316);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 29);
            this.label19.TabIndex = 25;
            this.label19.Text = "Total";
            // 
            // dieRoll
            // 
            this.dieRoll.Location = new System.Drawing.Point(321, 255);
            this.dieRoll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dieRoll.Name = "dieRoll";
            this.dieRoll.Size = new System.Drawing.Size(119, 34);
            this.dieRoll.TabIndex = 24;
            this.dieRoll.Text = "ROLL!";
            this.dieRoll.UseVisualStyleBackColor = true;
            this.dieRoll.Click += new System.EventHandler(this.dieRoll_Click);
            // 
            // dieSides
            // 
            this.dieSides.Location = new System.Drawing.Point(477, 174);
            this.dieSides.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dieSides.Name = "dieSides";
            this.dieSides.Size = new System.Drawing.Size(51, 22);
            this.dieSides.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(415, 142);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(188, 29);
            this.label18.TabIndex = 22;
            this.label18.Text = "Amount of Sides";
            // 
            // dieAmount
            // 
            this.dieAmount.Location = new System.Drawing.Point(180, 174);
            this.dieAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dieAmount.Name = "dieAmount";
            this.dieAmount.Size = new System.Drawing.Size(51, 22);
            this.dieAmount.TabIndex = 21;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(117, 142);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(175, 29);
            this.label17.TabIndex = 20;
            this.label17.Text = "Amount of Dice";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(196, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(368, 58);
            this.label16.TabIndex = 0;
            this.label16.Text = "DICE ROLLER";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(154, 20);
            this.label21.TabIndex = 5;
            this.label21.Text = "Current Character: ";
            // 
            // curCharDrop
            // 
            this.curCharDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.curCharDrop.FormattingEnabled = true;
            this.curCharDrop.Location = new System.Drawing.Point(173, 7);
            this.curCharDrop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.curCharDrop.Name = "curCharDrop";
            this.curCharDrop.Size = new System.Drawing.Size(225, 24);
            this.curCharDrop.TabIndex = 6;
            this.curCharDrop.SelectedIndexChanged += new System.EventHandler(this.curCharDrop_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(476, 4);
            this.addButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 31);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(620, 4);
            this.editButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 31);
            this.editButton.TabIndex = 8;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Visible = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(764, 4);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(88, 31);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Visible = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // CareActer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 496);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.curCharDrop);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.diePanel);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.mainList);
            this.Controls.Add(this.skillPanel);
            this.Controls.Add(this.itemPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CareActer";
            this.Text = "CareActer";
            this.itemPanel.ResumeLayout(false);
            this.itemInfo.ResumeLayout(false);
            this.itemInfo.PerformLayout();
            this.skillPanel.ResumeLayout(false);
            this.skillInfo.ResumeLayout(false);
            this.skillInfo.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            this.statsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statsSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsAC)).EndInit();
            this.AttributesGroup.ResumeLayout(false);
            this.AttributesGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statsCHA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsCON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsWIS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsDEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsINT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsSTR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsLvl)).EndInit();
            this.diePanel.ResumeLayout(false);
            this.diePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dieSides)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dieAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox mainList;
        private System.Windows.Forms.Panel itemPanel;
        private System.Windows.Forms.ListBox itemSelect;
        private System.Windows.Forms.GroupBox itemInfo;
        private System.Windows.Forms.TextBox itemDescBox;
        private System.Windows.Forms.TextBox itemNameBox;
        private System.Windows.Forms.Label itemDescLabel;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Panel skillPanel;
        private System.Windows.Forms.GroupBox skillInfo;
        private System.Windows.Forms.Label skillDescLabel;
        private System.Windows.Forms.Label skillNameLabel;
        private System.Windows.Forms.TextBox skillDescBox;
        private System.Windows.Forms.TextBox skillNameBox;
        private System.Windows.Forms.ListBox skillSelect;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown statsLvl;
        private System.Windows.Forms.TextBox statsBack;
        private System.Windows.Forms.TextBox statsClass;
        private System.Windows.Forms.TextBox statsRace;
        private System.Windows.Forms.TextBox statsName;
        private System.Windows.Forms.NumericUpDown statsCHA;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown statsCON;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown statsWIS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown statsDEX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown statsINT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown statsSTR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox AttributesGroup;
        private System.Windows.Forms.Button statsRandom;
        private System.Windows.Forms.NumericUpDown statsAC;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox statsAlign;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown statsSpeed;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown statsHP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button itemSave;
        private System.Windows.Forms.Button skillSave;
        private System.Windows.Forms.Button statsSave;
        private System.Windows.Forms.Panel diePanel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown dieAmount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown dieSides;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button dieRoll;
        private System.Windows.Forms.TextBox dieTotal;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox curCharDrop;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
    }
}

