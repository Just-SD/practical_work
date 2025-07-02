using System.Windows.Forms;

namespace traffic_accident.Forms
{
    partial class DangerousPlacesControl
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
            buttonGoMain = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonGoMain
            // 
            buttonGoMain.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            buttonGoMain.Location = new Point(12, 10);
            buttonGoMain.Name = "buttonGoMain";
            buttonGoMain.Size = new Size(38, 36);
            buttonGoMain.TabIndex = 20;
            buttonGoMain.Text = "❮";
            buttonGoMain.UseVisualStyleBackColor = true;
            buttonGoMain.Click += GoToMain;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.Location = new Point(100, 0);
            label1.Name = "label1";
            label1.Size = new Size(600, 46);
            label1.TabIndex = 21;
            label1.Text = "Места с высоким риском ДТП";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DangerousPlacesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(label1);
            Controls.Add(buttonGoMain);
            Name = "DangerousPlacesControl";
            Size = new Size(800, 450);
            Load += TrafficAccidentControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonGoMain;
        private Label label1;
    }
}