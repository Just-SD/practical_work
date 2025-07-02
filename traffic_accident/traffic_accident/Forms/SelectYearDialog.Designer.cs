using traffic_accident.Domain.Repositories;

namespace traffic_accident.Forms
{
    partial class SelectYearDialog
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
            labelHeading = new Label();
            buttonFindDangerousPlaces = new Button();
            comboBoxYear = new ComboBox();
            SuspendLayout();
            // 
            // labelHeading
            // 
            labelHeading.Font = new Font("Segoe UI", 12F);
            labelHeading.Location = new Point(12, 5);
            labelHeading.Name = "labelHeading";
            labelHeading.Size = new Size(158, 38);
            labelHeading.TabIndex = 2;
            labelHeading.Text = "Выберите год";
            labelHeading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonFindDangerousPlaces
            // 
            buttonFindDangerousPlaces.Font = new Font("Segoe UI", 12F);
            buttonFindDangerousPlaces.Location = new Point(32, 121);
            buttonFindDangerousPlaces.Name = "buttonFindDangerousPlaces";
            buttonFindDangerousPlaces.Size = new Size(120, 33);
            buttonFindDangerousPlaces.TabIndex = 4;
            buttonFindDangerousPlaces.Text = "Найти";
            buttonFindDangerousPlaces.UseVisualStyleBackColor = true;
            buttonFindDangerousPlaces.Click += GetSelectedYear;
            // 
            // comboBoxYear
            // 
            comboBoxYear.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxYear.Font = new Font("Segoe UI", 13F);
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(57, 50);
            comboBoxYear.MaxDropDownItems = 3;
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(68, 31);
            comboBoxYear.TabIndex = 5;
            // 
            // SelectYearDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(182, 170);
            ControlBox = false;
            Controls.Add(comboBoxYear);
            Controls.Add(buttonFindDangerousPlaces);
            Controls.Add(labelHeading);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectYearDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += SelectYearDialog_Load;
            ResumeLayout(false);
        }

        #endregion
        private Label labelHeading;
        private Button buttonFindDangerousPlaces;
        private ComboBox comboBoxYear;
    }
}