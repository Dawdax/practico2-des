using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GOES.API.Models;
using GOES.API.DTOs;
using Xunit;
using GOES.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GOES.API.Tests
{
    public class CandidatoControllerIntegrationTests : IDisposable
    {
        private readonly GoesDbContext _context;
        private readonly CandidatoController _controller;
        private readonly IConfiguration _configuration;

        public CandidatoControllerIntegrationTests()
        {
            // Configuración de la conexión a LocalDB
            var options = new DbContextOptionsBuilder<GoesDbContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GOES_DB;Trusted_Connection=True;")
                .Options;

            _context = new GoesDbContext(options);

            // Crear configuración con cadena de conexión
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            _configuration = configBuilder.Build();

            // Inicializar el controlador con la configuración real
            _controller = new CandidatoController(_configuration);
        }

        [Fact]
        public async Task Register_Y_Login_Candidato_Exitosamente()
        {
            // Crear un CandidatoDto de prueba
            var candidatoDto = new CandidatoDto
            {
                Nombre = "Juan",
                Apellidos = "Perez",
                Telefono = "123456789",
                CorreoElectronico = "juan.perez@test.com",
                FechaNacimiento = DateTime.Parse("1990-01-01"),
                Contrasena = "password123"
            };

            // Actuar: Llamar al método Register en el controlador
            var registerResult = await _controller.Register(candidatoDto);
            var okResult = Assert.IsType<OkObjectResult>(registerResult);
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);

            // Ahora verificar el login
            var loginDto = new LoginDto
            {
                CorreoElectronico = candidatoDto.CorreoElectronico,
                Contrasena = candidatoDto.Contrasena
            };

            var loginResult = await _controller.Login(loginDto);
            var loginOkResult = Assert.IsType<OkObjectResult>(loginResult);
            Assert.NotNull(loginOkResult);
            Assert.Equal(200, loginOkResult.StatusCode);
        }

        // Método para limpiar la base de datos después de las pruebas
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}


