using System.Linq;
using pastanova.Database;
namespace pastanova.Model
{ 
    public  class Automovel
    {
        public int Id { get; private set; }
        public decimal Preco { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Tipo { get; set; }

        protected IPrecoStrategy? precoStrategy;

        public void SetPrecoStrategy(IPrecoStrategy precoStrategy)
        {
            this.precoStrategy = precoStrategy;
        }

        public decimal CalcularPreco()
        {
            return precoStrategy.CalcularPreco();
        }
         public  void Salvar()
        {
            // Lógica específica para salvar um carro usando EF e LINQ
            using (var dbContext = new Contexto())
            {
                // Aqui você pode definir a lógica de salvamento do carro no banco
                Model.Automovel carro = new Model.Automovel
                {
                    Preco = Preco,
                    Marca = Marca,
                    Tipo = Tipo,
                    Modelo = Modelo
                };

                dbContext.Automoveis.Add(carro);
                dbContext.SaveChanges();
            }
        }

        public  void Atualizar()
        {
            using (var db = new Contexto())
            {
                var existente = db.Automoveis.FirstOrDefault(c => c.Id == this.Id);

                if (existente != null)
                {
                    // Atualizar as propriedades do carro existente com base no objeto atual
                    existente.Preco = this.Preco;
                    existente.Marca = this.Marca;
                    existente.Marca = this.Marca;
                    existente.Tipo = this.Tipo;

                    db.SaveChanges();
                }
            }
        }
        public  void Remover()
        {
            using (var db = new Contexto())
            {
                var existente = db.Automoveis.FirstOrDefault(m => m.Id == this.Id);

                if (existente != null)
                {
                    db.Automoveis.Remove(existente);
                    db.SaveChanges();
                }
            }
        }

         public   Automovel Busca(int id)
        {
            using (var db = new Contexto())
            {
                return db.Automoveis.Find(id);
            }
        }
    }
}