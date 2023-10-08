namespace EspacioDatos;
using EspacioPedido;
using System.IO;
using System.Text.Json;
//CLASE ABSTRACTA
public abstract class AccesoADatos{
    public virtual List<Cadeteria>? LeerCadeterias(){
        return null;
    }
    public virtual List<Cadete>? LeerCadetes(){
        return null;
    }
}
//JSON
public class AccesoJSON: AccesoADatos{
    public override List<Cadeteria>? LeerCadeterias(){
        string archivo = @"C:\tl2-tp4-2023-vaninaze\Cadeteria.json";
        string jsonString = File.ReadAllText(archivo);
        List<Cadeteria>? listaCadeterias = JsonSerializer.Deserialize<List<Cadeteria>>(jsonString);
        return listaCadeterias;
    }
    public override List<Cadete>? LeerCadetes(){
        string archivoCad = @"C:\tl2-tp4-2023-vaninaze\Cadetes.json";
        string jsonString = File.ReadAllText(archivoCad);
        List<Cadete>? listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonString);
        return listaCadetes;
    }
}
public class AccesoCSV: AccesoADatos{
    public override List<Cadeteria> LeerCadeterias(){
        List<Cadeteria> listaCadeterias = new();

        string nombreArch = @"C:\tl2-tp4-2023-vaninaze\Cadeteria.csv";
        StreamReader archivo = new(nombreArch);
        string? linea;
        while ((linea = archivo.ReadLine()) != null)
        {
            string[] fila = linea.Split(",").ToArray();
            string nomb = fila[0];
            string tel = fila[1];
            Cadeteria cadeteria = new Cadeteria(nomb, tel);
            listaCadeterias.Add(cadeteria);
        }
        return listaCadeterias;
    }
    public override List<Cadete> LeerCadetes(){
        List<Cadete> listaCadetes = new();

        string archCadetes = @"C:\tl2-tp4-2023-vaninaze\Cadetes.csv";
        StreamReader archivo2 = new(archCadetes);
        archivo2.ReadLine(); // Leo la primera línea y la descarto porque es el encabezado
        string? linea;
        Cadeteria cadeteria = new Cadeteria();
        while ((linea = archivo2.ReadLine()) != null)
        {
            string[] fila = linea.Split(",").ToArray();
            int id = Convert.ToInt16(fila[0]);
            string nombre = fila[1];
            string dir = fila[2];
            string tel = fila[3];
            Cadete cadete =  new Cadete(id, nombre, dir, tel);
            listaCadetes.Add(cadete);
        }
        return listaCadetes;
    }
}
