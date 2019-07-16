using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TestApplication
{
    public partial class Form1 : Form
    {


        private List<ArtikelDTO> Stammdaten = new List<ArtikelDTO>();
        private List<ArtikelDataDTO> Artikelliste = new List<ArtikelDataDTO>();
        
        // Vllt die datatable hier definieren
        //  DataTable table = new DataTable();
        // dann kann man sie unten benutzen

        public Form1()
        {
            this.LadeStammdaten();
            InitializeComponent();
        }

        public void LadeStammdaten()
        {
             foreach(DataRow row in this.table.Rows)
             { 
                 ArtikelDTO artikel = new ArtikelDTO();
                 
                 artikel.ID = row["ID"];
                 artikel.Name = row["Name"];
                 artikel.Preis = row["Preis"];
                 artikel.Description = row["Description"];
                 
                  this.Stammdaten.Add(artikel);
             }
        }
        
        public void StammdatenSpeichern()
        {
                foreach (ArtikelDTO artikel in this.Stammdaten)
                {
                
                   // --> DataRow dr = this.table.NewRow();
                    DataRow dr = table.NewRow();

                    dr[0] = ID;
                    dr[1] = artikel.Name;
                    dr[2] = artikel.Preis;
                    dr[3] = artikel.Description;

                    table.Rows.Add(dr);
                    
                }
        }

        public void ResetFelder()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        public void Protokollieren(string text)
        {
            System.IO.File.WriteAllText(@"C:\Users\Annalena\source\repos\TestApplication\TestApplication\protokoll.txt", text);
        }

        // Daten anlegen Button
        private void Button1_Click(object sender, EventArgs e)
        {
            ArtikelDataDTO artikeldata = new ArtikelDataDTO();
            ArtikelDTO artikel = new ArtikelDTO();

            artikel.Name = textBox1.Text;
            artikel.Preis = float.Parse(textBox2.Text);
            artikel.Description = textBox3.Text;

            artikeldata.Name = textBox1.Text;
            artikeldata.Preis = float.Parse(textBox2.Text);
            artikeldata.Description = textBox3.Text;
            artikeldata.action = 1;

            this.Artikelliste.Add(artikeldata);
            this.Stammdaten.Add(artikel);

            this.ResetFelder();

            this.Protokollieren("- Artikel angelegt");
            
        }

        // Daten bearbeiten Button
        private void Button2_Click(object sender, EventArgs e)
        {
            ArtikelDataDTO artikeldata = new ArtikelDataDTO();
            ArtikelDTO artikel = new ArtikelDTO();

            artikel.Name = textBox1.Text;
            artikel.Preis = float.Parse(textBox2.Text);
            artikel.Description = textBox3.Text;

            this.Stammdaten[int.Parse(textBox4.Text)] = artikel;

            artikeldata.Name = textBox1.Text;
            artikeldata.Preis = float.Parse(textBox2.Text);
            artikeldata.Description = textBox3.Text;
            artikeldata.action = 2;

            this.Artikelliste.Add(artikeldata);

            this.ResetFelder();

            this.Protokollieren("- Artikel bearbeitet");
        }

        // Daten löschen Button
        private void Button3_Click(object sender, EventArgs e)
        {
            ArtikelDataDTO artikel = new ArtikelDataDTO();

            this.Stammdaten.RemoveAt(int.Parse(textBox4.Text));

            artikel.Name = textBox1.Text;
            artikel.action = 3;

            this.Artikelliste.Add(artikel);

            this.ResetFelder();

            this.Protokollieren("- Artikel gelöscht");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // Daten übertragen Button
        private void Button4_Click(object sender, EventArgs e)
        {
            RakutenAPI rakuten = new RakutenAPI();
            rakuten.ArtikelListeVerarbeiten(this.Artikelliste);
        }

        // TODO: Speichern der Stammdaten, bei Klick auf Daten speichern Button (Button5)
        private void Button5_Click(object sender, EventArgs e)
        {
   
        }

        // Daten lesen Button
        private void Button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            // ID Textbox
            if(textBox4.Text.Length == 0)
            {
                int count = 0;
                string t = "";
                foreach (ArtikelDTO artikel in this.Stammdaten)
                {
                    t += String.Format("ID: {0},Name: {1}, Preis: {2}, Beschreibung: {3} \n", count, artikel.Name, artikel.Preis, artikel.Description);
                    richTextBox1.Text = t;
                    count++;
                }
            }
            else
            {
                if (this.Stammdaten.Count >= int.Parse(textBox4.Text))
                {
                    ArtikelDTO artikel = this.Stammdaten[int.Parse(textBox4.Text)];
                    string t = String.Format("ID: {0}, Name: {1}, Preis: {2}, Beschreibung: {3}", int.Parse(textBox4.Text), artikel.Name, artikel.Preis, artikel.Description);
                    richTextBox1.Text = t;
                }
            }

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }
}
