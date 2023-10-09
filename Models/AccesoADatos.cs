using System.IO;
using System.Text.Json;
using System.Text;
using EspacioTarea;
using EspacioTarea;

namespace EspacioDatos;

public class AccesoADatos
{
    public List<Tarea> LeerTareas()
    {
        string archivo = "Tareas.json";
        List<Tarea> tareas = new List<Tarea>();
        string jsonString;
        if (File.Exists(archivo))
        {
            using (var archivoOpen = new FileStream(archivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    jsonString = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
            }
            tareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString);

        }

        return tareas;
    }

    public void Guardar(List<Tarea> tareas)
    {
        string archivo = "Tareas.json";
        if (!File.Exists(archivo))
        {
            File.Create(archivo).Close();
        }
        string listadoTareas = JsonSerializer.Serialize(tareas);
        File.WriteAllText(archivo, listadoTareas);
    }
}