using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linha { get; set; }
        public int Coluna{ get; set; }
        private Peca[,] Peca { get; set; }

        public Tabuleiro(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
            Peca = new Peca[Linha, Coluna];
        }

        public Peca Pecas(int linha, int coluna)
        {
            return Peca[linha, coluna];
        }
    }
}
