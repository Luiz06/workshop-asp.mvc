using System;
using tabuleiro;
using xadrez;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez Partida = new PartidaDeXadrez();

                while (!Partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImpromiTabuleiro(Partida.Tab);

                    Console.WriteLine();
                    Console.Write("Digite origem ");
                    Posicao origem = Tela.LerPosicao().ToPosicao();
                    Console.Write("Digite origem ");
                    Posicao destino = Tela.LerPosicao().ToPosicao();

                    Partida.ExecutaMovimento(origem, destino);
                }
            }
            catch (TblException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}