using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
/* Edited by Ian Dumalin*/
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oefening1_Silo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Oef1_SiloList : Window
    {
        public Oef1_SiloList()
        {
            InitializeComponent();
            MakeSilos();
            txtIn.Text = string.Empty;
            txtOut.Text = string.Empty;
        }

        //globale declaratie van objecten silo's, aangezien die onder event zeker moeten kunnen benadert worden
        Silo oSilo1, oSilo2, oSilo3;

        //globale declaratie en instantiatie van beide lijsten.
        List<Silo> siloList = new List<Silo>();
        List<ProgressBar> pgbList = new List<ProgressBar>();

        //Methode doet et ni.
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    MakeSilos();
        //}

        private void btnInOut_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = new Button();
            senderButton = (Button)sender;
            switch (senderButton.Name)
            {
                case "btnIn1":
                    txtInMethod(siloList[0]);
                    break;
                case "btnIn2":
                    txtInMethod(siloList[1]);
                    break;
                case "btnIn3":
                    txtInMethod(siloList[2]);
                    break;
                case "btnOut1":
                    txtOutMethod(siloList[0]);
                    break;
                case "btnOut2":
                    txtOutMethod(siloList[1]);
                    break;
                case "btnOut3":
                    txtOutMethod(siloList[2]);
                    break;
            }
        }

        private void MakeSilos()
        {
            //aanmaken van de lijsten met de gewenste capaciteit
            siloList.Add(oSilo1 = new Silo(100));
            siloList.Add(oSilo2 = new Silo(200));
            siloList.Add(oSilo3 = new Silo(400));

            pgbList.Add(pgbSilo1);
            pgbList.Add(pgbSilo2);
            pgbList.Add(pgbSilo3);

            //max waarde van pgb instellen
            for (int i = 0; i < siloList.Count; i++)
            {
                pgbList[i].Maximum = siloList[i].Capacity;
            }

            RefreshSilos();
        }

        //methode voor het updaten van de pgb
        //visueel voorstellen van de inhoud van de silo
        private void RefreshSilos()
        {
            for (int i = 0; i < pgbList.Count; i++)
            {
                pgbList[i].Value = (double)siloList[i].Content;
            }
        }


        private void LoadSilo(Silo silo, int laden)
        {
            string sMessage = silo.Load(laden);

            RefreshSilos();

            if (sMessage != null)
            {
                MessageBox.Show(sMessage);
            }
        }

        private void UnloadSilo(Silo silo, int uitladen)
        {
            string sMessage = silo.Unload(uitladen);

            RefreshSilos();

            if (sMessage != null)
            {
                MessageBox.Show(sMessage);
            }
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            foreach (Silo s in siloList)
            {
                if (s.Content == 0)
                {
                    s.Cleaned = true;
                }
            }
        }

        private void txtInMethod(Silo silo)
        {
            if (int.TryParse(txtIn.Text, out int iIn))
            {
                LoadSilo(silo, iIn);
            }
        }

        private void txtOutMethod(Silo silo)
        {
            if (int.TryParse(txtOut.Text, out int iOut))
            {
                UnloadSilo(silo, iOut);
            }
        }
    }
}
