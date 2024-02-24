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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfKosarkaskiKlub.Forme
{
    /// <summary>
    /// Interaction logic for Trener.xaml
    /// </summary>
    public partial class Trener : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public Trener()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
            txtIme.Focus();
        }
        public Trener(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIme.Focus();
            PopuniPadajuceListe();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;

        }
        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();
                string vratiKosarkaskiKlub = @"select kosarkaskiKlubID, imeKluba from KosarkaskiKlub";
                DataTable dtKosarkaskiKlub = new DataTable();
                SqlDataAdapter daKosarkaskiKlub = new SqlDataAdapter(vratiKosarkaskiKlub, konekcija);
                daKosarkaskiKlub.Fill(dtKosarkaskiKlub);
                cbKosarkaskiKlub.ItemsSource = dtKosarkaskiKlub.DefaultView;
                cbKosarkaskiKlub.DisplayMemberPath = "imeKluba";
                daKosarkaskiKlub.Dispose();
                dtKosarkaskiKlub.Dispose();

            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }


        }
        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@ime", System.Data.SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@prezime", System.Data.SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@brojGodina", System.Data.SqlDbType.Int).Value = txtBrojGodina.Text;
                cmd.Parameters.Add("@vrstaTrenera", System.Data.SqlDbType.NVarChar).Value = txtVrstaTrenera.Text;
                cmd.Parameters.Add("@plata", System.Data.SqlDbType.Int).Value = txtPlata.Text;
                cmd.Parameters.Add("@kosarkaskiklubID", System.Data.SqlDbType.Int).Value = cbKosarkaskiKlub.SelectedValue;
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update Trener
                                        Set ime = @ime,
                                            prezime = @prezime,
                                            brojGodina = @brojGodina,
                                            vrstaTrenera = @vrstaTrenera,
                                            plata = @plata,
                                            kosarkaskiklubID = @kosarkaskiklubID
                                        where trenerID = @id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Trener(ime, prezime, brojGodina, vrstaTrenera, plata, kosarkaskiKlubID)
                                        values (@ime, @prezime, @brojGodina, @vrstaTrenera, @plata, @kosarkaskiklubID)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Greska prilikom konverzije podataka", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                azuriraj = false;
            }

        }
        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
