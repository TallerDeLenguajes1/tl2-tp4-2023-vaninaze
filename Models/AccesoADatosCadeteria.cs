namespace EspacioDatos;
using System.Text.Json;
using EspacioPedido;
public class AccesoADatosCadeteria{
    public Cadeteria Obtener(){
        string archivo = @"C:\tl2-tp4-2023-vaninaze\Cadeteria.json";
        string jsonString = File.ReadAllText(archivo);
        List<Cadeteria> listaCadeterias = JsonSerializer.Deserialize<List<Cadeteria>>(archivo);
        Cadeteria cadeteria = listaCadeterias[1];
        return cadeteria;
    }
}