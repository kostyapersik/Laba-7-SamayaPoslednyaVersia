using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_7_SamayaPoslednyaVersia
{
    public partial class Form4 : Form
    {

        #region ФУНКЦИЯ №7 Cоздание рваного массива с помощью датчика случайных чисел

        static public int[][] Create_Random_Ragged_Mas()
        {
            Random rnd = new Random();
            int rows = rnd.Next(2, 6);
            int[][] Ragged_array = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                Ragged_array[i] = new int[rnd.Next(1, 7)];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < Ragged_array[i].Length; j++)
                {
                    Ragged_array[i][j] = rnd.Next(-100, 100);
                }
            }
            return Ragged_array;
        }

        #endregion

        static public int[][] MyFunction(int[][] mas, int index, int kolvoStrok)
        {
            int[][] New_mas = new int[mas.Length - kolvoStrok][];
            int p = 0;
            for (int i = 0, k = 0; i < mas.Length; i++)
            {
                if (i == index)
                {
                    p = kolvoStrok - 1;

                }
                else
                {
                    if (p == 0)
                    {
                        New_mas[k] = new int[mas[i].Length];
                        for (int j = 0; j < mas[i].Length; j++)
                        {
                            New_mas[k][j] = mas[i][j];
                        }
                        k++;
                    }
                    else
                    {
                        p--;
                    }
                }

            }
            return New_mas;
        }


        int[][] mas = Create_Random_Ragged_Mas();


        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ///Подсказки для полей
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(textBox1, "Ваш\nмассив");

            toolTip4.IsBalloon = true;
            toolTip4.SetToolTip(textBox4, "Ввелите номер,\nс которого нужно\nдобавить строки");

            toolTip3.IsBalloon = true;
            toolTip3.SetToolTip(textBox2, "Введите количество строк,\nкоторые необходимо\nудобавить");

            toolTip2.IsBalloon = true;
            toolTip2.SetToolTip(textBox3, "Ваш изменённый\nмассив");

            textBox1.TextAlign = HorizontalAlignment.Left;//ориентация текста в первом textbox

            label2.Text = "Введите количество строк,\nкоторые вы хотите добавить\nи номер, с которого необходимо\nэти строки добавить";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            int rows = mas.Length;

            string[][] New_mas = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                New_mas[i] = new string[mas[i].Length];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < New_mas[i].Length; j++)
                {
                    New_mas[i][j] = Convert.ToString(mas[i][j]);
                }
            }

            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    textBox1.Text += (" " + mas[i][j] + "  ");
                }
                textBox1.Text += Environment.NewLine;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Ввод номера строки, с которого удалять
            int index;
            bool prov = true;
            do
            {

                prov = int.TryParse(textBox2.Text, out index);
                if (prov == false)
                    MessageBox.Show("Вы ввели \n недопустимое значение!", "Fatal ERROR!",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                if (index > mas.Length)
                {
                    MessageBox.Show("Вы ввели \n недопустимое значение!", "Fatal ERROR!",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Text = "";
                    prov = false;
                }
                else index -= 1;

            } while (!prov);

            //Ввод количества строк к удалению
            int kolvoStrok;
            bool oks1 = true;
            do
            {

                oks1 = int.TryParse(textBox4.Text, out kolvoStrok);

                if (oks1 == false)

                    MessageBox.Show("Вы ввели \n недопустимое значение!", "Fatal ERROR!",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Text = "";

                if (kolvoStrok > mas.Length)
                {

                    MessageBox.Show("Вы ввели \n недопустимое значение!", "Fatal ERROR!",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox4.Text = "";
                    oks1 = false;
                }


            } while (!oks1);




            int[][] New_mas1 = MyFunction(mas, index, kolvoStrok);


            int rows1 = New_mas1.Length;

            string[][] New_mas4 = new string[rows1][];

            for (int i = 0; i < rows1; i++)
            {
                New_mas4[i] = new string[New_mas1[i].Length];
            }

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < New_mas4[i].Length; j++)
                {
                    New_mas4[i][j] = Convert.ToString(New_mas1[i][j]);
                }
            }

            for (int i = 0; i < New_mas4.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    textBox3.Text += (" " + New_mas4[i][j] + "  ");
                }
                textBox3.Text += Environment.NewLine;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
            Close();
        }
    }
}
