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
    private static Cadeteria? instance;

    [JsonPropertyName("Nombre")] //indico que el campo Nombre en JSON se guarda aqui
    public string Nombre { get => nombre; set => nombre = value; }
     
    [JsonPropertyName("Telefono")]
    public string Telefono { get => telefono; set => telefono = value; }

    //inicializo la cadeteria con singleton
    public static Cadeteria GetInstance(){
        if(instance == null){
            AccesoJSON json = new();
            List<Cadeteria> listaCadeterias = json.LeerCadeterias();

            instance = listaCadeterias[2];
            
            instance.ListaCadetes= json.LeerCadetes();
        }
        return instance;
    }
    public Cadeteria(){
        
    }
    public Cadeteria(string nomb = "", string tel = "")
    {
        this.nombre = nomb;
        this.telefono = tel;
    }
    public List<Pedido> GetPedidos(){
        return this.ListaPedidos;
    }
    public List<Cadete> GetCadetes()
    {
        return this.ListaCadetes;
    }
    public void AgregarPedido(int num, string obs, string nomb, string dir, string telef, string datos){
        Pedido pedido = new Pedido(num, obs, nomb, dir, telef, datos);
        pedido.CambiarEstado(1);
        ListaPedidos.Add(pedido);
    }
    public void crearCadete(int id, string nombre, string dir, string telef){
        Cadete cad = new Cadete(id, nombre, dir, telef);
        ListaCadetes.Add(cad);
    }
    public void AgregarCadete(Cadete cad){
        ListaCadetes.Add(cad);
    }
    public float JornalACobrar(int idCad){
        float monto;
        int cont=0;
        foreach(Pedido ped in ListaPedidos){
            if(ped.IDcad != 0 && ped.IDcad == idCad){
                cont++;
            }
        }
        monto = 500*cont;
        return monto;
    }
    public void AsignarPedido(int idPed, int idCad){
        Cadete? cadBuscado = ListaCadetes.FirstOrDefault(cad => cad.Id == idCad);
        if(cadBuscado != null){
            ListaPedidos[idPed].GuardarCadete(cadBuscado);
        } else {
            Console.WriteLine("Error! Cadete no encontrado");
        }
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
        }
    }
    public void CambiarEstadoPedido(int idPedido,int NuevoEstado){
        ListaPedidos[idPedido].CambiarEstado(NuevoEstado);
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