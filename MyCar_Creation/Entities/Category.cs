using MyCar_Creation.Model;

namespace MyCar_Creation.Entities
{
	public class Category :BaseModel
	{
		public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int VehicleCount { get; set; }

        //Bu kategorinin altından birden fazla araç olabilir
        public List<Vehicle> Vehicles { get; set; }
    }
}
