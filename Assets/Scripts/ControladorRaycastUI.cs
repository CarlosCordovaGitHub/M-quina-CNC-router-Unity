using UnityEngine;

public class ControladorRaycastUI : MonoBehaviour
{
    public Camera camaraPrincipal;
    private BotonCNC botonActivo = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camaraPrincipal.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                BotonCNC boton = hit.collider.GetComponent<BotonCNC>();
                if (boton != null)
                {
                    boton.Presionar();
                    botonActivo = boton;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && botonActivo != null)
        {
            botonActivo.Soltar();
            botonActivo = null;
        }
    }
}
