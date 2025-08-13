using UnityEngine;

public class MovimientoCNC : MonoBehaviour
{
    [Header("Referencias de movimiento")]
    public Transform ejeX;           
    public Transform ejeY;           
    public Transform ejeZVisual;     

    [Header("Corte")]
    public CorteSimulado corteSimulado;

    public float velocidad = 2f;

    void Update()
    {
        // Eje Z visual (adelante y atrás)
        if (Input.GetKey(KeyCode.W))
            ejeZVisual.Translate(Vector3.forward * velocidad * Time.deltaTime);
        if (Input.GetKey(KeyCode.S) && !corteSimulado.TocandoTopeTrasero())
            ejeZVisual.Translate(Vector3.back * velocidad * Time.deltaTime);

        // Eje X lateral
        if (Input.GetKey(KeyCode.A) && !corteSimulado.TocandoLadoIzquierdo())
            ejeX.Translate(Vector3.left * velocidad * Time.deltaTime);
        if (Input.GetKey(KeyCode.D) && !corteSimulado.TocandoLadoDerecho())
            ejeX.Translate(Vector3.right * velocidad * Time.deltaTime);

        // Eje Y vertical
        if (Input.GetKey(KeyCode.Q) && !corteSimulado.TocandoSuperior())
            ejeY.Translate(Vector3.up * velocidad * Time.deltaTime);
        if (Input.GetKey(KeyCode.E) && !corteSimulado.TocandoMetal())
            ejeY.Translate(Vector3.down * velocidad * Time.deltaTime);
    }

    public void MoverArriba()
    {
        if (!corteSimulado.TocandoSuperior())
            ejeY.Translate(Vector3.up * velocidad * Time.deltaTime);
    }

    public void MoverAbajo()
    {
        if (!corteSimulado.TocandoMetal())
            ejeY.Translate(Vector3.down * velocidad * Time.deltaTime);
    }

    public void MoverIzquierda()
    {
        if (!corteSimulado.TocandoLadoIzquierdo())
            ejeX.Translate(Vector3.left * velocidad * Time.deltaTime);
    }

    public void MoverDerecha()
    {
        if (!corteSimulado.TocandoLadoDerecho())
            ejeX.Translate(Vector3.right * velocidad * Time.deltaTime);
    }

    public void MoverAdelante()
    {
        ejeZVisual.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    public void MoverAtras()
    {
        if (!corteSimulado.TocandoTopeTrasero())
            ejeZVisual.Translate(Vector3.back * velocidad * Time.deltaTime);
    }

    public void ActivarCorte()
    {
        Debug.Log("🟢 Corte Activado (placeholder)");
    }

    public void DetenerCorte()
    {
        Debug.Log("🔴 Corte Detenido (placeholder)");
    }
}
