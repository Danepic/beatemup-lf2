using UnityEngine;

namespace Resources.Backgrounds
{
    public class StageLimitsComponent : MonoBehaviour
    {
        public bool useLimits;
        public float minLimitX;
        public float maxLimitX;
        public float minLimitY;
        public float maxLimitY;
        public float minLimitZ;
        public float maxLimitZ;

        public BoxCollider groundCollider;
        
        void Awake()
        {
            Vector3 worldCenter = transform.TransformPoint(groundCollider.center);
            Vector3 worldSize = Vector3.Scale(groundCollider.size, transform.lossyScale) * 0.5f;

            minLimitX = worldCenter.x - worldSize.x;
            maxLimitX = worldCenter.x + worldSize.x;
            minLimitY = worldCenter.y - worldSize.y;
            maxLimitY = worldCenter.y + worldSize.y;
            minLimitZ = worldCenter.z - worldSize.z;
            maxLimitZ = worldCenter.z + worldSize.z;
        }
    }
}
