namespace Demos
{
    partial class ScatterDemo
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
            this.panelInteraction = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonBottom = new System.Windows.Forms.Button();
            this.buttonTop = new System.Windows.Forms.Button();
            this.buttonFront = new System.Windows.Forms.Button();
            this.buttonQuarter = new System.Windows.Forms.Button();
            this.labelViewMode = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelChart = new System.Windows.Forms.Panel();
            this.renderer3D1 = new EDD3D.Plot3D.Rendering.View.Renderer3D();
            this.panelInteraction.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInteraction
            // 
            this.panelInteraction.Controls.Add(this.buttonBack);
            this.panelInteraction.Controls.Add(this.buttonLeft);
            this.panelInteraction.Controls.Add(this.buttonRight);
            this.panelInteraction.Controls.Add(this.buttonBottom);
            this.panelInteraction.Controls.Add(this.buttonTop);
            this.panelInteraction.Controls.Add(this.buttonFront);
            this.panelInteraction.Controls.Add(this.buttonQuarter);
            this.panelInteraction.Controls.Add(this.labelViewMode);
            this.panelInteraction.Controls.Add(this.comboBox1);
            this.panelInteraction.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInteraction.Location = new System.Drawing.Point(0, 0);
            this.panelInteraction.Name = "panelInteraction";
            this.panelInteraction.Size = new System.Drawing.Size(160, 600);
            this.panelInteraction.TabIndex = 1;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(19, 286);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(121, 23);
            this.buttonBack.TabIndex = 8;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(20, 253);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(121, 23);
            this.buttonLeft.TabIndex = 7;
            this.buttonLeft.Text = "Left";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(19, 220);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(121, 23);
            this.buttonRight.TabIndex = 6;
            this.buttonRight.Text = "Right";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonBottom
            // 
            this.buttonBottom.Location = new System.Drawing.Point(20, 319);
            this.buttonBottom.Name = "buttonBottom";
            this.buttonBottom.Size = new System.Drawing.Size(121, 23);
            this.buttonBottom.TabIndex = 5;
            this.buttonBottom.Text = "Bottom";
            this.buttonBottom.UseVisualStyleBackColor = true;
            this.buttonBottom.Click += new System.EventHandler(this.buttonBottom_Click);
            // 
            // buttonTop
            // 
            this.buttonTop.Location = new System.Drawing.Point(19, 154);
            this.buttonTop.Name = "buttonTop";
            this.buttonTop.Size = new System.Drawing.Size(121, 23);
            this.buttonTop.TabIndex = 4;
            this.buttonTop.Text = "Top";
            this.buttonTop.UseVisualStyleBackColor = true;
            this.buttonTop.Click += new System.EventHandler(this.buttonTop_Click);
            // 
            // buttonFront
            // 
            this.buttonFront.Location = new System.Drawing.Point(20, 187);
            this.buttonFront.Name = "buttonFront";
            this.buttonFront.Size = new System.Drawing.Size(121, 23);
            this.buttonFront.TabIndex = 3;
            this.buttonFront.Text = "Front";
            this.buttonFront.UseVisualStyleBackColor = true;
            this.buttonFront.Click += new System.EventHandler(this.buttonFront_Click);
            // 
            // buttonQuarter
            // 
            this.buttonQuarter.Location = new System.Drawing.Point(19, 103);
            this.buttonQuarter.Name = "buttonQuarter";
            this.buttonQuarter.Size = new System.Drawing.Size(121, 23);
            this.buttonQuarter.TabIndex = 2;
            this.buttonQuarter.Text = "Quarter View";
            this.buttonQuarter.UseVisualStyleBackColor = true;
            this.buttonQuarter.Click += new System.EventHandler(this.buttonQuarter_Click);
            // 
            // labelViewMode
            // 
            this.labelViewMode.AutoSize = true;
            this.labelViewMode.Location = new System.Drawing.Point(20, 27);
            this.labelViewMode.Name = "labelViewMode";
            this.labelViewMode.Size = new System.Drawing.Size(60, 13);
            this.labelViewMode.TabIndex = 1;
            this.labelViewMode.Text = "View Mode";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "FREE",
            "PROFILE",
            "TOP",
            "FRONT"});
            this.comboBox1.Location = new System.Drawing.Point(19, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMemberChanged += new System.EventHandler(this.comboBox1_ValueMemberChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelChart);
            this.panelMain.Controls.Add(this.panelInteraction);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(782, 600);
            this.panelMain.TabIndex = 2;
            // 
            // panelChart
            // 
            this.panelChart.AutoSize = true;
            this.panelChart.Controls.Add(this.renderer3D1);
            this.panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChart.Location = new System.Drawing.Point(160, 0);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(622, 600);
            this.panelChart.TabIndex = 2;
            // 
            // renderer3D1
            // 
            this.renderer3D1.BackColor = System.Drawing.Color.Black;
            this.renderer3D1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderer3D1.Location = new System.Drawing.Point(0, 0);
            this.renderer3D1.Name = "renderer3D1";
            this.renderer3D1.Size = new System.Drawing.Size(622, 600);
            this.renderer3D1.TabIndex = 0;
            this.renderer3D1.VSync = false;
            this.renderer3D1.Load += new System.EventHandler(this.renderer3D1_Load);
            this.renderer3D1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.renderer3D1_KeyDown);
            this.renderer3D1.Move += new System.EventHandler(this.renderer3D1_Move);
            this.renderer3D1.Resize += new System.EventHandler(this.renderer3D1_Resize);
            // 
            // ScatterDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 600);
            this.Controls.Add(this.panelMain);
            this.MinimumSize = new System.Drawing.Size(760, 600);
            this.Name = "ScatterDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scatter Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScatterForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScatterDemo_KeyDown);
            this.panelInteraction.ResumeLayout(false);
            this.panelInteraction.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelChart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EDD3D.Plot3D.Rendering.View.Renderer3D renderer3D1;
        private System.Windows.Forms.Panel panelInteraction;
        private System.Windows.Forms.Label labelViewMode;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.Button buttonBottom;
        private System.Windows.Forms.Button buttonTop;
        private System.Windows.Forms.Button buttonFront;
        private System.Windows.Forms.Button buttonQuarter;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
    }
}