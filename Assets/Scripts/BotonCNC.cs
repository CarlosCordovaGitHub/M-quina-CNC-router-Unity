using UnityEngine;

public class BotonCNC : MonoBehaviour
{
    public enum TipoAccion
    {
        MoverArriba,
        MoverAbajo,
        MoverIzquierda,
        MoverDerecha,
        MoverAdelante,
        MoverAtras,
        ActivarCorte,
        DetenerCorte
    }

    public TipoAccion accion;
    public MovimientoCNC cnc;

    private bool presionado = false;

    void Update()
    {
        if (presionado)
        {
            EjecutarAccion();
        }
    }

    public void Presionar()
    {
        Debug.Log($"🟢 PRESIONADO: {accion}");
        presionado = true;
    }

    public void Soltar()
    {
        Debug.Log($"🔴 SOLTADO: {accion}");
        presionado = false;
    }

    public void EjecutarAccion()
    {
        if (cnc == null) return;

        switch (accion)
        {
            case TipoAccion.MoverArriba:
                cnc.MoverArriba();
                break;
            case TipoAccion.MoverAbajo:
                cnc.MoverAbajo();
                break;
            case TipoAccion.MoverIzquierda:
                cnc.MoverIzquierda();
                break;
            case TipoAccion.MoverDerecha:
                cnc.MoverDerecha();
                break;
            case TipoAccion.MoverAdelante:
                cnc.MoverAdelante();
                break;
            case TipoAccion.MoverAtras:
                cnc.MoverAtras();
                break;
            case TipoAccion.ActivarCorte:
                cnc.ActivarCorte();
                break;
            case TipoAccion.DetenerCorte:
                cnc.DetenerCorte();
                break;
        }
    }
}
