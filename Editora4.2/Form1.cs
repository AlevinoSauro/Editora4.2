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

        private void Form1_Load(object sender, EventArgs e)
        {

            clientesBindingSource.DataSource = this.editora_DataSet;

        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                clientesBindingSource.EndEdit();
                clientesTableAdapter.Update(this.editora_DataSet.Clientes);
                panel2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clientesBindingSource.ResetBindings(false);
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            clientesBindingSource.ResetBindings(false);
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            txtNomeCompleto.Focus();
        }

        private void btnNew2_Click(object sender, EventArgs e)
        {
            try
            {
                panel2.Enabled = true;
                txtNomeCompleto.Focus();
                //Add new row
                this.editora_DataSet.Clientes.AddClientesRow(this.editora_DataSet.Clientes.NewClientesRow());
                clientesBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clientesBindingSource.ResetBindings(false);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    clientesBindingSource.RemoveCurrent();
            }
        }

        private void txtSearch2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSearch2.Text))
                {
                    //Fill data to datatable
                    this.clientesTableAdapter.Fill(this.editora_DataSet.Clientes);
                    clientesBindingSource.DataSource = this.editora_DataSet.Clientes;
                    //dataGridView.DataSource = employeesBindingSource;
                }
                else
                {
                    //using linq to query data
                    var query = from o in this.editora_DataSet.Clientes
                                where o.Nome_Completo.Contains(txtSearch.Text) || o.Numero_Telefone == txtSearch.Text || o.Email == txtSearch.Text 
                                select o;
                    clientesBindingSource.DataSource = query.ToList();
                    //dataGridView.DataSource = query.ToList();
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        pictureBox.Image = Image.FromFile(ofd.FileName);//Load image from file to picturebox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                acervoBindingSource.EndEdit();
                acervoTableAdapter.Update(this.editora_DataSet.Acervo);
                panel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                acervoBindingSource.ResetBindings(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            acervoBindingSource.ResetBindings(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            txtTitulo.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Enabled = true;
                txtNomeCompleto.Focus();
                //Add new row
                this.editora_DataSet.Acervo.AddAcervoRow(this.editora_DataSet.Acervo.NewAcervoRow());
                acervoBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                acervoBindingSource.ResetBindings(false);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    //Fill data to datatable
                    this.acervoTableAdapter.Fill(this.editora_DataSet.Acervo);
                    acervoBindingSource.DataSource = this.editora_DataSet.Acervo;
                    //dataGridView.DataSource = employeesBindingSource;
                }
                else
                {
                    //using linq to query data
                    var query = from o in this.editora_DataSet.Acervo
                                where o.Titulo.Contains(txtSearch.Text) || o.Autor == txtSearch.Text || o.Sinopse == txtSearch.Text
                                select o;
                    acervoBindingSource.DataSource = query.ToList();
                    //dataGridView.DataSource = query.ToList();
                }
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    acervoBindingSource.RemoveCurrent();
            }
        }
    }
}
