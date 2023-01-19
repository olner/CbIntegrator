using CbIntegrator.Bussynes.Services;
namespace CbIntegrator.UI
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

        private void MainForm_Load(object sender, EventArgs e)
        {
            checkedListBox1.MultiColumn = true;
            var service = new CbDataService();
            var ds = service.GetTodayCurs();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds;
        }
    }
}