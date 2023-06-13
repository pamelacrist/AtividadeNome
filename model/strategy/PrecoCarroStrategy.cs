namespace pastanova.Model
{ 
public class PrecoCarroStrategy : IPrecoStrategy
{
    private Automovel carro;

    public PrecoCarroStrategy(Automovel carro)
    {
        this.carro = carro;
    }

    public decimal CalcularPreco()
    {
        decimal precoBase = 20000;
        decimal precoFinal = precoBase + (4 * 1000);
        return precoFinal;
    }
}
}