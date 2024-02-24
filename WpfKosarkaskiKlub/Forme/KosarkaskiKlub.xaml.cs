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
    /// Interaction logic for KosarkaskiKlub.xaml
    /// </summary>
    public partial class KosarkaskiKlub : Window
    {
       
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public KosarkaskiKlub()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
            txtImeKluba.Focus();
        }
        public KosarkaskiKlub(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImeKluba.Focus();
            PopuniPadajuceListe();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;

        }
        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();
                string vratiLigu = @"select ligaID, imeLige from Liga";
                DataTable dtLiga = new DataTable();
                SqlDataAdapter daLiga = new SqlDataAdapter(vratiLigu, konekcija);
                daLiga.Fill(dtLiga);
                cbLiga.ItemsSource = dtLiga.DefaultView;
                cbLiga.DisplayMemberPath = "imeLige";
                daLiga.Dispose();
                dtLiga.Dispose();

                string vratiArenu = @"select arenaID, imeArene from Arena";
                DataTable dtArena = new DataTable();
                SqlDataAdapter daArena = new SqlDataAdapter(vratiArenu, konekcija);
                daArena.Fill(dtArena);
                cbArena.ItemsSource = dtArena.DefaultView;
                cbArena.DisplayMemberPath = "imeArene";
                daArena.Dispose();
                dtArena.Dispose();

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
                cmd.Parameters.Add("@imeKluba", System.Data.SqlDbType.NVarChar).Value = txtImeKluba.Text;
                cmd.Parameters.Add("@drzavaKluba", System.Data.SqlDbType.NVarChar).Value = txtDrzavaKluba.Text;
                cmd.Parameters.Add("@godinaOsnivanja", System.Data.SqlDbType.Int).Value = txtGodinaOsvajanja.Text;
                cmd.Parameters.Add("@vrednostKluba", System.Data.SqlDbType.Int).Value = txtVrednostKluba.Text;
                cmd.Parameters.Add("@ligaID", System.Data.SqlDbType.Int).Value = cbLiga.SelectedValue;
                cmd.Parameters.Add("@arenaID", System.Data.SqlDbType.Int).Value = cbArena.SelectedValue;
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update KosarkaskiKlub
                                        Set imeKluba = @imeKluba,
                                            drzavaKluba = @drzavaKluba,
                                            godinaOsnivanja = @godinaOsnivanja,
                                            vrednostKluba = @vrednostKluba,
                                            ligaID = @ligaID,
                                            arenaID = @arenaID,                                          
                                        where kosarkaskiKlubID = @kosarkaskiKlubID";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into KosarkaskiKlub(imeKluba, drzavaKluba, godinaOsnivanja, vrednostKluba, ligaID, arenaID)
                                        values (@imeKluba, @drzavaKluba, @godinaOsnivanja, @vrednostKluba, @ligaID, @arenaID)";
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
