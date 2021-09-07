using Dapper;
using DapperModels.Config;
using DapperModels.Models;
using DapperModels.Operations.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DapperModels.Operations;
using ModelGenerator.Process;

namespace DapperModels
{
    public partial class DapperModelCreator : Form
    {
        private IOperation _operation;
        private string _serverName;
        private string _userName;
        private string _password;

        public DapperModelCreator(IOperation operation)
        {
            InitializeComponent();
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            _serverName = ServerName.Text;
            _userName = UserName.Text;
            _password = Password.Text;

            if (!string.IsNullOrWhiteSpace(_serverName) && !string.IsNullOrWhiteSpace(_userName) && !string.IsNullOrWhiteSpace(_password))
            {
                try
                {

                    using (var con = new SqlConnection($"Data Source={_serverName};User ID={_userName};Password={_password}"))
                    {
                        con.Open();
                        DatabasesDropDown.DataSource = con.Query<string>("SELECT Name FROM master.dbo.sysdatabases");
                    }

                    //DatabasesDropDown.DataSource = Process.GetDataBases(serverName, userName, password);
                }
                catch(Exception es)
                {
                    DatabasesDropDown.DataSource = null;
                }
            }
        }

        private void DatabasesDropDown_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Start_Click(object sender, EventArgs e)
        {
            ModelGenerator.Config.Configuration.ConnectionString = $"Data Source={_serverName};Initial Catalog={DatabasesDropDown.Text};User ID={_userName};Password={_password}";
            Process.StartProcessing(DatabasesDropDown.Text, OutputPath.Text);
        }

        private void Testing_Click(object sender, EventArgs e)
        {
            //StartProcessing(DatabasesDropDown.Text, true);
            //Checking();
        }

        private void Checking()
        {
            //Context.ConnectionString = Configuration.GetConnectionString();
            ////var info = new Info { Name = "Sharique", Phone = "03432581909", Detail = "Detail" };

            ////Context.AddIntoDb(info);

            //var ob = Context.SelectWhere<Info>(x => x.Name == "Sharique");
            
            
        }
    }
}
