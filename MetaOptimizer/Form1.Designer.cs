namespace MetaOptimizer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.servicemode = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.state_Label = new System.Windows.Forms.Label();
            this.default_Button = new System.Windows.Forms.Button();
            this.steamvr_Button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("M PLUS 1", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "MetaOptimizer Alpha";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText,
            this.servicemode});
            this.statusStrip1.Location = new System.Drawing.Point(0, 153);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(339, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusText
            // 
            this.statusText.AutoSize = false;
            this.statusText.BackColor = System.Drawing.SystemColors.Control;
            this.statusText.ForeColor = System.Drawing.Color.Black;
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(160, 17);
            this.statusText.Text = "Welcome to MetaOptimizer!";
            this.statusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // servicemode
            // 
            this.servicemode.AutoSize = false;
            this.servicemode.BackColor = System.Drawing.SystemColors.Control;
            this.servicemode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.servicemode.Name = "servicemode";
            this.servicemode.Size = new System.Drawing.Size(160, 17);
            this.servicemode.Text = "Status:";
            this.servicemode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.Font = new System.Drawing.Font("M PLUS 1", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "----------------------- Mode -----------------------";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // state_Label
            // 
            this.state_Label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.state_Label.Font = new System.Drawing.Font("M PLUS 1", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.state_Label.ForeColor = System.Drawing.Color.White;
            this.state_Label.Location = new System.Drawing.Point(29, 69);
            this.state_Label.Name = "state_Label";
            this.state_Label.Size = new System.Drawing.Size(278, 48);
            this.state_Label.TabIndex = 4;
            this.state_Label.Text = "Loading...";
            this.state_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // default_Button
            // 
            this.default_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.default_Button.Location = new System.Drawing.Point(92, 120);
            this.default_Button.Name = "default_Button";
            this.default_Button.Size = new System.Drawing.Size(75, 23);
            this.default_Button.TabIndex = 0;
            this.default_Button.Text = "Default";
            this.default_Button.UseVisualStyleBackColor = true;
            this.default_Button.Click += new System.EventHandler(this.default_Button_Click);
            // 
            // steamvr_Button
            // 
            this.steamvr_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.steamvr_Button.Location = new System.Drawing.Point(173, 120);
            this.steamvr_Button.Name = "steamvr_Button";
            this.steamvr_Button.Size = new System.Drawing.Size(75, 23);
            this.steamvr_Button.TabIndex = 1;
            this.steamvr_Button.Text = "SteamVR";
            this.steamvr_Button.UseVisualStyleBackColor = true;
            this.steamvr_Button.Click += new System.EventHandler(this.steamvr_Button_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(339, 175);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.state_Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.steamvr_Button);
            this.Controls.Add(this.default_Button);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "MetaOptimizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.ToolStripStatusLabel servicemode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label state_Label;
        private System.Windows.Forms.Button default_Button;
        private System.Windows.Forms.Button steamvr_Button;
        private System.Windows.Forms.Timer timer1;
    }
}

