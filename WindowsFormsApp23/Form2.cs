using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp23
{
    public partial class Calculator : Form
    {
        public class calc
        {
          public  Double value = 0;
          public   String sumbola = "";
          public  bool sumbola_click = false;
        }
       

        calc c = new calc();
        public Calculator()
        {
            InitializeComponent();
        }

        private void clicknumber(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0") || (c.sumbola_click))
            {
                textBox1.Clear();
            }



            c.sumbola_click = false;
            Button b = (Button)sender;
            textBox1.Text = textBox1.Text + b.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            
            Visible = false;
        }

        private void Sumbola(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            c.sumbola = b.Text;
            c.value = Double.Parse(textBox1.Text);
            c.sumbola_click = true;
            textBox1.Text = c.value + " " + c.sumbola;
            label1.Text = c.value + " " + c.sumbola;
         }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            c.sumbola_click = false;
            label1.Text = "";

            switch (c.sumbola)
            {
                case "/":
                    textBox1.Text = (c.value / Double.Parse(textBox1.Text)).ToString();
                    break;
                case "*":
                    textBox1.Text = (c.value * Double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (c.value - Double.Parse(textBox1.Text)).ToString();
                    break;
                case "+":
                    textBox1.Text = (c.value + Double.Parse(textBox1.Text)).ToString();
                    break;
                default:
                    break;

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            c.value = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }
    }
}
