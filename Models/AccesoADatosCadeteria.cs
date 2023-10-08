namespace EspacioDatos;
using System.Text.Json;
using EspacioPedido;
public class AccesoADatosCadeteria{
    public Cadeteria Obtener(){
        string fileName = "Cadeteria.json";
        if (File.Exists(fileName)){
            string jsonString = File.ReadAllText(fileName);
            List<Cadeteria> listaCadeterias = JsonSerializer.Deserialize<List<Cadeteria>>(jsonString);
            Cadeteria cadeteria = listaCadeterias[1];
            return cadeteria;
        } else {
            return null;
        }
    }
}