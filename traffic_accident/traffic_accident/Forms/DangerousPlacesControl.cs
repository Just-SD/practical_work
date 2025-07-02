using traffic_accident.Domain.Repositories;

namespace traffic_accident.Forms
{
    internal partial class DangerousPlacesControl : UserControl
    {
        public event Action BackButtonClicked;
        private List<PlaceSolution> placeSolutions;

        public DangerousPlacesControl(List<PlaceSolution> placeSolutions)
        {
            this.placeSolutions = placeSolutions;

            InitializeComponent();
        }

        public DangerousPlacesControl()
        {
            InitializeComponent();
        }

        private void TrafficAccidentControl_Load(object sender, EventArgs eventArgs)
        {
            int accountToOffset = 0;

            foreach (var placeSolution in placeSolutions)
            {
                CreateOncePanel(placeSolution, accountToOffset);
                accountToOffset++;
            }
        }

        private void CreateOncePanel(PlaceSolution placeSolution, int accountToOffset)
        {
            Panel oncePanel = new();
            Label labelAddress = new();
            ListView listViewTypesTA = new();
            ListBox listBoxTypesTA = new();
            Label label3 = new();
            Label label2 = new();
            ListBox listBoxSolutions = new ListBox();
            oncePanel.SuspendLayout();
            SuspendLayout();
            // 
            // oncePanel
            // 
            oncePanel.BorderStyle = BorderStyle.FixedSingle;
            oncePanel.Controls.Add(label3);
            oncePanel.Controls.Add(label2);
            oncePanel.Controls.Add(listBoxSolutions);
            oncePanel.Controls.Add(listBoxTypesTA);
            oncePanel.Controls.Add(labelAddress);
            oncePanel.Font = new Font("Segoe UI", 9F);
            oncePanel.Location = new Point(3, 56 + 361 * accountToOffset);
            oncePanel.Name = "oncePanel";
            oncePanel.Size = new Size(774, 339);
            oncePanel.TabIndex = 21;
            // 
            // listBoxTypesTA
            // 
            listBoxTypesTA.Font = new Font("Segoe UI", 10F);
            listBoxTypesTA.Location = new Point(8, 128);
            listBoxTypesTA.Size = new Size(758, 85);
            listBoxTypesTA.Name = "listBoxSolutions";
            listBoxTypesTA.TabIndex = 1;
            listBoxTypesTA.SelectionMode = SelectionMode.None;
            listBoxTypesTA.HorizontalScrollbar = false;
            listBoxTypesTA.ScrollAlwaysVisible = true;
            foreach (var type in placeSolution.MainTypesTrafficAccident)
                listBoxTypesTA.Items.Add(type);
            // 
            // labelAddress
            // 
            labelAddress.Font = new Font("Segoe UI", 15F);
            labelAddress.BorderStyle = BorderStyle.FixedSingle;
            labelAddress.Location = new Point(3, 3);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(766, 97);
            labelAddress.TabIndex = 0;
            labelAddress.Text = placeSolution.Address.Replace(';', ',');
            labelAddress.TextAlign = ContentAlignment.TopCenter;
            // 
            // listBoxSolutions
            // 
            listBoxSolutions.Font = new Font("Segoe UI", 10F);
            listBoxSolutions.Location = new Point(8, 240);
            listBoxSolutions.Size = new Size(758, 85);
            listBoxSolutions.Name = "listBoxSolutions";
            listBoxSolutions.TabIndex = 2;
            listBoxSolutions.SelectionMode = SelectionMode.None;
            listBoxSolutions.HorizontalScrollbar = false;
            listBoxSolutions.ScrollAlwaysVisible = true;
            foreach (var solution in placeSolution.PossibleSolutions)
                listBoxSolutions.Items.Add(solution);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(304, 107);
            label2.Name = "label2";
            label2.Size = new Size(167, 19);
            label2.TabIndex = 3;
            label2.Text = "Основные причины ДТП";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(311, 219);
            label3.Name = "label3";
            label3.Size = new Size(144, 19);
            label3.TabIndex = 4;
            label3.Text = "Возможные решения";

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
