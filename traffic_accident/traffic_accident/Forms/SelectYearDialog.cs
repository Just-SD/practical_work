using traffic_accident.Domain.Repositories;

namespace traffic_accident.Forms
{
    internal partial class SelectYearDialog : Form
    {
        private bool allowClose = false;
        public int SelectedYear { get; private set; }

        public SelectYearDialog()
        {
            InitializeComponent();
        }

        private void SelectYearDialog_Load(object sender, EventArgs e)
        {
            List<int> availableYears = new();

            foreach (var year in DateHandler.GetAvailableYears())
                availableYears.Add(year);

            comboBoxYear.DataSource = availableYears;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!allowClose && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Блокирует закрытие alt + f4
            }

            base.OnFormClosing(e);
        }

        private void GetSelectedYear(object sender, EventArgs e)
        {
            if (comboBoxYear.SelectedItem == null)
                return;
            SelectedYear = (int)comboBoxYear.SelectedItem;

            this.DialogResult = DialogResult.Continue;
            allowClose = true;
            this.Close();
        }
    }
}
