namespace EspacioDatos;
using System.Text.Json;
using EspacioPedido;
public class AccesoADatosCadetes{
    public List<Cadete> Obtener(){
        string archivo = @"C:\tl2-tp4-2023-vaninaze\Cadetes.json";
        string jsonString = File.ReadAllText(archivo);
        List<Cadete> listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonString);
        return listaCadetes;
    }
    public void Guardar(List<Cadete> Cadetes){
        string fileName = "Cadetes.json";
        string jsonString = JsonSerializer.Serialize(Cadetes);
        File.WriteAllText(fileName, jsonString);
    }
}