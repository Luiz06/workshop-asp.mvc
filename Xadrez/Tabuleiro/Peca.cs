using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QuantMovimentos { get; set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Cor cor, Tabuleiro tab)
        {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QuantMovimentos = 0;
        }
        public void QuantMovimento()
        {
            QuantMovimentos++;
        }
        public void DecrementaMovimento()
        {
            QuantMovimentos--;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPosiveis();
            for (int i = 0; i < Tab.Linha ; i++)
            {
                for (int j = 0; j < Tab.Coluna; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPosiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPosiveis();

    }
}
