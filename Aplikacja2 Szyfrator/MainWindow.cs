﻿using Effortless.Net.Encryption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja2_Szyfrator
{
    public partial class MainWindow : Form
    {
        byte[] key = new byte[] { 155, 61, 238, 189, 165, 191, 63, 200, 240, 118, 241, 210, 234, 5, 49, 75, 5, 70, 163, 163, 4, 26, 118, 74, 9, 192, 97, 26, 56, 100, 219, 99 };
        byte[] iv = new byte[] { 53, 182, 177, 250, 198, 222, 60, 145, 39, 169, 1, 44, 198, 67, 193, 161, 206, 77, 150, 236, 163, 37, 180, 70, 240, 182, 35, 174, 169, 118, 229, 249, };

        string content, path;

        List<Password> password = new List<Password>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
             using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Pliki Szyfratora (*.szyfrator)|*.szyfrator|Pliki tekstowe(*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    path = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        content = reader.ReadToEnd();
                    }
                    text.Text = deszyfruj(content);


                }

            }

            
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(password);
            byte[] byteArray = Encoding.UTF8.GetBytes(zaszyfruj(json));


            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();


            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.Filter = "Pliki Szyfratora (*.szyfrator)|*.szyfrator|Pliki tekstowe(*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Write(byteArray, 0, byteArray.Length);
                    myStream.Close();
                }
            }
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }




 

        private void odszyfruj_Click(object sender, EventArgs e)
        {
           
       
        
        
        
        
        }

        string deszyfruj(string zaszyfrowane)
        {
            try
            {
                return Strings.Decrypt(zaszyfrowane, key, iv);
            }
            catch (Exception)
            {
                MessageBox.Show("BŁĄD! to nie jest plik programu Sztfrator", "Szyfrator - błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "BŁĄD to nie jest plik programu Sztfrator";
                

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string json = "[{ 'id':0,'name':'nazwa','login':'test','password':'<ReferenceError: test is not defined>','email':'test.co.gmail','notes':'jakieś notatki'},{ 'id':1,'name':'nazwa','login':'test','password':'<ReferenceError: test is not defined>','email':'test.co.gmail','notes':'jakieś notatki'},{ 'id':2,'name':'nazwa','login':'test','password':'<ReferenceError: test is not defined>','email':'test.co.gmail','notes':'jakieś notatki'},{ 'id':3,'name':'nazwa','login':'test','password':'<ReferenceError: test is not defined>','email':'test.co.gmail','notes':'jakieś notatki'},{ 'id':4,'name':'nazwa','login':'test','password':'<ReferenceError: test is not defined>','email':'test.co.gmail','notes':'jakieś notatki'},{ 'id':5,'name':'nazwa','login':'test','password':'<ReferenceError: test is not defined>','email':'test.co.gmail','notes':'jakieś notatki'},{ 'id':6,'name':'nazwa','login':'test','password':'<ReferenceError: test is not defined>','email':'test.co.gmail','notes':'jakieś notatki'}]";
            // List<Password> password = new List<Password>(); // = JsonConvert.DeserializeObject<List<Password>>(json);
            //Console.WriteLine(password[2].password);
            string json2 = JsonConvert.SerializeObject(password);

           //Console.WriteLine(json2);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        string zaszyfruj(string odszyfrowane)
        {
            try
            {
                return Strings.Encrypt(odszyfrowane, key, iv);
            }
            catch (Exception)
            {
                MessageBox.Show("BŁĄD!! to nie jest plik programu Sztfrator", "Szyfrator - błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "BŁĄD zapisu";

            }

        }

    }



}
