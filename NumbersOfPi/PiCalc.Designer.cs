namespace NumbersOfPi
{
    partial class PiCalc
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
            this.components = new System.ComponentModel.Container();
            this._digits = new System.Windows.Forms.NumericUpDown();
            this.calcBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtBoxPi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtBox_StopWatch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._digits)).BeginInit();
            this.SuspendLayout();
            // 
            // _digits
            // 
            this._digits.Location = new System.Drawing.Point(101, 31);
            this._digits.Name = "_digits";
            this._digits.Size = new System.Drawing.Size(55, 20);
            this._digits.TabIndex = 0;
            // 
            // calcBtn
            // 
            this.calcBtn.Location = new System.Drawing.Point(175, 31);
            this.calcBtn.Name = "calcBtn";
            this.calcBtn.Size = new System.Drawing.Size(75, 23);
            this.calcBtn.TabIndex = 1;
            this.calcBtn.Text = "Calculate";
            this.calcBtn.UseVisualStyleBackColor = true;
            this.calcBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 229);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(293, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 1;
            // 
            // txtBoxPi
            // 
            this.txtBoxPi.Location = new System.Drawing.Point(0, 78);
            this.txtBoxPi.Multiline = true;
            this.txtBoxPi.Name = "txtBoxPi";
            this.txtBoxPi.Size = new System.Drawing.Size(293, 98);
            this.txtBoxPi.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Digits of Pi:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // txtBox_StopWatch
            // 
            this.txtBox_StopWatch.Location = new System.Drawing.Point(193, 194);
            this.txtBox_StopWatch.Name = "txtBox_StopWatch";
            this.txtBox_StopWatch.Size = new System.Drawing.Size(100, 20);
            this.txtBox_StopWatch.TabIndex = 5;
            // 
            // PiCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 252);
            this.Controls.Add(this.txtBox_StopWatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxPi);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.calcBtn);
            this.Controls.Add(this._digits);
            this.Name = "PiCalc";
            this.Text = "Digits of Pi";
            this.Load += new System.EventHandler(this.PiCalc_Load);
            ((System.ComponentModel.ISupportInitialize)(this._digits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown _digits;
        private System.Windows.Forms.Button calcBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtBoxPi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtBox_StopWatch;
    }
}

