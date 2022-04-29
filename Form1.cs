using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class4_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ArrayList formaPag = new ArrayList
            {
                new FormaDePag(1, "Selecione:"),
                new FormaDePag(2, "Dinheiro"),
                new FormaDePag(3, "Cartão"),
                new FormaDePag(4, "Boleto"),
                new FormaDePag(5, "Pix")
            };
            comboBox1.DataSource = formaPag;
            //comboBox1.DisplayMember = "Descrição";
            comboBox1.ValueMember = "Descricao";
            ArrayList quantPag = new ArrayList
            {
                new QuantPag(1, ""),
                new QuantPag(2, ""),
                new QuantPag(3, ""),
                new QuantPag(4, ""),
                new QuantPag(5, "")
            };
            comboBox2.DataSource = quantPag;
            comboBox2.ValueMember = "Id";
        }
        public class FormaDePag
        {
            public  int Id { get; set; }
            public string Descricao { get; set; }
            public FormaDePag (int id, string descricao)
            {
                Id = id;
                Descricao = descricao;
            }
        }
        public class QuantPag
        {
            public int Id { get; set; }
          
            public QuantPag(int id, string descricao)
            {
                Id = id;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = comboBox1.SelectedIndex;

            if (id == 2)
            {
                label5.Text = "";
                label2.Text = "Informe em quantas vezes deseja pagar:";
            } 
            else if (id == 4)
            {
                Random random = new Random();
                label5.Text = $"Chave Pix: {random.Next()}";
            }
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int id = comboBox2.SelectedIndex + 1;
            var calc = Convert.ToDecimal(textBox1.Text) / Convert.ToDecimal(id);
            label5.Text = $"Valor a ser pago: {id}x de R$ {calc:F2}";
        }
    }
}
