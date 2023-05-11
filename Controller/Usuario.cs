namespace pastanova.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public class Usuario
    {
       
        public Usuario(){}

       
       public static void criar(ListView lista, List<Model.Usuario> Usuarios, pastanova.View.FormularioUsuario formulario)
       {
           string nome = formulario.nomeUsuario.Text.Trim();
           if (nome != "")
           {
               try
               {
                   Model.Usuario novoUsuario = new Model.Usuario() { Nome = nome, Id = Usuarios.Count() + 1 };
                   Database.Contexto db = new Database.Contexto();
                   db.Usuario.Add(novoUsuario);
                   db.SaveChanges();
                   listar(lista);
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Ocorreu um erro ao criar o novo Usuario: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }
           else
           {
               MessageBox.Show("Por favor, insira um nome para o Usuario.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
       }
        public static void listar(ListView lista){
            try{
                Database.Contexto db = new Database.Contexto();
                List<Model.Usuario> Usuarios = db.Usuario.ToList();
                AtualizarListaUsuarios(lista,Usuarios);
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        public static void remover(ListView lista)
        {
            if (lista.SelectedItems.Count > 0)
            {
                Model.Usuario selecionado = (Model.Usuario)lista.SelectedItems[0].Tag;
                // Remove o Usuario da lista
                Database.Contexto db = new Database.Contexto();
                var UsuarioToRemove = db.Usuario.Find(selecionado.Id);
                if (UsuarioToRemove != null)
                {
                    try
                    {
                        db.Usuario.Remove(UsuarioToRemove);
                        db.SaveChanges();
                        listar(lista);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao remover o Usuario: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            }
        } 
       public static void editar(ListView lista, List<Model.Usuario> Usuarios, pastanova.View.FormularioUsuario formulario, Model.Usuario selecionado)
       {
           string nome = formulario.nomeUsuario.Text.Trim();
           if (nome != "")
           {
               try
               {
                   Database.Contexto db = new Database.Contexto();
                   Model.Usuario Usuario = db.Usuario.Find(selecionado.Id);
                   if (Usuario != null)
                   {
                       Usuario.Nome = nome;
                       db.SaveChanges();
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
        private static ListView AtualizarListaUsuarios(ListView lista, List<Model.Usuario> Usuarios)
        {
            try
            {
                // Limpa todos os itens da lista de Usuarios
                lista.Items.Clear();
        
                // Adiciona cada Usuario da lista na lista de Usuarios
                foreach (Model.Usuario Usuario in Usuarios)
                {
                    ListViewItem item = new ListViewItem(Usuario.Nome);
                    item.Tag = Usuario;
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
    }
}