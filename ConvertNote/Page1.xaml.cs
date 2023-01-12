using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConvertNote
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        //Partie Boutons (Convert et Clear)
        private void btnconvert_Click(object sender, RoutedEventArgs e)
        ///<summary>
        ///Permet de récupérer la valeur des input de note_act et note_max
        ///Si notemax est négative, erreur / si noteact > notemax, erreur (ordre important)
        ///Sinon conversion en note sur 20
        ///</summary>
        {
            //si une des textbox de note est vide (ou les deux)
            if (note_act.Text == "" || note_max.Text == "")
            {
                note_result.Text = "Une note ne peut être vide"; //on affiche l'erreur dans le textblock de resultat
                return;
            }
            //si c'est ok, on essaye de convertir les valeurs récupérées en int
            if((VerifyIfInt(note_act.Text) == false) || (VerifyIfInt(note_max.Text) == false))
            {
                note_result.Text = "Les valeurs doivent être des entiers"; //on affiche l'erreur dans le textblock de resultat
                return;
            }
            //si c'est ok, on convertit en int
            int noteact = Convert.ToInt32(note_act.Text);
            int notemax = Convert.ToInt32(note_max.Text);
            if ((VerifyValue(noteact, notemax)) == true)
            {
                //si c'est ok
                while (notemax % 20 != 0)
                {
                    noteact = noteact * 10;
                    notemax = notemax * 10;
                }
                int diviseur = notemax / 20;
                int resultat = noteact / diviseur;
                note_result.Text = $"Equivaut à {resultat}/20"; //on affiche le résultat dans le textblock de resultat
            }
        }

        private void btnclear_Click(object sender, RoutedEventArgs e)
        ///<summary>
        ///Effacer le contenu de toutes les textbox de l'app
        ///</summary>
        {
            note_act.Text = "";
            note_max.Text = "";
            note_result.Text = "";
        }

        //Partie Code
        private bool VerifyIfInt(string note)
        {
            if (int.TryParse(note, out int value))
            {
                return true;
            }
            return false;
        }

        private bool VerifyValue(int noteact, int notemax)
        {
            //si une des valeurs (ou les deux) est négative
            if (notemax < 0 || (noteact < 0 && notemax < 0))
            {
                note_result.Text = "La valeur max de la note ne peut être négative"; //on affiche l'erreur dans le textblock de resultat
                return false;
            }
            //si la note est supérieure a la note max
            if (notemax < noteact)
            {
                note_result.Text = "Votre note ne peut être supérieure à la note max"; //on affiche l'erreur dans le textblock de resultat
                return false;
            }
            return true;
        }
    }
}
