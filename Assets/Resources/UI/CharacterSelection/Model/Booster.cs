using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Model
{
    [System.Serializable]
    public class Booster
    {
        public string id;
        public string name;
        public int cardCount;
        public string boosterMugshotResourcePath;
        public DateTime createdAt;
        public DateTime updatedAt;
        public int number;

        public Booster(string id, string name, int cardCount, string resourcePath, DateTime createdAt, DateTime updatedAt, int number)
        {
            this.id = id;
            this.name = name;
            this.cardCount = cardCount;
            this.boosterMugshotResourcePath = resourcePath;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
            this.number = number;
        }

        public Sprite GetSprite()
        {
            return Resources.Load<Sprite>(boosterMugshotResourcePath);
        }
    }
}