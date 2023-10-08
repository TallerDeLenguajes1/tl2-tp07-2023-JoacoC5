using System.IO;
using System.Text;
using EspacioTarea;
using EspacioDatos;

namespace EspacioManejo;

public class ManejoDeTareas
{
    private AccesoADatos accesoDatos;

    public ManejoDeTareas(AccesoADatos accesoDatos)
    {
        this.accesoDatos = accesoDatos;
    }

    public List<Tarea> AgregarTarea(Tarea nuevo)
    {
        List<Tarea> listado = accesoDatos.LeerTareas();
        listado.Add(nuevo);
        nuevo.Id = listado.Count();

        accesoDatos.Guardar(listado);

        return listado;
    }

    public Tarea ObtenerTareaPorId(int idBuscado)
    {
        List<Tarea> listado = accesoDatos.LeerTareas();
        if (listado.Exists(x => x.Id == idBuscado))
        {
            return listado.Find(X => X.Id == idBuscado);
        }
        else
        {
            return null;
        }
    }

    public bool ActualizarTarea(Tarea modificada)
    {
        List<Tarea> listado = accesoDatos.LeerTareas();
        if (listado.Exists(x => x.Id == modificada.Id))
        {
            Tarea auxTarea = listado.Find(X => X.Id == modificada.Id);
            auxTarea.Titulo = modificada.Titulo;
            auxTarea.Descripcion = modificada.Descripcion;
            auxTarea.Estado = modificada.Estado;

            accesoDatos.Guardar(listado);
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Tarea> EliminarTarea(int idBuscado)
    {
        List<Tarea> listado = accesoDatos.LeerTareas();
        if (listado.Exists(x => x.Id == idBuscado))
        {
            Tarea auxiliar = listado.Find(X => X.Id == idBuscado);

            listado.Remove(auxiliar);
        }

        return listado;
    }

    public List<Tarea> GetTareas()
    {
        return accesoDatos.LeerTareas();
    }

    public List<Tarea> GetTareasCompletadas()
    {
        List<Tarea> listado = accesoDatos.LeerTareas();
        List<Tarea> completadas = new List<Tarea>();
        completadas = listado.FindAll(x => x.Estado == Estado.Completada);

        return completadas;
    }
}
