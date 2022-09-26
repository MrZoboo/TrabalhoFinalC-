/// <summary>
/// classe Robot, filha da classe Item
/// </summary>
public class Robot : Item{

    /// <summary>
    /// método que cria um mapa (objeto da classe Map) no referencial do robô.
    /// </summary>
    /// <value></value>
    public Map visão_do_robô {get; private set;} //é como se o mapa estivesse na cabeça do robô, ele que vai imprimir o mapa.
    private int abscissa, ordenada;
    private int pontos = 0;
    private int Vermelhas = 0;
    private int Verdes = 0;
    private int Azuis = 0;
    public int energia = 10;
    
    /// <summary>
    /// construtor da classe Robot
    /// </summary>
    /// <param name="visão_do_robô"> recebe um mapa (que será seu referencial)</param>
    /// <param name="abscissa"> recebe a sua linha inicial</param>
    /// <param name="ordenada"> recebe a sua coluna inicial</param>
    /// <returns></returns>
    public Robot(Map visão_do_robô, int abscissa = 0, int ordenada = 0) : base("ME "){
        this.visão_do_robô = visão_do_robô;
        this.abscissa = abscissa;
        this.ordenada = ordenada;
        this.visão_do_robô.Alocar(this, abscissa, ordenada);
    }

    /// <summary>
    /// um método que verifica se o robô ainda tem energia
    /// </summary>
    /// <returns>retorna true em caso afirmativo</returns>
    public bool Tem_Energia(){
        return this.energia > 0;
    }
    
    /// <summary>
    /// um método que verifica se o mapa visto pelo robô ainda tem joias
    /// </summary>
    /// <returns> retorna true em caso afirmaivo</returns>
    public bool Acabaram_As_Joias(){
        return !visão_do_robô.Tem_Joia();
    }
    
    /// <summary>
    /// método que move o robô para um casa na direção sul
    /// </summary>
    public void Mover_Sul(){
        if(visão_do_robô.Possivel_Movimento("mov_sul", abscissa, ordenada) == true)
        {
            visão_do_robô.Mudança(this.abscissa, this.ordenada, this.abscissa+1, this.ordenada);
            this.abscissa++;
            this.energia--;
        }
        
    }
     
     /// <summary>
     /// método que move o robô para um casa na direção norte
     /// </summary>
    public void Mover_Norte(){
        if(visão_do_robô.Possivel_Movimento("mov_norte", abscissa, ordenada) == true)
        {
            visão_do_robô.Mudança(this.abscissa, this.ordenada, this.abscissa-1, this.ordenada);
            this.abscissa--;
            this.energia--;
        }
    }
    
    /// <summary>
    /// método que move o robô para um casa na direção oeste
    /// </summary>
    public void Mover_Oeste(){
        if(visão_do_robô.Possivel_Movimento("mov_oeste", abscissa, ordenada) == true){
            visão_do_robô.Mudança(this.abscissa, this.ordenada, this.abscissa, this.ordenada-1);
            this.ordenada--;
            this.energia--;
        }
    }
    
    /// <summary>
    /// método que move o robô para um casa na direção leste
    /// </summary>
    public void Mover_Leste(){
        if(visão_do_robô.Possivel_Movimento("mov_leste", abscissa, ordenada) == true){
            visão_do_robô.Mudança(this.abscissa, this.ordenada, this.abscissa, this.ordenada+1);
            this.ordenada++;
            this.energia--;
        }
    }
    
    /// <summary>
    /// método que imprime o mapa no referencial do robô
    /// </summary>
    public void Imprime_visão_do_robô(){
        visão_do_robô.Imprime();
        Console.WriteLine($"joias proximas: {visão_do_robô.Joias_Proximas(abscissa, ordenada)} ");
        Console.WriteLine($"pontos: {pontos}");
        Console.WriteLine($"energia: {energia}");
        Console.WriteLine($"Joias coletadas: {Vermelhas} Vermelhas, {Verdes} Verdes, {Azuis} Azuis");
    }
    
    /// <summary>
    /// método que pega as joias ou árvores das proximidades e devolve pontos/energia
    /// </summary>
    public void Pegar_Joias_ou_Arvores(){
        if(visão_do_robô.Joias_Proximas(abscissa, ordenada) != 0 || visão_do_robô.Arvores_Proximas(abscissa, ordenada) !=0){
            int a = visão_do_robô.Remover_Joias(abscissa,ordenada);
            if(a == 100){
                Vermelhas += 1;
            }
            if(a == 50){
                Verdes += 1;
            }
            if(a == 10){
                Azuis += 1;
                energia += 5;
            }
            if(a == 1){
                energia+= 3;
                a = 0;
            }
            pontos += a;
        }
    }
    
    /// <summary>
    /// método que desconta 10 pontos de energia caso exista uma toxina nas proximidades
    /// </summary>
    public void EfeitoToxico(){
        if(visão_do_robô.Toxinas_Proximas(abscissa, ordenada) != 0){
            energia = energia - 10;
        }
    }

}