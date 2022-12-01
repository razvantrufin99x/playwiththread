using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace playwiththread
{
    public partial class Form1 : Form
    {

        private delegate void SafeCallDelegate(string text);
        private delegate void SafeCallDelegate2(string text, TextBox t);
        private delegate void SafeCallDelegate3(string text, TextBox t);
        private Thread thread2 = null;

        
        
    

        private void Button1_Click(object sender, EventArgs e)
    {
        thread2 = new Thread(new ThreadStart(SetText));
        thread2.Start();
        Thread.Sleep(1);
    }

    private void WriteTextSafe(string text)
    {
        if (textBox1.InvokeRequired)
        {
            var d = new SafeCallDelegate(WriteTextSafe);
            textBox1.Invoke(d, new object[] { text });
            Thread.Sleep(10);

        }
        else
        {
            textBox1.Text = text;
        }
       
    }

    private void WriteTextSafe2(string text,TextBox t)
    {
        if (t.InvokeRequired)
        {
            var d = new SafeCallDelegate2(WriteTextSafe2);
            t.Invoke(d, new object[] { text, t });
            Thread.Sleep(10);

        }
        else
        {
            t.Text = text;
        }

    }

    private void WriteTextSafe3(string text, TextBox t)
    {
        if (t.InvokeRequired)
        {
            var d = new SafeCallDelegate3(WriteTextSafe3);
            t.Invoke(d, new object[] { text, t });
            Thread.Sleep(10);

        }
        else
        {
            t.Text = text;
        }

    }

    private void SetText()
    {
        WriteTextSafe("This text was set safely.");
        for (int i = 1; i < 100; i++)
        {
            WriteTextSafe(i.ToString());
           
        }
    }

    private void SetText2()
    {
        WriteTextSafe2("This text was set safely.", textBox2);
        for (int i = 1; i < 100; i++)
        {
            WriteTextSafe2(i.ToString(), textBox2);

        }
    }

    private void SetText3()
    {
        WriteTextSafe3("This text was set safely.", textBox3);
        for (int i = 1; i < 100; i++)
        {
            WriteTextSafe3(i.ToString(), textBox3);

        }
    }

    public Form1()
        {
            InitializeComponent();

            button1 = new Button
            {
                Location = new Point(15, 55),
                Size = new Size(240, 20),
                Text = "Set text safely"
            };
            button1.Click += new EventHandler(Button1_Click);
            textBox1 = new TextBox
            {
                Location = new Point(15, 15),
                Size = new Size(240, 20)
            };
            Controls.Add(button1);
            Controls.Add(textBox1);
        }

        
        

        public void changetext(string s)
        {

            textBox1.Text += s + " \r\n" ;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        
            
            //Thread thread = new Thread(new ThreadStart(CountUntilx));
            //thread.Start();
       

        private void CountUntilx()
        {
           

            for (int i = 0; i < 100; i++)
            {
               
                    this.changetext(i.ToString());
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            thread2 = new Thread(new ThreadStart(SetText2));
            thread2.Start();
            Thread.Sleep(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            thread2 = new Thread(new ThreadStart(SetText3));
            thread2.Start();
            Thread.Sleep(1);
        }
    }
}
