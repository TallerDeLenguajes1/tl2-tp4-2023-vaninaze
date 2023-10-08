namespace EspacioDatos;
public abstract class AccesoADatos<T>{
    public virtual T Obtener(){
        return default(T);
    }
}