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

namespace Task_Manager
{
    public partial class ProjectUserControl : UserControl
    {
        public ProjectUserControl()
        {
            InitializeComponent();
        }
        string _projectName;
        int _projectColor;
        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; lblProjectName.Text = _projectName; }
        }
        public int ProjectColor
        {

            get 
            { 
                return _projectColor; 
            }
            set 
            {
                _projectColor = value;
                switch(_projectColor)
                {
                    case 0:
                        lblColor.BackColor = Color.Blue;
                        break;
                    case 1:
                        lblColor.BackColor = Color.Green;
                        break;
                    case 2:
                        lblColor.BackColor = Color.White;
                        break;
                    case 3:
                        lblColor.BackColor = Color.Purple;
                        break;
                    case 4:
                        lblColor.BackColor = Color.Gray;
                        break;
                    default:
                        lblColor.BackColor = Color.Red;
                        break;
                }
            }
        }

        private void lblProjectName_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(16, 78, 136);
        }

        private void lblProjectName_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(14, 65, 114);
        }

        private void lblProjectName_Click(object sender, EventArgs e)
        {
            HomePage2.home2.ForProjectUserControl(ProjectName);
        }
    }
}
