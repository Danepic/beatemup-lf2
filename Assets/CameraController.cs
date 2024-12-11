using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<Transform> players; // Array contendo os Transforms dos jogadores
    private Camera cam;
    private Vector3 basePosition = new(0f, 4.24f, -13.88f);
    private Vector3 baseRotation = new(13.776f, 0f, 0f);
    public float minX = float.MaxValue;
    public float maxX = float.MinValue;
    public float minY = float.MaxValue;
    public float maxY = float.MinValue;

    void Start()
    {
        cam = GetComponent<Camera>();
        players = GameObject.FindGameObjectsWithTag("Character").Select(chara => chara.transform).ToList();
    }

    void LateUpdate()
    {
        if (players.Count == 0)
        {
            return;
        }

        if (players.Count == 1)
        {
            var newPosition = players[0].position + basePosition;
            transform.position = Vector3.Lerp(transform.position, newPosition, 10);
        }
        else
        {
            minX = float.MaxValue;
            maxX = float.MinValue;
            minY = float.MaxValue;
            maxY = float.MinValue;
            foreach (Transform player in players)
            {
                float x = player.gameObject.transform.position.x;
                if (x < minX) minX = x;
                if (x > maxX) maxX = x;

                float y = player.gameObject.transform.position.y;
                if (y < minY) minY = y;
                if (y > maxY) maxY = y;
            }

            var newPosition = new Vector3((maxX + minX) / 2, ((maxY + minY) / 2) + 4.24f, -13.88f);
            transform.position = Vector3.Lerp(transform.position, newPosition, 10f);
        }
    }
}
