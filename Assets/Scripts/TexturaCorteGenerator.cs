using UnityEngine;

public class TexturaCorteGenerator : MonoBehaviour
{
    public int resolucion = 1024;
    public Color colorCorte = Color.black;
    public Renderer maderaRenderer;

    private Texture2D texturaCorte;

    void Start()
    {
        texturaCorte = new Texture2D(resolucion, resolucion, TextureFormat.RGBA32, false);
        ClearTexture();

        // Asigna la textura al material
        maderaRenderer.material.SetTexture("_CorteMask", texturaCorte);
    }

    public void Pintar(Vector2 uv)
    {
        int x = (int)(uv.x * resolucion);
        int y = (int)(uv.y * resolucion);
        int radio = 2;

        for (int i = -radio; i <= radio; i++)
        {
            for (int j = -radio; j <= radio; j++)
            {
                if (x + i >= 0 && x + i < resolucion && y + j >= 0 && y + j < resolucion)
                {
                    texturaCorte.SetPixel(x + i, y + j, colorCorte);
                }
            }
        }

        texturaCorte.Apply();
    }

    public void ClearTexture()
    {
        Color[] fill = new Color[resolucion * resolucion];
        for (int i = 0; i < fill.Length; i++) fill[i] = Color.clear;
        texturaCorte.SetPixels(fill);
        texturaCorte.Apply();
    }
}
