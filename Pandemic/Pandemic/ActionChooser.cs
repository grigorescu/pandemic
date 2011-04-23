using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pandemic
{
    public partial class ActionChooser : Form
    {
        List<Action> actions;
        public Action selection;
        public ActionChooser(List<Action> actions)
        {
            this.actions = actions;
            InitializeComponent();
            listBox1.DataSource = actions;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selection = actions[listBox1.SelectedIndex];
            Hide();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selection = actions[listBox1.SelectedIndex];
            Hide();
        }



        

        
    }
}
