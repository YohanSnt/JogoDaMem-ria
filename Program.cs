namespace JogoDaMemória
{
    internal class Program
    {
        public static void PrintMatrix(int[,] matrix)
        {
            Console.Write("   ");
            for (int j = 0; j < 4; j++)
            {
                Console.Write(" {0}  ", j + 1);
            }
            Console.WriteLine("\n  -----------------");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("{0} |", i + 1);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(" {0} |", matrix[i, j]);
                }
                Console.WriteLine("\n  -----------------");
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            int[,] jogo = new int[4, 4];
            int[,] tela = new int[4, 4];
            
            Console.WriteLine("Nome do Player 1: ");
            string nomeP1 = Console.ReadLine();

            Console.WriteLine("Nome do Player 2: ");
            string nomeP2 = Console.ReadLine();

            Player p1 = new Player(nomeP1);
            Player p2 = new Player(nomeP2);


            //Para criar números aleatórios
            Random gerador = new Random();

            for (int i = 1; i <= 8; i++) //Atribui os pares de números às posições
            {
                //Escolhe a posição do primeiro número do par
                int lin, col;
                for (int j = 0; j < 2; j++)
                {
                    do
                    {
                        lin = gerador.Next(0, 4);
                        col = gerador.Next(0, 4);

                    } while (jogo[lin, col] != 0);
                    jogo[lin, col] = i;
                }
            }

            //Sorteio jogador que começa
            int jogador = gerador.Next(1,3);

           

            int acertos = 0;
            do
            {
                Program.PrintMatrix(jogo);
                Program.PrintMatrix(tela);
                

                //Pedir as posições do primeiro número
                Console.WriteLine("Escolha uma linha para jogar [1, 4]: ");
                int lin1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Escolha uma coluna para jogar [1, 4]: ");
                int col1 = int.Parse(Console.ReadLine());

                lin1--;
                col1--;

                tela[lin1, col1] = jogo[lin1, col1];

                 Program.PrintMatrix(tela);



                //Pedir as posições do segundo número
                Program.PrintMatrix(jogo);
                Console.WriteLine("Escolha uma linha para jogar [1, 4]: ");
                int lin2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Escolha uma coluna para jogar [1, 4]: ");
                int col2 = int.Parse(Console.ReadLine());

                lin2--;
                col2--;

                tela[lin2, col2] = jogo[lin2, col2];

                Program.PrintMatrix(tela);



                //Em caso de acerto, a matriz tela permanece como está.
                //Em caso de erro, precisamos voltar as posições para zero.
                if (jogo[lin1, col1] != jogo[lin2, col2])
                {
                    tela[lin1, col1] = 0;
                    tela[lin2, col2] = 0;
                }
                else
                {
                    if (jogador == 1)
                        p1.Score += 1;
                    else 
                        p2.Score += 1;
                    acertos++;
                }

            } while (acertos < 8);
            Console.WriteLine(p1.ToString());
            Console.WriteLine();
            Console.WriteLine(p2.ToString());
        }
    }
}