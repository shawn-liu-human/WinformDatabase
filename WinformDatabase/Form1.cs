using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dapper;

namespace WinformDatabase
{
    public partial class Form1 : Form
    {
        IDbConnection connection;

        public Form1(IDbConnection connection)
        {
            InitializeComponent();

            this.connection = connection;
            dataInit();
        }

        private void dataInit()
        { 
            // 初始化, 创建数据库表并插入测试数据.
            connection.Execute(@"
                drop database Practice
                drop table Account
                create database Practice
                create table Account(UserName varchar, Password varchar) 
                insert into Account values('a', 'b')
                ");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // 查询对应的用户名密码是否存在
            var account = connection.Query("select * from Account where UserName = @userName and password = @password", 
                new { userName = userNameInput.Text, password = passwodInput.Text }).SingleOrDefault();

            // 不存在则登陆失败
            if (account == null)
            {
                MessageBox.Show("用户或密码不存在.");
            }
            else 
            {
                MessageBox.Show("登陆成功!");
            }
        }
    }
}
