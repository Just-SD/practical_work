using traffic_accident.Domain.Repositories;

namespace traffic_accident.Forms
{
    internal partial class SelectPeriodDialog : Form
    {
        private bool allowClose = false;

        public DateTime LowerDate { get; private set; }
        public DateTime UpperDate { get; private set; }

        public SelectPeriodDialog()
        {
            InitializeComponent();
        }

        private void SelectPeriodDialog_Load(object sender, EventArgs e)
        {
            dateTimePickerLowerLimit.MaxDate = DateTime.Today;
            dateTimePickerUpperLimit.MaxDate = DateTime.Today;
            dateTimePickerLowerLimit.MinDate = DateHandler.GetEarliestDateTrafficAccident();
            dateTimePickerUpperLimit.MinDate = dateTimePickerLowerLimit.MinDate;
        }

        private void FindTAForPeriod(object sender, EventArgs e)
        {
            DateTime lowerDate = dateTimePickerLowerLimit.Value;
            DateTime upperDate = dateTimePickerUpperLimit.Value;

            if (upperDate >= lowerDate)
            {
                LowerDate = lowerDate;
                UpperDate = upperDate;

                this.DialogResult = DialogResult.Continue;
                allowClose = true;
                this.Close();
            }
            else
            {
                MessageBox.Show($"Неверно выбран период.\nИзменить данные и попробуйте ещё раз.");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!allowClose && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Блокирует закрытие alt + f4
            }

            base.OnFormClosing(e);
        }
    }
}
