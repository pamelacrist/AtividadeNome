namespace pastanova.View
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormularioAutomovel : Form
    {
        Button botaoSalvar;
        private Label lblPreco;
        public TextBox preco;

        private Label lblMarca;
        public TextBox marca;

        private Label lblModelo;
        public TextBox modelo;

        private Label lblTipo;
        public ComboBox tipo;

        private Button botaoCancelar;

        public FormularioAutomovel(string nomeUsuarioAtual = "", string quantidadeUsuarioAtual = "")
        {
            this.Text = "Veiculo";
            this.Width = 600;
            lblPreco = new Label();
            lblPreco.Location = new Point(10, 10);
            lblPreco.Width = 150;
            lblPreco.Text = "Preço";
            this.Controls.Add(lblPreco);

            preco = new TextBox();
            preco.Location = new Point(10, 40);
            preco.Width = 150;
            this.Controls.Add(preco);

            lblMarca = new Label();
            lblMarca.Location = new Point(10, 70);
            lblMarca.Width = 150;
            lblMarca.Text = "Marca";
            this.Controls.Add(lblMarca);

            marca = new TextBox();
            marca.Location = new Point(10, 100);
            marca.Width = 150;
            this.Controls.Add(marca);

            lblModelo = new Label();
            lblModelo.Location = new Point(10, 130);
            lblModelo.Width = 150;
            lblModelo.Text = "Modelo";
            this.Controls.Add(lblModelo);

            modelo = new TextBox();
            modelo.Location = new Point(10, 160);
            modelo.Width = 150;
            this.Controls.Add(modelo);

            lblTipo = new Label();
            lblTipo.Location = new Point(10, 190);
            lblTipo.Width = 150;
            lblTipo.Text = "Tipo";
            this.Controls.Add(lblTipo);

            tipo = new ComboBox();
            tipo.Location = new Point(10, 220);
            tipo.Width = 150;
            tipo.Items.AddRange(new string[] { "Carro", "Moto" });
            this.Controls.Add(tipo);

            botaoSalvar = new Button();
            botaoSalvar.Text = "Salvar";
            botaoSalvar.Location = new Point(10, 260);
            botaoSalvar.Click += new EventHandler(this.botaoSalvar_Click);
            this.Controls.Add(botaoSalvar);

            botaoCancelar = new Button();
            botaoCancelar.Text = "Cancelar";
            botaoCancelar.Location = new Point(botaoSalvar.Right + 10, 260);
            botaoCancelar.Click += new EventHandler(this.botaoCancelar_Click);
            this.Controls.Add(botaoCancelar);
        }
        private void botaoSalvar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void botaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}