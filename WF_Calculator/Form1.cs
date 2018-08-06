using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Calculator
{
    public partial class Form1 : Form
    {
        public StringBuilder result = new StringBuilder(50);
        public Command MyCommand = new Command();
        //-------------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            //////////////////////////////////////////////////////////////////
            
            ToolStripMenuItem TypeItem = new ToolStripMenuItem("Calc type");
            ToolStripMenuItem newItem = new ToolStripMenuItem("Standard") { Checked = true, CheckOnClick = true };
            TypeItem.DropDownItems.Add(newItem);
            MainMenu.Items.Add(TypeItem);

            ToolStripMenuItem HelpItem = new ToolStripMenuItem("Help");
            ToolStripMenuItem Help = new ToolStripMenuItem("Help");
            HelpItem.DropDownItems.Add(Help);
            Help.Click += HelpOnClick;
            Help.ShortcutKeys = Keys.F1;

            ToolStripMenuItem About = new ToolStripMenuItem("About");
            HelpItem.DropDownItems.Add(About);
            About.Click += AboutOnClick;

           
            MainMenu.Items.Add(HelpItem);

            
        }
        //-------------------------------------------------------------------------------
        void HelpOnClick(object sender, EventArgs e)
        {
            // Кнопка[CE] удаляет только последнее введённое число, кнопка[C] - полная отмена операции.
            string msg = @"Калькулятор можно использовать для выполнения простых операций: сложения, вычитания, умножения и деления. 

            Сочетания клавиш для работы с программой:
            F1  - Открытие справки
            F9  - Нажатие кнопки +/- 
            /    - Нажатие кнопки /  
            *    - Нажатие кнопки * 
            +    - Нажатие кнопки + 
            -    - Нажатие кнопки - 
            0-9 - Нажатие цифровых кнопок (0-9)
            =    - Нажатие кнопки = 
            .    - Нажатие кнопки . (десятичный разделитель)
            BACKSPACE - Нажатие кнопки Backspace
            ESC - Нажатие кнопки CE (удаляет только 
                    последнее введённое число)
            DEL - Нажатие кнопки C (полная отмена операции)
             ";
            MessageBox.Show(msg,"HELP");
        }
        //-------------------------------------------------------------------------------
        void AboutOnClick(object sender, EventArgs e)
        {
            MessageBox.Show("О программе");
        }
        //-------------------------------------------------------------------------------
        private void printResult()
        {
            if (result.Length == 0)
                ResultText.Text = "0";
            else
                ResultText.Text = result.ToString();
        }
        //-------------------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.NumPad1 || keyData == Keys.D1)
            {
                button1.PerformClick();
                button1.Focus();
                return true;
            }
            else if (keyData == Keys.NumPad2 || keyData == Keys.D2)
            {
                button2.PerformClick();
                button2.Focus();
                return true;
            }
            else if (keyData == Keys.NumPad3 || keyData == Keys.D3)
            {
                button3.PerformClick();
                button3.Focus();
                return true;
            }
            else if (keyData == Keys.NumPad4 || keyData == Keys.D4)
            {
                button4.PerformClick();
                button4.Focus();
                return true;
            }
            else if (keyData == Keys.NumPad5 || keyData == Keys.D5)
            {
                button5.PerformClick();
                button5.Focus();
                return true;
            }
            else if (keyData == Keys.NumPad6 || keyData == Keys.D6)
            {
                button6.PerformClick();
                button6.Focus();
                return true;
            }
            else if (keyData == Keys.NumPad7 || keyData == Keys.D7)
            {
                button7.PerformClick();
                button7.Focus();
                return true;
            }
            else if (keyData == Keys.NumPad8 || keyData == Keys.D8)
            {
                button8.PerformClick();
                button8.Focus();
                return true;
            }
            else if (keyData == Keys.NumPad9 || keyData == Keys.D9)
            {
                button9.PerformClick();
                button9.Focus();
                return true;
            }
            else if (keyData == Keys.NumPad0 || keyData == Keys.D0)
            {
                button0.PerformClick();
                button0.Focus();
                return true;
            }
            else if (keyData == Keys.Add || keyData == (Keys.Shift | Keys.Oemplus))  //+
            {
                buttonPlus.PerformClick();
                buttonPlus.Focus();
                return true;
            }
            else if (keyData == Keys.Subtract || keyData == (Keys.Shift | Keys.OemMinus))  //-
            {
                buttonMinus.PerformClick();
                buttonMinus.Focus();
                return true;
            }
            else if (keyData == Keys.Multiply || keyData == (Keys.Shift | Keys.D8))  //*
            {
                buttonMultiply.PerformClick();
                buttonMultiply.Focus();
                return true;
            }
            else if (keyData == Keys.Divide || keyData == Keys.Oem2)  // /
            {
                buttonDivide.PerformClick();
                buttonDivide.Focus();
                return true;
            }
            else if (keyData == Keys.F9)  // +/-
            {
                buttonPlusMinus.PerformClick();
                buttonPlusMinus.Focus();
                return true;
            }
            else if (keyData == Keys.Decimal || keyData == Keys.OemPeriod)  // Dot
            {
                buttonDot.PerformClick();
                buttonDot.Focus();
                return true;
            }
            else if (keyData == Keys.Escape)  // CE
            {
                buttonCE.PerformClick();
                buttonCE.Focus();
                return true;
            }
            else if (keyData == Keys.Delete)  // C
            {
                buttonC.PerformClick();
                buttonC.Focus();
                return true;
            }
            else if (keyData == Keys.Back)  // <-
            {
                buttonBackspace.PerformClick();
                buttonBackspace.Focus();
                return true;
            }
            else if (keyData == Keys.Enter || keyData == Keys.Oemplus)  // =
            {
                buttonEnter.PerformClick();
                buttonEnter.Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //-------------------------------------------------------------------------------
        private void NumberButton_Click(object sender, EventArgs e)
        {
            var myBut = sender as Button;
            result.Append(myBut.Text);
            printResult();
        }
        //-------------------------------------------------------------------------------
        private void Form1_Resize(object sender, EventArgs e)
        {
            var f = sender as Form;
            var font22 = new Font(buttonCE.Font.FontFamily.Name, 22f);
            var font12 = new Font(buttonCE.Font.FontFamily.Name, 12f);
            var buttons = tableLayoutPanel2.Controls.OfType<Button>().ToList();
            var count = buttons.Count();

            if (f.WindowState == FormWindowState.Maximized)
            {
                for (int i = 0; i < count; i++)
                {
                    buttons[i].Font = font22;
                }
            }
           else
            {
                for (int i = 0; i < count; i++)
                {
                    buttons[i].Font = font12;
                }
            }
        }
        //-------------------------------------------------------------------------------
        private void OperatioButtonOnClick(object sender, EventArgs e)
        {
            double.TryParse(result.ToString(), out double number);
            Operations op;
            var myBut = sender as Button;
            if (myBut.Text == "+")
                op = Operations.Plus;
            else if (myBut.Text == "-")
                op = Operations.Minus;
            else if (myBut.Text == "*")
                op = Operations.Mult;
            else 
                op = Operations.Divide;

            MyCommand.ChangeOperation(number, op);
            result.Clear();
            result.Append(MyCommand.Res.ToString());
            printResult();
            result.Clear();

        }
        //-------------------------------------------------------------------------------
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            double.TryParse(result.ToString(), out double number);
            MyCommand.GetResult(number);
            result.Clear();
            result.Append(MyCommand.Res.ToString());
            printResult();
            MyCommand = new Command();
        }
        //-------------------------------------------------------------------------------
        private void buttonPlusMinus_Click(object sender, EventArgs e) // +/-
        {
            double.TryParse(result.ToString(), out double res);
            if (res > 0)
                result.Insert(0, '-');
            else
                result.Remove(0, 1);
            printResult();
        }
        //-------------------------------------------------------------------------------
        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!result.ToString().Contains("."))
            {
                if(result.Length == 0)
                    result.Append("0.");
                else
                    result.Append('.');
            }
            printResult();
        }
        //-------------------------------------------------------------------------------
        private void buttonCE_Click(object sender, EventArgs e)
        {
            result.Clear();
            printResult();
            
        }
        //-------------------------------------------------------------------------------
        private void buttonC_Click(object sender, EventArgs e)
        {
            result.Clear();
            printResult();
            MyCommand = new Command();
        }
        //-------------------------------------------------------------------------------
        private void buttonBackspace_Click(object sender, EventArgs e) 
        {
            result.Remove(result.Length - 1, 1);
            printResult();
        }
        //-------------------------------------------------------------------------------
    }
    //////////////////////////////////////////////////////////////////////////////////////
    public enum Operations { Plus, Minus, Divide, Mult }
    //------------------------------------------------------------------------------------
    public class Command
    {
        public double Res { get; set; } = 0;        
        public Operations Operation { get ; set; }
        private double x { get; set; }

        public void ChangeOperation(double number, Operations Operation)
        {
            if (Res == 0)
                Res = number;
            else
            {
                x = number;
                Execute();                
            }
            this.Operation = Operation;
        }

        public void GetResult(double number)
        {
                x = number;
                Execute();
        }

        public void Execute()
        {
            if (Operation == Operations.Plus)
            {
                Res += x;
            }
            else if (Operation == Operations.Minus)
            {
                Res -= x;
            }
            else if (Operation == Operations.Divide)
            {
                if (x != 0)
                    Res /= x;
                else
                    MessageBox.Show("На 0 делить нельзя!");
            }
            else 
            {
                Res *= x;
            }
        
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////
}
