using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceDDD.Domain.Core.Notifications
{
    public class Notification
    {
        [NotMapped]
        public string Nome { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notification> Notifications;

        public Notification()
        {
            Notifications = new List<Notification>();
        }

        public bool Valida(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                Notifications.Add(new Notification
                {
                    Mensagem = "Campo Obrigatório",
                    Nome = valor.GetType().Name
                });
                return false;
            }
            return true;
        }

        public bool Valida(decimal valor)
        {
            if (valor < 1)
            {
                Notifications.Add(new Notification
                {
                    Mensagem = "Valor deve ser maior que 0",
                    Nome = valor.GetType().Name
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