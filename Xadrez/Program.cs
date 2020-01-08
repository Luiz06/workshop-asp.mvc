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
                    Tela.ImprimiTabuleiro(Partida.Tab);

                    Console.WriteLine();
                    Console.Write("Digite origem ");
                    Posicao origem = Tela.LerPosicao().ToPosicao();              

                    bool[,] posicoesPosiveis = Partida.Tab.Pecas(origem).MovimentosPosiveis();

                    Console.Clear();
                    Tela.ImprimiTabuleiro(Partida.Tab, posicoesPosiveis);
                    Console.WriteLine();
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