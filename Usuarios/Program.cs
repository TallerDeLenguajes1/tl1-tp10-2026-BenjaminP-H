using System.Text.Json;
using Usuarios;

HttpClient client = new HttpClient(); 
var url = "https://jsonplaceholder.typicode.com/users/"; 
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode(); 
string responseBody = await response.Content.ReadAsStringAsync();
List<Usuario> listaUsuarios = JsonSerializer.Deserialize<List<Usuario>>(responseBody);

Console.WriteLine("====================================================");
Console.WriteLine("=========== Lista De Usuarios Traducidas ===========");
Console.WriteLine("====================================================");

for(int i = 0 ; i < 5 ; i++)
{
    Console.WriteLine($"=========== Usuario {i + 1} ===========");
    Console.WriteLine($"Nombre: {listaUsuarios[i].name}");
    Console.WriteLine($"Correo: {listaUsuarios[i].email}");
    Console.WriteLine($"Domicilio: {listaUsuarios[i].address.city}");
}

