using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Practica_calificada_1.Controllers
{
    [Route("[controller]")]
    public class FormularioController : Controller
    {
        private readonly ILogger<FormularioController> _logger;

        public FormularioController(ILogger<FormularioController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro(Formulario formulario)
        {
            int Comisión = 0;
            if (Monto <= 300){
                Comisión = 1;
                Monto = monto - 1;
            } else {
                Comisión = 3;
                Monto = monto -3;
            }

            IGV = monto*0.18;
            Monto = Monto +IGV;
            

            if(sp.checked || dow.checked || bonos.checked){
                ViewData["Respuesta"]= "Fecha de operación: " + Fecha + "\n"
                "IGV: " + IGV + "\n" +"Comisión: " + Comisión;
            }
            return View("Formulario");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }

    public class Formulario{
        public string? Nombres {get; set;}
        public string? Apellidos {get; set;}
        public date? Fecha {get; set;}
        public boolean? sp {get; set;}
        public boolean? dow {get; set;}
        public boolean? bonos {get; set;}
        public decimal? Monto {get; set;}
    }
}