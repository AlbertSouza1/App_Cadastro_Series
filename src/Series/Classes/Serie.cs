using Series.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series.Classes
{
    public class Serie : EntidadeBase
    {
        public int MyProperty { get; set; }
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }

        private int Ano { get; set; }

        private bool Excluido { get; set; }
        
        public Serie(){}

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = string.Empty;

            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descricao: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
        
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}
