using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    internal class ProdutoInformation
    {
        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _nome;
        private string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private decimal _preco;
        private decimal Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }

        private int _estoque;
        public int Estoque
        {
            get { return _estoque; }
            set { _estoque = value; }
        }
    }
}
