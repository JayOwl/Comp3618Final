namespace AsyncNumbersOfPi
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
            this._digits = new System.Windows.Forms.NumericUpDown();
            this._calcButton = new System.Windows.Forms.Button();
            this._pi = new System.Windows.Forms.TextBox();
            this._piProgress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.WorkerThread = new System.ComponentModel.BackgroundWorker();
            this.TimeInfo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._digits)).BeginInit();
            this.SuspendLayout();
            // 
            // _digits
            // 
            this._digits.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._digits.Location = new System.Drawing.Point(135, 12);
            this._digits.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._digits.Name = "_digits";
            this._digits.Size = new System.Drawing.Size(120, 29);
            this._digits.TabIndex = 0;
            // 
            // _calcButton
            // 
            this._calcButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._calcButton.Location = new System.Drawing.Point(261, 12);
            this._calcButton.Name = "_calcButton";
            this._calcButton.Size = new System.Drawing.Size(237, 31);
            this._calcButton.TabIndex = 1;
            this._calcButton.Text = "Calculate (Async)";
            this._calcButton.UseVisualStyleBackColor = true;
            this._calcButton.Click += new System.EventHandler(this._calcButton_Click);
            // 
            // _pi
            // 
            this._pi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._pi.Location = new System.Drawing.Point(16, 49);
            this._pi.Multiline = true;
            this._pi.Name = "_pi";
            this._pi.ReadOnly = true;
            this._pi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._pi.Size = new System.Drawing.Size(482, 392);
            this._pi.TabIndex = 2;
            // 
            // _piProgress
            // 
            this._piProgress.Location = new System.Drawing.Point(12, 482);
            this._piProgress.Name = "_piProgress";
            this._piProgress.Size = new System.Drawing.Size(485, 23);
            this._piProgress.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Digits of Pi:";
            // 
            // TimeInfo
            // 
            this.TimeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeInfo.Location = new System.Drawing.Point(12, 447);
            this.TimeInfo.Name = "TimeInfo";
            this.TimeInfo.ReadOnly = true;
            this.TimeInfo.Size = new System.Drawing.Size(486, 29);
            this.TimeInfo.TabIndex = 5;
            // 
            // PiCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(510, 517);
            this.Controls.Add(this.TimeInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._piProgress);
            this.Controls.Add(this._pi);
            this.Controls.Add(this._calcButton);
            this.Controls.Add(this._digits);
            this.Name = "PiCalc";
            this.Text = "Async Pi Calculator";
            ((System.ComponentModel.ISupportInitialize)(this._digits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown _digits;
        private System.Windows.Forms.Button _calcButton;
        private System.Windows.Forms.TextBox _pi;
        private System.Windows.Forms.ProgressBar _piProgress;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker WorkerThread;
        private System.Windows.Forms.TextBox TimeInfo;
    }
}

