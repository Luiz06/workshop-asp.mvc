using System;
using tabuleiro;
using xadrez;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.ColocarPeca(new Torre(tab, Cor.Preta) , new Posicao(2, 2));
            tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(3, 6));

            Tela.ImpromiTabuleiro(tab);
        }
    }
}
