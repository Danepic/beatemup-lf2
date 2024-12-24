using UnityEngine;
using UnityEngine.UI;

public class FadeImageUI : MonoBehaviour
{
    public float fadeSpeed = 1f; // Velocidade da transição
    public float minAlpha = 0.3f; // Valor mínimo do alfa
    public float maxAlpha = 1f; // Valor máximo do alfa

    private Image image;
    private bool fadingOut = true; // Controla se está diminuindo ou aumentando o alfa

    void Start()
    {
        // Obtém o componente Image anexado ao GameObject
        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("O script FadeImageUI precisa ser anexado a um GameObject com um componente Image.");
        }
    }

    void Update()
    {
        if (image != null)
        {
            Color color = image.color;

            // Alterna entre aumentando ou diminuindo o alfa
            if (fadingOut)
            {
                color.a -= fadeSpeed * Time.deltaTime;
                if (color.a <= minAlpha)
                {
                    color.a = minAlpha;
                    fadingOut = false;
                }
            }
            else
            {
                color.a += fadeSpeed * Time.deltaTime;
                if (color.a >= maxAlpha)
                {
                    color.a = maxAlpha;
                    fadingOut = true;
                }
            }

            image.color = color;
        }
    }
}
