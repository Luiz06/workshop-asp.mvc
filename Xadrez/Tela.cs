using System;
using tabuleiro;


namespace Xadrez
{
    class Tela
    {
        public static void ImpromiTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linha; i++)
            {
                for (int j = 0; j < tab.Coluna; j++)
                    if (tab.Pecas(i,j) == null)
                    {
                        Console.Write("-");

                    }
                    else
                    {
                        Console.Write(tab.Pecas(i, j) + " ");
                    }
               
                Console.WriteLine();
            }
        }
    }
}
