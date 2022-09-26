/// <summary>
/// Basicamente, a classe Map é a resposável por todos os métodos relacionados a criação do mapa;
/// </summary>
public class Map{
    
    /// <summary>
    /// o atributo mapa será uma matriz de de objetos da classe Item
    /// </summary>
    private Item[,] mapa; 

    /// <summary>
    /// dimensão do mapa.
    /// </summary>
    /// <value></value>
    public int dimensão {get; private set;}
    
    /// <summary>
    /// construtor da classe Map.
    /// recebe o nivel do jogo e a dimensão do mapa;
    /// </summary>
    /// <param name="nivel"> esse parâmetro condiz com o nível atual do jogo </param>
    /// <param name="dimensão"> esse parâmetro conzid com a dimensão do mapa</param>
    public Map(int nivel, int dimensão = 10){
        this.dimensão = dimensão <= 30 ? dimensão:30;
        mapa = new Item[dimensão, dimensão];

        for(int i = 0; i< mapa.GetLength(0); i++){
            for(int j = 0; j< mapa.GetLength(1); j++){
                mapa[i,j] = new Terreno();
            }
        }
        if(nivel == 1){
            Criar_Mapa1();
        }else{
            CriarMapaAleatório();
        }
    }

    /// <summary>
    /// método que imprime o mapa;
    /// </summary>
    public void Imprime(){
        for(int i = 0; i< mapa.GetLength(0); i++){
            for(int j = 0; j< mapa.GetLength(1); j++){
                Console.Write(mapa[i,j]);
            }
            Console.Write("\n");
        }
    }

    /// <summary>
    /// método que aloca determinado objeto da classe Item no mapa
    /// </summary>
    /// <param name="objeto"> recebe objeto da classe Item</param>
    /// <param name="x">linha da matriz mapa na qual desejamos alocar o objeto</param>
    /// <param name="y">coluna da matriz mapa na qual desejamos alocar o objeto</param>
    public void Alocar(Item objeto, int x, int y){
        mapa[x,y] = objeto;
    }

    /// <summary>
    /// método que gera o mapa fixo do nível 1.
    /// </summary>
    public void Criar_Mapa1(){
        this.Alocar(new Red(), 1, 9);
        this.Alocar(new Red(), 8, 8);
        this.Alocar(new Green(), 9, 1);
        this.Alocar(new Green(), 7, 6);
        this.Alocar(new Blue(), 3, 4);
        this.Alocar(new Blue(), 2, 1);
        this.Alocar(new Water(), 5, 0);
        this.Alocar(new Water(), 5, 1);
        this.Alocar(new Water(), 5, 2);
        this.Alocar(new Water(), 5, 3);
        this.Alocar(new Water(), 5, 4);
        this.Alocar(new Water(), 5, 5);
        this.Alocar(new Water(), 5, 6);
        this.Alocar(new Tree(), 5, 9);
        this.Alocar(new Tree(), 3, 9);
        this.Alocar(new Tree(), 8, 3);
        this.Alocar(new Tree(), 2, 5);
        this.Alocar(new Tree(), 1, 4);
    }

    /// <summary>
    /// método que ger o mapa aleatório (depois do nível 1).
    /// </summary>
    private void CriarMapaAleatório(){
        Random k = new Random();

        for(int x = 0; x< 3; x++){
            int  xRandom = k.Next(0, dimensão);
            int  yRandom = k.Next(0, dimensão);
            this.Alocar(new Blue(), xRandom, yRandom);
        }
        for(int x = 0; x< 3; x++){
            int  xRandom = k.Next(0, dimensão);
            int  yRandom = k.Next(0, dimensão);
            this.Alocar(new Green(), xRandom, yRandom);
        }
        for(int x = 0; x< 3; x++){
            int  xRandom = k.Next(0, dimensão);
            int  yRandom = k.Next(0, dimensão);
            this.Alocar(new Red(), xRandom, yRandom);
        }
        for(int x = 0; x< 3; x++){
            int  xRandom = k.Next(0, dimensão);
            int  yRandom = k.Next(0, dimensão);
            this.Alocar(new Tree(), xRandom, yRandom);
        }
        for(int x = 0; x< 3; x++){
            int  xRandom = k.Next(0, dimensão);
            int  yRandom = k.Next(0, dimensão);
            this.Alocar(new Water(), xRandom, yRandom);
        }
        for(int x = 0; x< 3; x++){
            int  xRandom = k.Next(0, dimensão);
            int  yRandom = k.Next(0, dimensão);
            this.Alocar(new Toxin(), xRandom, yRandom);
        }

    }

    /// <summary>
    /// método que faz a mudança da localização do objeto.
    /// </summary>
    /// <param name="Xi">linha inicial do objeto na matriz</param>
    /// <param name="Yi">coluna inicial do objeto na matriz</param>
    /// <param name="Xf">linha final do objeto na matriz</param>
    /// <param name="Yf">coluna final do objeto na matriz</param>
    public void Mudança(int Xi,int Yi, int Xf,int Yf ){
        mapa[Xf, Yf] = mapa[Xi,Yi];
        mapa[Xi,Yi] = new Terreno();
    }
    
    /// <summary>
    /// método que remove as joias ou árvores de uma dada proximidade 
    /// </summary>
    /// <param name="x">linha de localização da zona de proximidade</param>
    /// <param name="y"> coluna de localização da zona de proximidade</param>
    /// <returns> retorna os pontos da joia que estavam na localização dada</returns>
    public int Remover_Joias(int x, int y){
        int a1 = x-1, a2 = y-1, b1 = x+2, b2 = y+2 ;
        if(x == 0){
            a1 = 0;
        }
        if(x == dimensão-1){
            b1 = x+1;
        }
        if(y == 0){
            a2 = 0;
        }
        if(y == dimensão-1){
            b2 = y+1;
        }
        for(int i = a1; i < b1; i++){
            for(int j = a2 ; j < b2; j++){
                if(mapa[i, j] is Item){
                    if(mapa[i,j] is Red){
                        mapa[i, j] = new Terreno();
                        return 100;
                    }
                    if(mapa[i,j] is Green){
                        mapa[i, j] = new Terreno();
                        return 50;
                    }
                    if(mapa[i,j] is Blue){
                        mapa[i, j] = new Terreno(); 
                        return 10;
                    }
                    if(mapa[i,j] is Tree){
                        mapa[i, j] = new Terreno(); 
                        return 1;
                    }
                }
            }
        }
        return 0;
        
    }
    
    /// <summary>
    /// método que verifica se o movimento é possível para uma dada casa
    /// </summary>
    /// <param name="direção"> string que condiz com a direção do movimento</param>
    /// <param name="x">linha atual de referência</param>
    /// <param name="y">coluna atual de referência</param>
    /// <returns> retorna um booleano, true para o movimento ser possível e false caso o contrário</returns>
    public bool  Possivel_Movimento(string direção, int x, int y){
        if(direção == "mov_norte"){
            if(x-1 != -1 && mapa[x-1,y] is not Jewel && mapa[x-1,y] is not Obstacle){
                return true;
            }else {
                return false;
            }
        }
        if(direção == "mov_sul"){
            if(x+1 != dimensão && mapa[x+1,y] is not Jewel && mapa[x+1,y] is not Obstacle){
                return true;
            }else{
                return false;
            }
        }
        if(direção == "mov_leste"){
            if(y+1 != dimensão && mapa[x,y+1] is not Jewel  && mapa[x,y+1] is not Obstacle){
                return true;
            }else {
                return false;
            }
        }
        if(direção == "mov_oeste"){
            if(y-1 != -1 && mapa[x,y-1] is not Jewel && mapa[x,y-1] is not Obstacle){
                return true;
            }else {
                return false;
            }
        }
    return true;
    }

    /// <summary>
    /// método que verifica a existência de joias nas proximidades
    /// </summary>
    /// <returns> retorna um booleano</returns>
    public bool Tem_Joia(){
        for(int i = 0; i< mapa.GetLength(0); i++){
            for(int j = 0; j< mapa.GetLength(1); j++){
                if(mapa[i,j] is Jewel){
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// método que verifica quantas joias proximas existem em uma determinada região
    /// </summary>
    /// <param name="x"> linha da região de referência</param>
    /// <param name="y"> coluna da região de referência</param>
    /// <returns> retorna um inteiro que qualifica quantas joias estão nas proximidades</returns>
    public int Joias_Proximas(int x, int y){
        int a1 = x-1, a2 = y-1, b1 = x+2, b2 = y+2 ;
        if(x == 0){
            a1 = 0;
        }
        if(x == dimensão-1){
            b1 = x+1;
        }
        if(y == 0){
            a2 = 0;
        }
        if(y == dimensão-1){
            b2 = y+1;
        }
        int contador = 0; 
        for(int i = a1; i < b1; i++){
            for(int j = a2 ; j < b2; j++){
                if(mapa[i, j] is Jewel){
                    contador++;
                }
            }
        }
        return contador;
        
    }

    /// <summary>
    /// método que verifica quantas árvores proximas existem em uma determinada região
    /// </summary>
    /// <param name="x"> linha da região de referência</param>
    /// <param name="y"> coluna da região de referência</param>
    /// <returns> retorna um inteiro que qualifica quantas árvores estão nas proximidades</returns>
    public int Arvores_Proximas(int x, int y){
        int a1 = x-1, a2 = y-1, b1 = x+2, b2 = y+2 ;
        if(x == 0){
            a1 = 0;
        }
        if(x == dimensão-1){
            b1 = x+1;
        }
        if(y == 0){
            a2 = 0;
        }
        if(y == dimensão-1){
            b2 = y+1;
        }
        int contador = 0; 
        for(int i = a1; i < b1; i++){
            for(int j = a2 ; j < b2; j++){
                if(mapa[i, j] is Tree){
                    contador++;
                }
            }
        }
        return contador;
        
    }
   
   /// <summary>
   /// método que verifica quantas toxinas proximas existem em uma determinada região
   /// </summary>
   /// <param name="x"> linha da região de referência</param>
   /// <param name="y"> coluna da região de referência</param>
   /// <returns> retorna um inteiro que qualifica quantas toxinas estão nas proximidades</returns>
    public int Toxinas_Proximas(int x, int y){
        int a1 = x-1, a2 = y-1, b1 = x+2, b2 = y+2 ;
        if(x == 0){
            a1 = 0;
        }
        if(x == dimensão-1){
            b1 = x+1;
        }
        if(y == 0){
            a2 = 0;
        }
        if(y == dimensão-1){
            b2 = y+1;
        }
        int contador = 0; 
        for(int i = a1; i < b1; i++){
            for(int j = a2 ; j < b2; j++){
                if(mapa[i, j] is Toxin){
                    contador++;
                }
            }
        }
        return contador;
        
    }

} 