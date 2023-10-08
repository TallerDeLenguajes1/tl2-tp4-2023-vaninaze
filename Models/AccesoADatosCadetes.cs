namespace EspacioDatos;
using System.Text.Json;
using EspacioPedido;

public class AccesoADatosCadetes{
    public List<Cadete> Obtener(){
        string fileName = "Cadetes.json";
        string jsonString = File.ReadAllText(fileName);
        List<Cadete> listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonString);
        return listaCadetes;
    }
    public void Guardar(List<Cadete> Cadetes){
        string fileName = "Cadetes.json";
        string jsonString = JsonSerializer.Serialize(Cadetes);
        File.WriteAllText(fileName, jsonString);
    }
}