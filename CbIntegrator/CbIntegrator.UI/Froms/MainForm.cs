using CbIntegrator.Bussynes.Services;
using CbIntegrator.UI.Froms;
using System.Data;

namespace CbIntegrator.UI
{
	public partial class MainForm : Form
	{
        readonly CbDataService service = new();
        public MainForm()
		{
			InitializeComponent();
		}

        private void MainForm_Load(object sender, EventArgs e)
        {
            //checkedListBox1.MultiColumn = true;
            var curs = service.GetTodayCurs();
            if (curs != null)
            {
                for (var i = 0; i < curs.Rows.Count; i++)
                {
                    checkedListBox1.Items.Add(curs.Rows[i][0].ToString());
                }
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = curs;
            }
            else
            {
                MessageBox.Show("Ошибка подключения к веб серивису");
            }
        }
    }
}