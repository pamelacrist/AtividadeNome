
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
        ListView listaUsuarios;
        List<Model.Usuario> Usuarios = new List<Model.Usuario>();
        public ListaUsuario()
        {
            this.Text = "Usuario";
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
            this.listaUsuarios = new ListView();
            listaUsuarios.Location = new Point(10, botaoRemover.Bottom + 10);
            listaUsuarios.Width = 300;
            listaUsuarios.Height = 300;
            listaUsuarios.View = View.Details;
            listaUsuarios.FullRowSelect = true;
            listaUsuarios.Columns.Add("Nome", 150);
            listaUsuarios.FullRowSelect = true;
            this.Controls.Add(listaUsuarios);
            Controller.Usuario.listar(listaUsuarios);
        }
        private void botaoCriar_Click(object sender, EventArgs e)
        {
            FormularioUsuario formulario = new pastanova.View.FormularioUsuario();
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (formulario.ShowDialog(this) == DialogResult.OK)
            {
                Controller.Usuario.criar(listaUsuarios, Usuarios, formulario);
            }
        }
        private void botaoEditar_Click(object sender, EventArgs e)
        {
            if (listaUsuarios.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listaUsuarios.SelectedItems[0];

                if (itemSelecionado != null && itemSelecionado.Tag != null)
                {
                    Model.Usuario UsuarioSelecionado = (Model.Usuario)itemSelecionado.Tag;
                    FormularioUsuario formulario = new FormularioUsuario(UsuarioSelecionado.Nome);
                    // Show testDialog as a modal dialog and determine if DialogResult = OK.
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                    {
                        Controller.Usuario.editar(listaUsuarios, Usuarios, formulario,UsuarioSelecionado);
                    }
                }
            }
        }
        private void botaoRemover_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Certeza que quer remover ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check which button was clicked
            if (result == DialogResult.Yes)
            {
                Controller.Usuario.remover(listaUsuarios);
            }
        }

    }
}