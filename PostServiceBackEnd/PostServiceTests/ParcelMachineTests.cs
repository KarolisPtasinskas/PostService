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
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ParcelMachineService_GetById_Returns_ParcelMachinePutDTO()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ParcelMachineProfile>());
            var mapper = new Mapper(config);

            int id = 1;
            var mockParcelMachineRepository = new Mock<IParcelMachineRepository<ParcelMachine>>();

            mockParcelMachineRepository.Setup(h => h.GetByIdAsync(id)).ReturnsAsync(new ParcelMachine() { Id = id });

            var parcelMachineService = new ParcelMachineService(mockParcelMachineRepository.Object, mapper);
            var result = parcelMachineService.GetByIdAsync(id);

            var parcelMachinePutDTO = new ParcelMachinePutDTO { Id = id };

            Assert.AreEqual(parcelMachinePutDTO.Id, result.Id);
        }

        [Test]
        public void ParcelMachineService_GetById_ThrowsArgumentException()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ParcelMachineProfile>());
            var mapper = new Mapper(config);

            int id = 999; //Add non existing ID
            var mockParcelMachineRepository = new Mock<IParcelMachineRepository<ParcelMachine>>();

            mockParcelMachineRepository.Setup(h => h.GetByIdAsync(id)).Returns(Task.FromResult<ParcelMachine>(null));

            var parcelMachineService = new ParcelMachineService(mockParcelMachineRepository.Object, mapper);
            Assert.ThrowsAsync<ArgumentException>(() => parcelMachineService.GetByIdAsync(id));
        }
    }
}