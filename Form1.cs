namespace Cantina_1._3
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
    }
}
