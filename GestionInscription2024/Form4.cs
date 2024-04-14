using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInscription2024
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=D:\\BD\\gestionEudiant.accdb");
     
        private void Form4_Load(object sender, EventArgs e)
        {
           
        }

        private void etudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0D)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox1.Focus();
                }
                else
                {
                    textBox2.Enabled = true;
                    textBox2.Focus();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0D)
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    textBox2.Focus();
                }
                else
                {
                    textBox3.Enabled = true;
                    textBox3.Focus();
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0D)
            {
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    textBox3.Focus();
                }
                else
                {
                    textBox4.Enabled = true;
                    textBox4.Focus();
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0D)
            {
                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    textBox4.Focus();
                }
                else
                {
                    comboBox1.Enabled = true;
                    comboBox1.Focus();
                }
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0D)
            {
                if (string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    comboBox1.Focus();
                }
                else
                {
                    dateTimePicker1.Enabled = true;
                    dateTimePicker1.Focus();
                }
            }
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0D)
            {
                if (string.IsNullOrWhiteSpace(dateTimePicker1.Text))
                {
                    dateTimePicker1.Focus();
                }
                else
                {
                    textBox7.Enabled = true;
                    textBox7.Focus();
                }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0D)
            {
                if (string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    textBox7.Focus();
                }
                else
                {
                    button1.Enabled = true;
                    button1.Focus();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Voulez-vous vraiment quitter ?", "Message-Alphonse", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox7.Text = "";
        }
        public void Save() {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "insert into Etudiant values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Value + "','" + textBox7.Text + "')";
                cnn.Open();
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception e) {
                MessageBox.Show("Une erreur est survenue :"  + e.Message);
                DialogResult rep = MessageBox.Show("Voulez-vous quitter ?", "Message-Alphonse", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rep == DialogResult.Yes) {
                    Application.Exit();
                }
                cnn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
