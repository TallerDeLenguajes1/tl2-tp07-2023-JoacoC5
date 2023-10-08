using Microsoft.AspNetCore.Mvc;
using EspacioManejo;
using EspacioDatos;

namespace tl2_tp07_2023_JoacoC5.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private ManejoDeTareas manejoTareas;

    private readonly ILogger<TareaController> _logger;
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        AccesoADatos accesoDatos = new AccesoADatos();
        manejoTareas = new ManejoDeTareas(accesoDatos);
    }


}