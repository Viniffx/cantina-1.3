using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;


namespace Cantina_1._3
{
    public partial class Form1_Pedidos : Form
    {
        private List<Produto> produtos;
        private Carrinho carrinho;

        public Form1_Pedidos()
        {
            InitializeComponent();

            txtValorPago.Visible = false;
            txtTroco.Visible = false;
            labelV.Visible = false;
            labelT.Visible = false;

            carrinho = new Carrinho();

            produtos = new List<Produto>
            {
                new Produto { Nome = "Pão de Queijo", Preco = 3.50m },
                new Produto { Nome = "Coxinha", Preco = 5.00m },
                new Produto { Nome = "Pastel de Carne", Preco = 6.00m },
                new Produto { Nome = "Pastel de Queijo", Preco = 5.50m },
                new Produto { Nome = "Hamburger", Preco = 8.00m },
                new Produto { Nome = "Cheese Burger", Preco = 9.00m },
                new Produto { Nome = "X - Tudo", Preco = 12.00m },
                new Produto { Nome = "Água Mineral", Preco = 2.50m },
                new Produto { Nome = "Suco Natural 300ml", Preco = 4.00m },
                new Produto { Nome = "Refrigerante Lata", Preco = 4.50m },
                new Produto { Nome = "Milk Shake", Preco = 12.00m },
            };

            cmbPagamento.Items.AddRange(new string[] { "Dinheiro", "Débito", "Crédito", "Pix", "VR", "VA" });

            listBox1.DataSource = produtos;
            listBox1.DisplayMember = "Descricao";

            listBox2.DisplayMember = "DescricaoCarrinho";
        }
        // Essa função serve apenas para alterar a fonte da message box
        public class FormMessageBox : Form
        {
            private Label lblMensagem;
            private Button btnOk;

            public FormMessageBox(string mensagem)
            {
                this.Text = "Pedido Finalizado";
                this.Size = new Size(350, 300); // Ajuste do tamanho da caixa
                this.StartPosition = FormStartPosition.CenterScreen;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;

                lblMensagem = new Label
                {
                    Text = mensagem,
                    Font = new Font("Arial", 12, FontStyle.Regular), // Fonte Arial 12 sem negrito
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft, // Texto justificado à esquerda
                    Dock = DockStyle.Top,
                    Height = 220, // Ajuste da altura do label
                    Padding = new Padding(10) // Espaçamento interno para melhor visualização
                };

                btnOk = new Button
                {
                    Text = "OK",
                    Size = new Size(80, 30), // Tamanho do botão
                    Location = new Point((this.Width - 80) / 2, this.Height - 80) // Ajuste da posição no final
                };

                btnOk.Anchor = AnchorStyles.Bottom; // Fixar o botão na parte inferior
                btnOk.Click += (sender, e) => this.Close();

                this.Controls.Add(lblMensagem);
                this.Controls.Add(btnOk);
            }

            public static void Show(string mensagem)
            {
                FormMessageBox form = new FormMessageBox(mensagem);
                form.ShowDialog();
            }
        }


        public class Produto
        {
            public string Nome { get; set; }
            public decimal Preco { get; set; }
            public int Quantidade { get; set; } = 1;

            public string Descricao => $"{Nome} - R$ {Preco:F2}";
            public string DescricaoCarrinho => $"{Quantidade}x {Nome} - R$ {Preco * Quantidade:F2}";
        }

        public class Carrinho
        {
            private List<Produto> itens = new List<Produto>();

            public void Adicionar(Produto produto)
            {
                Produto itemExistente = itens.FirstOrDefault(p => p.Nome == produto.Nome);

                if (itemExistente != null)
                {
                    itemExistente.Quantidade += produto.Quantidade;
                }
                else
                {
                    itens.Add(produto);
                }
            }

            public decimal Total() => itens.Sum(p => p.Preco * p.Quantidade);
            public List<Produto> Listar() => new List<Produto>(itens);
            public void Limpar() => itens.Clear();
        }

        private void AtualizarTotal()
        {
            lblTotal.Text = $"Total: R${carrinho.Total():F2}";

            listBox2.Items.Clear();
            foreach (var item in carrinho.Listar())
            {
                listBox2.Items.Add(item.DescricaoCarrinho);
            }
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Produto produto)
            {
                Produto novoProduto = new Produto
                {
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = (int)numericUpDown.Value
                };

                carrinho.Adicionar(novoProduto);
                AtualizarTotal();
                numericUpDown.Value = 1;
            }
        }

        private void btnremover_Click_1(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                string itemSelecionado = listBox2.SelectedItem.ToString();
                Produto produtoRemover = carrinho.Listar().FirstOrDefault(p => p.DescricaoCarrinho == itemSelecionado);

                if (produtoRemover != null)
                {
                    carrinho.Listar().Remove(produtoRemover); // Isso não funciona

                    // Solução: Acesse diretamente a lista de itens da classe Carrinho
                    var itensCarrinho = typeof(Carrinho).GetField("itens", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(carrinho) as List<Produto>;

                    if (itensCarrinho != null)
                    {
                        itensCarrinho.Remove(produtoRemover);
                    }

                    AtualizarTotal();
                }
            }
        }

        private void btbEncerrar_Click(object sender, EventArgs e)
        {
            decimal totalPedido = carrinho.Total();
            string nome = string.IsNullOrWhiteSpace(nomeCliente.Text) ? "Cliente" : nomeCliente.Text;
            string mensagem = $"Pedido de {nome}\nTotal do pedido: R$ {totalPedido:F2}";

            // Verifica se o pagamento foi em dinheiro e se o valor pago é suficiente
            if (cmbPagamento.SelectedItem?.ToString() == "Dinheiro" && decimal.TryParse(txtValorPago.Text, out decimal valorPago))
            {
                if (valorPago < totalPedido)
                {
                    MessageBox.Show("Valor insuficiente! Por favor, insira um valor maior ou igual ao total do pedido.", "Erro no Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Impede o encerramento do pedido
                }

                decimal troco = valorPago - totalPedido;

                if (troco > 0) // Exibe o troco se houver
                {
                    mensagem += $"\nTroco: R$ {troco:F2}";
                }
            }

            // Adiciona a data e hora do pedido
            string dataHoraPedido = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            mensagem += $"\nData e Hora: {dataHoraPedido}";

            // Verifica se o pedido é para viagem
            if (checkViagem.Checked)
            {
                mensagem += "\nPedido para viagem";
            }

            FormMessageBox.Show(mensagem);

            // Limpar carrinho e atualizar a interface
            carrinho.Limpar();
            listBox2.Items.Clear();
            txtValorPago.Clear();
            txtTroco.Clear();
            cmbPagamento.SelectedIndex = -1;
            txtValorPago.Visible = false;
            txtTroco.Visible = false;
            labelV.Visible = false;
            labelT.Visible = false;
            AtualizarTotal();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem is Produto produto)
            {
                produto.Quantidade = (int)numericUpDown.Value;
                AtualizarTotal();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cmbPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool dinheiro = cmbPagamento.SelectedItem?.ToString() == "Dinheiro";
            txtValorPago.Visible = dinheiro;
            txtTroco.Visible = dinheiro;
            labelV.Visible = dinheiro;
            labelT.Visible = dinheiro;
        }

        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValorPago.Text, out decimal valorPago))
            {
                decimal troco = valorPago - carrinho.Total();
                txtTroco.Text = troco >= 0 ? troco.ToString("F2") : "0.00"; // Evita troco negativo
            }
            else
            {
                txtTroco.Text = "0.00"; // Caso o valor digitado seja inválido
            }
        }

        private void txtTroco_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkViagem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nomeCliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


/*namespace Cantina_1._3
{
    public partial class Form1 : Form
    {
        private List<Produto> produtos;
        private Carrinho carrinho;
        public Form1()
        {
            InitializeComponent();
            carrinho = new Carrinho();
            listBox1.DataSource = produtos;
            listBox1.DisplayMember = "Nome";
            listBox1.ValueMember = "Preco";
            listBox2.DisplayMember = "Nome";
            listBox2.ValueMember = "Preco";
            listBox1.Items.Add(new Produto { Nome = "Mini Pizza - R$ 12,00", Preco = 12 });
            listBox1.Items.Add(new Produto { Nome = "Pastel - R$ 10,00", Preco = 10 });
            listBox1.Items.Add(new Produto { Nome = "Fogazza - R$ 5,00", Preco = 5 });
            listBox1.Items.Add(new Produto { Nome = "Bolo de Pote - R$ 8,00", Preco = 8 });
            listBox1.Items.Add(new Produto { Nome = "Churros - R$ 6,00", Preco = 6 });
            listBox1.Items.Add(new Produto { Nome = "Milk Shake - R$ 12,00", Preco = 12 });
            listBox1.Items.Add(new Produto { Nome = "Suco Natural - R$ 8,00", Preco = 8 });
            listBox1.Items.Add(new Produto { Nome = "Refrigerante - R$ 7,00", Preco = 7 });


        }
        public class Produto
        {
            public string Nome { get; set; }
            public decimal Preco { get; set; }
        }

        public class Carrinho
        {
            private List<Produto> itens = new List<Produto>();

            public void Adicionar(Produto produto) => itens.Add(produto);
            public void Remover(Produto produto) => itens.Remove(produto);

            public decimal Total() => itens.Sum(p => p.Preco);
            public List<Produto> Listar() => new List<Produto>(itens);
            public void Limpar() => itens.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AtualizarTotal()
        {
            lblTotal.Text = $"Total: R${carrinho.Total():F2}";
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Produto produto)
            {
                carrinho.Adicionar(produto);
                listBox2.Items.Add(produto);
                AtualizarTotal();
            }
        }

        private void btnremover_Click_1(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem is Produto produto)
            {
                carrinho.Remover(produto);
                listBox2.Items.Remove(produto);
                AtualizarTotal();
            }
        }

        private void btbEncerrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Total do pedido: R$ {carrinho.Total():F2}", "Pedido Finalizado");
            carrinho.Limpar();
            listBox2.Items.Clear();
            AtualizarTotal();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
*/

