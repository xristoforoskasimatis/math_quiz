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
    public partial class Form1 : Form
    {
        Random rd = new Random();
        public class prakseis
        {
           public int plusLeft;
           public int plusRight;
           public int minusLeft;
           public int minusRight;
           public int multiLeft;
           public int multiRight;
           public int divLeft;
           public int divRight;            
        }
        prakseis p = new prakseis();
        
        int questions;
        int timeLeft;
        int totaltime;
        int score=0;
        public bool calculator = false;    
        bool winner = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartQuiz();
            helpToolStripMenuItem.Enabled = true;
            button1.Enabled = false;
            panel1.Visible = false;
        }
        private void Endgame()
        {
            button1.Enabled = true;
            panel1.Visible = true;
            label21.Text = totaltime.ToString();

            if (p.plusLeft + p.plusRight == Sum.Value)
                score++;
            if (p.minusLeft - p.minusRight == Sub.Value)
                score++;
            if (p.multiLeft * p.multiRight == Mul.Value)
                score++;
            if (p.divLeft / p.divRight == Div.Value)
                score++;

            label23.Text = (score*25).ToString() +"/100";

            Sum.Value = p.plusLeft + p.plusRight;
            Sub.Value = p.minusLeft - p.minusRight;
            Mul.Value = p.multiLeft * p.multiRight;
            Div.Value = p.divLeft / p.divRight;
            if (winner==false)
            {
                label24.Text = "you did not complete the test!" +"\n"+ "try again";
            }
        }
        private void StartQuiz()
        {
            Sum.Value = 0;
            Sub.Value = 0;
            Mul.Value = 0;
            Div.Value = 0;


            p.plusLeft = rd.Next(51);
            label1.Text = p.plusLeft.ToString();
            p.plusRight = rd.Next(51);
            label3.Text = p.plusRight.ToString();

            p.minusLeft = rd.Next(1,101);
            label5.Text = p.minusLeft.ToString();
            p.minusRight = rd.Next(1, p.minusLeft);
            label7.Text = p.minusRight.ToString();

            p.multiLeft = rd.Next(2, 11);
            label9.Text = p.multiLeft.ToString();
            p.multiRight = rd.Next(2, 11);
            label11.Text = p.multiRight.ToString();

            p.divRight = rd.Next(2,11);
            label15.Text = p.divRight.ToString();
            int temp = rd.Next(2,11);
            p.divLeft = temp * p.divRight;
            label13.Text = p.divLeft.ToString();


            timeLeft = 70;
            label19.Text = "70 seconds";
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckResult())
            {
                timer1.Stop();
                totaltime =70- timeLeft;
                Endgame();
                
            }
            else if (timeLeft >0)
            {
                timeLeft--;
                label19.Text = timeLeft + " seconds ";
            }
            else
            {
               
              timer1.Stop();
              button1.Enabled = true;
               Endgame();

            }

            if (timeLeft >40 )
            {
                label19.BackColor = Color.Green;
            }
            if (timeLeft < 40)
            {
                label19.BackColor = Color.Orange;


            }
            if (timeLeft <20)
            {
                label19.BackColor = Color.Red;
            }

        }

        private bool CheckResult()
        {
            if ((p.plusLeft + p.plusRight == Sum.Value) &&
                   (p.minusLeft - p.minusRight == Sub.Value) &&
                   (p.multiLeft * p.multiRight == Mul.Value) &&
                   (p.divLeft / p.divRight == Div.Value))
            {
                winner = true;
                return true;
            }
            else
                return false;
                   
                   
             
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (calculator == false)
            {
                Calculator f2 = new Calculator();
                calculator = true;
                f2.Show();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (calculator == false)
            {
                Calculator f2 = new Calculator();
                f2.Show();
                calculator = true;
            }
           
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void question1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(questions < 2)
            {
                if ((Sum.Value == p.plusLeft - p.plusRight)||(Sum.Value == p.plusLeft / p.plusRight)||(Sum.Value == p.plusLeft * p.plusRight))
                { MessageBox.Show("take a better look at the question!!"); }
                else if (p.plusLeft + p.plusRight > Sum.Value)
                {
                    MessageBox.Show("the answer is higher");
                }
                else if (p.plusLeft + p.plusRight < Mul.Value)
                {
                    MessageBox.Show("the answer is lower");
                }

                questions++;
            }
            else{ MessageBox.Show("No Questions left!!"); }
        }

        private void question1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (questions < 2)
            {
                if ((p.minusLeft + p.minusRight == Sub.Value) || (p.minusLeft * p.minusRight == Sub.Value) || (p.minusLeft / p.minusRight == Sub.Value))
                { MessageBox.Show("take a better look at the question!!"); }
                else if (p.minusLeft - p.minusRight > Sub.Value)
                {
                    MessageBox.Show("the answer is higher");
                }
                else if (p.minusLeft - p.minusRight < Sub.Value)
                {
                    MessageBox.Show("the answer is lower");
                }


                questions++;
            }
            else { MessageBox.Show("No Questions left!!"); }
        }

        private void question1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (questions < 2)
            {
                if ((p.multiLeft + p.multiRight == Mul.Value) || (p.multiLeft - p.multiRight == Mul.Value) || (p.multiLeft / p.multiRight == Mul.Value))
                { MessageBox.Show("take a better look at the question!!"); }
                else if (p.multiLeft * p.multiRight > Mul.Value)
                {
                    MessageBox.Show("the answer is higher");
                }
                else if (p.multiLeft * p.multiRight < Mul.Value)
                {
                    MessageBox.Show("the answer is lower");
                }

                questions++;
            }
            else { MessageBox.Show("No Questions left!!"); }
        }

        private void question1ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (questions < 2)
            {
                if ((p.divLeft + p.divRight == Div.Value) || (p.divLeft - p.divRight == Div.Value) || (p.divLeft * p.divRight == Div.Value))
                { MessageBox.Show("take a better look at the question!!"); }
                else if (p.divLeft / p.divRight > Div.Value)
                {
                    MessageBox.Show("the answer is higher");
                }
                else if (p.divLeft / p.divRight < Div.Value)
                {
                    MessageBox.Show("the answer is lower");
                }

                questions++;
            }
            else { MessageBox.Show("No Questions left!!"); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            helpToolStripMenuItem.Enabled = false;
        }

        private void Div_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
