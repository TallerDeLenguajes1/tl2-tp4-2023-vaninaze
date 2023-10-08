namespace EspacioDatos;
using System.Text.Json;
using EspacioPedido;
public class AccesoADatosPedidos:AccesoADatos<List<Pedido>>{
    public override List<Pedido> Obtener(){
        string fileName = "Pedidos.json";
        string jsonString = @"C:\tl2-tp4-2023-vaninaze\"+fileName;
        List<Pedido> listaPedidos = JsonSerializer.Deserialize<List<Pedido>>(jsonString);
        return listaPedidos;
    }
    public void Guardar(List<Pedido> Pedidos){
        string fileName = "Pedidos.json";
        string jsonString = JsonSerializer.Serialize(Pedidos);
        FileStream archivo = new FileStream(fileName, FileMode.Create);
        using(StreamWriter strWrite = new StreamWriter(archivo)){
            strWrite.WriteLine("{0}", jsonString);
            strWrite.Close();
        }
        /*Otra forma de serializar:
        File.WriteAllText(fileName, jsonString);*/
    }
}