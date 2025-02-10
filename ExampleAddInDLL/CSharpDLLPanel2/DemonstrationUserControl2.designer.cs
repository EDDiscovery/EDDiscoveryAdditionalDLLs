
namespace DemoUserControl
{ 
    partial class DemonstrationUserControl2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ExtendedControls.TabStyleSquare tabStyleSquare1 = new ExtendedControls.TabStyleSquare();
            this.extButton1 = new ExtendedControls.ExtButton();
            this.extPanelDataGridViewScroll1 = new ExtendedControls.ExtPanelDataGridViewScroll();
            this.extScrollBar1 = new ExtendedControls.ExtScrollBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extTabControl1 = new ExtendedControls.ExtTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.extComboBox1 = new ExtendedControls.ExtComboBox();
            this.extCheckBox1 = new ExtendedControls.ExtCheckBox();
            this.extPanelDataGridViewScroll1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.extTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // extButton1
            // 
            this.extButton1.Location = new System.Drawing.Point(23, 524);
            this.extButton1.Name = "extButton1";
            this.extButton1.Size = new System.Drawing.Size(143, 28);
            this.extButton1.TabIndex = 5;
            this.extButton1.Text = "extButton1";
            this.extButton1.UseVisualStyleBackColor = true;
            // 
            // extPanelDataGridViewScroll1
            // 
            this.extPanelDataGridViewScroll1.Controls.Add(this.extScrollBar1);
            this.extPanelDataGridViewScroll1.Controls.Add(this.dataGridView1);
            this.extPanelDataGridViewScroll1.InternalMargin = new System.Windows.Forms.Padding(0);
            this.extPanelDataGridViewScroll1.Location = new System.Drawing.Point(19, 164);
            this.extPanelDataGridViewScroll1.Name = "extPanelDataGridViewScroll1";
            this.extPanelDataGridViewScroll1.Size = new System.Drawing.Size(732, 330);
            this.extPanelDataGridViewScroll1.TabIndex = 4;
            this.extPanelDataGridViewScroll1.VerticalScrollBarDockRight = true;
            // 
            // extScrollBar1
            // 
            this.extScrollBar1.AlwaysHideScrollBar = false;
            this.extScrollBar1.ArrowBorderColor = System.Drawing.Color.LightBlue;
            this.extScrollBar1.ArrowButtonColor = System.Drawing.Color.LightGray;
            this.extScrollBar1.ArrowColorScaling = 0.5F;
            this.extScrollBar1.ArrowDownDrawAngle = 270F;
            this.extScrollBar1.ArrowUpDrawAngle = 90F;
            this.extScrollBar1.BorderColor = System.Drawing.Color.White;
            this.extScrollBar1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.extScrollBar1.HideScrollBar = false;
            this.extScrollBar1.LargeChange = 0;
            this.extScrollBar1.Location = new System.Drawing.Point(713, 0);
            this.extScrollBar1.Maximum = -1;
            this.extScrollBar1.Minimum = 0;
            this.extScrollBar1.MouseOverButtonColor = System.Drawing.Color.Green;
            this.extScrollBar1.MousePressedButtonColor = System.Drawing.Color.Red;
            this.extScrollBar1.Name = "extScrollBar1";
            this.extScrollBar1.Size = new System.Drawing.Size(19, 330);
            this.extScrollBar1.SliderColor = System.Drawing.Color.DarkGray;
            this.extScrollBar1.SmallChange = 1;
            this.extScrollBar1.TabIndex = 1;
            this.extScrollBar1.Text = "extScrollBar1";
            this.extScrollBar1.ThumbBorderColor = System.Drawing.Color.Yellow;
            this.extScrollBar1.ThumbButtonColor = System.Drawing.Color.DarkBlue;
            this.extScrollBar1.ThumbColorScaling = 0.5F;
            this.extScrollBar1.ThumbDrawAngle = 0F;
            this.extScrollBar1.Value = -1;
            this.extScrollBar1.ValueLimited = -1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.Size = new System.Drawing.Size(713, 330);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // extTabControl1
            // 
            this.extTabControl1.AllowDragReorder = false;
            this.extTabControl1.Controls.Add(this.tabPage1);
            this.extTabControl1.Controls.Add(this.tabPage2);
            this.extTabControl1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.extTabControl1.Location = new System.Drawing.Point(19, 30);
            this.extTabControl1.Name = "extTabControl1";
            this.extTabControl1.SelectedIndex = 0;
            this.extTabControl1.Size = new System.Drawing.Size(736, 100);
            this.extTabControl1.TabBackgroundColor = System.Drawing.Color.Transparent;
            this.extTabControl1.TabColorScaling = 0.5F;
            this.extTabControl1.TabControlBorderBrightColor = System.Drawing.Color.LightGray;
            this.extTabControl1.TabControlBorderColor = System.Drawing.Color.DarkGray;
            this.extTabControl1.TabDisabledScaling = 0.5F;
            this.extTabControl1.TabIndex = 3;
            this.extTabControl1.TabMouseOverColor = System.Drawing.Color.White;
            this.extTabControl1.TabNotSelectedBorderColor = System.Drawing.Color.Gray;
            this.extTabControl1.TabNotSelectedColor = System.Drawing.Color.Gray;
            this.extTabControl1.TabSelectedColor = System.Drawing.Color.LightGray;
            this.extTabControl1.TabStyle = tabStyleSquare1;
            this.extTabControl1.TextNotSelectedColor = System.Drawing.SystemColors.ControlText;
            this.extTabControl1.TextSelectedColor = System.Drawing.SystemColors.ControlText;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(728, 74);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // extComboBox1
            // 
            this.extComboBox1.BorderColor = System.Drawing.Color.White;
            this.extComboBox1.ButtonColorScaling = 0.5F;
            this.extComboBox1.DataSource = null;
            this.extComboBox1.DisableBackgroundDisabledShadingGradient = false;
            this.extComboBox1.DisplayMember = "";
            this.extComboBox1.DropDownBackgroundColor = System.Drawing.Color.Gray;
            this.extComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.extComboBox1.Location = new System.Drawing.Point(216, 524);
            this.extComboBox1.MouseOverBackgroundColor = System.Drawing.Color.Silver;
            this.extComboBox1.Name = "extComboBox1";
            this.extComboBox1.ScrollBarButtonColor = System.Drawing.Color.LightGray;
            this.extComboBox1.ScrollBarColor = System.Drawing.Color.LightGray;
            this.extComboBox1.SelectedIndex = -1;
            this.extComboBox1.SelectedItem = null;
            this.extComboBox1.SelectedValue = null;
            this.extComboBox1.Size = new System.Drawing.Size(181, 21);
            this.extComboBox1.TabIndex = 6;
            this.extComboBox1.Text = "extComboBox1";
            this.extComboBox1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.extComboBox1.ValueMember = "";
            // 
            // extCheckBox1
            // 
            this.extCheckBox1.AutoSize = true;
            this.extCheckBox1.CheckBoxColor = System.Drawing.Color.Gray;
            this.extCheckBox1.CheckBoxDisabledScaling = 0.5F;
            this.extCheckBox1.CheckBoxInnerColor = System.Drawing.Color.White;
            this.extCheckBox1.CheckColor = System.Drawing.Color.DarkBlue;
            this.extCheckBox1.ImageButtonDisabledScaling = 0.5F;
            this.extCheckBox1.ImageIndeterminate = null;
            this.extCheckBox1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.extCheckBox1.ImageUnchecked = null;
            this.extCheckBox1.Location = new System.Drawing.Point(439, 524);
            this.extCheckBox1.MouseOverColor = System.Drawing.Color.CornflowerBlue;
            this.extCheckBox1.Name = "extCheckBox1";
            this.extCheckBox1.Size = new System.Drawing.Size(95, 17);
            this.extCheckBox1.TabIndex = 7;
            this.extCheckBox1.Text = "extCheckBox1";
            this.extCheckBox1.TickBoxReductionRatio = 0.75F;
            this.extCheckBox1.UseVisualStyleBackColor = true;
            // 
            // DemonstrationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.extCheckBox1);
            this.Controls.Add(this.extComboBox1);
            this.Controls.Add(this.extButton1);
            this.Controls.Add(this.extPanelDataGridViewScroll1);
            this.Controls.Add(this.extTabControl1);
            this.Name = "DemonstrationUserControl";
            this.Size = new System.Drawing.Size(803, 643);
            this.extPanelDataGridViewScroll1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.extTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ExtendedControls.ExtTabControl extTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ExtendedControls.ExtPanelDataGridViewScroll extPanelDataGridViewScroll1;
        private ExtendedControls.ExtScrollBar extScrollBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private ExtendedControls.ExtButton extButton1;
        private ExtendedControls.ExtComboBox extComboBox1;
        private ExtendedControls.ExtCheckBox extCheckBox1;
    }
}
