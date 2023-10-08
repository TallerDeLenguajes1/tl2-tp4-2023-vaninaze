namespace EspacioDatos;
using System.Text.Json;
using EspacioPedido;

public class AccesoADatosPedidos{
    public List<Pedido> Obtener(){
        string fileName = "Pedidos.json";
        if(File.Exists(fileName)){
            string jsonString = File.ReadAllText(fileName);
            List<Pedido> listaPedidos = JsonSerializer.Deserialize<List<Pedido>>(jsonString);
            return listaPedidos;
        } else {
            return null;
        }
    }
    public bool Guardar(List<Pedido> Pedidos){
        string fileName = "Pedidos.json";
        string jsonString = JsonSerializer.Serialize(Pedidos);
        File.WriteAllText(fileName, jsonString);
        /*FileStream archivo = new FileStream(fileName, FileMode.Create);
        using(StreamWriter strWrite = new StreamWriter(archivo)){
            strWrite.WriteLine("{0}", jsonString);
            strWrite.Close();
        }*/
        if(jsonString != null){
            return true;
        } else {
            return false;
        }
    }
}