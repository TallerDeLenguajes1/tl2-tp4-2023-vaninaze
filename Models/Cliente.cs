namespace EspacioPedido;
public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string datosReferencia;

    public string Nombre { get => nombre; }
    public string Direccion { get => direccion; }
    public string Telefono { get => telefono; }
    public string DatosReferencia { get => datosReferencia; }

    public Cliente(string nomb, string dir, string tel, string datos)
    {
        nombre = nomb;
        direccion = dir;
        telefono = tel;
        datosReferencia = datos;
    }

}