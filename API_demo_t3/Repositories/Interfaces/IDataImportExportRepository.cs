using API_demo_t3.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_demo_t3.Repositories.Interfaces
{
    public interface IDataImportExportRepository
    {
        public Task<string> ImportFileDataAsync(IFormFile model);
    }
}
