using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WP_2020_01_HW01_9A713021
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MD5 md5 = MD5.Create();//建立一個MD5
            byte[] source = Encoding.Default.GetBytes(textBox1.Text);//將字串轉為Byte[]
            byte[] crypto = md5.ComputeHash(source);//進行MD5加密
            string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
            label3.Text=("密碼:  " + result);//輸出結果
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string pat = @"[\u4e00-\u9fa5]";

            Regex rg = new Regex(pat);
            Match mh = rg.Match(textBox1.Text);
            if (mh.Success)
                return;
            MessageBox.Show("請輸入中文");
            //textBox1.Text = "請輸入中文";
            //textBox1.Undo();
        }

    }
}
