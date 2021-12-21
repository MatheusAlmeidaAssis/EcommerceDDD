using EcommerceDDD.Domain.Core.Notifications;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceDDD.Domain.Core.Entities
{
    public class EntityBase : Notification
    {
        [Column(Order = 0)]
        public int Id { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime DateExclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}