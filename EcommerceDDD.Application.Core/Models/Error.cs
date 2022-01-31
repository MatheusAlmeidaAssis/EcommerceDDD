using System;
using System.Collections.Generic;

namespace EcommerceDDD.Application.Core.Models
{
    public class Error
    {
        public string NomeCampo { get; set; }

        public string Mensagem { get; set; }

        public List<Error> Errors;

        public Error()
        {
            Errors = new List<Error>();
        }

        public bool Valida(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                Errors.Add(new Error
                {
                    Mensagem = "Campo Obrigatório",
                    NomeCampo = valor.GetType().Name
                });
                return false;
            }
            return true;
        }

        public bool Valida(decimal valor)
        {
            if (valor < 1)
            {
                Errors.Add(new Error
                {
                    Mensagem = "Valor deve ser maior que 0",
                    NomeCampo = valor.GetType().Name
                });
                return false;
            }
            return true;
        }

        public bool Valida(int valor)
        {
            return Valida(Convert.ToDecimal(valor));
        }
    }
}