using EspacioPedido;
using Microsoft.AspNetCore.Mvc;

namespace CadeteriaController;

[ApiController]
[Route("[controller]")]

public class CadeteriaController: ControllerBase
{
    public static Cadeteria? cadeteria;
    private readonly ILogger<CadeteriaController> logger;
    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        this.logger = logger;
        cadeteria = Cadeteria.GetInstance();
    }
    [HttpGet("GetCadeteria")]
    public ActionResult<string> GetCadeteria(){
        string resultado = "Nombre cadeteria: "+cadeteria.Nombre +" Telefono: "+cadeteria.Telefono;
        return resultado;
    }
    [HttpGet("GetCadetes")]
    public ActionResult<List<Cadete>> GetCadetes(){
        List<Cadete> listaCadetes = cadeteria.GetCadetes();
        return Ok(listaCadetes);
    }
    [HttpGet("GetPedidos")]
    public ActionResult<List<Pedido>> GetPedidos(){
        List<Pedido> listaPedidos = cadeteria.GetPedidos();
        return Ok(listaPedidos);
    }
    [HttpGet("GetInforme")]
    public ActionResult<string> GetInforme(){
        string informe = cadeteria.GetInforme();
        return Ok(informe);
    }
    [HttpPut("AgregarPedido")]
    public ActionResult<Pedido> AgregarPedido(int idPed, string Observacion, string NombCliente, string Direccion, string Telefono, string datosReferencia){
        cadeteria.AgregarPedido(idPed, Observacion, NombCliente, Direccion, Telefono, datosReferencia);
        Pedido pedido = cadeteria.BuscarPedido(idPed);
        return Ok(pedido);
    }

    [HttpPut("AsignarPedido")]
    public ActionResult<Pedido> AsignarPedido(int idPedido, int idCadete){
        cadeteria.AsignarPedido(idPedido, idCadete);
        Pedido ped = cadeteria.BuscarPedido(idPedido);
        return Ok(ped);
    }

    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstadoPedido(int idPedido,int NuevoEstado){
        cadeteria.CambiarEstadoPedido(idPedido, NuevoEstado);
        Pedido pedido = cadeteria.BuscarPedido(idPedido);
        return Ok(pedido);
    }

    [HttpPut("CambiarCadetePedido")]
    public ActionResult<Pedido> CambiarCadetePedido(int idPedido,int idNuevoCadete){
        cadeteria.CambiarCadetePedido(idPedido, idNuevoCadete);
        Pedido pedido = cadeteria.BuscarPedido(idPedido);
        return Ok(pedido);
    }
}