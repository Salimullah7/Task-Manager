using Entity;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Manager
{
    public partial class UserInfoForm : Form
    {
        public UserInfoForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            button5.Visible = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = false;
            button5.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.ReadOnly = false;
            button5.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.ReadOnly = false;
            button5.Visible = true;
            textBox5.Visible = true;
        }

        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            UserSer uService = new UserSer();
            User us = uService.GetAll(LogIn.user_ID);

            textBox1.Text = us.UserName;
            textBox2.Text = us.Email;
            textBox3.Text = us.Phone;
            textBox4.Text = us.Password;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if(textBox5.Visible == true)
            {
                if(!(textBox4.Text.Equals(textBox5.Text)))
                {
                    MessageBox.Show("Your Retype Password Don't Match");
                    flag = true;
                }
            }

            if(!flag)
            {
                UserSer uService = new UserSer();
                User uS = new User();
                uS.UID = LogIn.user_ID;
                uS.Email = textBox2.Text;
                uS.Phone = textBox3.Text;
                uS.UserName = textBox1.Text;
                uS.Password = textBox4.Text;
                uService.Update(uS);
                button5.Visible = false;
            }

        }
    }
}
