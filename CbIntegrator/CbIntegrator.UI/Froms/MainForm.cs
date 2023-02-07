using CbIntegrator.Bussynes.Services;
using CbIntegrator.Bussynes.Models;
using System.Data;
using CbIntegrator.Bussynes.Repositories;
using CbIntegrator.UI.Tools;
using CbIntegrator.Bussynes.Tools;

namespace CbIntegrator.UI
{
    public partial class MainForm : Form
    {

        private readonly ICbDataService service;
        private readonly IUsersRepository repository;
        DataTable curs = new();
        List<DataTable> tables = new();
        bool dontRunHandler = true;

        public MainForm(IUsersRepository repository,ICbDataService service)
        {
            InitializeComponent();
            this.repository = repository;
            this.service = service;
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = true;
            curs = service.GetTodayCurs();
            if (curs != null)
            {
                SetSettings();
                tables = DataTableExtentions.SplitTable(curs, 10,GetSelectedItemsName());
                SetPagination();
                //SetDataGrid(tables[0]);
                dataGridView1.DataSource = tables[0];
            }
            else
            {
                MessageBox.Show("Ошибка подключения к веб серивису");
            }
        }
        private List<string> GetSelectedItemsName()
        {
            List<string> items = new();
            foreach(var item in checkedListBox1.CheckedItems)
            {
                items.Add(item.ToString());
            }
            return items;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (dontRunHandler) return;
                if (e.NewValue == CheckState.Checked)
                {
                    ValueRefresh();
                    var items = checkedListBox1.Items;
                    repository.AddUserCurs(CurrentUser.Login, items[e.Index].ToString());
                }
                else
                {
                    ValueRefresh();
                    var items = checkedListBox1.Items;
                    repository.DeleteUserCurs(CurrentUser.Login, items[e.Index].ToString());
                }
            });
        }
        private void ValueRefresh()
        {
            tables = DataTableExtentions.SplitTable(curs, 10, GetSelectedItemsName());
            //SetDataGrid(tables[listBox1.SelectedIndex]);
            dataGridView1.DataSource = tables[listBox1.SelectedIndex];
            SetPagination();
        }
    
        private void SetSettings()
        {
            checkedListBox1.Items.Clear();
            var checkBox = CheckedListBoxExtensions.SetSettings(repository, curs);
            foreach(var item in checkBox.Items)
                checkedListBox1.Items.Add(item);
            for (int i = 0; i < checkBox.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, checkBox.GetItemChecked(i));
        }
        private void SetPagination()
        {
            listBox1.Items.Clear();
            for(var i = 0; i < tables.Count; i++)
            {
                listBox1.Items.Add("Страница " + (i + 1));
            }
            listBox1.SelectedIndex = 0;
        }


        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            dontRunHandler = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tables[listBox1.SelectedIndex];
        }
    }
}