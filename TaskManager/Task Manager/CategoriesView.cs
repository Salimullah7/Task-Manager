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
    public partial class CategoriesView : Form
    {

        int mov;
        int movX;
        int movY;


        public CategoriesView()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (tBoxCategoryName.Text != null && !(tBoxCategoryName.Text.Equals("Enter Project Name")))
            {
                Category cat = new Category();
                cat.Name = tBoxCategoryName.Text;
                if (cBoxColorList.SelectedIndex >= 0)
                    cat.Color = cBoxColorList.SelectedIndex;
                cat.UserID = LogIn.user_ID;
                CategorySer catS = new CategorySer();
                catS.Insert(cat, LogIn.user_ID);
                MessageBox.Show("Category Is Created");
                this.Close();

                HomePage2.home2.CategoryListShow();
            }
            else
                MessageBox.Show("Please Enter The Project Name");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
