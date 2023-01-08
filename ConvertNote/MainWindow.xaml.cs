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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnconvert_Click(object sender, RoutedEventArgs e)
        ///<summary>
        ///Permet de récupérer la valeur des input de note_act et note_max
        ///Si notemax est négative, erreur / si noteact > notemax, erreur (ordre important)
        ///Sinon conversion en note sur 20
        ///</summary>
        {
            int noteact = Convert.ToInt32(note_act.Text);
            int notemax = Convert.ToInt32(note_max.Text);
            //si une des valeurs (ou les deux) est négative
            if (notemax < 0 || (noteact < 0 && notemax < 0))
            {
                note_result.Text = "La valeur max de la note ne peut être négative"; //on affiche l'erreur dans la textbox de resultat
                return;
            }
            //si la note est supérieure a la note max
            if (notemax < noteact)
            {
                note_result.Text = "Votre note ne peut être supérieure à la note max"; //on affiche l'erreur dans la textbox de resultat
                return;
            }
            //si c'est ok
            while (notemax % 20 != 0)
            {
                noteact = noteact * 10;
                notemax = notemax * 10;
            }
            int diviseur = notemax / 20;
            int resultat = noteact / diviseur;
            note_result.Text = $"Equivaut à {resultat}/20"; //on affiche le résultat dans la textbox de resultat
        }
    }
}
