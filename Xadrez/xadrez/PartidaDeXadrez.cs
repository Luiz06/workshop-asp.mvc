using System;
using System.Collections.Generic;
using tabuleiro;


namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public HashSet<Peca> Pecas { get; set; }
        public HashSet<Peca> Capturadas { get; set; }
        public bool Xeque { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.RetiraPeca(destino);
            p.DecrementaMovimento();
            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca r = Rei(cor);
            if (r == null)
            {
                throw new TblException("Não tem rei da cor" + cor + "no tabuleito");
            }

            foreach (Peca x in PecasJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPosiveis();
                if (mat[r.Posicao.Linha, r.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TesteXeque(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in PecasJogo(cor))
            {
                bool[,] mat = x.MovimentosPosiveis();
                for (int i = 0; i < Tab.Linha; i++)
                {
                    for (int j = 0; j < Tab.Coluna; j++)
                    {
                        if(mat[i,j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(x.Posicao, new Posicao(i, j));
                            bool testXeque = EstaEmXeque(cor);
                            DesfazerMovimento(origem, destino, pecaCapturada);
                            if(!testXeque)
                            {
                                return false;
                            }

                        }
                    }
                }

            }
            return true;
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetiraPeca(origem);
            p.QuantMovimento();
            Peca pecaCapturada = Tab.RetiraPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tab.Pecas(pos) == null)
            {
                throw new TblException("Nao existe peça na origem escolhida");
            }
            if (JogadorAtual != Tab.Pecas(pos).Cor)
            {
                throw new TblException("A peça de origem não é sua");
            }
            if (!Tab.Pecas(pos).ExisteMovimentosPossiveis())
            {
                throw new TblException("Não há movimentos possíveis para a peça de origem escolhida");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Pecas(origem).PodeMoverPara(destino))
            {
                throw new TblException("posição de destino inválida!");
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazerMovimento(origem, destino, pecaCapturada);
                throw new TblException("Você não pode se por em xeque");
            }
            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (TesteXeque(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
        }

        public void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }


        public HashSet<Peca> PecasJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }
        private void ColocarPecas()
        {

            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));

        }
    }
}
