/// <summary>
/// classe filha da classe Item que entrega casas vazias do mapa
/// </summary>
public class Terreno : Item{

    /// <summary>
    /// construtor da classe Terreno que retorna sua simbologia no mapa
    /// </summary>
    /// <returns> retorna a simbologia de uma casa vazia no mapa</returns>
    public Terreno() : base ("-- "){}
}