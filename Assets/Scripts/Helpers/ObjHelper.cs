using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Domains;
using Enums;
using UnityEngine;

namespace Helpers {
    [System.Serializable]
    public class ObjHelper {
        public ObjTypeEnum type;

        public HeaderHelper header;

        public StatsHelper stats;

        public Dictionary<int, Sprite> sprites;

        public Dictionary<int, FrameEntity> frames;

        public Dictionary<int, Queue<ObjProcess>> opoints;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}