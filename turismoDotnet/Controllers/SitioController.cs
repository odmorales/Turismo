using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using turismoDotnet.Models;

namespace turismoDotnet.Controllers {
    [Route ("api/[controller]")]
    [ApiController]

    public class SitioController : ControllerBase {
        private readonly SitioService _sitioService;
        public IConfiguration Configuration { get; }
        public SitioController (IConfiguration configuration) {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _sitioService = new SitioService (connectionString);
        }
        // GET: api/Sitio
        [HttpGet]
        public IEnumerable<SitioViewModel> Gets () {
            var sitios = _sitioService.ConsultarTodos ().Select (s => new SitioViewModel (s));
            return sitios;
        }
        // POST: api/Sitio
        [HttpPost]
        public ActionResult<SitioViewModel> Post (SitioInputModel sitioInput) {
            Sitio sitio = MapearSitio (sitioInput);
            var response = _sitioService.Guardar(sitio);
            if (response.Error) {
                ModelState.AddModelError ("Guardar Sitio", response.Mensaje);
                var problemDetails = new ValidationProblemDetails (ModelState) {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest (problemDetails);
            }
            return Ok (response.Sitio);
        }
        private Sitio MapearSitio (SitioInputModel sitioInput) {
            var sitio = new Sitio {
                Nombre = sitioInput.Nombre,
                Descripcion = sitioInput.Descripcion,
                Informacion = sitioInput.Informacion,
                ImagenesPath = sitioInput.ImagenesPath
            };
            return sitio;
        }
    }
}