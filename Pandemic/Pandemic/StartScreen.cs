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
        Player.Type humanPlayerType;


        public StartScreen()
        {
            InitializeComponent();
          
            int hpNum = rand.Next(4);
            
            switch (hpNum)
            {
                case 0:
                    humanPlayerType = Player.Type.DISPATCHER;
                    this.playerType.Image = ((System.Drawing.Image)(Image.FromFile("..\\..\\pics\\dispatcher.png")));
                    break;
                case 1:
                    humanPlayerType = Player.Type.MEDIC;
                    this.playerType.Image = ((System.Drawing.Image)(Image.FromFile("..\\..\\pics\\medic.png")));
                    break;
                case 2:
                    humanPlayerType = Player.Type.OPERATIONS;
                    this.playerType.Image = ((System.Drawing.Image)(Image.FromFile("..\\..\\pics\\operationsExpert.png")));
                    break;
                case 3:
                    humanPlayerType = Player.Type.RESEARCHER;
                    this.playerType.Image = ((System.Drawing.Image)(Image.FromFile("..\\..\\pics\\researcher.png")));
                    break;
                case 4:
                    humanPlayerType = Player.Type.SCIENTIST;
                    this.playerType.Image = ((System.Drawing.Image)(Image.FromFile("..\\..\\pics\\scientist.png")));
                    break;
            }
            
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            int numHardness;
            if (easyButton.Checked || mediumButton.Checked || hardButton.Checked)
            {
                if (this.easyButton.Checked)
                {
                    numHardness = 4;
                }
                else if (this.mediumButton.Checked)
                {
                    numHardness = 5;
                }
                else //hard
                {
                    numHardness = 6;
                }
                GameEngine ge = new GameEngine(humanPlayerType, numHardness);
                GameBoard gb = new GameBoard(false, ge);
                gb.Show();
                this.Hide();
                gb.update(ge.gs);
            }    
        }


    }
}
