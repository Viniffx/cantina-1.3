namespace Cantina_1._3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            lblTotal = new Label();
            btnAdicionar = new Button();
            btnremover = new Button();
            btbEncerrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 41);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "Produtos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(468, 41);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 1;
            label2.Text = "Carrinho";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(81, 82);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(203, 124);
            listBox1.TabIndex = 2;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(468, 82);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(203, 124);
            listBox2.TabIndex = 3;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(468, 227);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(70, 25);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total:  ";
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(327, 93);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(97, 23);
            btnAdicionar.TabIndex = 5;
            btnAdicionar.Text = "Adicionar >";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click_1;
            // 
            // btnremover
            // 
            btnremover.Location = new Point(327, 161);
            btnremover.Name = "btnremover";
            btnremover.Size = new Size(97, 23);
            btnremover.TabIndex = 6;
            btnremover.Text = "< Remover";
            btnremover.UseVisualStyleBackColor = true;
            btnremover.Click += btnremover_Click_1;
            // 
            // btbEncerrar
            // 
            btbEncerrar.Location = new Point(309, 290);
            btbEncerrar.Name = "btbEncerrar";
            btbEncerrar.Size = new Size(150, 45);
            btbEncerrar.TabIndex = 7;
            btbEncerrar.Text = "Fechar Pedido";
            btbEncerrar.UseVisualStyleBackColor = true;
            btbEncerrar.Click += btbEncerrar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btbEncerrar);
            Controls.Add(btnremover);
            Controls.Add(btnAdicionar);
            Controls.Add(lblTotal);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label lblTotal;
        private Button btnAdicionar;
        private Button btnremover;
        private Button btbEncerrar;
    }
}
