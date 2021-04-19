using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWithEntity
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
            button2.Visible = true;
            listBox1.Visible = true;
            button3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            label2.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
            listBox1.Visible = false;
            button3.Visible = false;
            FormListarTabelas FormListarTabelas = new FormListarTabelas();
            FormListarTabelas.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            label2.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
            listBox1.Visible = false;
            button3.Visible = false;
            FormInsereTable FormInsereTable = new FormInsereTable();
            FormInsereTable.ShowDialog();
        }
    }
}
