using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AAV_Task_09.Models;

namespace AAV_Task_09
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        //private bool isValidTextBox()
        //{
        //    using (var db = new ShopDbContext());
            
        //}

        //private void buttonReg_Click(object sender, EventArgs e)
        //{
        //    using (project1_dbContext db = new project1_dbContext())
        //    {
        //        User user1 = new User
        //        {
        //            Login = textBoxLogin.Text,
        //            Password = textBoxPass2.Text,
        //            NumberPhone = maskedTextBoxPhone.Text,
        //            Mail = textBoxMail.Text,
        //            IdAccess = 3,
        //            FirstName = textBox2.Text,
        //            LastName = textBox1.Text,
        //            MiddleName = textBox3.Text
        //        };
        //        db.Users.Add(user1);
        //        db.SaveChanges();
        //        var a = MessageBox.Show("Регистрация прошла успешно. Для доступа в приложение авторизуйтесь.", "Успешная регистрация", MessageBoxButtons.OK, MessageBoxIcon.None);
        //        if (a == DialogResult.OK)
        //        {
        //            Form1 form2 = new Form1();
        //            form2.Show();
        //            this.Hide();
        //        }

        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Form1 form1 = new Form1();
        //    this.Hide();
        //    form1.Show();
        //}

        //private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar))
        //    {
        //        if (!char.IsLetter(e.KeyChar))
        //            e.Handled = true;
        //    }
        //    return;
        //}
    }
}
