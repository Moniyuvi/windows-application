using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace coursework1
{
    public partial class Form1 : Form
    {
        int index = 0;
        string[] text_array = new string[10];
        string actualPerson;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.ShowDialog();
            textBox1.Text = of.FileName;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(textBox1.Text);
            richTextBox1.Text = sr.ReadToEnd();
            text_array = richTextBox1.Text.Split('\n');
            UpdateText(index);


            sr.Close();
        }
        //list sort
        void UpdateText(int index)
        {
            string[] person_data = text_array[index].Split(',');
            actualPerson = text_array[index];
            textBox3.Text = person_data[0];
            textBox4.Text = person_data[1];
            textBox5.Text = person_data[2];
            textBox6.Text = person_data[3];
            textBox7.Text = person_data[4];
            // Time Span
            string[] doe_array = person_data[3].Split('/');
            DateTime doe = new DateTime(int.Parse(doe_array[0]), int.Parse(doe_array[1]), int.Parse(doe_array[2]));
            DateTime now = DateTime.Today;
            TimeSpan difference = now - doe;
            int difference_days = (int)difference.TotalDays;
            if (radioButton3.Checked)
            {
                textBox2.Text = difference_days.ToString();
            } else if (radioButton2.Checked)
            {
                textBox2.Text = (difference_days / 30).ToString();
            }
            else if (radioButton1.Checked)
            {
                textBox2.Text = (difference_days / 365).ToString();
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)

                {
                    StreamWriter sw = new StreamWriter(richTextBox1.Text, true);
                    sw.WriteLine('\n' + richTextBox2.Text);
                    sw.Close();
                }
        }



        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {// next button
            if (index < 9)
            {
                index++;
                UpdateText(index);
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {// previous
            if (index > 0)
            {
                index--;
                UpdateText(index);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            index = 0;
            UpdateText(index);

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            index = 9;
            UpdateText(index);
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            SortedList sList = new SortedList();
            int i = 0;

            foreach (string line in text_array)
            {
                sList.Add(line.Split(',')[0], line);
            }
            foreach (DictionaryEntry d in sList)
            {
                text_array[i] = (string)d.Value;
                i++;
            }
            index = Array.IndexOf(text_array, actualPerson);
            richTextBox1.Text = "";
            int k = 0;
            foreach (string line in text_array)
            {
                if (k < 10)
                {
                    richTextBox1.Text += line + '\n';
                }
                else
                {
                    richTextBox1.Text += line;
                }
                k++;
            }
            UpdateText(index);
        }
        
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateText(index);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateText(index);
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateText(index);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Form2 item = new Form2();
            item.Show();
        }
        // Close application
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.X)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
