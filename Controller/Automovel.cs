namespace pastanova.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using pastanova.Model;

    public class Automovel
    {

        public Automovel() { }


        public static  void criar(ListView lista, List<Model.Automovel> veiculos, pastanova.View.FormularioAutomovel formulario)
        {
            if (formulario.tipo.Text.Trim() != "")
            {
                try
                {
                    Model.Automovel veiculo = CriarVeiculo(formulario.tipo.Text);
                    veiculo.Marca = formulario.marca.Text;
                    veiculo.Modelo = formulario.modelo.Text;
                    veiculo.Tipo = formulario.tipo.Text;
                    veiculo.Preco = decimal.Parse(formulario.preco.Text);
                    veiculo.Salvar();

                    listar(lista);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao criar o novo Automovel: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     listar(lista);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um tipo para o Automovel.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 listar(lista);
            }
        }

        private static Model.Automovel CriarVeiculo(string tipoVeiculo)
        {
            // Aqui você pode criar e retornar o veículo correto com base no tipo informado
            Model.Automovel automovel = new Model.Automovel();
            automovel.Tipo=tipoVeiculo;
            return automovel;
        }

        public static void listar(ListView lista)
        {
            try
            {
                Database.Contexto db = new Database.Contexto();
                List<Model.Automovel> Automoveis = db.Automoveis.ToList();
                List<Model.Automovel> automoveis = new List<Model.Automovel>();
                automoveis.AddRange((IEnumerable<Model.Automovel>)Automoveis);
                AtualizarListaUsuarios(lista,automoveis);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
         private static ListView AtualizarListaUsuarios(ListView lista, List<Model.Automovel> automoveis)
        {
            try
            {
                // Limpa todos os itens da lista de Usuarios
                lista.Items.Clear();
        
                // Adiciona cada Usuario da lista na lista de Usuarios
                foreach (Model.Automovel automovel in automoveis)
                {
                    
                    decimal preco = 0;
                    if (automovel.Tipo == "Carro")
                    {
                        automovel.SetPrecoStrategy(new PrecoCarroStrategy(automovel));
                        preco = automovel.CalcularPreco();
                    } else if (automovel.Tipo == "Moto") {
                        automovel.SetPrecoStrategy(new PrecoMotoStrategy(automovel));
                        preco = automovel.CalcularPreco();
                    }
                    ListViewItem item = new ListViewItem(automovel.Id.ToString());
                    item.SubItems.Add(automovel.Marca);
                    item.SubItems.Add(automovel.Modelo);
                    item.SubItems.Add(automovel.Preco.ToString("C"));
                    item.SubItems.Add(preco.ToString("C"));
                    item.SubItems.Add(automovel.Tipo);
                    item.Tag = automovel;
                    lista.Items.Add(item);
                }
        
                return lista;
            }
            catch (Exception ex)
            {
                // handle any exceptions that occur during the update process
                MessageBox.Show("Ocorreu um erro ao atualizar a lista de Usuarios: " + ex.Message);
                return null;
            }
        }
       
        public static void remover(ListView lista,List<Model.Automovel> Automovels)
        {
            if (lista.SelectedItems.Count > 0)
            {
                Model.Automovel selecionado = (Model.Automovel)lista.SelectedItems[0].Tag;
               
                    try
                    {
                    int indiceVeiculo = selecionado.Id;
                    Model.Automovel veiculo = Automovels[indiceVeiculo];
                    // Obter o tipo de veículo com base no objeto veiculo
                    Model.Automovel automovel = CriarVeiculo(veiculo.Tipo);
                    automovel = automovel.Busca(selecionado.Id);
                    automovel.Remover();
                    listar(lista);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao remover o Automovel: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
            }
        }
        public static void editar(ListView lista, List<Model.Automovel> Automovels, pastanova.View.FormularioAutomovel formulario, Model.Automovel selecionado)
        {
            string nome = formulario.modelo.Text.Trim();
            if (nome != "")
            {
                try
                {
                    int indiceVeiculo = selecionado.Id;
                    Model.Automovel veiculo = Automovels[indiceVeiculo];

                    // Obter o tipo de veículo com base no objeto veiculo
                    Model.Automovel automovel = CriarVeiculo(veiculo.Tipo);
                    automovel = automovel.Busca(selecionado.Id);
                    if (automovel != null)
                    {
                        automovel.Marca = formulario.marca.Text.Trim();
                        automovel.Modelo = formulario.modelo.Text.Trim();
                        automovel.Tipo = formulario.tipo.Text.Trim();
                        automovel.Preco = decimal.Parse(formulario.preco.Text.Trim());
                        automovel.Atualizar();
                    }
                    listar(lista);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um Erro" + ex.Message, "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show("Infome o Nome", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }
       

    }
}