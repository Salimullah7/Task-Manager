using Entity;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Manager
{
    public partial class SignUp : Form
    {

        int mov;
        int movX;
        int movY;


        public SignUp()
        {
            InitializeComponent();
        }



        private void pBoxAddTaskView_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            User uN = new User();
            if (textBox1.Text != null && !(textBox1.Text.Equals("Name...........")))
            {
                uN.UserName = textBox1.Text;
                if (textBox2.Text != null && !(textBox2.Text.Equals("Email...........")))
                {
                    bool flag = EmailIsValid(textBox2.Text);
                    if(flag == false)
                    {
                        MessageBox.Show("Your Mail Address Is not valid");
                    }
                    else
                    {
                        uN.Email = textBox2.Text;
                        if (textBox3.Text != null && !(textBox3.Text.Equals("Phone...........")))
                        {

                            bool phoneFlag = PhoneValid(textBox3.Text);
                            if(phoneFlag == false)
                            {
                                MessageBox.Show("Your Phone No Is not valid");
                            }
                            else
                            {
                                uN.Phone = textBox3.Text;
                                if (textBox4.Text != null && !(textBox4.Text.Equals("Password...........")))
                                {
                                    uN.Password = textBox4.Text;

                                    UserSer uSr = new UserSer();
                                    uSr.Insert(uN);
                                    uSr = new UserSer();
                                    int uid = uSr.GetUserID(uN.UserName);
                                    CategorySer cgS = new CategorySer();

                                    Category cat = new Category();
                                    cat.Name = "Inbox";
                                    cat.UserID = uid;
                                    cat.Color = 0;
                                    cgS.Insert(cat, LogIn.user_ID);

                                    cat = new Category();
                                    cat.Name = "Today";
                                    cat.UserID = uid;
                                    cat.Color = 0;
                                    cgS.Insert(cat, LogIn.user_ID);

                                    cat = new Category();
                                    cat.Name = "Next 7 Day";
                                    cat.UserID = uid;
                                    cat.Color = 0;
                                    cgS.Insert(cat, LogIn.user_ID);

                                    MessageBox.Show("Sign Up Complete");

                                    this.Close();
                                }

                                else
                                    MessageBox.Show("Please Input Your Password");
                            }

                        }

                        else
                            MessageBox.Show("Please Input Your Phone");
                    }
                    
                }
                    
                else
                    MessageBox.Show("Please Input Your Email");
            }
                
            else
                MessageBox.Show("Please Input Your Name");
            
        }


        public static bool PhoneValid(string phone)
        {
            string expression = "\\d+";

            if (Regex.IsMatch(phone, expression))
            {
                if (Regex.Replace(phone, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }


        public static bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }


        private void SignUp_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
