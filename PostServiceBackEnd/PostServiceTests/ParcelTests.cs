using AutoMapper;
using Moq;
using NUnit.Framework;
using PostServiceBackEnd.AutoMapper;
using PostServiceBackEnd.DTO;
using PostServiceBackEnd.Entities;
using PostServiceBackEnd.Repositories;
using PostServiceBackEnd.Services;
using System;
using System.Threading.Tasks;

namespace PostServiceTests
{
    class ParcelTests
    {
        [Test]
        public void ParcelService_GetById_Returns_ParcelPutDTO()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ParcelProfile>());
            var mapper = new Mapper(config);

            int id = 1;
            var mockParcelRepository = new Mock<IParcelRepository<Parcel>>();

            mockParcelRepository.Setup(h => h.GetByIdAsync(id)).ReturnsAsync(new Parcel() { Id = id });

            var parcelService = new ParcelService(mockParcelRepository.Object, mapper);
            var result = parcelService.GetByIdAsync(id);

            var parcelPutDTO = new ParcelPutDTO { Id = id };

            Assert.AreEqual(parcelPutDTO.Id, result.Id);
        }

        [Test]
        public void ParcelService_GetById_ThrowsArgumentException()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ParcelProfile>());
            var mapper = new Mapper(config);

            int id = 1; //Add existing ID
            var mockParcelRepository = new Mock<IParcelRepository<Parcel>>();

            mockParcelRepository.Setup(h => h.GetByIdAsync(id)).Returns(Task.FromResult<Parcel>(null));

            var parcelService = new ParcelService(mockParcelRepository.Object, mapper);
            Assert.ThrowsAsync<ArgumentException>(() => parcelService.GetByIdAsync(id));
        }
    }
}
