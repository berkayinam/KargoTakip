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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(139, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 23);
            textBox1.TabIndex = 1;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(358, 21);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(154, 23);
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
            dataGridView1.Size = new Size(500, 504);
            dataGridView1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(295, 22);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(57, 23);
            textBox2.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(295, 4);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 5;
            label1.Text = "Magaza";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 4);
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
            // Form1
            // 
            ClientSize = new Size(525, 564);
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
    }
}
