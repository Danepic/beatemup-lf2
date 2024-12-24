using UnityEngine;

public class RadarChart : MonoBehaviour
{
public int numberOfAttributes = 6; // Número de atributos (ex: 6)
    public float[] attributeValues; // Valores dos atributos, de 0 a 10
    public float radius = 5f; // Raio do gráfico
    public Color lineColor = Color.blue; // Cor da linha

    private LineRenderer lineRenderer;

    void Start()
    {
        // Inicializar o LineRenderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = numberOfAttributes + 1; // +1 para fechar o gráfico
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        // Inicializar os valores dos atributos (se você quiser usar valores fixos ou recebê-los dinamicamente)
        attributeValues = new float[] { 6, 6, 8, 7, 8, 10 };

        // Atualizar o gráfico com os valores dos atributos
        UpdateRadarChart();
    }

    void UpdateRadarChart()
    {
        // Calculando os ângulos para cada atributo
        float angleStep = 360f / numberOfAttributes;

        for (int i = 0; i < numberOfAttributes; i++)
        {
            float angle = i * angleStep;
            float value = attributeValues[i];

            // Convertendo para coordenadas polares
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * (value / 10f) * radius;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * (value / 10f) * radius;

            // Definindo as posições dos pontos do gráfico
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }

        // Fechando o gráfico (última posição igual à primeira)
        lineRenderer.SetPosition(numberOfAttributes, lineRenderer.GetPosition(0));
    }
}
