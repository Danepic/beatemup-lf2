using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<Transform> players;
    private Vector3 baseOffset = new(0f, 4.24f, -13.88f);
    private Vector3 baseRotation = new(13.776f, 0f, 0f);
    
    [Header("Limites do Mapa")]
    public bool useLimits = false;
    public float minLimitX = -50f;
    public float maxLimitX =  50f;
    public float minLimitY =   0f;
    public float maxLimitY =  20f;
    public float minLimitZ = -20f;
    public float maxLimitZ =  20f;
    
    [Header("Suavização")]
    public float smoothSpeed = 5f;

    [Header("Zoom Dinâmico")]
    public float minZoomDistance = 10f;
    public float maxZoomDistance = 30f;
    public float zoomFactorZ = 0.2f;
    public float zoomFactorY = 0.1f;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Character").Select(chara => chara.transform).ToList();
    }

    void LateUpdate()
    {
        if (players == null || players.Count == 0)
            return;

        if (players.Count == 1)
        {
            Vector3 targetPos = players[0].position + baseOffset;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);
        }
        else
        {
            float minX = players.Min(p => p.position.x);
            float maxX = players.Max(p => p.position.x);
            float minY = players.Min(p => p.position.y);
            float maxY = players.Max(p => p.position.y);
            float minZ = players.Min(p => p.position.z);
            float maxZ = players.Max(p => p.position.z);

            float midX = (minX + maxX) / 2f;
            float midY = (minY + maxY) / 2f;
            float midZ = (minZ + maxZ) / 2f;
            
            float distX = maxX - minX;
            float distY = maxY - minY;
            float distZ = maxZ - minZ;
            
            float distance = Mathf.Clamp(Mathf.Max(distX, distY, distZ), minZoomDistance, maxZoomDistance);

            Vector3 targetPos = new Vector3(
                midX, 
                baseOffset.y + (distance * zoomFactorY) + midY, 
                baseOffset.z - (distance * zoomFactorZ) + midZ
            );

            if (useLimits)
            {
                targetPos.x = Mathf.Clamp(targetPos.x, minLimitX, maxLimitX);
                targetPos.y = Mathf.Clamp(targetPos.y, minLimitY, maxLimitY);
                targetPos.z = Mathf.Clamp(targetPos.z, minLimitZ, maxLimitZ);
            }

            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);
        }

        transform.rotation = Quaternion.Euler(baseRotation);
    }
}
