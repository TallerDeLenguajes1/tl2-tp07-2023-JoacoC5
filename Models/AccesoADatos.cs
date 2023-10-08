using System.IO;
using System.Text.Json;
using EspacioTarea;
using EspacioTarea;

namespace EspacioDatos;

public class AccesoADatos
{
    public List<Tarea> LeerTareas()
    {
        string archivo = "Tareas.json";
        if (File.Exists(archivo))
        {
            string jsonString = File.ReadAllText(archivo);
            List<Tarea> tareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString);
            return tareas;
        }
        else
        {
            return null;
        }
    }

    public void Guardar(List<Tarea> tareas)
    {
        if (tareas != null)
        {
            string archivo = "Tareas.json";
            string listadoTareas = JsonSerializer.Serialize(tareas);
            File.WriteAllText(archivo, listadoTareas);
        }
    }
}