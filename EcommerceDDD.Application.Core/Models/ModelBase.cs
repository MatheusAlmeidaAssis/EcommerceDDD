using EcommerceDDD.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceDDD.Application.Core.Models
{
    public abstract class ModelBase : Error
    {
        [Column(Order = 0)]
        public int Id { get; set; }

        public ModelBase(EntityBase entityBase)
        {
            Id = entityBase.Id;
        }
    }
}