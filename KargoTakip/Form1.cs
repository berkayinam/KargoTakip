using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
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

            timer1.Interval = 900000; // 15 dakika
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            comboBox1.SelectedValue = "UPS";
        }


        private async void btnEkle_Click(object sender, EventArgs e)
        {
            var firma = comboBox1.SelectedItem?.ToString();
            var takipNo = textBox1.Text.Trim();
            var magazaID = textBox2.Text.Trim();

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
                var kargo = new Kargo
                {
                    Firma = firma,
                    TakipNo = takipNo,
                    TeslimEdildi = await KargoDurumuKontrolEt(firma, takipNo),
                    MagazaID = magazaID
                };
                kargoListesi.Add(kargo);
                YenileGrid();
            }
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private async Task<bool> KargoDurumuKontrolEt(string? firma, string? takipNo)
        {
            if (firma == "UPS")
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.GetStringAsync($"https://www.ups.com.tr/WaybillSorgu.aspx?Waybill={takipNo}");
                        return response.Contains("Paketiniz teslim edilmiþtir", StringComparison.OrdinalIgnoreCase);
                    }
                }
                catch
                {
                    MessageBox.Show("Beklenmeyen Hata, Manuel Test Edin...");
                    return false;
                }
            }

            return false;
        }

        private async void Timer1_Tick(object? sender, EventArgs e)
        {
            foreach (var kargo in kargoListesi)
            {
                kargo.TeslimEdildi = await KargoDurumuKontrolEt(kargo.Firma, kargo.TakipNo);
            }
            YenileGrid();
        }
        private void YenileGrid()
        {
            dataGridView1.DataSource = null;
            var siraliListe = kargoListesi
                .OrderBy(k => k.TeslimEdildi)
                .ToList();

            dataGridView1.DataSource = siraliListe;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is Kargo kargo)
                {
                    row.DefaultCellStyle.BackColor = kargo.TeslimEdildi ? Color.LightGreen : Color.IndianRed;
                }
            }
        }

    }
}

