namespace Kalkulator
{
    public partial class Form1 : Form
    {

        //---------------------Promenljive-------------------------------
        double Vrednost = 0;//cuva vrednost text box-a nakon kliknute operacije
        bool OperacijaKliknuta = false;//ukazuje da li je operacija kliknuta
        string Operacija = "";//cuva koja je operacija u pitanju
        bool Greska = false;//ukazuje da je poruka o gresci ispisana ili ne
        double rez = 1;//za cuvanje rezultata operacije x^a
        //----------------------------------------------------------------

        public Form1()
        {
            InitializeComponent();
        }

        //------Metoda za ispis brojeva----------------------
        private void dugme_0_Click(object sender, EventArgs e)
        {
            var dugme = (Button)sender;

            if (rezultat.Text == "0" || OperacijaKliknuta == true || Greska == true)
            {

                rezultat.Clear();
                OperacijaKliknuta = false;
                Greska = false;

            }

            rezultat.Text = rezultat.Text + dugme.Text;
        }
        //---------------------------------------------------------

        //--------Metoda za operacije----------------------------
        private void OperacijaKlik(object sender, EventArgs e)
        {
            var dugme = (Button)sender;

            Vrednost = double.Parse(rezultat.Text);
            OperacijaKliknuta = true;
            Operacija = dugme.Text;
        }
        //---------------------------------------------------------

        //---------Metoda za izracunavanje krajnjeg rezultata-------
        private void JednakoKlik(object sender, EventArgs e)
        {
            switch (Operacija)
            {
                case "+":
                    rezultat.Text = (Vrednost + double.Parse(rezultat.Text)).ToString();
                    break;
                case "-":
                    rezultat.Text = (Vrednost - double.Parse(rezultat.Text)).ToString();
                    break;
                case "*":
                    rezultat.Text = (Vrednost * double.Parse(rezultat.Text)).ToString();
                    break;
                case "/":
                    if (rezultat.Text == "0")
                    {
                        rezultat.Text = "Greska";
                        Greska = true;
                    }   
                    else
                    rezultat.Text = (Vrednost / double.Parse(rezultat.Text)).ToString();
                    break;
                case "stepen":
                    if (rezultat.Text == "0")
                        rezultat.Text = "1";
                    else
                    {
                        try
                        {
                            for (double i = 0; i < int.Parse(rezultat.Text); i++)
                            {
                                rez = rez * Vrednost;
                            }
                            rezultat.Text = rez.ToString();
                        }
                        catch (Exception)
                        {
                            rezultat.Text = "GRESKA";
                            Greska = true;
                            throw;
                        }

                    }
                    break;

                default:
                    break;
            }
        }
        //---------------------------------------------------------

        //-------Metoda za brisanje text box-a-------------------
        private void DugmeCeKlik(object sender, EventArgs e)
        {
            rezultat.Text = "0";
        }
        //-----------------------------------------------------

        //------Metoda koja brise/resetuje kalkulator----------
        private void DugmeCKlik(object sender, EventArgs e)
        {
            rezultat.Text = "0";
            Vrednost = 0;
        }
        //----------------------------------------------------

        //-----------Metoda za backspace-------------------------
        private void DugmeBsKlik(object sender, EventArgs e)
        {
            if (rezultat.Text == "0")
            {

            }
            else if (rezultat.Text.Length == 1)
            {
                rezultat.Text = "0";
            }
            else if (rezultat.Text.Length > 1)
            {
                rezultat.Text = rezultat.Text.Remove(rezultat.Text.Length - 1, 1);
            }
        }
        //---------------------------------------------------------

        //------------------------Metoda za koren------------------
        private void DugmeKorenKlik(object sender, EventArgs e)
        {
            rezultat.Text = (Math.Sqrt(double.Parse(rezultat.Text))).ToString();
        }
        //--------------------------------------------------------------

        //---------Metoda za operaciju 1/x-------------------------
        private void DugmeJedanKrozXKlik(object sender, EventArgs e)
        {
            if(rezultat.Text == "0")
            {
                rezultat.Text = "GRESKA";
                Greska = true;
            }
            else 
                rezultat.Text = (1 / double.Parse(rezultat.Text)).ToString();
        }
        //------------------------------------------------------------

        //------------------Metoda za operaciju x^a-------------------
        private void DugmeStepenKlik(object sender, EventArgs e)
        {
            Vrednost = double.Parse(rezultat.Text);
            Operacija = "stepen";
            OperacijaKliknuta = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //----------Metoda za promenu znaka-----------------------------
        private void PromenaZnakaKlik(object sender, EventArgs e)
        {
            rezultat.Text = (double.Parse(rezultat.Text)*(-1)).ToString();
        }
        //--------------------------------------------------------------

    }
}