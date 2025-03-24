using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Modelo;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace BLL
{
    public class ClientesBLL
    {
        public void Incluir(ClienteInformation cliente)
        {
            // nome do cliente é obrigatório
            if (cliente.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do cliente é obrigatório");
            }

            // Email sempre em minúsculo
            cliente.Email = cliente.Email.ToLower();

            // se tudo estiver ok, chama a rotina de inserção
            ClientesDAL obj = new ClientesDAL();
            obj.Incluir(cliente);
        }

        public void Alterar(ClienteInformation cliente)
        {
            // nome do cliente é obrigatório
            if (cliente.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do cliente é obrigatório");
            }
            // Email sempre em minúsculo
            cliente.Email = cliente.Email.ToLower();
            // se tudo estiver ok, chama a rotina de alteração
            ClientesDAL obj = new ClientesDAL();
            obj.Alterar(cliente);
        }

        public void Excluir(int codigo)
        {
            // se tudo estiver ok, chama a rotina de exclusão
            if (codigo < 1)
            {
                throw new Exception("Selecione um cliente antes de excluí-lo");
            }
            ClientesDAL obj = new ClientesDAL();
            obj.Excluir(codigo);
        }
    }
}
