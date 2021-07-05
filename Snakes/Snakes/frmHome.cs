using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snakes
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            //Oyun ekranina gecis yapildi.
            frmGameScreen gameScreen = new frmGameScreen();
            gameScreen.Show();                      
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Uygulama kapatildi.
            Application.Exit();
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Uygulama kapatildi.
            Application.Exit();
        }
    }
}
