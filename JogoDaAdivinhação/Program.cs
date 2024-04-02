using System.Security.Cryptography;

namespace JogoDaAdivinhação
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                int numaleatorio = NumeroAleatorio();

                (int opd, int chances) = Dificuldade();

                Jogo(numaleatorio, chances);

                int opm = Rexit();
                if (opm == 1)
                {
                    continue;
                }
                break;
            }
        }
        static void Cabecalho()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("######################################################################################");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                          Academia do programador 2024                          ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                              Jogo da adivinhação                               ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("######################################################################################\n\n");
        }
        static int LerInt(string texto)
        {
            while (true)
            {
                Console.Write(texto);
                var digitouNumero = int.TryParse(Console.ReadLine(), out var numero);

                if (digitouNumero)
                {
                    return numero;
                }

                Console.Write("\nPor favor digite um numero.\n\nPrecione qualquer tecla para continuar.");
                Console.ReadLine();
                Cabecalho();
            }
        }
        public static (int, int) Dificuldade()
        {
            int opd = 0;
            int chances = 0;
            while (true)
            {
                Cabecalho();
                opd = LerInt("Escolha seu nível de dificuldade:\n1. Fácil\n2. Médio\n3. Difícil\nSua opção: ");
                if (opd != 1 && opd != 2 && opd != 3)
                {
                    Console.Write("\n\nOpção inválida, por favor verifique o número digitado de acordo com as opções informadas.\n\nPrecione qualquer tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }
                break;
            }
            switch (opd)
            {
                case 1:
                    chances = 15;
                break;

                case 2:
                    chances = 10;
                break;

                case 3:
                    chances = 5;
                break;
            }
            return (opd, chances);
        }
        static int NumeroAleatorio()
        {
            Random gerador = new Random();
            int numeroaleatorio = gerador.Next(1, 20);
            return numeroaleatorio;
        }
        private static void Jogo(int numaleatorio, int chances)
        {
            int pontos = 1000;
            int tentativa = 0;
            int aux = 0;
            Console.Write("\n\n######################################################################################");
            Console.Write("\n\nVocê deve adivinhar um numero entre 1 e 20");
            Console.Write("\n\n######################################################################################");

            while (tentativa <= chances)
            {
                tentativa++;
                if (tentativa == chances)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\n\n######################################################################################");
                    Console.Write("\n\nATENÇÃO!!!! Ultima tentativa!");
                    Console.Write("\n\n######################################################################################");
                }
                Console.Write($"\n\nTentativa {tentativa} de {chances}\n");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                int chute = LerInt($"Qual o seu {tentativa}º chute? ");

                if (chute < numaleatorio)
                {
                    Console.Write("\n\nSeu chute foi menor que o número secreto!\n\n");
                    aux = (numaleatorio - chute) / 2;
                    pontos -= aux;

                    if (pontos <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n\n\n######################################################################################");
                        Console.WriteLine("###                                                                                ###");
                        Console.WriteLine("###                                   Game Over!                                   ###");
                        Console.WriteLine("###                                                                                ###");
                        Console.WriteLine($"###  Que pena, seus pontos acabaram. Você fez {pontos} em {tentativa} tentativas.  ###");
                        Console.WriteLine("###                                                                                ###");
                        Console.WriteLine("######################################################################################\n\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        tentativa = chances + 5;
                    }
                    if (tentativa == chances)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n\n######################################################################################");
                        Console.WriteLine("###                                                                                ###");
                        Console.WriteLine("###                                   Game Over!                                   ###");
                        Console.WriteLine("###                                                                                ###");
                        Console.WriteLine($"###  Que pena, suas chances acabaram. Você fez {pontos} em {tentativa} tentativas  ###");
                        Console.WriteLine("###                                                                                ###");
                        Console.WriteLine("######################################################################################\n\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        tentativa = chances + 5;
                    }
                }
                if (chute > numaleatorio)
                {
                    Console.Write("\n\nSeu chute foi maior que o número secreto!");
                    aux = (chute - numaleatorio) / 2;
                    pontos -= aux;

                    if (pontos <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n\n######################################################################################");
                        Console.WriteLine("###                                                                                ###");
                        Console.WriteLine("###                                   Game Over!                                   ###");
                        Console.WriteLine("###                                                                                ###");
                        Console.WriteLine($"###  Que pena, seus pontos acabaram. Você fez {pontos} em {tentativa} tentativas.  ###");
                        Console.WriteLine("###                                                                                ###");
                        Console.WriteLine("######################################################################################\n\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        tentativa = chances + 5;
                    }
                    if (tentativa == chances)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n\n######################################################################################");
                        Console.WriteLine("###                                                                                ###");
                        Console.WriteLine("###                                   Game Over!                                   ###");
                        Console.WriteLine("###                                                                                ###");
                        Console.WriteLine($"       Que pena, suas chances acabaram. Você fez {pontos} em {tentativa} tentativas");
                        Console.WriteLine("###                                                                                ###");
                        Console.WriteLine("######################################################################################\n\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        tentativa = chances + 5;
                    }
                }
                if (chute == numaleatorio)
                {
                    Console.WriteLine("\n\n######################################################################################");
                    Console.WriteLine("###                                                                                ###");
                    Console.WriteLine("###                             Parabéns, você acertou!                            ###");
                    Console.WriteLine("###                                                                                ###");
                    Console.WriteLine($"                         Você fez {pontos} pontos em {tentativa} tentativas.  ");
                    Console.WriteLine("###                                                                                ###");
                    Console.WriteLine("######################################################################################\n\n");
                    Console.Write("\n\n");
                    tentativa = chances + 5;
                }
            }
        }
        static int Rexit() //Rexit = Restart or Exit
        {
            int opm;
            while (true)
            {
                Console.Write("\n\n######################################################################################");
                opm = LerInt("\nEscolha sua opção.\n\n1. Jogar novamente\n2. Sair\n\nDigite sua opção: ");
                if (opm != 1 && opm != 2)
                {
                    Console.Write("\nPor favor escolha uma opção valida do menu.\n\nPrecione qualquer tecla para continuar.");
                    Console.ReadLine();
                    continue;
                }
                break;
            }
            return opm;
        }
    }
}