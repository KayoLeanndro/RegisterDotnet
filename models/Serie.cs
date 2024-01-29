
namespace DIO.Series
{
    public class Serie : BaseEntity
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }


        public Serie(int id, Genero genero, string Titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = Titulo;
            this.Descricao = descricao;
            this.Ano = ano;
        }

        public string toString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descricão: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;

            return retorno;
        }

        public string retornarTitulo()
        {
            return this.Titulo;
        }
        public int retornarId()
        {
            return this.Id;
        }



    }
}