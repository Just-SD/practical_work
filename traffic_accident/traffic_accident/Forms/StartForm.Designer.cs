namespace traffic_accident.Forms
{
    partial class StartFrom
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
            label1 = new Label();
            buttonGetAllTA = new Button();
            buttonGetTAForPeriod = new Button();
            buttonFindPlace = new Button();
            panelMain = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(776, 80);
            label1.TabIndex = 0;
            label1.Text = "Система выявления мест с потенциально высоким риском ДТП";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonGetAllTA
            // 
            buttonGetAllTA.Font = new Font("Segoe UI", 15F);
            buttonGetAllTA.Location = new Point(130, 208);
            buttonGetAllTA.Name = "buttonGetAllTA";
            buttonGetAllTA.Size = new Size(227, 82);
            buttonGetAllTA.TabIndex = 1;
            buttonGetAllTA.Text = "Все ДТП";
            buttonGetAllTA.UseVisualStyleBackColor = true;
            buttonGetAllTA.Click += ShowTrafficAccidentControl;
            // 
            // buttonGetTAForPeriod
            // 
            buttonGetTAForPeriod.Font = new Font("Segoe UI", 15F);
            buttonGetTAForPeriod.Location = new Point(433, 208);
            buttonGetTAForPeriod.Name = "buttonGetTAForPeriod";
            buttonGetTAForPeriod.Size = new Size(227, 82);
            buttonGetTAForPeriod.TabIndex = 2;
            buttonGetTAForPeriod.Text = "ДТП за выбранный период";
            buttonGetTAForPeriod.UseVisualStyleBackColor = true;
            buttonGetTAForPeriod.Click += ShowTrafficAccidentForPeriod;
            // 
            // buttonFindPlace
            // 
            buttonFindPlace.Font = new Font("Segoe UI", 15F);
            buttonFindPlace.Location = new Point(90, 315);
            buttonFindPlace.Name = "buttonFindPlace";
            buttonFindPlace.Size = new Size(620, 82);
            buttonFindPlace.TabIndex = 3;
            buttonFindPlace.Text = "Найти места с высоким риском ДТП";
            buttonFindPlace.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(800, 450);
            panelMain.TabIndex = 4;
            // 
            // StartFrom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonFindPlace);
            Controls.Add(buttonGetTAForPeriod);
            Controls.Add(buttonGetAllTA);
            Controls.Add(label1);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "StartFrom";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;

        private Label label1;
        private Button buttonGetAllTA;
        private Button buttonGetTAForPeriod;
        private Button buttonFindPlace;
    }
}