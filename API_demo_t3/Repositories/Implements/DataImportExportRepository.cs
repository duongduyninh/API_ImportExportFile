using API_demo_t3.Data;
using API_demo_t3.DTOs;
using API_demo_t3.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_demo_t3.Models.Entities;

namespace API_demo_t3.Repositories.Implements
{
    public class DataImportExportRepository : IDataImportExportRepository
    {
        private readonly IMapper _mapper;
        private readonly DbContextBMW _context;

        public DataImportExportRepository(IMapper mapper , DbContextBMW context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> ImportFileDataAsync(IFormFile file )
        {
            if (file == null || file.Length == 0 ) 
            {
                return ("No file uploaded.");
            }
            try
            {
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    var currentDocument = new System.Reflection.Metadata.Document();

                    string line;

                    int documentId = 0;

                    while ((line = await streamReader.ReadLineAsync()) != null)
                    {
                        var parts = line.Split(',');
                        var entityType = parts[0].Trim();// parts[0] luc nay la ten cac bang du lieu
                        switch (entityType) 
                        {
                            case "Document" :
                                var DocumentDTO = new DocumentDTO
                                {
                                    DocumentNumber = parts[1].Trim(),
                                    Date = parts[2].Trim(),
                                    SalePerson = parts[3].Trim()
                                };

                                var AddDocument = _mapper.Map<Document>(DocumentDTO);
                                     _context.Documents.Add(AddDocument);
                                      await _context.SaveChangesAsync();
                                     documentId = AddDocument.Id;
                                break;
                            case "Customer":
                                if(documentId != 0)
                                {
                                    var CustomerDTO = new CustomerDTO
                                    {
                                        CustomerName = parts[1].Trim(),
                                        Birthday = parts[2].Trim(),
                                        Email = parts[3].Trim(),
                                        Phone = parts[4].Trim(),
                                        DocumentId = documentId
                                    };
                                    var AddCustomer = _mapper.Map<Customer>(CustomerDTO);
                                    _context.Customers.Add(AddCustomer);
                                    await _context.SaveChangesAsync();
                                }
                                break;
                            case "Vehicle":
                                if (documentId != 0)
                                {
                                    var VehicleDTO = new VehicleDTO
                                    {
                                        Make = parts[1].Trim(),
                                        Model = parts[2].Trim(),
                                        Year = parts[3].Trim(),
                                        VIN = parts[4].Trim(),
                                        DocumentId = documentId
                                    };
                                    var AddVehicle = _mapper.Map<Vehicle>(VehicleDTO);
                                    _context.Vehicles.Add(AddVehicle);
                                    await _context.SaveChangesAsync();
                                }
                                break;
                            case "Appointment":
                                if(documentId != 0)
                                {
                                    var AppointmentDTO = new AppointmentDTO
                                    {
                                        BookedAt = parts[1].Trim(),
                                        VIN = parts[2].Trim(),
                                        DocumentId = documentId
                                    };
                                    var AddAppointment = _mapper.Map<Appointment>(AppointmentDTO);
                                    _context.Appointments.Add(AddAppointment);
                                    await _context.SaveChangesAsync();
                                }
                                break;
                        }

                    }
                }
                return ("Success.");

            }
            catch 
            {
                return ("Error.");

            }
        }

       
    }
}
