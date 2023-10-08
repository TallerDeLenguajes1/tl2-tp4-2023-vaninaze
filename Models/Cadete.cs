using System.Text.Json.Serialization;
using EspacioInforme;

namespace EspacioPedido;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    
    public int Id{ get => id; set => id = value; }
    [JsonPropertyName("Nombre")]
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    [JsonPropertyName("Telefono")]
    public string Telefono { get => telefono; set => telefono = value; }

    public Cadete(){ //NECESARIO
        
    }
    public Cadete(int id, string nom, string dir, string telef)
    {
        this.id = id;
        nombre = nom;
        direccion = dir;
        telefono = telef;
    } 
}