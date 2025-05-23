namespace Cantina_1._3
{
    partial class Balcao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            btnEntregar = new Button();
            imageList1 = new ImageList(components);
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(32, 123);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(812, 199);
            listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            listBox2.Enabled = false;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(32, 370);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(812, 154);
            listBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 95);
            label1.Name = "label1";
            label1.Size = new Size(72, 19);
            label1.TabIndex = 2;
            label1.Text = "Pedidos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Inter", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 342);
            label2.Name = "label2";
            label2.Size = new Size(82, 19);
            label2.TabIndex = 3;
            label2.Text = "Entregue";
            label2.Click += label2_Click;
            // 
            // btnEntregar
            // 
            btnEntregar.Font = new Font("Inter", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEntregar.Location = new Point(850, 149);
            btnEntregar.Name = "btnEntregar";
            btnEntregar.Size = new Size(93, 64);
            btnEntregar.TabIndex = 4;
            btnEntregar.Text = "Entregar";
            btnEntregar.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Bolt_com_fundo_amarelo;
            pictureBox1.Location = new Point(295, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(288, 87);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // Balcao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 255, 0);
            ClientSize = new Size(955, 552);
            Controls.Add(pictureBox1);
            Controls.Add(btnEntregar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            ForeColor = SystemColors.ControlText;
            Name = "Balcao";
            Text = "Balcao";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private Label label1;
        private Label label2;
        private Button btnEntregar;
        private ImageList imageList1;
        private PictureBox pictureBox1;
    }
}