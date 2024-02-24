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
    /// Interaction logic for Trofej.xaml
    /// </summary>
    public partial class Trofej : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public Trofej()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
            txtImeTrofeja.Focus();
        }
        public Trofej(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImeTrofeja.Focus();
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
                cmd.Parameters.Add("@imeTrofeja", System.Data.SqlDbType.NVarChar).Value = txtImeTrofeja.Text;
                cmd.Parameters.Add("@godinaOsnivanjaTrofeja", System.Data.SqlDbType.Int).Value = txtGodinaOsvajanja.Text;
                cmd.Parameters.Add("@kosarkaskiklubID", System.Data.SqlDbType.Int).Value = cbKosarkaskiKlub.SelectedValue;
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update Trofej
                                        Set imeTrofeja = @imeTrofeja,
                                            godinaOsnivanjaTrofeja = @godinaOsnivanjaTrofeja,
                                            kosarkaskiklubID = @kosarkaskiklubID
                                        where trofejID = @id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Trofej(imeTrofeja, godinaOsnivanjaTrofeja, kosarkaskiKlubID)
                                        values (@imeTrofeja, @godinaOsnivanjaTrofeja, @kosarkaskiklubID)";
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
