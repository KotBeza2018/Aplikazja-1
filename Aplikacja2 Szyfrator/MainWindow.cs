using Effortless.Net.Encryption;
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
        private Panel buttonPanel = new Panel();
        //private DataGridView passwordsDataGridView = new DataGridView();
        private Button addNewRowButton = new Button();
        private Button deleteRowButton = new Button();

        public MainWindow()
        {
            InitializeComponent();
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
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


        private void passwordsDataGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.passwordsDataGridView.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString())
                                .ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }
        }

        private void addNewRowButton_Click(object sender, EventArgs e)
        {
            this.passwordsDataGridView.Rows.Add();
        }

        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            if (this.passwordsDataGridView.SelectedRows.Count > 0 &&
                this.passwordsDataGridView.SelectedRows[0].Index !=
                this.passwordsDataGridView.Rows.Count - 1)
            {
                this.passwordsDataGridView.Rows.RemoveAt(
                    this.passwordsDataGridView.SelectedRows[0].Index);
            }
        }

        private void SetupLayout()
        {
            //this.Size = new Size(600, 500);

            addNewRowButton.Text = "Add Row";
            addNewRowButton.Location = new Point(10, 10);
            addNewRowButton.Click += new EventHandler(addNewRowButton_Click);

            deleteRowButton.Text = "Delete Row";
            deleteRowButton.Location = new Point(100, 10);
            deleteRowButton.Click += new EventHandler(deleteRowButton_Click);

            buttonPanel.Controls.Add(addNewRowButton);
            buttonPanel.Controls.Add(deleteRowButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.buttonPanel);
        }

        private void SetupDataGridView()
        {
            //this.Controls.Add(passwordsDataGridView);

            passwordsDataGridView.ColumnCount = 7;
            passwordsDataGridView.Name = "songsDataGridView";
           // passwordsDataGridView.Location = new Point(8, 8);
            //passwordsDataGridView.Size = new Size(500, 250);
            passwordsDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            passwordsDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            passwordsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            passwordsDataGridView.RowHeadersVisible = false;

            passwordsDataGridView.Columns[0].Name = "Release Date";
            passwordsDataGridView.Columns[1].Name = "Track";
            passwordsDataGridView.Columns[2].Name = "Title";
            passwordsDataGridView.Columns[3].Name = "Artist";
            passwordsDataGridView.Columns[4].Name = "Album";
            passwordsDataGridView.Columns[4].DefaultCellStyle.Font =
                new Font(passwordsDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            passwordsDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            passwordsDataGridView.MultiSelect = false;
            passwordsDataGridView.Dock = DockStyle.None;
            passwordsDataGridView.CellFormatting += new
                DataGridViewCellFormattingEventHandler(
                passwordsDataGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {

            string[] row0 = { "11/22/1968", "29", "Revolution 9",
            "Beatles", "The Beatles [White Album]" };
            string[] row1 = { "1960", "6", "Fools Rush In",
            "Frank Sinatra", "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971", "1", "One of These Days",
            "Pink Floyd", "Meddle" };
            string[] row3 = { "1988", "7", "Where Is My Mind?",
            "Pixies", "Surfer Rosa" };
            string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            "Cramps", "Psychedelic Jungle" };
            string[] row5 = { "6/10/2003", "13",
            "Scatterbrain. (As Dead As Leaves.)",
            "Radiohead", "Hail to the Thief" };
            string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            passwordsDataGridView.Rows.Add(row0);
            passwordsDataGridView.Rows.Add(row1);
            passwordsDataGridView.Rows.Add(row2);
            passwordsDataGridView.Rows.Add(row3);
            passwordsDataGridView.Rows.Add(row4);
            passwordsDataGridView.Rows.Add(row5);
            passwordsDataGridView.Rows.Add(row6);

            passwordsDataGridView.Columns[0].DisplayIndex = 3;
            passwordsDataGridView.Columns[1].DisplayIndex = 4;
            passwordsDataGridView.Columns[2].DisplayIndex = 0;
            passwordsDataGridView.Columns[3].DisplayIndex = 1;
            passwordsDataGridView.Columns[4].DisplayIndex = 2;
        }

    }

}
