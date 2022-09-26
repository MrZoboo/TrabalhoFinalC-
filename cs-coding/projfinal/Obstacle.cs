/// <summary>
/// classe obstáculo (que engloba Tree, WWater e Toxina)
/// </summary>
public abstract class Obstacle : Item{
    
    /// <summary>
    /// construtor da classe Obstacle
    /// </summary>
    /// <param name="Caracteres"> recebe uma string Caracteres de sua classe mãe Item</param>
    /// <returns> retorna o Caractere usado na sua simbologia </returns>
    public Obstacle(string Caracteres) : base(Caracteres){}
}
