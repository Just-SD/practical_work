namespace traffic_accident.Forms
{
    partial class SelectPeriodDialog
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
            dateTimePickerLowerLimit = new DateTimePicker();
            dateTimePickerUpperLimit = new DateTimePicker();
            labelHeading = new Label();
            labelDash = new Label();
            buttonFindTAForPeriod = new Button();
            SuspendLayout();
            // 
            // dateTimePickerLowerLimit
            // 
            dateTimePickerLowerLimit.Font = new Font("Segoe UI", 12F);
            dateTimePickerLowerLimit.Location = new Point(5, 61);
            dateTimePickerLowerLimit.Name = "dateTimePickerLowerLimit";
            dateTimePickerLowerLimit.Size = new Size(183, 29);
            dateTimePickerLowerLimit.TabIndex = 0;
            // 
            // dateTimePickerUpperLimit
            // 
            dateTimePickerUpperLimit.Font = new Font("Segoe UI", 12F);
            dateTimePickerUpperLimit.Location = new Point(213, 61);
            dateTimePickerUpperLimit.Name = "dateTimePickerUpperLimit";
            dateTimePickerUpperLimit.Size = new Size(183, 29);
            dateTimePickerUpperLimit.TabIndex = 1;
            // 
            // labelHeading
            // 
            labelHeading.Font = new Font("Segoe UI", 12F);
            labelHeading.Location = new Point(0, 0);
            labelHeading.Name = "labelHeading";
            labelHeading.Size = new Size(402, 38);
            labelHeading.TabIndex = 2;
            labelHeading.Text = "Выберите период";
            labelHeading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDash
            // 
            labelDash.AutoSize = true;
            labelDash.Font = new Font("Segoe UI", 12F);
            labelDash.Location = new Point(193, 64);
            labelDash.Name = "labelDash";
            labelDash.Size = new Size(16, 21);
            labelDash.TabIndex = 3;
            labelDash.Text = "-";
            // 
            // buttonFindTAForPeriod
            // 
            buttonFindTAForPeriod.Font = new Font("Segoe UI", 12F);
            buttonFindTAForPeriod.Location = new Point(141, 111);
            buttonFindTAForPeriod.Name = "buttonFindTAForPeriod";
            buttonFindTAForPeriod.Size = new Size(120, 33);
            buttonFindTAForPeriod.TabIndex = 4;
            buttonFindTAForPeriod.Text = "Найти";
            buttonFindTAForPeriod.UseVisualStyleBackColor = true;
            buttonFindTAForPeriod.Click += FindTAForPeriod;
            // 
            // SelectPeriodDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 159);
            ControlBox = false;
            Controls.Add(buttonFindTAForPeriod);
            Controls.Add(labelDash);
            Controls.Add(labelHeading);
            Controls.Add(dateTimePickerUpperLimit);
            Controls.Add(dateTimePickerLowerLimit);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectPeriodDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += SelectPeriodDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePickerLowerLimit;
        private DateTimePicker dateTimePickerUpperLimit;
        private Label labelHeading;
        private Label labelDash;
        private Button buttonFindTAForPeriod;
    }
}