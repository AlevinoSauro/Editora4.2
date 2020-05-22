using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editora4._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customizeMenu();
        }

        private void customizeMenu()
        {
            pnItens.Visible = false;
            pnCliente.Visible = false;
            
        }

        private void hideMenu()
        {
            if (pnCliente.Visible == false)
                pnCliente.Visible = true;
            if (pnItens.Visible == false)
                pnItens.Visible = true;
        }

        private void  showMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            showMenu(pnCliente);
        }

        private void btnItens_Click(object sender, EventArgs e)
        {
            showMenu(pnCliente);
        }
    }
}