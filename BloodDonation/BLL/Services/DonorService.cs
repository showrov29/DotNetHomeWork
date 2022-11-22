using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DonorService
    {
        public List<DonorDTO> Get()
        {
            var dbdata= DataAccessFactory.DonorDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Donor, DonorDTO>());
            var mapper = new Mapper(config);
            var donors = mapper.Map<List<DonorDTO>>(dbdata);
            return donors;
        }

        public static DonorDTO Get(int id)
        {
            var data = DataAccessFactory.GroupDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Donor, DonorDTO>());
            var mapper = new Mapper(config);
            var donor = mapper.Map<DonorDTO>(data);
            return donor;
        }


        public static DonorDTO Add(DonorDTO dto)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DonorDTO, Donor>();
                cfg.CreateMap<Donor, DonorDTO>();

            }

            );
            var mapper = new Mapper(config);
            var donor = mapper.Map<Donor>(dto);
            var result = DataAccessFactory.DonorDataAccess().Add(donor);

            return mapper.Map<DonorDTO>(result);

        }

    }
}
