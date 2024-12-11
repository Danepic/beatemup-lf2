using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enums;
using UnityEngine;

namespace Chars
{
    [Serializable]
    public class StatsChar
    {
        public int aggressive;

        public int technique;

        public int intelligent;

        public int speed;

        public int resistance;

        public int stamina;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}