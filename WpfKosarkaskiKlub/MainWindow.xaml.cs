using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using WpfKosarkaskiKlub.Forme;

namespace WpfKosarkaskiKlub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ucitanaTabela;
        bool azuriraj;
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        #region Select Upiti
        private static string igracSelect = @"select igracID as ID, ime as Ime, prezime as Prezime, brojGodina as 'Broj Godina',visina as Visina, nacionalnost as Nacionalnost, plata as Plata,imeKluba as 'Kosarkaski Klub'
                                              from Igrac join KosarkaskiKlub on Igrac.kosarkaskiKlubID = KosarkaskiKlub.kosarkaskiKlubID ";
        private static string kosarkaskiKlubSelect = @"select kosarkaskiKlubID as ID, imeKluba as 'Ime Kluba', drzavaKluba as 'Drzava Kluba', godinaOsnivanja as 'Godina Osnivanja', vrednostKluba as 'Vrednost Kluba', imeLige as Liga, imeArene as Arena
                                             from KosarkaskiKlub join Liga on KosarkaskiKlub.ligaID=Liga.ligaID
                                                                 join Arena on KosarkaskiKlub.arenaID= Arena.arenaID";
        private static string dresSelect = @"select dresID as ID, bojaDresa as 'Boja Dresa', imeKluba as 'Kosarkaski Klub'
                                             from Dres join KosarkaskiKlub on Dres.kosarkaskiKlubID = KosarkaskiKlub.kosarkaskiKlubID ";
        private static string arenaSelect = @"select arenaID as ID, imeArene as 'Ime Arene',kapacitetArene as 'Kapacitet Arene' from Arena";
        private static string ligaSelect = @"select ligaID as ID, imeLige as 'Ime Lige', drzava as Drzava, brojKlubova as 'Broj Klubova' from Liga";
        private static string navijacSelect = @"select navijacID as ID, ime as Ime, prezime as Prezime, brojGodina as 'Broj Godina', brojSezonskeKarte as 'Broj Sezonske Karte',imeKluba as 'Kosarkaski Klub'
                                               from Navijac join KosarkaskiKlub on Navijac.kosarkaskiKlubID = KosarkaskiKlub.kosarkaskiKlubID";
        private static string sponzorSelect = @"select sponzorID as ID, imeSponzora as 'Ime Sponzora', imeKluba as 'Kosarkaski Klub'
                                                from Sponzor join KosarkaskiKlub on Sponzor.kosarkaskiKlubID = KosarkaskiKlub.kosarkaskiKlubID";
        private static string trofejSelect = @"select trofejID as ID, imeTrofeja as 'Ime Trofeja', godinaOsnivanjaTrofeja as 'Godina Osnivanja', imeKluba as 'Kosarkaski Klub'
                                               from Trofej join KosarkaskiKlub on Trofej.kosarkaskiKlubID = KosarkaskiKlub.kosarkaskiKlubID";
        private static string trenetSelect = @"select trenerID as ID,ime as Ime, Prezime as prezime, brojGodina as 'Broj Godina', vrstaTrenera as 'Vrsta Trenera', plata as Plata, imeKluba as 'Kosarkaski Klub'
                                               from Trener join KosarkaskiKlub on Trener.kosarkaskiKlubID = KosarkaskiKlub.kosarkaskiKlubID";
        #endregion
        #region Select Naredbe
        private static string selectUslovIgrac = @"select * from Igrac where igracID=";
        private static string selectUslovKosarkaskiKlub = @"select * from KosarkaskiKlub where kosarkaskiKlubID=";
        private static string selectUslovDres = @"select * from Dres where dresID=";
        private static string selectUslovArena = @"select * from Arena where arenaID=";
        private static string selectUslovLiga = @"select * from Liga where ligaID=";
        private static string selectUslovNavijac = @"select * from Navijac where navijacID=";
        private static string selectUslovSponzor = @"select * from Sponzor where sponzorID=";
        private static string selectUslovTrofej = @"select * from Trofej where trofejID=";
        private static string selectUslovTrener = @"select * from Trener where trenerID=";
        #endregion

        #region Delete Naredbe
        private static string igracDelete = @"delete from Igrac where igracID=";
        private static string kosarkaskiKlubDelete = @"delete from KosarkaskiKlub where kosarkaskiKlubID=";
        private static string dresDelete = @"delete from Dres where dresID=";
        private static string arenaDelete = @"delete from Arena where arenaID=";
        private static string ligaDelete = @"delete from Liga where ligaID=";
        private static string navijacDelete = @"delete from Navijac where navijacID=";
        private static string sponzorDelete = @"delete from Sponzor where sponzorID=";
        private static string trofejDelete = @"delete from Trofej where trofejID=";
        private static string trenerDelete = @"delete from Trener where trenerID=";
        #endregion


        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(igracSelect);
        }
        private void UcitajPodatke(string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dt = new DataTable();

                dataAdapter.Fill(dt);
                if (dataGridCentralni != null)
                {
                    dataGridCentralni.ItemsSource = dt.DefaultView;
                }
                ucitanaTabela = selectUpit;
                dt.Dispose();
                dataAdapter.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspesno Ucitani podaci!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void PopuniFormu(string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();

                if (citac.Read())     
                {
                    if (ucitanaTabela.Equals(igracSelect))
                    {
                        Igrac prozorIgrac = new Igrac(azuriraj, red); 


                        prozorIgrac.txtIme.Text = citac["ime"].ToString();
                        prozorIgrac.txtPrezime.Text = citac["prezime"].ToString();
                        prozorIgrac.txtBrojGodina.Text = citac["brojGodina"].ToString();
                        prozorIgrac.txtVisina.Text = citac["visina"].ToString();
                        prozorIgrac.txtNacionalnost.Text = citac["nacionalnost"].ToString();
                        prozorIgrac.txtPlata.Text = citac["plata"].ToString();
                        prozorIgrac.cbKosarkaskiKlub.SelectedValue = citac["kosarkaskiKlubID"].ToString();

                        prozorIgrac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(kosarkaskiKlubSelect))
                    {
                        KosarkaskiKlub prozorKosarkaskiKlub = new KosarkaskiKlub(azuriraj, red);


                        prozorKosarkaskiKlub.txtImeKluba.Text = citac["imeKluba"].ToString();
                        prozorKosarkaskiKlub.txtDrzavaKluba.Text = citac["drzavaKluba"].ToString();  
                        prozorKosarkaskiKlub.txtGodinaOsvajanja.Text = citac["godinaOsnivanja"].ToString();
                        prozorKosarkaskiKlub.txtVrednostKluba.Text = citac["vrednostKluba"].ToString();                       
                        prozorKosarkaskiKlub.cbLiga.SelectedValue = citac["ligaID"].ToString();
                        prozorKosarkaskiKlub.cbArena.SelectedValue = citac["arenaID"].ToString();

                        prozorKosarkaskiKlub.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(dresSelect))
                    {
                        Dres prozorDres = new Dres(azuriraj, red);

                        prozorDres.txtBojaDresa.Text = citac["bojaDresa"].ToString();
                        prozorDres.cbKosarkaskiKlub.SelectedValue = citac["kosarkaskiKlubID"].ToString();

                        prozorDres.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(arenaSelect))
                    {
                        Arena prozorArena = new Arena(azuriraj, red);

                        prozorArena.txtImeArene.Text = citac["imeArene"].ToString();
                        prozorArena.txtKapacitetArene.Text = citac["kapacitetArene"].ToString();

                        prozorArena.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(ligaSelect))
                    {
                        Liga prozorLiga = new Liga(azuriraj, red);

                        prozorLiga.txtImeLige.Text = citac["imeLige"].ToString();
                        prozorLiga.txtDrzava.Text = citac["drzava"].ToString();
                        prozorLiga.txtBrojKlubova.Text = citac["brojKlubova"].ToString();

                        prozorLiga.ShowDialog();
                    }                                   
                    else if (ucitanaTabela.Equals(navijacSelect))
                    {
                        Navijac prozorKupac = new Navijac(azuriraj, red);

                        prozorKupac.txtIme.Text = citac["ime"].ToString();
                        prozorKupac.txtPrezime.Text = citac["prezime"].ToString();  
                        prozorKupac.txtBrojGodina.Text = citac["brojGodina"].ToString();
                        prozorKupac.txtBrojSezonskeKarte.Text = citac["brojSezonskeKarte"].ToString();
                        prozorKupac.cbKosarkaskiKlub.SelectedValue = citac["kosarkaskiKlubID"].ToString();

                        prozorKupac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(sponzorSelect))
                    {
                        Sponzor prozorSponzor = new Sponzor(azuriraj, red);

                        prozorSponzor.txtImeSponzora.Text = citac["imeSponzora"].ToString();
                        prozorSponzor.cbKosarkaskiKlub.SelectedValue = citac["kosarkaskiKlubID"].ToString();

                        prozorSponzor.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(trofejSelect))
                    {
                        Trofej prozorTrofej = new Trofej(azuriraj, red);

                        prozorTrofej.txtImeTrofeja.Text = citac["imeTrofeja"].ToString();
                        prozorTrofej.txtGodinaOsvajanja.Text = citac["godinaOsnivanjaTrofeja"].ToString(); 
                        prozorTrofej.cbKosarkaskiKlub.SelectedValue = citac["kosarkaskiKlubID"].ToString();

                        prozorTrofej.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(trenetSelect))
                    {
                        Trener prozorTrener = new Trener(azuriraj, red);

                        prozorTrener.txtIme.Text = citac["ime"].ToString();
                        prozorTrener.txtPrezime.Text = citac["prezime"].ToString();
                        prozorTrener.txtBrojGodina.Text = citac["brojGodina"].ToString();
                        prozorTrener.txtVrstaTrenera.Text = citac["vrstaTrenera"].ToString();
                        prozorTrener.txtPlata.Text = citac["plata"].ToString();
                        prozorTrener.cbKosarkaskiKlub.SelectedValue = citac["kosarkaskiKlubID"].ToString();

                        prozorTrener.ShowDialog();
                    }
                    


                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }
        private void ObrisiZapis(string deleteUpit)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnIgrac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(igracSelect);

        }
        private void btnKosarkaskiKlub_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(kosarkaskiKlubSelect);

        }
        private void btnDres_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dresSelect);

        }
        private void btnArena_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(arenaSelect);

        }
        private void btnLiga_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(ligaSelect);

        }
        private void btnNavijac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(navijacSelect);

        }
        private void btnSponzor_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(sponzorSelect);

        }
        private void btnTrofej_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(trofejSelect);

        }
        private void btnTrener_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(trenetSelect);

        }


        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;

            if (ucitanaTabela.Equals(igracSelect))
            {
                prozor = new Igrac();
                prozor.ShowDialog();
                UcitajPodatke(igracSelect);
            }
            else if (ucitanaTabela.Equals(kosarkaskiKlubSelect))
            {
                prozor = new KosarkaskiKlub();
                prozor.ShowDialog();
                UcitajPodatke(kosarkaskiKlubSelect);
            }
            else if (ucitanaTabela.Equals(dresSelect))
            {
                prozor = new Dres();
                prozor.ShowDialog();
                UcitajPodatke(dresSelect);
            }
            else if (ucitanaTabela.Equals(arenaSelect))
            {
                prozor = new Arena();
                prozor.ShowDialog();
                UcitajPodatke(arenaSelect);
            }
            else if (ucitanaTabela.Equals(ligaSelect))
            {
                prozor = new Liga();
                prozor.ShowDialog();
                UcitajPodatke(ligaSelect);
            }
            else if (ucitanaTabela.Equals(navijacSelect))
            {
                prozor = new Navijac();
                prozor.ShowDialog();
                UcitajPodatke(navijacSelect);
            }
            else if (ucitanaTabela.Equals(sponzorSelect))
            {
                prozor = new Sponzor();
                prozor.ShowDialog();
                UcitajPodatke(sponzorSelect);
            }
            else if (ucitanaTabela.Equals(trofejSelect))
            {
                prozor = new Trofej();
                prozor.ShowDialog();
                UcitajPodatke(trofejSelect);
            }
            else if (ucitanaTabela.Equals(trenetSelect))
            {
                prozor = new Trener();
                prozor.ShowDialog();
                UcitajPodatke(trenetSelect);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(igracSelect))
            {
                PopuniFormu(selectUslovIgrac);
                UcitajPodatke(igracSelect); 
            }
            else if (ucitanaTabela.Equals(kosarkaskiKlubSelect))
            {
                PopuniFormu(selectUslovKosarkaskiKlub);
                UcitajPodatke(kosarkaskiKlubSelect);
            }
            else if (ucitanaTabela.Equals(dresSelect))
            {
                PopuniFormu(selectUslovDres);
                UcitajPodatke(dresSelect);
            }
            else if (ucitanaTabela.Equals(arenaSelect))
            {
                PopuniFormu(selectUslovArena);
                UcitajPodatke(arenaSelect);
            }
            else if (ucitanaTabela.Equals(ligaSelect))
            {
                PopuniFormu(selectUslovLiga);
                UcitajPodatke(ligaSelect);
            }
            else if (ucitanaTabela.Equals(navijacSelect))
            {
                PopuniFormu(selectUslovNavijac);
                UcitajPodatke(navijacSelect);
            }
            else if (ucitanaTabela.Equals(sponzorSelect))
            {
                PopuniFormu(selectUslovSponzor);
                UcitajPodatke(sponzorSelect);
            }
            else if (ucitanaTabela.Equals(trofejSelect))
            {
                PopuniFormu(selectUslovTrofej);
                UcitajPodatke(trofejSelect);
            }
            else if (ucitanaTabela.Equals(trenetSelect))
            {
                PopuniFormu(selectUslovTrener);
                UcitajPodatke(trenetSelect);
            }

        }
        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(igracSelect))
            {
                ObrisiZapis(igracDelete);
                UcitajPodatke(igracSelect); 
            }
            else if (ucitanaTabela.Equals(kosarkaskiKlubSelect))
            {
                ObrisiZapis(kosarkaskiKlubDelete);
                UcitajPodatke(kosarkaskiKlubSelect);
            }
            else if (ucitanaTabela.Equals(dresSelect))
            {
                ObrisiZapis(dresDelete);
                UcitajPodatke(dresSelect);
            }
            else if (ucitanaTabela.Equals(arenaSelect))
            {
                ObrisiZapis(arenaDelete);
                UcitajPodatke(arenaSelect);
            }
            else if (ucitanaTabela.Equals(ligaSelect))
            {
                ObrisiZapis(ligaDelete);
                UcitajPodatke(ligaSelect);
            }
            else if (ucitanaTabela.Equals(navijacSelect))
            {
                ObrisiZapis(navijacDelete);
                UcitajPodatke(navijacSelect);
            }
            else if (ucitanaTabela.Equals(sponzorSelect))
            {
                ObrisiZapis(sponzorDelete);
                UcitajPodatke(sponzorSelect);
            }
            else if (ucitanaTabela.Equals(trofejSelect))
            {
                ObrisiZapis(trofejDelete);
                UcitajPodatke(trofejSelect);
            }
            else if (ucitanaTabela.Equals(trenetSelect))
            {
                ObrisiZapis(trenerDelete);
                UcitajPodatke(trenetSelect);
            }
        }












    }
}
