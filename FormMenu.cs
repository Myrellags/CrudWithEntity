using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        string nomeTabela;
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
            MinhaBD bd = new MinhaBD();
            int numeroDeProdutos = bd.Database.ExecuteSqlRaw("SELECT * FROM Cliente");
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

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text);
            string campo = textBox2.Text;
            int y = listBox1.Items.Count;
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool sucesso = false;
            string tabela1 = "dbo.Tabela";
            string tabela2 = textBox1.Text;
            MinhaBD bd = new MinhaBD();
            bd.Database.ExecuteSqlRaw("EXEC sp_rename {0}, {1}", tabela1, tabela2);    
            foreach (var item in listBox1.Items)
            {
                string coluna = item.ToString();
                bd.Database.ExecuteSqlRaw("ALTER TABLE dbo." + tabela2 + " ADD " + coluna + " VARCHAR(40) NULL;");
                sucesso = true;
            }
            bd.Database.ExecuteSqlRaw("CREATE TABLE Tabela (Id INT IDENTITY(1,1));");
            textBox1.Text = "";
            listBox1.Items.Clear();
            if (sucesso = true) 
            {
                MessageBox.Show("Tabela criada com sucesso");
            }
        }
    }

    class tabela
    {
        public int Id { get; set; }
    }

    class MinhaBD : DbContext 
    {
        public DbSet<tabela> tabela { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BDCrudWithEntity;Trusted_Connection=True;");
        }
    }

}
