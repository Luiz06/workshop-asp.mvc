
namespace tabuleiro
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao( int linha, int posica)
        {
            Linha = linha;
            Coluna = Coluna;
        }

        public override string ToString()
        {
            return Linha + "," + Coluna;
        }
    }
}
