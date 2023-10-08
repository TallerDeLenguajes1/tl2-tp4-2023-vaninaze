using EspacioPedido;
namespace EspacioInforme;
public class Informe
{
    float montoTotalPedidos;
    int cantEnvios;
    public Informe()
    {
    }
    public void CargarInforme(List<Pedido> listaPedidos){
        int envios=0;
        foreach(Pedido ped in listaPedidos){
            if(ped.Estado == 2){ //entrgado
                envios++;
            }
        }
        this.montoTotalPedidos = 500*envios;
        this.cantEnvios = envios;
    }
    public string GetInforme(){
        string informe="Monto total recaudado: "+this.montoTotalPedidos+" Cantidad de envios: "+this.cantEnvios +"";
        return informe;
    }
}