using Microsoft.AspNetCore.Mvc;
using EspacioManejo;
using EspacioDatos;
using EspacioTarea;
using Microsoft.AspNetCore.Http.HttpResults;

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

    [HttpPost("AddTarea")]
    public ActionResult<List<Tarea>> AddTarea(Tarea nueva)
    {
        List<Tarea> auxiliar = manejoTareas.AgregarTarea(nueva);

        if (auxiliar != null)
        {
            return Ok(auxiliar);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("GetTareaPorID")]
    public ActionResult<Tarea> GetTareaPorID(int idBuscado)
    {
        Tarea buscada = manejoTareas.ObtenerTareaPorId(idBuscado);

        if (buscada != null)
        {
            return Ok(buscada);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("Actualizar tarea")] //NO SE REFLEJA EL CAMBIO
    public ActionResult<Tarea> ActualizarTarea(Tarea modificada)
    {
        bool control = manejoTareas.ActualizarTarea(modificada);

        if (control)
        {
            return Ok(modificada);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpDelete("EliminarTarea")] //NO REALIZA EFECTO
    public ActionResult BorrarTarea(int id)
    {
        bool control = manejoTareas.EliminarTarea(id);
        if (control)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpGet("GetTareas")]
    public ActionResult<List<Tarea>> GetListaTareas()
    {
        List<Tarea> tareas = manejoTareas.GetTareas();

        if (tareas != null)
        {
            return Ok(tareas);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("GetTareasCompletadas")]
    public ActionResult<List<Tarea>> GetTareasCompletadas()
    {
        List<Tarea> completadas = manejoTareas.GetTareasCompletadas();

        if (completadas != null)
        {
            return Ok(completadas);
        }
        else
        {
            return NotFound();
        }
    }
}