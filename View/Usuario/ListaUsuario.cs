
namespace pastanova.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public class ListaUsuario : Form
    {
        Button botaoCriar;
        Button botaoEditar;
        Button botaoRemover;
        ListView listaVeiculos;
        List<Model.Automovel> Veiculos = new List<Model.Automovel>();
        public ListaUsuario()
        {
            this.Text = "Veiculo";
            this.Width = 600;
            this.botaoCriar = new Button();
            botaoCriar.Text = "Criar";
            botaoCriar.Location = new Point(10, 10);
            botaoCriar.Click += new EventHandler(this.botaoCriar_Click);
            this.Controls.Add(botaoCriar);

            this.botaoEditar = new Button();
            botaoEditar.Text = "Editar";
            botaoEditar.Location = new Point(botaoCriar.Right + 10, 10);
            botaoEditar.Click += new EventHandler(this.botaoEditar_Click);
            this.Controls.Add(botaoEditar);

            this.botaoRemover = new Button();
            botaoRemover.Text = "Remover";
            botaoRemover.Location = new Point(botaoEditar.Right + 10, 10);
            botaoRemover.Click += new EventHandler(this.botaoRemover_Click);
            this.Controls.Add(botaoRemover);
            this.listaVeiculos = new ListView();
            listaVeiculos.Location = new Point(10, botaoRemover.Bottom + 10);
            listaVeiculos.Width = 600;
            listaVeiculos.Height = 300;
            listaVeiculos.View = View.Details;
            listaVeiculos.FullRowSelect = true;
            listaVeiculos.Columns.Add("ID", 100);
            listaVeiculos.Columns.Add("Marca", 100);
            listaVeiculos.Columns.Add("Modelo", 100);
            listaVeiculos.Columns.Add("Preco", 100);
            listaVeiculos.Columns.Add("Preco Venda", 100);
            listaVeiculos.Columns.Add("Tipo", 100);
            this.Controls.Add(listaVeiculos);
            Controller.Automovel.listar(listaVeiculos);
        }
        private void botaoCriar_Click(object sender, EventArgs e)
        {
            FormularioAutomovel formulario = new pastanova.View.FormularioAutomovel();
            // Show formulario as a modal dialog and determine if DialogResult = OK.
            if (formulario.ShowDialog(this) == DialogResult.OK)
            {
              Controller.Automovel.criar(listaVeiculos,Veiculos,formulario);
            }
        }

        private void botaoEditar_Click(object sender, EventArgs e)
        {
            if (listaVeiculos.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listaVeiculos.SelectedItems[0];
               
                if (itemSelecionado != null)
                {
                    // Obter o veículo selecionado com base no índice do item selecionado na lista
                    Model.Automovel automovel = (Model.Automovel)itemSelecionado.Tag;
                    FormularioAutomovel formulario = new FormularioAutomovel();
                    formulario.tipo.Text = automovel.Tipo;
                    formulario.marca.Text = automovel.Marca;
                    formulario.modelo.Text = automovel.Modelo;
                    formulario.preco.Text = automovel.Preco.ToString();
                    // Show formulario as a modal dialog and determine if DialogResult = OK.
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                    {
                        automovel.Marca = formulario.marca.Text;
                        automovel.Modelo = formulario.modelo.Text;
                        automovel.Tipo = formulario.tipo.Text;
                        automovel.Atualizar();
                        // Atualizar as informações do veículo na lista exibida no formulário
                        itemSelecionado.SubItems[1].Text = automovel.Marca;
                        itemSelecionado.SubItems[2].Text = automovel.Modelo;
                        itemSelecionado.SubItems[3].Text = automovel.Tipo;
                    }
                }
            }
        }
      
        private void botaoRemover_Click(object sender, EventArgs e)
        {
            if (listaVeiculos.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listaVeiculos.SelectedItems[0];

                if (itemSelecionado != null)
                {
                    // Obter o veículo selecionado com base no índice do item selecionado na lista
                    int indiceVeiculo = itemSelecionado.Index;
                    Model.Automovel automovel = (Model.Automovel)itemSelecionado.Tag;

                    DialogResult result = MessageBox.Show("Tem certeza que deseja remover o veículo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Remover o veículo do banco de dados
                        automovel.Remover();

                        // Remover o veículo da lista exibida no formulário
                        Controller.Automovel.listar(listaVeiculos);
                    }
                }
            }
        }

    }
}