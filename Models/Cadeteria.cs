namespace EspacioPedido;

using System.Text.Json.Serialization;

using EspacioDatos;
using EspacioInforme;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> ListaCadetes = new List<Cadete>();
    private List<Pedido> ListaPedidos = new List<Pedido>();
    private static Cadeteria? cadeteria;

    [JsonPropertyName("Nombre")] //indico que el campo Nombre en JSON se guarda aqui
    public string Nombre { get => nombre; set => nombre = value; }
     
    [JsonPropertyName("Telefono")]
    public string Telefono { get => telefono; set => telefono = value; }

    //inicializo la cadeteria con singleton
    public static Cadeteria GetInstancia(){
        if(cadeteria == null){
            AccesoADatosCadeteria jsonCadeterias = new();
            cadeteria = jsonCadeterias.Obtener();

            AccesoADatosCadetes jsonCadetes = new();
            cadeteria.ListaCadetes = jsonCadetes.Obtener();
        }
        return cadeteria;
    }
    public Cadeteria(){
        
    }
    public Cadeteria(string nomb = "", string tel = "")
    {
        this.nombre = nomb;
        this.telefono = tel;
    }
    public List<Pedido> GetPedidos(){
        AccesoADatosPedidos jsonPedidos = new();
        List<Pedido> listaPedidos = jsonPedidos.Obtener();
        return listaPedidos;
    }
    public List<Cadete> GetCadetes()
    {
        return this.ListaCadetes;
    }
    public void AgregarPedido(int num, string obs, string nomb, string dir, string telef, string datos){
        Pedido pedido = new Pedido(num, obs, nomb, dir, telef, datos);
        pedido.CambiarEstado(1);
        ListaPedidos.Add(pedido);

        AccesoADatosPedidos jsonPedidos = new();
        jsonPedidos.Guardar(ListaPedidos);
    }
    public void AgregarCadete(Cadete cad){
        ListaCadetes.Add(cad);

        AccesoADatosCadetes jsonCadetes = new();
        jsonCadetes.Guardar(ListaCadetes);
    }
    public void AsignarPedido(int idPed, int idCad){
        Cadete? cadBuscado = ListaCadetes.FirstOrDefault(cad => cad.Id == idCad);
        if(cadBuscado != null){
            ListaPedidos[idPed].GuardarCadete(cadBuscado);
        } else {
            Console.WriteLine("Error! Cadete no encontrado");
        }
        AccesoADatosPedidos jsonPedidos = new();
        jsonPedidos.Guardar(ListaPedidos);
    }
    public void CambiarCadetePedido(int idPed, int idCad)
    {
        Pedido? ped = ListaPedidos.FirstOrDefault(ped => ped.Numero == idPed);
        if(ped != null){
            foreach (Cadete cad in ListaCadetes)
            {
                if (cad.Id == idCad && ped.IDcad != idCad)
                {
                    ped.GuardarCadete(cad);
                }
                else
                {
                    Console.WriteLine("Cadete no existe");
                }
            }
            AccesoADatosPedidos jsonPedidos = new();
            jsonPedidos.Guardar(ListaPedidos);
        }
    }
    public void CambiarEstadoPedido(int idPedido,int NuevoEstado){
        ListaPedidos[idPedido].CambiarEstado(NuevoEstado);
        AccesoADatosPedidos jsonPedidos = new();
        jsonPedidos.Guardar(ListaPedidos);
    }
    public Pedido? BuscarPedido(int idPedido){
        Pedido? ped = ListaPedidos.FirstOrDefault(ped => ped.Numero == idPedido);
        return ped;
    }
    public string GetInforme(){
        Informe informe = new();
        informe.CargarInforme(ListaPedidos);
        string resultado = informe.GetInforme();
        return resultado;
    }
}