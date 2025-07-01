using traffic_accident.Domain.Models;
using traffic_accident.Domain.Repositories;

namespace traffic_accident.Forms
{
    internal partial class TrafficAccidentControl : UserControl
    {
        public event Action BackButtonClicked;
        private List<TrafficAccident> trafficAccidents;

        public TrafficAccidentControl(List<TrafficAccident> trafficAccidents)
        {
            this.trafficAccidents = trafficAccidents;

            InitializeComponent();
        }

        private void TrafficAccidentControl_Load(object sender, EventArgs eventArgs)
        {
            int accountToOffset = 0;

            foreach (var trafficAccident in trafficAccidents)
            {
                CreateOncePanel(trafficAccident, accountToOffset);
                accountToOffset++;
            }
        }

        private void CreateOncePanel(TrafficAccident trafficAccident, int accountToOffset)
        {
            Panel oncePanel = new Panel();
            Label labelAddress = new Label();
            Label labelAddressHeading = new Label();
            Label labelNumbersHeading = new Label();
            ListBox listBoxNumbers = new ListBox();
            TextBox textBoxCauseDescription = new TextBox();
            TextBox textBoxTypeDescription = new TextBox();
            TextBox textBoxCause = new TextBox();
            Label labelCauseHeading = new Label();
            Label labelDate = new Label();
            TextBox textBoxType = new TextBox();
            oncePanel.SuspendLayout();
            SuspendLayout();
            // 
            // oncePanel
            // 
            oncePanel.BorderStyle = BorderStyle.FixedSingle;
            oncePanel.Controls.Add(labelAddress);
            oncePanel.Controls.Add(labelAddressHeading);
            oncePanel.Controls.Add(labelNumbersHeading);
            oncePanel.Controls.Add(listBoxNumbers);
            oncePanel.Controls.Add(textBoxCauseDescription);
            oncePanel.Controls.Add(textBoxTypeDescription);
            oncePanel.Controls.Add(textBoxCause);
            oncePanel.Controls.Add(labelCauseHeading);
            oncePanel.Controls.Add(labelDate);
            oncePanel.Controls.Add(textBoxType);
            oncePanel.Font = new Font("Segoe UI", 9F);
            oncePanel.Location = new Point(3, 63 + 322 * accountToOffset);
            oncePanel.Name = "panel1";
            oncePanel.Size = new Size(774, 296);
            oncePanel.TabIndex = 21;
            // 
            // labelAddress
            // 
            labelAddress.Font = new Font("Segoe UI", 12F);
            labelAddress.Location = new Point(3, 229);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(531, 61);
            labelAddress.TabIndex = 12;
            labelAddress.Text = trafficAccident.AddressTrafficAccident.Replace(';', '.');
            labelAddress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelAddressHeading
            // 
            labelAddressHeading.Font = new Font("Segoe UI", 12F);
            labelAddressHeading.Location = new Point(3, 198);
            labelAddressHeading.Name = "labelAddressHeading";
            labelAddressHeading.Size = new Size(531, 31);
            labelAddressHeading.TabIndex = 11;
            labelAddressHeading.Text = "Адрес";
            labelAddressHeading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelNumbersHeading
            // 
            labelNumbersHeading.Font = new Font("Segoe UI", 12F);
            labelNumbersHeading.Location = new Point(540, 198);
            labelNumbersHeading.Name = "labelNumbersHeading";
            labelNumbersHeading.Size = new Size(229, 43);
            labelNumbersHeading.TabIndex = 10;
            labelNumbersHeading.Text = $"Участников ДТП: {1+trafficAccident.CarNumbers.Length}";
            labelNumbersHeading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listBoxNumbers
            // 
            listBoxNumbers.Font = new Font("Segoe UI", 12F);
            listBoxNumbers.FormattingEnabled = true;
            listBoxNumbers.ItemHeight = 21;
            listBoxNumbers.Location = new Point(540, 244);
            listBoxNumbers.Items.Add(trafficAccident.CarNumber);
            if (trafficAccident.IsMultipleParticipants)
                foreach(var number in trafficAccident.CarNumbers)
                    listBoxNumbers.Items.Add(number);
            listBoxNumbers.Name = "listBoxNumbers";
            listBoxNumbers.Size = new Size(229, 46);
            listBoxNumbers.TabIndex = 9;
            // 
            // textBoxCauseDescription
            // 
            textBoxCauseDescription.Font = new Font("Segoe UI", 12F);
            textBoxCauseDescription.Location = new Point(451, 123);
            textBoxCauseDescription.Multiline = true;
            textBoxCauseDescription.Name = "textBoxCauseDescription";
            textBoxCauseDescription.ReadOnly = true;
            textBoxCauseDescription.ScrollBars = ScrollBars.Vertical;
            textBoxCauseDescription.Size = new Size(318, 72);
            textBoxCauseDescription.TabIndex = 8;
            if (trafficAccident.CauseDescription != null)
                textBoxCauseDescription.Text = trafficAccident.CauseDescription;
            textBoxCauseDescription.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxTypeDescription
            // 
            textBoxTypeDescription.Font = new Font("Segoe UI", 12F);
            textBoxTypeDescription.Location = new Point(451, 4);
            textBoxTypeDescription.Multiline = true;
            textBoxTypeDescription.Name = "textBoxTypeDescription";
            textBoxTypeDescription.ReadOnly = true;
            textBoxTypeDescription.ScrollBars = ScrollBars.Vertical;
            textBoxTypeDescription.Size = new Size(318, 72);
            textBoxTypeDescription.TabIndex = 7;
            if (trafficAccident.TypeDescription != null)
                textBoxTypeDescription.Text = trafficAccident.TypeDescription;
            textBoxTypeDescription.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxCause
            // 
            textBoxCause.Font = new Font("Segoe UI", 12F);
            textBoxCause.Location = new Point(3, 123);
            textBoxCause.Multiline = true;
            textBoxCause.Name = "textBoxCause";
            textBoxCause.ReadOnly = true;
            textBoxCause.ScrollBars = ScrollBars.Vertical;
            textBoxCause.Size = new Size(442, 72);
            textBoxCause.TabIndex = 6;
            textBoxCause.Text = CausesHandler.GetCauseName(trafficAccident);
            textBoxCause.TextAlign = HorizontalAlignment.Center;
            // 
            // labelCauseHeading
            // 
            labelCauseHeading.Font = new Font("Segoe UI", 12F);
            labelCauseHeading.Location = new Point(3, 79);
            labelCauseHeading.Name = "labelCauseHeading";
            labelCauseHeading.Size = new Size(442, 43);
            labelCauseHeading.TabIndex = 5;
            labelCauseHeading.Text = "Причина ДТП";
            labelCauseHeading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDate
            // 
            labelDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelDate.Location = new Point(3, 16);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(105, 48);
            labelDate.TabIndex = 4;
            labelDate.Text = $"Дата аварии\n{trafficAccident.Date}";
            labelDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxType
            // 
            textBoxType.Font = new Font("Segoe UI", 12F);
            textBoxType.Location = new Point(114, 4);
            textBoxType.Multiline = true;
            textBoxType.Name = "textBoxType";
            textBoxType.ReadOnly = true;
            textBoxType.ScrollBars = ScrollBars.Vertical;
            textBoxType.Size = new Size(331, 72);
            textBoxType.TabIndex = 3;
            textBoxType.Text = TypeHandler.GetTypeName(trafficAccident);
            textBoxType.TextAlign = HorizontalAlignment.Center;

            this.Controls.Add(oncePanel);
            oncePanel.ResumeLayout();
            ResumeLayout();
        }

        private void GoToMain(object sender, EventArgs e)
        {
            BackButtonClicked.Invoke();
        }
    }
}
