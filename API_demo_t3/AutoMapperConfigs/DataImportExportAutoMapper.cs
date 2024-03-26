using API_demo_t3.DTOs;
using API_demo_t3.Models.Entities;
using AutoMapper;
using System.Reflection.Metadata;
using Document = API_demo_t3.Models.Entities.Document;

namespace API_demo_t3.AutoMapperConfigs
{
    public class DataImportExportAutoMapper : Profile
    {
        public DataImportExportAutoMapper()
        {
            CreateMap<Document, DocumentDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
        } 
    }
}
