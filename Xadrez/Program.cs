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
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(2, 4));
                tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(3, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(5, 2));

                Tela.ImpromiTabuleiro(tab);
            }
            catch (TblException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}