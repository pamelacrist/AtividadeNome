namespace pastanova.View
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public class Menu : Form
    {

        Button botaoSair;
        Button botaoUsuario;

        public Menu()
        {
            Text = "Titulo da Janela";
            this.botaoUsuario = new Button();
            botaoUsuario.Text = "Usuario";
            botaoUsuario.Width = 100;
            botaoUsuario.Location = new Point(Width / 2 - botaoUsuario.Width / 2, Height / 2 - botaoUsuario.Height / 2 - 90);
            botaoUsuario.Click += new EventHandler(botaoUsuario_Click);
            Controls.Add(botaoUsuario);
            this.botaoSair = new Button();
            botaoSair.Text = "Sair";
            botaoSair.Width = 100;
            botaoSair.Location = new Point(Width / 2 - botaoSair.Width / 2, Height / 2 - botaoSair.Height / 2);
            botaoSair.Click += new EventHandler(botaoSair_Click);
            Controls.Add(botaoSair);
        }
        private void botaoUsuario_Click(object sender, EventArgs e)
        {
            var tela = new pastanova.View.ListaUsuario();
            tela.ShowDialog();
        }
        private void botaoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnCancelarClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}