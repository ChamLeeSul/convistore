using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConviStoreMgm
{
    struct Goods
    {

        public String name;
        public int count;

        public Goods(string name, int count)
        {
            this.name = name;
            this.count = count;
        }
    }

    public partial class Form1 : Form
    {

        List<Goods> goods = new List<Goods>();
        
        public Form1()
        {
            InitializeComponent();

            this.button1.Click += Button1_Click;
            this.button2.Click += Button2_Click;
        }

        private void updateRichTextBox()
        {
            richTextBox1.Text = "";
            foreach (var item in goods)
            {
                richTextBox1.Text += item.name + ": " + item.count + "\r\n";
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            goods.RemoveAll(x => x.name == textBox1.Text);

            updateRichTextBox();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var find = goods.FindIndex(g => g.name.Equals(textBox1.Text));
                if (find == -1) throw new Exception();

                var updated = goods[find];
                updated.count += 1;

                goods[find] = updated;
            }
            catch
            {
                goods.Add(new Goods(textBox1.Text, 1));
            }

            updateRichTextBox();
        }
    }
}
