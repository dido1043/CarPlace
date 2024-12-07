using CarPlace.Data;
using CarPlace.Data.DTO.ServiceRecordsModel;
using CarPlace.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPlace.Controllers
{
    public class ServiceRecordsController : Controller
    {
        private readonly AppDbContext _context;
        public ServiceRecordsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/cars/records/all")]
        public async Task<IActionResult> All()
        {
            var records = await _context.ServiceRecords.Select(c => new ServiceRecordDTO
            {
                Id = c.Id,
                CarId = c.CarId,
                ServiceDate = c.ServiceDate,
                ServiceDetails = c.ServiceDetails,
            }).ToListAsync();

            return Ok(records);
        }
        [HttpPost]
        [Route("/cars/records/add")]
        public async Task<IActionResult> Add([FromBody] ServiceRecordDTO serviceRecord)
        {
            var currentCar = await _context.Cars.FindAsync(serviceRecord.CarId);

            if (currentCar == null)
            {
                return NotFound("Car not found");
            }

            var entity = new ServiceRecord()
            {
                Id = serviceRecord.Id,
                CarId = currentCar.Id,
                ServiceDate = serviceRecord.ServiceDate,
                ServiceDetails = serviceRecord.ServiceDetails
            };
            _context.ServiceRecords.Add(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpPut]
        [Route("/cars/records/edit/{srId}")]
        public async Task<IActionResult> Edit(int srId, [FromBody] ServiceRecordDTO serviceRecord)
        {
            var record = await _context.ServiceRecords.FindAsync(srId);

            CheckRecordValidation(record);

            record.ServiceDate = serviceRecord.ServiceDate;
            record.ServiceDetails = serviceRecord.ServiceDetails;

            _context.ServiceRecords.Update(record);
            await _context.SaveChangesAsync();
            
            return Ok(serviceRecord);

        }

        [HttpDelete]
        [Route("/cars/records/delete/{srId}")]
        public async Task<IActionResult> Delete(int srId)
        {
            var record = await _context.ServiceRecords.FindAsync(srId);
            CheckRecordValidation(record);

            _context.ServiceRecords.Remove(record);
            await _context.SaveChangesAsync();
            return Ok();
        }


        private void CheckRecordValidation(ServiceRecord? record)
        {
            if (record == null)
            {
                throw new Exception("Invalid service record!");
            }
        }
    }
}
