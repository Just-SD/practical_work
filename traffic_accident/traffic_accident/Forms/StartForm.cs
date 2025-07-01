namespace traffic_accident.Forms
{
    internal partial class StartFrom : Form
    {
        public StartFrom()
        {
            InitializeComponent();
        }

        private void ShowTrafficAccidentControl(object sender, EventArgs e)
        {
            label1.Visible = false;
            buttonGetAllTA.Visible = false;
            buttonGetTAForPeriod.Visible = false;
            buttonFindPlace.Visible = false;

            panelMain.Controls.Clear();
            var control = new TrafficAccidentControl(DataBase.TrafficAccidentHandler.GetAllTrafficAccidents());
            control.Dock = DockStyle.Fill;

            control.BackButtonClicked += () =>
            {
                panelMain.Controls.Clear();

                label1.Visible = true;
                buttonGetAllTA.Visible = true;
                buttonGetTAForPeriod.Visible = true;
                buttonFindPlace.Visible = true;
            };

            panelMain.Controls.Add(control);
        }
    }
}
