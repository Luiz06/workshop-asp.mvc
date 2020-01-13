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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(Partida);

                        Console.WriteLine();
                        Console.Write("Digite origem ");
                        Posicao origem = Tela.LerPosicao().ToPosicao();
                        Partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPosiveis = Partida.Tab.Pecas(origem).MovimentosPosiveis();

                        Console.Clear();
                        Tela.ImprimiTabuleiro(Partida.Tab, posicoesPosiveis);
                        Console.WriteLine();
                        Console.Write("Digite Destino ");
                        Posicao destino = Tela.LerPosicao().ToPosicao();
                        Partida.ValidarPosicaoDestino(origem, destino);

                        Partida.RealizaJogada(origem, destino);
                    }
                    catch (TblException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TblException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}