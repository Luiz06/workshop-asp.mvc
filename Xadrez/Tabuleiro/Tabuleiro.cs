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

        public Peca Pecas(Posicao pos)
        {
            return Peca[pos.Linha, pos.Coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if(ExistePeca(pos))
            {
                throw new TblException("Já existe peça nessa posição");
            }
            Peca[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);

            return Pecas(pos) != null;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linha || pos.Coluna<0 || pos.Coluna>= Coluna)
            {
                return false;
            }
            return true;
        }
        public void ValidarPosicao(Posicao pos)
        {
            if(!PosicaoValida(pos))
            {
                throw new TblException("Possição Inválida");
            }
        }
    }
}
