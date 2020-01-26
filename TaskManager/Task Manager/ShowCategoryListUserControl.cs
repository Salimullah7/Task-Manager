using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using Entity;

namespace Task_Manager
{
    public partial class ShowCategoryListUserControl : UserControl
    {
        CategorySer cat;
        List<Category> ct;
        public ShowCategoryListUserControl()
        {
            InitializeComponent();
        }
        string _text;
        List<string> _items;

        public string TEXT
        {
            get { return _text; }
            set { _text = value; textBox1.Text = _text; }
        }
        public List<string> ListItems
        {
            get { return _items; }
            set 
            { 
                _items = value;
                if(_items != null)
                {
                    ct = new List<Category>();
                    ct = cat.GetAll(LogIn.user_ID);
                    for(int i=0; i<ct.Count; i++)
                    {
                        listBox1.Items.Add(ct[i].Name);
                    }
                }
                
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //listBox1.SetSelected(listBox1.SelectedIndex, true);
            MessageBox.Show(listBox1.SelectedItem.ToString());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //listBox1.Controls.Clear();
            //if (textBox1.Text != null)
            //{
            //    cat = new CategorySer();
            //    List<string> listName = cat.GetAll(textBox1.Text);
            //    for (int i = 0; i < listName.Count; i++)
            //    {
            //        listBox1.Items.Add(listName[i]);
            //    }
            //}

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
