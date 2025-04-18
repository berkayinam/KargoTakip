using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KargoTakip
{
    public partial class Form1 : Form
    {
        private List<Kargo> kargoListesi = new List<Kargo>();

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(new string[] { "UPS", "Aras", "Yurtiçi" });

            timer1.Interval = 900000; // 1dk 60,000 // 5dk 300,000// 10dk  600,000// 15dk  900,000 //30 dk  1,800,000// 60dk  3,600,000
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            comboBox1.SelectedValue = "UPS";
        }


        private async void btnEkle_Click(object sender, EventArgs e)
        {
            var firma = comboBox1.SelectedItem?.ToString();
            var takipNo = textBox1.Text.Trim();
            var magazaID = textBox2.Text.Trim();
            var talepID = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(firma) || string.IsNullOrEmpty(takipNo))
            {
                MessageBox.Show("Lütfen firma ve takip numarasý giriniz.");
                return;
            }
            if (kargoListesi.Any(k => k.TakipNo == takipNo))
            {
                MessageBox.Show("Bu takip numarasý zaten eklendi.");
                return;
            }
            else
            {
                var durum = await KargoDurumuKontrolEt(firma, takipNo);
                var kargo = new Kargo
                {
                    Firma = firma,
                    TakipNo = takipNo,
                    TeslimEdildi = durum.TeslimEdildi,
                    LastUpdate = DateTime.Now.ToString("HH:mm"),
                    OngorulenTeslimat = durum.OngorulenTeslimat,
                    MagazaID = magazaID,
                    TalepID = talepID
                };

                kargoListesi.Add(kargo);
                YenileGrid();
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        public class KargoDurumSonucu
        {
            public bool TeslimEdildi { get; set; }
            public string? OngorulenTeslimat { get; set; }
        }

        private async Task<KargoDurumSonucu> KargoDurumuKontrolEt(string? firma, string? takipNo)
        {
            if (firma == "UPS")
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.GetStringAsync($"https://www.ups.com.tr/WaybillSorgu.aspx?Waybill={takipNo}");
                        var sonuc = new KargoDurumSonucu();
                        var match = Regex.Match(response, @"<span[^>]*id=""ctl00_MainContent_Label2""[^>]*>Öngörülen Teslimat Zamaný<\/span><br\s*\/?>\s*<span[^>]*id=""ctl00_MainContent_teslimat_zamani""[^>]*>(.*?)<\/span>", RegexOptions.Singleline);

                        if (match.Success)
                        {
                            var ongorulen = match.Groups[1].Value.Trim();
                            ongorulen = Regex.Replace(ongorulen, "<.*?>", "").Trim();
                            sonuc.OngorulenTeslimat = ongorulen;
                        }

                        sonuc.TeslimEdildi = response.Contains("Paketiniz teslim edilmiþtir", StringComparison.OrdinalIgnoreCase);

                        return sonuc;
                    }
                }
                catch
                {
                    MessageBox.Show("Beklenmeyen Hata, Manuel Test Edin...");
                    return new KargoDurumSonucu { TeslimEdildi = false };
                }
            }

            return new KargoDurumSonucu { TeslimEdildi = false };
        }
        private async void Timer1_Tick(object? sender, EventArgs e)
        {
            foreach (var kargo in kargoListesi)
            {
                var durum = await KargoDurumuKontrolEt(kargo.Firma, kargo.TakipNo);
                kargo.TeslimEdildi = durum.TeslimEdildi;
                if (!string.IsNullOrEmpty(durum.OngorulenTeslimat))
                {
                    kargo.OngorulenTeslimat = durum.OngorulenTeslimat;
                }
            }

            YenileGrid();
        }

        private void YenileGrid()
        {
            var siraliListe = kargoListesi
                .OrderBy(k => k.TeslimEdildi)
                .ToList();

            dataGridView1.DataSource = null;
            CheckBoxKolonuEkle();
            ButonKolonuEkle();
            dataGridView1.DataSource = siraliListe;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is Kargo kargo)
                {
                    row.DefaultCellStyle.BackColor = kargo.TeslimEdildi ? Color.LightGreen : Color.IndianRed;
                    kargo.LastUpdate = DateTime.Now.ToString("HH:mm");
                }
            }
            if (dataGridView1.Columns.Contains("TeslimEdildi"))
                dataGridView1.Columns["TeslimEdildi"].Visible = false;
            if (dataGridView1.Columns.Contains("OngorulenTeslimat"))
                dataGridView1.Columns["OngorulenTeslimat"].Visible = false;


        }

        private void ButonKolonuEkle()
        {
            if (!dataGridView1.Columns.Contains("Detay"))
            {
                var btn = new DataGridViewButtonColumn();
                btn.Name = "Detay";
                btn.HeaderText = "Detay";
                btn.Text = "Göster";
                btn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btn);
            }
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            var silinecekler = kargoListesi.Where(k => k.IsChecked).ToList();

            if (silinecekler.Count == 0)
            {
                MessageBox.Show("Seçili kargo yok.");
                return;
            }

            var result = MessageBox.Show($"{silinecekler.Count} kargo silinecek. Emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (var item in silinecekler)
                {
                    kargoListesi.Remove(item);
                }

                YenileGrid();
            }
        }
        private void CheckBoxKolonuEkle()
        {
            if (!dataGridView1.Columns.Contains("IsChecked"))
            {
                var chk = new DataGridViewCheckBoxColumn();
                chk.DataPropertyName = "IsChecked";
                chk.HeaderText = "Not Alýndý";
                chk.Name = "IsChecked";
                chk.Width = 60;
                dataGridView1.Columns.Insert(0, chk);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Detay")
            {
                var kargo = dataGridView1.Rows[e.RowIndex].DataBoundItem as Kargo;
                if (kargo != null)
                {
                    string mesaj = "Detay bilgisi bulunamadý.";
                    if (!string.IsNullOrEmpty(kargo.OngorulenTeslimat))
                    {
                        mesaj = $"Öngörülen Teslimat: {kargo.OngorulenTeslimat}";
                    }
                    MessageBox.Show(mesaj, "Kargo Detayý");
                }
            }
        }
    }
}

