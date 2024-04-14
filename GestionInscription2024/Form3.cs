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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=D:\\BD\\gestionEudiant.accdb");
     
        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0D)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("le nom de l'utilisateur est obligatoire dans cette zone, veuillez bien le saisir");
                    textBox1.Focus();
                }
                else
                { 
                    textBox2.Enabled=true;
                    textBox2.Focus();
                    button2.Enabled = true;
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==0x0D) {
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("le mot de passe de l'utilisateur est obligatoire dans cette zone, veuillez bien le saisir");
                    textBox2.Focus();
                }
                else {
                    button1.Enabled = true;
                    button1.Focus();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd =new OleDbCommand();
            cmd.Connection=cnn;
            cmd.CommandText="select user, Motdepasse from Utilisateurs where user='"+textBox1.Text+"'AND Motdepasse ='"+textBox2.Text+"'";
            OleDbDataReader lire;
            cnn.Open();
            lire=cmd.ExecuteReader();
            
            if (lire.Read()){
            Form frm = new Form4();
            frm.Show();
            this.Close();
            }else{
            MessageBox.Show("le nom d'utilisateur ou le mot de passe est incorrect");
                textBox1.Text="";
                textBox1.Focus();
                textBox2.Text="";
                textBox2.Enabled=false;
                button1.Enabled=false;
                button2.Enabled=false;
                
            }
            cnn.Close();
        }
    }
}
