using EspacioPedido;
using EspacioDatos;
using EspacioInforme;
using Microsoft.AspNetCore.Mvc;

namespace CadeteriaController;

[ApiController]
[Route("[controller]")]

public class CadeteriaController: ControllerBase
{
    public Cadeteria? cadeteria;
    private readonly ILogger<CadeteriaController> logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        this.logger = logger;
        AccesoADatosCadeteria accCadeteria = new AccesoADatosCadeteria();
        cadeteria = new Cadeteria(accCadeteria);
    }
    [HttpGet("GetCadeteria")]
    public ActionResult<string> GetCadeteria(){
        string resultado = "Nombre cadeteria: "+cadeteria.Nombre +" \n Telefono: "+cadeteria.Telefono;
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
    [HttpPost("AgregarPedido")]
    public ActionResult<Pedido> AgregarPedido(Pedido ped, int idCad){

        bool resultado = cadeteria.AgregarPedido(ped, idCad);
        if(resultado){
            return Ok(ped);
        } else {
            return BadRequest(ped);
        }
    }

    [HttpPut("AsignarPedido")]
    public ActionResult<Pedido> AsignarPedido(int idPedido, int idCadete){
        bool resultado = cadeteria.AsignarPedido(idPedido, idCadete);
        Pedido ped = cadeteria.BuscarPedido(idPedido);
        if(resultado){
            return Ok(ped);
        } else {
            return BadRequest(ped);
        }
    }

    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstadoPedido(int idPedido,int NuevoEstado){
        bool resultado = cadeteria.CambiarEstadoPedido(idPedido, NuevoEstado);
        Pedido pedido = cadeteria.BuscarPedido(idPedido);
        if(resultado){
            return Ok(pedido);
        } else {
            return BadRequest(pedido);
        }
    }

    [HttpPut("CambiarCadetePedido")]
    public ActionResult<bool> CambiarCadetePedido(int idPedido,int idNuevoCadete){
        bool resultado = cadeteria.CambiarCadetePedido(idPedido, idNuevoCadete);
        if(resultado){
            return Ok(resultado);
        } else {
            return BadRequest(resultado);
        }
    }
}