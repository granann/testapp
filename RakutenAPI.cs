using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace TestApplication
{
    class RakutenAPI
    {

        public RakutenAPI()
        {
            //this.ArtikelListeVerarbeiten(artikelliste);
        }

        public void ArtikelListeVerarbeiten(List<ArtikelDataDTO> liste)
        {
            foreach (ArtikelDataDTO artikel in liste)
            {

                MessageBox.Show(artikel.Name);
                switch (artikel.action)
                {
                    case 1:
                        this.ArtikelAnlegen(artikel);
                        break;
                    case 2:
                        this.ArtikelBearbeiten(artikel);
                        break;
                    case 3:
                        this.ArtikelLöschen(artikel);
                        break;
                    default:
                        Console.WriteLine("Keine valide Aktion");
                        break;
                }

            }
        }

        public string ArtikelAnlegen(ArtikelDataDTO artikel) 
        {
            // API Request an Rakuten --> artikel anlegena
            return "";
        }

        public string ArtikelBearbeiten(ArtikelDataDTO artikel)
        {
            // API Request an Rakuten --> artikel bearbeiten
            return "";
        }

        public string ArtikelLöschen(ArtikelDataDTO artikel)
        {
            // API Request an Rakuten --> artikel löschen
            return "";
        }

    }
}
