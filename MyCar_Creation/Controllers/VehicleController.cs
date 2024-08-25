using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar_Creation.Context;
using MyCar_Creation.Dtos;
using MyCar_Creation.Entities;

namespace MyCar_Creation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VehicleController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		public VehicleController(ApplicationDbContext context)
		{
			_context = context;
		}


		[HttpPost]
		public ActionResult CreateVehicle(VehicleDTO model)
		{
			Vehicle vehicle = new()
			{
				Brand = model.Brand,
				Model = model.Model,
				ModelYear = model.ModelYear,
				Price = model.Price,
				Description = model.Description,
				CategoryId = model.CategoryId,
			};
			//Maplemek
			_context.Vehicles.Add(vehicle);
			if (_context.SaveChanges() > 0)
			{
				return Ok();
			}
			return BadRequest();
		}

		[HttpDelete("{vehicleId")]
		public ActionResult DeleteVehicle([FromRoute] Guid vehicleId)
		{
			Vehicle category = _context.Vehicles.Find(vehicleId);
			if (category != null)
			{
				_context.Vehicles.Remove(category);
				if (_context.SaveChanges() > 0)
				{
					return Ok();
				}
			}
			return BadRequest();
		}

		[HttpGet]
		public ActionResult GetAllVehicle()
		{
			List<Vehicle> categories = _context.Vehicles.ToList();

			if (categories is not null)
			{
				return Ok(categories);
			}
			return NotFound();
		}

		[HttpPut("{vehicleId}")]
		public ActionResult UpdateVehicle([FromRoute] Guid vehicleId, VehicleDTO model)
		{
			Vehicle vehicle = _context.Vehicles.Find(vehicleId);
			if (vehicle != null)
			{
				return Ok(vehicle);
			}
			return NotFound();
		}

		[HttpGet("{vehicleId}")]
		public ActionResult GetVehicleById([FromRoute] Guid vehicleId)
		{
			Vehicle vehicle = _context.Vehicles.Find(vehicleId);
			if (vehicle != null)
			{
				return Ok(vehicle);
			}
			return NotFound();
		}

		[HttpGet("{categoryId}")]
		public ActionResult GetVehicleByCategoryId([FromRoute] Guid categoryId)
		{
			List<Vehicle> vehicles = _context.Vehicles.Where(x => x.CategoryId == categoryId).ToList();
			if (vehicles != null)
			{
				return Ok(vehicles);
			}
			return NotFound();
		}
	}

}
