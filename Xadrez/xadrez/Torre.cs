using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(cor, tab)
        {

        }


        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Pecas(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPosiveis()
        {
            bool[,] mat = new bool[Tab.Linha, Tab.Coluna];

            Posicao pos = new Posicao(0, 0);

            //cima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);          
                while (Tab.PosicaoValida(pos) && PodeMover(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                    if (Tab.Pecas(pos) != null && Tab.Pecas(pos).Cor != Cor)
                    {
                        break;
                    }
                pos.Linha--;
                }           
            //baixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);        
                while (Tab.PosicaoValida(pos) && PodeMover(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                    if (Tab.Pecas(pos) != null && Tab.Pecas(pos).Cor != Cor)
                    {
                        break;
                    }
                    pos.Linha++;
                }
            
            //direita
            pos.DefinirValores(Posicao.Linha , Posicao.Coluna + 1);
                while (Tab.PosicaoValida(pos) && PodeMover(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                    if (Tab.Pecas(pos) != null && Tab.Pecas(pos).Cor != Cor)
                    {
                        break;
                    }
                pos.Coluna++;
                }
            //esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Pecas(pos) != null && Tab.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna--;
            }
           

            return mat;
        }
    

        public override string ToString()
        {
            return "T";
        }
    }
}
