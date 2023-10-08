namespace EspacioPedido;
using EspacioPedido;
public class Pedido
{
    private int numero;
    private string observacion;
    private Cliente cliente;
    private int estado;

    private int idCad;
    Cadete cadete;

    public int IDcad { get => idCad; }
    public int Estado { get => estado; }
    public int Numero { get => numero; }

    public Pedido(){
    }
    public Pedido(int num, string obs, string nomb, string dir, string telef, string datos)
    {
        cliente = new Cliente(nomb, dir, telef, datos);
        numero = num;
        observacion = obs;
        estado = 0; //Pendiente
        idCad = 0;
    }
    public void GuardarCadete(Cadete cad){
        cadete = cad;
        Console.WriteLine("Pedido ID: "+Numero);
        Console.WriteLine("Nuevo Cadete: "+cad.Id);
    }
    public void CambiarEstado(int NuevoEstado)
    {
        this.estado = NuevoEstado;
        //0: pendiente, 1:aceptado, 2:entregado
    }
}