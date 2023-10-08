namespace EspacioPedido;
using EspacioPedido;
public class Pedido
{
    private int numero;
    private string? observacion;
    private int estado;

    private Cliente? cliente;
    private Cadete? cadete;

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public int Estado { get => estado; set => estado = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    
    public Cadete? Cadete { get => cadete; set => cadete = value; }

    public Pedido(){
    
    }
    
    public Pedido(int num, string obs, string nomb, string dir, string telef, string datos)
    {
        cliente = new Cliente(nomb, dir, telef, datos);
        numero = num;
        observacion = obs;
        estado = 0; //Pendiente
        cadete = new Cadete();
    }
    public void AsignarNumero(int num){
        numero = num;
    }
    public void GuardarCadete(Cadete cad){
        cadete = cad;
    }
    public void CambiarEstado(int NuevoEstado)
    {
        estado = NuevoEstado;
        //0: pendiente, 1:aceptado, 2:entregado
    }
    public int GetEstado(){
        return estado;
    }
}