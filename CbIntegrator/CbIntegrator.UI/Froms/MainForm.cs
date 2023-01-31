using CbIntegrator.Bussynes.Services;
using CbIntegrator.Bussynes.Models;
using CbIntegrator.UI.Froms;
using System.Data;
using CbIntegrator.Bussynes.Tools;
using CbIntegrator.Bussynes.Repositories;

namespace CbIntegrator.UI
{
	public partial class MainForm : Form
	{
        
        private readonly CbDataService service = new();
        private readonly IUsersRepository repository;
        DataTable curs = new();
        private List<string> settings;

        public MainForm(IUsersRepository repository)
		{
			InitializeComponent();
            this.repository = repository;
		}

        private void MainForm_Load(object sender, EventArgs e)
        {
            curs = service.GetTodayCurs();
            //var tables = DataTableExtentions.SplitTable(curs,10);
            if (curs != null)
            {

                SetSettings();
                SetDataGrid(curs);
            }
            else
            {
                MessageBox.Show("������ ����������� � ��� ��������");
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                SetDataGrid(curs);
            });

        }
        private void SetDataGrid(DataTable curs)
        {
            DataTable newDt = curs.Clone();
            newDt.TableName = "Table";
            newDt.Clear();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = true;
            foreach(var a in checkedListBox1.CheckedItems)
            {
                foreach (DataRow row in curs.Rows)
                {
                    if (a == row[0])
                    {
                        DataRow newRow = newDt.NewRow();
                        newRow.ItemArray = row.ItemArray;
                        newDt.Rows.Add(newRow);
                    }
                }
            }
            dataGridView1.DataSource = newDt;
        }
        private void SetSettings()
        {
            checkedListBox1.Items.Clear();
            var userCurses = repository.GetUserCurse(CurrentUser.Login);
            var check = false;
            //TODO: ���� ����� ����
            if (userCurses != null)
            {
                for (var i = 0; i < curs.Rows.Count; i++)
                {
                    foreach (var userCurs in userCurses)
                    {
                        if (userCurs.Replace(" ", "") == curs.Rows[i][0].ToString().Replace(" ", ""))
                        {
                            checkedListBox1.Items.Add(curs.Rows[i][0].ToString(), CheckState.Checked);
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        checkedListBox1.Items.Add(curs.Rows[i][0].ToString());
                    }
                    check = false;
                }
            }
            else
            {
                for (var i = 0; i < curs.Rows.Count; i++)
                {
                    checkedListBox1.Items.Add(curs.Rows[i][0].ToString());
                }
            }
        }
    }
}