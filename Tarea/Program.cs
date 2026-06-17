using Tarea;
using System.Text.Json;


HttpClient client =  new HttpClient();

var url = "https://jsonplaceholder.typicode.com/todos/";

HttpResponseMessage response = await client.GetAsync(url);

response.EnsureSuccessStatusCode();


string responseBody = await response.Content.ReadAsStringAsync();

List<Tareas> listaTarea = JsonSerializer.Deserialize<List<Tareas>>(responseBody);

List<Tareas> tareasPendientes = new List<Tareas>();
List<Tareas> tareasCompletadas = new List<Tareas>();

Console.WriteLine("=========== Lista De Tareas Traducidas ===========;");
Console.WriteLine();
foreach(var tareas in listaTarea)
{
    Console.WriteLine("ID: " + tareas.id + " Nombre: " + tareas.title + " Estado: " + tareas.completed);
    if(tareas.completed)
    {
        tareasCompletadas.Add(tareas);
    }
    else
    {
        tareasPendientes.Add(tareas);
    }
}
Console.WriteLine();
Console.WriteLine("=========== Tareas Completadas ===========");
Console.WriteLine();
foreach(var tareas in tareasCompletadas)
{
    Console.WriteLine("ID: " + tareas.id + " Nombre: " + tareas.title + " Estado: " + tareas.completed);
}
Console.WriteLine();
Console.WriteLine("=========== Tareas Pendientes ===========");
Console.WriteLine();
foreach(var tareas in tareasPendientes)
{
    Console.WriteLine("ID: " + tareas.id + " Nombre: " + tareas.title + " Estado: " + tareas.completed);
}

Console.WriteLine();
Console.WriteLine("===========  Lista de Tareas Formato Json ===========");
Console.WriteLine();

string json = JsonSerializer.Serialize(
    listaTarea,
    new JsonSerializerOptions
    {
     WriteIndented = true   
    });

File.WriteAllText("tareas.json", json);

Console.WriteLine("Archivo generado correctamente.");