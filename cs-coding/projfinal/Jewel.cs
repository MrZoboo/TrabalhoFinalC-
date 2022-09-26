/// <summary>
/// É aclasse mãe das Joias. Além disso, é classe filha de Item
/// </summary>
public abstract class Jewel : Item{
    
    /// <summary>
    /// esse método é o construtor da classe Jewel
    /// </summary>
    /// <param name="Caracteres"> recebe uma string de caracteres que serão usados na simbologia do mapa</param>
    /// <returns> retornaos respectivos símbolos</returns>
    public Jewel(string Caracteres) : base(Caracteres){
    }
}