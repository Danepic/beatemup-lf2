using Enums;
using Helpers;
using UnityEngine;
using System;
using System.Collections.Generic;
using Domains;
using System.Linq;
using AYellowpaper.SerializedCollections;

namespace Utils
{
    public class FrameLoadUtil
    {

        public static SerializedDictionary<int, FrameEntity> Exec(string textFileWithoutBmp)
        {
            bool bdyScope = false;
            bool itrScope = false;
            bool opointScope = false;

            SerializedDictionary<int, FrameEntity> result = new();
            FrameEntity currentFrameToMap = null;

            foreach (string line in textFileWithoutBmp.Split("\n"))
            {
                string trimLine = line.Trim();

                if (trimLine.StartsWith("<frame>"))
                {
                    currentFrameToMap = new();

                    var id_name = trimLine.Split(DatFileLoadUtil.SPLIT_PATTERN_FOR_FRAME, StringSplitOptions.RemoveEmptyEntries);

                    currentFrameToMap.id = int.Parse(id_name[1]);
                    currentFrameToMap.name = id_name[2];

                    continue;
                }

                if (trimLine.StartsWith("pic"))
                {
                    var picLineValues = trimLine.Split(DatFileLoadUtil.SPLIT_PATTERN_FOR_VALUE_FRAME.Concat(DatFileLoadUtil.SPLIT_PATTERN_FOR_FRAME).ToArray(), StringSplitOptions.RemoveEmptyEntries);

                    currentFrameToMap.properties = new();

                    for (int currentPicLine = 0; currentPicLine < picLineValues.Length; currentPicLine++)
                    {
                        var trimValue = picLineValues[currentPicLine].Trim();

                        if (trimValue.StartsWith("pic"))
                        {
                            currentFrameToMap.properties.pic = int.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("state"))
                        {
                            currentFrameToMap.properties.state = (StateFrameEnum)int.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("wait"))
                        {
                            currentFrameToMap.properties.wait = float.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("next"))
                        {
                            currentFrameToMap.properties.next = int.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("delete"))
                        {
                            currentFrameToMap.properties.delete = bool.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("dvx"))
                        {
                            currentFrameToMap.properties.dvx = float.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("dvy"))
                        {
                            currentFrameToMap.properties.dvy = float.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("dvz"))
                        {
                            currentFrameToMap.properties.dvz = float.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("hitTaunt"))
                        {
                            currentFrameToMap.properties.hitTaunt = int.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("hitJump"))
                        {
                            currentFrameToMap.properties.hitJump = int.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("hitDefense"))
                        {
                            currentFrameToMap.properties.hitDefense = int.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("hitAttack"))
                        {
                            currentFrameToMap.properties.hitAttack = int.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("holdDefenseAfter"))
                        {
                            currentFrameToMap.properties.holdDefenseAfter = int.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("hitGround"))
                        {
                            currentFrameToMap.properties.hitGround = int.Parse(picLineValues[currentPicLine + 1]);
                        }
                        if (trimValue.StartsWith("hitAir"))
                        {
                            currentFrameToMap.properties.hitAir = int.Parse(picLineValues[currentPicLine + 1]);
                        }
                    }

                    continue;
                }

                if (trimLine.StartsWith("bdy") && !trimLine.StartsWith("bdy_end"))
                {
                    bdyScope = true;
                    continue;
                }

                if (bdyScope)
                {
                    bdyScope = false;
                    currentFrameToMap.bdy = new();
                    var bdyLineValues = trimLine.Split(DatFileLoadUtil.SPLIT_PATTERN_FOR_VALUE_FRAME.Concat(DatFileLoadUtil.SPLIT_PATTERN_FOR_FRAME).ToArray(), StringSplitOptions.RemoveEmptyEntries);

                    for (int currentBdyValue = 0; currentBdyValue < bdyLineValues.Length; currentBdyValue++)
                    {
                        var trimValue = bdyLineValues[currentBdyValue].Trim();
                        if (trimValue.StartsWith("default"))
                        {
                            currentFrameToMap.bdy.defaultBdy = bool.Parse(bdyLineValues[currentBdyValue + 1]);
                        }
                        if (trimValue.StartsWith("kind"))
                        {
                            currentFrameToMap.bdy.kind = (BdyKindEnum)int.Parse(bdyLineValues[currentBdyValue + 1]);
                        }
                        if (trimValue.StartsWith("x"))
                        {
                            currentFrameToMap.bdy.x = float.Parse(bdyLineValues[currentBdyValue + 1]);
                        }
                        if (trimValue.StartsWith("y"))
                        {
                            currentFrameToMap.bdy.y = float.Parse(bdyLineValues[currentBdyValue + 1]);
                        }
                        if (trimValue.StartsWith("z") && !trimValue.StartsWith("zwidth"))
                        {
                            currentFrameToMap.bdy.z = float.Parse(bdyLineValues[currentBdyValue + 1]);
                        }
                        if (trimValue.StartsWith("w"))
                        {
                            currentFrameToMap.bdy.w = float.Parse(bdyLineValues[currentBdyValue + 1]);
                        }
                        if (trimValue.StartsWith("h"))
                        {
                            currentFrameToMap.bdy.h = float.Parse(bdyLineValues[currentBdyValue + 1]);
                        }
                        if (trimValue.StartsWith("zwidth"))
                        {
                            currentFrameToMap.bdy.zwidth = float.Parse(bdyLineValues[currentBdyValue + 1]);
                        }
                    }

                    continue;
                }

                if (trimLine.StartsWith("bdy_end"))
                {
                    bdyScope = false;
                    continue;
                }

                if (trimLine.StartsWith("opoint") && !trimLine.StartsWith("opoint_end"))
                {
                    opointScope = true;
                    continue;
                }

                if (opointScope)
                {
                    opointScope = false;
                    currentFrameToMap.opoint = new();
                    var opointLineValues = trimLine.Split(DatFileLoadUtil.SPLIT_PATTERN_FOR_VALUE_FRAME.Concat(DatFileLoadUtil.SPLIT_PATTERN_FOR_FRAME).ToArray(), StringSplitOptions.RemoveEmptyEntries);

                    for (int currentOpointValue = 0; currentOpointValue < opointLineValues.Length; currentOpointValue++)
                    {
                        var trimValue = opointLineValues[currentOpointValue].Trim();
                        if (trimValue.StartsWith("x"))
                        {
                            currentFrameToMap.opoint.x = float.Parse(opointLineValues[currentOpointValue + 1]);
                        }
                        if (trimValue.StartsWith("y"))
                        {
                            currentFrameToMap.opoint.y = float.Parse(opointLineValues[currentOpointValue + 1]);
                        }
                        if (trimValue.StartsWith("z") && !trimValue.StartsWith("zwidth"))
                        {
                            currentFrameToMap.opoint.z = float.Parse(opointLineValues[currentOpointValue + 1]);
                        }
                        if (trimValue.StartsWith("action"))
                        {
                            currentFrameToMap.opoint.action = int.Parse(opointLineValues[currentOpointValue + 1]);
                        }
                        if (trimValue.StartsWith("oid"))
                        {
                            currentFrameToMap.opoint.oid = int.Parse(opointLineValues[currentOpointValue + 1]);
                        }
                        if (trimValue.StartsWith("facingFront"))
                        {
                            currentFrameToMap.opoint.facingFront = bool.Parse(opointLineValues[currentOpointValue + 1]);
                        }
                        if (trimValue.StartsWith("quantity"))
                        {
                            currentFrameToMap.opoint.quantity = int.Parse(opointLineValues[currentOpointValue + 1]);
                        }
                        if (trimValue.StartsWith("poolQuantity"))
                        {
                            currentFrameToMap.opoint.poolQuantity = int.Parse(opointLineValues[currentOpointValue + 1]);
                        }
                    }

                    continue;
                }

                if (trimLine.StartsWith("opoint_end"))
                {
                    opointScope = false;
                    continue;
                }

                if (trimLine.StartsWith("itr") && !trimLine.StartsWith("itr_end"))
                {
                    itrScope = true;
                    continue;
                }

                if (itrScope)
                {
                    itrScope = false;
                    currentFrameToMap.itr = new();
                    var itrLineValues = trimLine.Split(DatFileLoadUtil.SPLIT_PATTERN_FOR_VALUE_FRAME.Concat(DatFileLoadUtil.SPLIT_PATTERN_FOR_FRAME).ToArray(), StringSplitOptions.RemoveEmptyEntries);

                    for (int currentItrValue = 0; currentItrValue < itrLineValues.Length; currentItrValue++)
                    {
                        var trimValue = itrLineValues[currentItrValue].Trim();
                        if (trimValue.StartsWith("default"))
                        {
                            currentFrameToMap.itr.defaultItr = bool.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("kind"))
                        {
                            currentFrameToMap.itr.kind = (ItrKindEnum)int.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("x"))
                        {
                            currentFrameToMap.itr.x = float.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("y"))
                        {
                            currentFrameToMap.itr.y = float.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("z") && !trimValue.StartsWith("zwidth"))
                        {
                            currentFrameToMap.itr.z = float.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("w"))
                        {
                            currentFrameToMap.itr.w = float.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("h"))
                        {
                            currentFrameToMap.itr.h = float.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("zwidth"))
                        {
                            currentFrameToMap.itr.zwidth = float.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("dvx"))
                        {
                            currentFrameToMap.itr.dvx = float.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("dvy"))
                        {
                            currentFrameToMap.itr.dvy = float.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("dvz") && !trimValue.StartsWith("zwidth"))
                        {
                            currentFrameToMap.itr.dvz = float.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("rest"))
                        {
                            currentFrameToMap.itr.rest = float.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("applyInSingleEnemy"))
                        {
                            currentFrameToMap.itr.applyInSingleEnemy = bool.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("action"))
                        {
                            currentFrameToMap.itr.action = int.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("defensable"))
                        {
                            currentFrameToMap.itr.defensable = bool.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("injury"))
                        {
                            currentFrameToMap.itr.injury = int.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("nextIfHit"))
                        {
                            currentFrameToMap.itr.nextIfHit = int.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("level"))
                        {
                            currentFrameToMap.itr.level = int.Parse(itrLineValues[currentItrValue + 1]);
                        }
                        if (trimValue.StartsWith("effect"))
                        {
                            currentFrameToMap.itr.effect = (ItrEffectEnum)int.Parse(itrLineValues[currentItrValue + 1]);
                        }
                    }

                    continue;
                }

                if (trimLine.StartsWith("itr_end"))
                {
                    itrScope = false;
                    continue;
                }

                if (trimLine.StartsWith("<frame_end>") && currentFrameToMap != null)
                {
                    result.Add(currentFrameToMap.id, currentFrameToMap);
                }
            }

            return result;
        }
    }
}