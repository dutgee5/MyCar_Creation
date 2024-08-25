﻿using MyCar_Creation.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCar_Creation.Entities
{
	public class Vehicle :BaseModel
	{
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ModelYear { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        //Vehicleyle bağlantılı bir tane kategori olabilir
        public Category Category { get; set; }
    }
}
