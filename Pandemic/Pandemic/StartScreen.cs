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
    public partial class StartScreen : Form
    {
        Random rand =new Random();
        public StartScreen()
        {
            InitializeComponent();
           
            if (this.easyButton.Checked)
            {

            }
            else if (this.mediumButton.Checked)
            {

            }
            else if (this.hardButton.Checked)
            {

            }

            //this.playerType.ImageLocation = 
            int hpNum = rand.Next(4);
            Player.Type humanPlayerType;
            switch (hpNum)
            {
                case 0:
                    humanPlayerType = Player.Type.DISPATCHER;
                    //this.playerType.ImageLocation = 
                    break;
                case 1:
                    humanPlayerType = Player.Type.MEDIC;
                    //this.playerType.ImageLocation = 
                    break;
                case 2:
                    humanPlayerType = Player.Type.OPERATIONS;
                    //this.playerType.ImageLocation = 
                    break;
                case 3:
                    humanPlayerType = Player.Type.RESEARCHER;
                    //this.playerType.ImageLocation = 
                    break;
                case 4:
                    humanPlayerType = Player.Type.SCIENTIST;
                    //this.playerType.ImageLocation = 
                    break;
            }
            
        }


    }
}
