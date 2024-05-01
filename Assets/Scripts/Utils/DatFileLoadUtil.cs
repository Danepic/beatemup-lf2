using Enums;
using Helpers;
using UnityEngine;
using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using System.Linq;
using Domains;

namespace Utils
{
    public class DatFileLoadUtil
    {
        public static readonly string BMP_TAG_BEGIN = "<bmp_begin>";
        public static readonly string BMP_TAG_END = "<bmp_end>";

        public static readonly string[] SPLIT_PATTERN_FOR_FRAME = { " ", "  ", "   ", "    " };
        public static readonly string[] SPLIT_PATTERN_FOR_VALUE_FRAME = { ": ", ":  ", ":   ", ":    " };

        public static ObjHelper Exec(TextAsset datFile, List<GameObject> opointsToPool)
        {
            var textFile = datFile.text;
            var bmpSplit = textFile.Split(BMP_TAG_BEGIN)[1].Split(BMP_TAG_END);
            var bmpContent = bmpSplit[0];
            var textFileWithoutBmp = bmpSplit[1];

            return new ObjHelper()
            {
                type = GetType(bmpContent),
                sprites = GetSprites(bmpContent),
                header = GetHeader(bmpContent),
                frames = FrameLoadUtil.Exec(textFileWithoutBmp)
                // stats = GetStatsFromDataFile.Apply(dataFileAccess)
            };
        }

        private static ObjTypeEnum GetType(string bmpContent)
        {
            foreach (string line in bmpContent.Split("\n"))
            {
                string trimLine = line.Trim();
                if (trimLine.StartsWith("type"))
                {
                    string type = GetValue(trimLine, "type");
                    if (type != null)
                        return Enum.Parse<ObjTypeEnum>(type);
                }

            }

            throw new Exception("Type not found for Object Entity!");
        }

        private static string GetValue(string line, string keyLine)
        {
            return line.Replace(keyLine + ":", "").Split(" ")[1];
        }

        private static SerializedDictionary<int, Sprite> GetSprites(string bmpContent)
        {
            var result = new SerializedDictionary<int, Sprite>();

            foreach (string line in bmpContent.Split("\n"))
            {
                string trimLine = line.Trim();
                if (trimLine.StartsWith("file"))
                {
                    string spritePath = trimLine.Split(": ")[1];
                    Sprite[] sprites = Resources.LoadAll<Sprite>(spritePath);
                    foreach (Sprite sprite in sprites)
                    {
                        string[] nameValues = sprite.name.Split("_");

                        int spriteNumber = int.Parse(nameValues[nameValues.Length - 1]);
                        int keyValue = int.Parse(nameValues[nameValues.Length - 2]) * 100;

                        result.Add(keyValue + spriteNumber, sprite);
                    }
                }
            }

            return result;
        }

        private static HeaderHelper GetHeader(string bmpContent)
        {
            var result = new HeaderHelper();

            foreach (string line in bmpContent.Split("\n"))
            {
                string trimLine = line.Trim();
                if (trimLine.StartsWith("start_hp"))
                {
                    result.startHp = int.Parse(trimLine.Split(": ")[1]);
                }
                if (trimLine.StartsWith("start_mp"))
                {
                    result.startMp = int.Parse(trimLine.Split(": ")[1]);
                }
                if (trimLine.StartsWith("name"))
                {
                    result.name = trimLine.Split(": ")[1];
                }
            }

            return result;
        }

        public static Dictionary<int, Queue<ObjProcess>> EnrichOpoints(
            Dictionary<int, FrameEntity> frames,
            List<GameObject> opointsToPool,
            int ownerId,
            TeamEnum ownerTeam
        )
        {
            Dictionary<int, Queue<ObjProcess>> result = new();

            IEnumerable<KeyValuePair<int, FrameEntity>> framesWithOpoint = frames.Where(currentFrame => currentFrame.Value.opoint != null);

            foreach (KeyValuePair<int, FrameEntity> frame in framesWithOpoint)
            {
                var frameId = frame.Value.id;
                var poolObjectsQuantity = frame.Value.opoint.poolQuantity * frame.Value.opoint.quantity;

                Queue<ObjProcess> framePoolObjects = new();

                var gameObjectToPool = opointsToPool[frame.Value.opoint.oid];

                for (int currentPool = 0; currentPool < poolObjectsQuantity; currentPool++)
                {
                    var gameObjectToPoolInstantiate = GameObject.Instantiate<GameObject>(gameObjectToPool);
                    OpointEntity opointData = frame.Value.opoint;
                    
                    ObjProcess opointObjProcess = gameObjectToPoolInstantiate.GetComponent<ObjProcess>();
                    opointObjProcess.dataHelper.originLocalPosition = new Vector3(opointData.x, opointData.y, opointData.z);
                    opointObjProcess.dataHelper.ownerId = ownerId;
                    opointObjProcess.dataHelper.originPool = framePoolObjects;
                    opointObjProcess.dataHelper.team = ownerTeam;
                    gameObjectToPoolInstantiate.SetActive(false);

                    framePoolObjects.Enqueue(opointObjProcess);
                }

                result.Add(frameId, framePoolObjects);
                Debug.Log($"Queue opoint {gameObjectToPool.name} in frame {frame.Key} with pool size of {framePoolObjects.Count()}");
            }
            return result;
        }
    }
}