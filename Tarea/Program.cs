using Tarea;
using System;
using System.Text.Json;
using System.ComponentModel;


HttpClient client =  new HttpClient();

var url = "https://jsonplaceholder.typicode.com/todos/";

HttpResponseMessage response = await client.GetAsync(url);

response.EnsureSuccessStatusCode();


string responseBody = await response.Content.ReadAsStringAsync();
List<Tareas> listTareas = JsonSerializer.Deserialize<List<Tareas>>(responseBody);


foreach(var tareas in listTareas)
{
    Console.WriteLine("ID: " + tareas.id + " Nombre: " + tareas.title + " Estado: " + tareas.completed);
}
