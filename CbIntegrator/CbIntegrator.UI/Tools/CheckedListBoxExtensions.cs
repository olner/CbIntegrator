using CbIntegrator.Bussynes.Repositories;
using CbIntegrator.Bussynes.Models;
using System.Data;

namespace CbIntegrator.UI.Tools
{
    internal class CheckedListBoxExtensions
    {
        public static CheckedListBox SetSettings(IUsersRepository repository,DataTable curs)
        {
            var checkBox = new CheckedListBox();
            var userCurses = repository.GetUserCurse(CurrentUser.Login);
            var check = false;
            if (userCurses != null)
            {
                for (var i = 0; i < curs.Rows.Count; i++)
                {
                    foreach (var userCurs in userCurses)
                    {
                        if (userCurs.Replace(" ", "") == curs.Rows[i][0].ToString().Replace(" ", ""))
                        {
                            checkBox.Items.Add(curs.Rows[i][0].ToString(), CheckState.Checked);
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        checkBox.Items.Add(curs.Rows[i][0].ToString());
                    }
                    check = false;
                }
            }
            else
            {
                for (var i = 0; i < curs.Rows.Count; i++)
                {
                    checkBox.Items.Add(curs.Rows[i][0].ToString());
                }
            }
            return checkBox;
        }
    }
}
