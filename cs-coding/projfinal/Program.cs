/// <summary>
/// classe que contém a função Main()
/// </summary>
public class JewelCollector {
    /// <summary>
    /// método Main(), que é o responsável por rodar o jogo como um todo.
    /// é aqui onde a progressão de nível e avaliação de vitória/derrota acontecem.
    /// </summary>
    public static void Main() {
        int nivel = 1;
        int dimensão = 10;
        bool vitória = true;
        while(vitória == true){
            bool running = true;
            Map teste = new Map(nivel, dimensão);
            Robot robô = new Robot(teste);
            do {
                Console.Clear();
                Console.WriteLine ($"Nível: {nivel}");
                robô.EfeitoToxico();
                robô.Imprime_visão_do_robô();
                
                Console.WriteLine("Enter the command: ");
                string command = Console.ReadLine();
        
                if (command.Equals("quit")) {
                    running = false;
                    vitória = false;
                } else if (command.Equals("w")) {
                    robô.Mover_Norte();
                } else if (command.Equals("a")) {
                    robô.Mover_Oeste();
                } else if (command.Equals("s")) {
                    robô.Mover_Sul();
                } else if (command.Equals("d")) {
                    robô.Mover_Leste();
                } else if (command.Equals("g")) {
                    robô.Pegar_Joias_ou_Arvores();
                }
                if(robô.Acabaram_As_Joias()){
                    Console.Clear();
                    Console.WriteLine($"Nível {nivel} concluído! :)");

                    running = false;
                }
                if(!robô.Tem_Energia()){
                    Console.Clear();
                    Console.WriteLine($"Parabéns!");
                    Console.WriteLine($"Você chegou até o nivel {nivel}");
                    Console.WriteLine("Tente novamente! :)");
                    vitória = false;
                    running = false;
                }
            } while (running);
            nivel++;
            dimensão++;
        }
    }
}