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
    public partial class Form3 : Form
    {
        #region ФУНКЦИЯ №5 Создание двумерного массива с помощью датчика случайных чисел
        static public int[,] Create_Random_Two_Dem_Mas()////////// Создание двумерного массива с помощью датчика случайных чисел [ДСЧ] (Create_Random_Two_Dem_Mas)
        {


            Random n = new Random();
            int strok = n.Next(3, 6);
            int stolbci = n.Next(3, 6);
            int[,] TwoDemMas = new int[strok, stolbci];
            //////////Вывод получившегося массива


            for (int i = 0; i < strok; i++)
            {
                for (int j = 0; j < stolbci; j++)
                {
                    TwoDemMas[i, j] = n.Next(-100, 100);
                }

            }
            return TwoDemMas;
        }

        #endregion

        #region ФУНКЦИЯ №11 Удаление строки с выбранным номером



        static public int[,] DeleteString(int[,] TwoDemMas, int numb)
        {
            int kolvoStrok = TwoDemMas.GetUpperBound(0) + 1;

            int kolvoColumns = TwoDemMas.Length / kolvoStrok;

            int[,] NewTwoDemMas = new int[kolvoStrok - 1, kolvoColumns];





            for (int i = numb - 1; i < TwoDemMas.GetUpperBound(0); i++)
            {
                for (int j = 0; j < TwoDemMas.GetUpperBound(1) + 1; j++)
                {

                    TwoDemMas[i, j] = TwoDemMas[i + 1, j];

                }
            }


            for (int i = 0; i < NewTwoDemMas.GetLength(0); i++)
            {
                for (int j = 0; j < NewTwoDemMas.GetLength(1); j++)
                {


                    NewTwoDemMas[i, j] = TwoDemMas[i, j];


                }
            }

            return NewTwoDemMas;
        }

        #endregion

        int[,] mas = Create_Random_Two_Dem_Mas();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cоздание массива
            textBox1.Text = "";




            int rows = mas.GetUpperBound(0) + 1;
            int columns = mas.Length / rows;

            string[,] New_mas = new string[rows, columns];

            //Заполнение массива 
            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < columns; k++)
                {
                    New_mas[i, k] = Convert.ToString(mas[i, k]);
                }
            }
            //Вывод массива
            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < columns; k++)
                {
                    textBox1.Text += New_mas[i, k] + "  ";
                }
                textBox1.Text += Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            //Создание изменённого массива
            int numb;
            int rows = mas.GetUpperBound(0) + 1;
            bool ok = int.TryParse(textBox2.Text, out numb);
            if (ok)
            {
                if (numb <= rows)
                {
                    int[,] New_mas1 = DeleteString(mas, numb);

                    int rows1 = New_mas1.GetUpperBound(0) + 1;
                    int columns = New_mas1.Length / rows1;

                    string[,] New_mas_string = new string[rows1, columns];

                    //Заполнение массива 

                    for (int i = 0; i < rows1; i++)
                    {
                        for (int k = 0; k < columns; k++)
                        {
                            New_mas_string[i, k] = Convert.ToString(New_mas1[i, k]);
                        }
                    }
                    for (int i = 0; i < rows1; i++)
                    {
                        for (int k = 0; k < columns; k++)
                        {
                            textBox3.Text += New_mas_string[i, k] + "  ";
                        }
                        textBox3.Text += Environment.NewLine;
                    }
                }
                else
                {
                    MessageBox.Show("Вы ввели \n недопустимое значение!", "Fatal ERROR!",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Вы ввели \n недопустимое значение!", "Fatal ERROR!",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
            Close();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            ///Подсказки для полей
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(textBox1, "Ваш\nмассив");

            toolTip3.IsBalloon = true;
            toolTip3.SetToolTip(textBox2, "Введите номер строки,\nкоторую необходимо\nудалить");

            toolTip2.IsBalloon = true;
            toolTip2.SetToolTip(textBox3, "Ваш изменённый\nмассив");

            textBox1.TextAlign = HorizontalAlignment.Center;
        }
    }
}
