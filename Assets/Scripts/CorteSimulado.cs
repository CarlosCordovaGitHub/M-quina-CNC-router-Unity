using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class CorteSimulado : MonoBehaviour
{
    [Header("Referencias")]
    public Transform husillo;

    [Header("Parámetros")]
    public float distanciaMinima = 0.01f;

    private float alturaYBase = -1f;
    private LineRenderer lineRenderer;
    private List<Vector3> puntos = new List<Vector3>();
    private Vector3 ultimoPunto;
    private bool tocandoMadera = false;
    private bool tocandoMetal = false;

    private bool tocandoLadoIzquierdo = false;
    private bool tocandoLadoDerecho = false;
    private bool tocandoSuperior = false;
    private bool tocandoTopeTrasero = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        puntos.Clear();
        Debug.Log("🟢 CorteSimulado iniciado");
    }

    void Update()
    {
        if (!tocandoMetal && tocandoMadera)
        {
            Vector3 nuevoPunto = new Vector3(
                husillo.position.x,
                alturaYBase,
                husillo.position.z
            );

            if (Vector3.Distance(ultimoPunto, nuevoPunto) > distanciaMinima)
            {
                puntos.Add(nuevoPunto);
                lineRenderer.positionCount = puntos.Count;
                lineRenderer.SetPositions(puntos.ToArray());
                ultimoPunto = nuevoPunto;

                Debug.Log("✏ Punto de corte agregado: " + nuevoPunto);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Madera"))
        {
            tocandoMadera = true;
            float alturaSuperior = other.bounds.center.y + other.bounds.extents.y;
            alturaYBase = alturaSuperior;

            Vector3 primerPunto = new Vector3(
                husillo.position.x,
                alturaYBase,
                husillo.position.z
            );

            puntos.Add(primerPunto);
            lineRenderer.positionCount = puntos.Count;
            lineRenderer.SetPositions(puntos.ToArray());
            ultimoPunto = primerPunto;

            Debug.Log($"✏ Inicio de corte en madera: {primerPunto}");
        }

        if (other.CompareTag("Metal"))
        {
            tocandoMetal = true;
            Debug.Log("🟥 Tocando base metálica: " + other.name);
        }

        if (other.CompareTag("LateralIzquierdo"))
        {
            tocandoLadoIzquierdo = true;
            Debug.Log("⬅ Tocando lateral izquierdo: " + other.name);
        }

        if (other.CompareTag("LateralDerecho"))
        {
            tocandoLadoDerecho = true;
            Debug.Log("➡ Tocando lateral derecho: " + other.name);
        }

        if (other.CompareTag("Superior"))
        {
            tocandoSuperior = true;
            Debug.Log("⬆ Tocando puente eje X: " + other.name);
        }

        if (other.CompareTag("TopeTrasero"))
        {
            tocandoTopeTrasero = true;
            Debug.Log("⛔ Tocando tope trasero: " + other.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Madera"))
        {
            tocandoMadera = false;
            Debug.Log("❌ Ya no toca la madera: " + other.name);
        }

        if (other.CompareTag("Metal"))
        {
            tocandoMetal = false;
            Debug.Log("✅ Ya no toca la base metálica");
        }

        if (other.CompareTag("LateralIzquierdo"))
        {
            tocandoLadoIzquierdo = false;
            Debug.Log("✅ Ya no toca lateral izquierdo");
        }

        if (other.CompareTag("LateralDerecho"))
        {
            tocandoLadoDerecho = false;
            Debug.Log("✅ Ya no toca lateral derecho");
        }

        if (other.CompareTag("Superior"))
        {
            tocandoSuperior = false;
            Debug.Log("✅ Ya no toca puente superior");
        }

        if (other.CompareTag("TopeTrasero"))
        {
            tocandoTopeTrasero = false;
            Debug.Log("✅ Ya no toca tope trasero");
        }
    }

    public bool TocandoLadoIzquierdo() => tocandoLadoIzquierdo;
    public bool TocandoLadoDerecho() => tocandoLadoDerecho;
    public bool TocandoSuperior() => tocandoSuperior;
    public bool TocandoMetal() => tocandoMetal;
    public bool TocandoTopeTrasero() => tocandoTopeTrasero;
}
