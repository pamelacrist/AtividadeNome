namespace pastanova.Model
{ 
 public class PrecoMotoStrategy : IPrecoStrategy
{
    private Automovel moto;

    public PrecoMotoStrategy(Automovel moto)
    {
        this.moto = moto;
    }

    public decimal CalcularPreco()
    {
        decimal precoBase = 10000;
        decimal precoFinal = precoBase + (300 * 10);
        return precoFinal;
    }
}
}