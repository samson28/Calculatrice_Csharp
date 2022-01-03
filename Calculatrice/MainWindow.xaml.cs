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

namespace Calculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double premiereValeur, derniereValeur, resultat;
        Operateur op;

        public MainWindow()
        {
            InitializeComponent();
            btnAC.Click += BtnAC_Click;
            btnAdd.Click += btnOperation_Click;
            btnMulti.Click += btnOperation_Click;
            btnPM.Click += BtnPM_Click;
            btnPrc.Click += BtnPrc_Click;
            btnEgal.Click += BtnEgal_Click;
            btnPoint.Click += BtnPoint_Click;
            btnMoins.Click += btnOperation_Click;
            btnDiv.Click += btnOperation_Click;
        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            if (!lblResultat.Content.ToString().Contains(","))
            {
                lblResultat.Content = $"{lblResultat.Content},";
            }
        }


        private void BtnEgal_Click(object sender, RoutedEventArgs e)
        {
            
            derniereValeur = double.Parse(lblResultat.Content.ToString());

            switch (op)
            {
                case Operateur.Addition:
                    resultat = premiereValeur + derniereValeur;
                    break;
                case Operateur.Soustraction:
                    resultat = premiereValeur - derniereValeur;
                    break;
                case Operateur.Division:
                    if (derniereValeur == 0)
                        MessageBox.Show("imposible de diviser pas 0","erreur",MessageBoxButton.OK,MessageBoxImage.Error);
                    else
                        resultat = premiereValeur / derniereValeur;
                    break;
                case Operateur.Multiplication:
                    resultat = premiereValeur * derniereValeur;
                    break;
                default:
                    break;
            }
            lblResultat.Content = resultat.ToString();
        }

        private void BtnPrc_Click(object sender, RoutedEventArgs e)
        {
            double prc = 0;
            if(op==Operateur.Addition || op==Operateur.Soustraction)
            {
                if (double.TryParse(lblResultat.Content.ToString(), out prc))
                {
                    prc = prc / 100;
                    lblResultat.Content = (premiereValeur*prc).ToString();
                }
               
            }
            else
            {
                prc = prc / 100;
                lblResultat.Content = prc.ToString();
            }
        }

        private void BtnPM_Click(object sender, RoutedEventArgs e)
        {
            double pm;
            if(double.TryParse(lblResultat.Content.ToString(),out pm))
            {
                pm = pm * (-1);
                lblResultat.Content = pm.ToString();

            }
        }


        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            lblResultat.Content = "0";
        }

        /*private void btnSept_Click(object sender, RoutedEventArgs e)
        {
            if (lblResultat.Content.ToString()=="0")
            {
                lblResultat.Content = "7";
            }
            else
            {
                lblResultat.Content = $"{lblResultat.Content}7";
            }
        }*/


        private void btnNombre_Click(object sender, RoutedEventArgs e)
        {
            int valeurCliquee = int.Parse((sender as Button).Content.ToString());

            if (lblResultat.Content.ToString() == "0")
            {
                lblResultat.Content = $"{valeurCliquee}";
            }
            else
            {
                lblResultat.Content = $"{lblResultat.Content}{valeurCliquee}";
            }
           
        }

        public enum Operateur
        {
            Addition, Soustraction, Division, Multiplication
        }

        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnAdd) op = Operateur.Addition;
            if (sender == btnMoins) op = Operateur.Soustraction;
            if (sender == btnMulti) op = Operateur.Multiplication;
            if (sender == btnDiv) op = Operateur.Division;

            premiereValeur = double.Parse(lblResultat.Content.ToString());
            lblResultat.Content = "0";
        }
    }
}
