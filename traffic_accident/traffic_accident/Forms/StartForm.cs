using traffic_accident.Domain.Repositories;

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
            InvisibleAll();

            panelMain.Controls.Clear();
            var control = new TrafficAccidentControl(DataBase.TrafficAccidentHandler.GetAllTrafficAccidents());
            control.Dock = DockStyle.Fill;

            control.BackButtonClicked += () =>
            {
                panelMain.Controls.Clear();

                VisibleAll();
            };

            panelMain.Controls.Add(control);
        }

        private void ShowTrafficAccidentForPeriod(object sender, EventArgs e)
        {
            this.Enabled = false;

            using (var dialog = new SelectPeriodDialog())
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.Continue)
                {
                    this.Enabled = true;
                    InvisibleAll();

                    var control =
                        new TrafficAccidentControl(DataBase.TrafficAccidentHandler
                        .GetTrafficAccidentsForPeriod(dialog.LowerDate, dialog.UpperDate));
                    control.Dock = DockStyle.Fill;

                    control.BackButtonClicked += () =>
                    {
                        panelMain.Controls.Clear();

                        VisibleAll();
                    };

                    panelMain.Controls.Add(control);
                }
            }
        }

        private void ShowDangerousPlaces(object sender, EventArgs e)
        {
            this.Enabled = false;

            using (var dialog = new SelectYearDialog())
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.Continue)
                {
                    this.Enabled = true;
                    InvisibleAll();

                    List<PlaceSolution> placeSolutions = new();

                    foreach (var address in AddressHandler.GetDangerousPlacesInYear(dialog.SelectedYear))
                        placeSolutions.Add(new PlaceSolution(address));

                    var control = new DangerousPlacesControl(placeSolutions);

                    control.Dock = DockStyle.Fill;

                    control.BackButtonClicked += () =>
                    {
                        panelMain.Controls.Clear();

                        VisibleAll();
                    };

                    panelMain.Controls.Add(control);
                }
            }
        }

        private void InvisibleAll()
        {
            label1.Visible = false;
            buttonGetAllTA.Visible = false;
            buttonGetTAForPeriod.Visible = false;
            buttonFindPlace.Visible = false;
        }

        private void VisibleAll()
        {
            label1.Visible = true;
            buttonGetAllTA.Visible = true;
            buttonGetTAForPeriod.Visible = true;
            buttonFindPlace.Visible = true;
        }
    }
}
