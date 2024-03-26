using API_demo_t3.Data;
using API_demo_t3.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_demo_t3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataImportExportController : ControllerBase
    {
        private readonly DbContextBMW _context;
        private readonly IDataImportExportRepository _dataImportExportRepository;

        public DataImportExportController(DbContextBMW context 
                                        , IDataImportExportRepository dataImportExportRepository ) 
        {
            _context = context;
            _dataImportExportRepository = dataImportExportRepository;
        }
        [HttpPost("ImportDB_file")]
        public async Task<IActionResult> ImportDB(IFormFile file)
        {
            try
            {
                return Ok(await _dataImportExportRepository.ImportFileDataAsync(file));
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

    }
}
