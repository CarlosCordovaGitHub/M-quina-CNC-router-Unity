using UnityEngine;

public class ActivadorCorte : MonoBehaviour
{
    public TrailRenderer trail;
    private bool tocandoMadera = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Madera"))
        {
            tocandoMadera = true;
            trail.emitting = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Madera"))
        {
            tocandoMadera = false;
            trail.emitting = false;
        }
    }

    void Update()
    {
        // Opcional: por seguridad
        if (!tocandoMadera)
        {
            trail.emitting = false;
        }
    }
}
