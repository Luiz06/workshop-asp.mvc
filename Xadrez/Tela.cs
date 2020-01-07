using System;
using tabuleiro;
using xadrez;


namespace Xadrez
{
    class Tela
    {
        public static void ImpromiTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linha; i++)
            {
                Console.Write(8- i + " ");
                for (int j = 0; j < tab.Coluna; j++)
                    if (tab.Pecas(i,j) == null)
                    {
                        Console.Write("- ");

                    }
                    else
                    {
                        ImprimePeca(tab.Pecas(i, j));
                        Console.Write(" ");
                    }
               
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
        }

        public static void ImprimePeca(Peca peca)
        {
            if(peca.Cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }

        public static PosicaoXadrez LerPosicao()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);


        }
    }
}
