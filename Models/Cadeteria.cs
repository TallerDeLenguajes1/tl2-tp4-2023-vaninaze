namespace EspacioPedido;

using System.Text.Json.Serialization;

using EspacioPedido;
using EspacioDatos;
using EspacioInforme;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete>? ListaCadetes = new List<Cadete>();
    private List<Pedido>? ListaPedidos = new List<Pedido>();
    private AccesoADatosCadetes? accesoCadetes;
    private AccesoADatosPedidos? accesoPedidos;

    public Cadeteria(){

    }

    public Cadeteria(AccesoADatosCadeteria accCadeteria){ 

        Cadeteria cadeteria = accCadeteria.Obtener();
        nombre = cadeteria.nombre;
        telefono = cadeteria.telefono;

        //Obtengo los cadetes
        accesoCadetes = new AccesoADatosCadetes();
        ListaCadetes = accesoCadetes.Obtener();

        //Obtengo los pedidos
        accesoPedidos = new AccesoADatosPedidos();
        ListaPedidos = accesoPedidos.Obtener();
    }
    public Cadeteria(string nomb = "", string tel = "")
    {
        this.nombre = nomb;
        this.telefono = tel;
    }
    public string Nombre { get => nombre; set => nombre = value; }
     
    public string Telefono { get => telefono; set => telefono = value; }
    
    public List<Pedido> GetPedidos(){
        return this.ListaPedidos;
    }
    public List<Cadete> GetCadetes()
    {
        return this.ListaCadetes;
    }
    public bool AgregarPedido(Pedido pedido, int idCad){
        if(idCad != 0){
            Cadete? cadBuscado = ListaCadetes.FirstOrDefault(cad => cad.Id == idCad);
            if(cadBuscado != null){
                pedido.GuardarCadete(cadBuscado);
            } else {
                return false;
            }
        }
        ListaPedidos.Add(pedido);
        pedido.CambiarEstado(1);
        pedido.AsignarNumero(ListaPedidos.Count());

        if(accesoPedidos.Guardar(ListaPedidos)){
            return true;
        } else {
            return false;
        }
    }
    public void AgregarCadete(Cadete cad){
        ListaCadetes.Add(cad);

        accesoCadetes.Guardar(ListaCadetes);
    }
    public bool AsignarPedido(int idPed, int idCad){
        Cadete? cadBuscado = ListaCadetes.FirstOrDefault(cad => cad.Id == idCad);
        Pedido? pedido = ListaPedidos.FirstOrDefault(pedido => pedido.Numero == idPed);
        if(cadBuscado != null && pedido != null){
            ListaPedidos[idPed].GuardarCadete(cadBuscado);
            if(accesoPedidos.Guardar(ListaPedidos)){
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }
    public bool CambiarCadetePedido(int idPed, int idCad)
    {
        Pedido? ped = ListaPedidos.FirstOrDefault(ped => ped.Numero == idPed);
        Cadete? cad = ListaCadetes.FirstOrDefault(cad => cad.Id == idCad);
        if(ped != null && cad != null){
            ped.GuardarCadete(cad);
            if(accesoPedidos.Guardar(ListaPedidos)){
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }
    public bool CambiarEstadoPedido(int idPedido,int NuevoEstado){
        Pedido? ped = ListaPedidos.FirstOrDefault(ped => ped.Numero == idPedido);
        if(ped != null){
            ListaPedidos[idPedido].CambiarEstado(NuevoEstado);
            
            if(accesoPedidos.Guardar(ListaPedidos)){
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }
    public Pedido? BuscarPedido(int idPedido){
        Pedido? ped = ListaPedidos.FirstOrDefault(ped => ped.Numero == idPedido);
        if(ped == null){
            return null;
        } else {
            return ped;
        }
    }
    public string GetInforme(){
        Informe informe = new();
        informe.CargarInforme(ListaPedidos);
        string resultado = informe.GetInforme();
        return resultado;
    }
}