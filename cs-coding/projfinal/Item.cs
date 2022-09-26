/// <summary>
/// classe mãe de todos os objetos que vão figurar no mapa(Robot, Terreno, Obstacle, Jewel)
/// </summary>
public abstract class Item { 
    
    private string Caracteres; 

    /// <summary>
    /// construtor da classe Item
    /// </summary>
    /// <param name="Caracteres"> recebe Caracteres que serão a simbologia usada pelos objetos de cada classe filha quando forem alocados no mapa</param>
    public Item(string Caracteres){
        this.Caracteres = Caracteres;
    }
    
    /// <summary>
    /// transforma Caracteres na simbologia usada pelos objetos de cada classe filha
    /// </summary>
    /// <returns> retorna uma string que condiz com a sequência de caracteres que seus objetos terão no mapa</returns>
    public sealed override string ToString(){ 
        return Caracteres;
    }

}