using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BE;

namespace PL
{
    static class Checks
    {
        const string path = @"C:\Users\eitha\Documents\מכון לב\הנדסת מערכת חלונים\WindowsProject\Photos";
        public static string NameCheck(TextBox textBox, ref bool flag)
        {
            if(!flag) return textBox.Text;
            if (!char.IsLetter((textBox.Text.FirstOrDefault())))
            {
                MessageBox.Show("please fill the Name field with the currect details");
                textBox.Text = "";
                flag = false;
            }               
            return textBox.Text;
        }
        public static double DoubleCheck(TextBox textBox, string name, ref bool flag)
        {
            double d=0;
            if (!flag) return d;
            if (!double.TryParse(textBox.Text,out d)||d<=0)
            {
                MessageBox.Show("please fill the "+ name+ " field with the currect details");
                textBox.Text = "";
                flag = false;
            }
            return d;
        }
        public static Category CategoryCheck(ComboBox CategoryComboBox, ref bool flag)
        {
            Category c=Category.Food;
            if (!flag) return c;
            if (CategoryComboBox.Text=="")
            {
                MessageBox.Show("please fill the Category field with the currect details");
                flag = false;
            }
            else
                c = (Category)Enum.Parse(typeof(Category), CategoryComboBox.Text);            
            return c;
        }
        public static string ImagePathCheck(TextBox textBox,ref bool flag)
        {
            if (!flag) return textBox.Text;
            if (!File.Exists(path+@"\"+ textBox.Text+".PNG"))
            {
                MessageBox.Show("please fill the Image Path field with the currect details");
                textBox.Text = "";
                flag = false;
            }
            return textBox.Text;
        }
    }
}
