namespace KargoTakip
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button btnEkle;
        private DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            btnEkle = new Button();
            dataGridView1 = new DataGridView();
            timer1 = new System.Windows.Forms.Timer(components);
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSil = new Button();
            textBox3 = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(86, 23);
            comboBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(105, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 23);
            textBox1.TabIndex = 1;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(410, 23);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(107, 23);
            btnEkle.TabIndex = 2;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Location = new Point(12, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(586, 504);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellClick += DataGridView1_CellClick;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(261, 23);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(57, 23);
            textBox2.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(261, 5);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 5;
            label1.Text = "Magaza ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(105, 5);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 6;
            label2.Text = "Takip No";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 4);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 7;
            label3.Text = "Kargo";
            // 
            // btnSil
            // 
            btnSil.Location = new Point(523, 23);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(75, 23);
            btnSil.TabIndex = 8;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(324, 23);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(80, 23);
            textBox3.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(324, 5);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 10;
            label4.Text = "Talep ID";
            // 
            // Form1
            // 
            ClientSize = new Size(610, 564);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(btnSil);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(btnEkle);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Kargo Takip Sistemi";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSil;
        private TextBox textBox3;
        private Label label4;
    }
}
