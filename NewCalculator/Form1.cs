using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewCalculator
{
    public partial class Form1 : Form
    {
        private double Value = 0;
        private bool decimalCheck = false;
        private String Op = "";
        public Form1()
        {
            InitializeComponent();
        }

        //Getting input and checking it
        private void Button_Click(object sender, EventArgs e)
        {
            Button input = (Button) sender;
            try
            {
                if (textBox1.Text == "0")
                    textBox1.Text = input.Text;
                else if (decimalCheck == true && input.Text == ".")
                    Console.WriteLine("Already a decimal, not doing anything");
                else if(input.Text == ".")
                {
                    decimalCheck = true;
                    textBox1.Text += input.Text;
                }
                else
                    textBox1.Text = (textBox1.Text + input.Text);
            }
            catch
            {
                Console.WriteLine("Not a double");
            }
        }

        //Clearing the variables
        private void ClearField(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            Value = 0;
            decimalCheck = false;
        }

        private void getOperator(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            Op = temp.Text;
            Value = Double.Parse(textBox1.Text);
            textBox1.Text = "0";
            textBox2.Text = Value + " " + Op;
            decimalCheck = false;
        }
        private void Calculate(object sender, EventArgs e)
        {
            textBox2.Text += (" " + textBox1.Text);
            switch (Op)
            {
                case "+":
                    Console.WriteLine(Convert.ToString(Value) + " " + textBox1.Text);
                    textBox1.Text = Convert.ToString((Value + Double.Parse(textBox1.Text)));
                    break;
                case "-":
                    textBox1.Text = Convert.ToString((Value - Double.Parse(textBox1.Text)));
                    break;
                case "/":
                    textBox1.Text = Convert.ToString(Value / Double.Parse(textBox1.Text));
                    break;
                case "*":
                    textBox1.Text = Convert.ToString(Value * Double.Parse(textBox1.Text));
                    break;
                default:
                    break;
            }
            Op = "";
            textBox2.Text += (" = " + textBox1.Text);
            textBox1.Text = "0";
        }
    }
}
