using Enums;
using UnityEngine;
using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using System.Linq;
using Domains;
using System.Reflection;

public class ObjController : MonoBehaviour
{
    protected ObjTypeEnum type;
    public int id;
    public int? ownerId;
    public ObjController owner;
    public GroundEnum stage;
    public List<ObjController> cancellableOpoints = new();
    protected float waitFrame;
    protected Vector3 originalLocalScale;
    public Color originalColor;
    protected SpriteRenderer spriteRenderer;
    public TeamEnum team;
    public bool facingRight = true;
    public int pic;
    public StateFrameEnum state;
    protected float wait;
    public int repeatCount;
    public int currentRepeat;
    protected Action next;

    protected List<string> palettes = new();

    public int paletteIndex = 0;
    public float zSizeDefault = 0.22f;
    public SerializedDictionary<int, Sprite> sprites = new();
    protected Sprite inv;
    public MethodInfo currentFrame;
    public int currentFrameId;

    protected float dvx;

    protected float dvy;

    protected float dvz;
    public MethodInfo summonAction;
    public bool enableNextIfHit;
    protected ObjController targetHit = null;
    protected Vector3 originLocalPosition;
    protected Dictionary<int, Queue<ObjController>> opoints = new();
    protected Queue<ObjController> originPool = new();
    public int hitNormalFrame;
    public int hitBloodFrame;
    public int defenseHitFrame;
    protected bool execOpointOnceInFrame = true;
    protected bool execPhysicsOnceInFrame = true;
    public Dictionary<int, MethodInfo> frames = new();
    protected bool actionTriggered = false;
    public int startFrame = 0;
    private float shortestDistance = Mathf.Infinity;
    protected bool attachToOwner = false;

    protected void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        id = gameObject.GetInstanceID();
        GetSprites();
        originalLocalScale = transform.localScale;
        originalColor = spriteRenderer.color;
        originLocalPosition = transform.position;
        inv = Resources.Load<Sprite>("Etc/inv");
    }

    public void Start()
    {
        if (summonAction != null)
        {
            this.ChangeFrame(summonAction);
        }
        waitFrame = 0f;
        Facing();
    }

    public void Update()
    {
        currentFrame.Invoke(this, null);
        spriteRenderer.sprite = sprites.GetValueOrDefault(pic, inv);
    }

    protected void ChangeFrame(MethodInfo nextFrame)
    {
        if (actionTriggered)
        {
            actionTriggered = false;
        }
        currentFrame = nextFrame;
        currentFrameId = frames.FirstOrDefault(x => x.Value == currentFrame).Key;
        execOpointOnceInFrame = true;
        execPhysicsOnceInFrame = true;
        waitFrame = 0f;
        dvx = 0; dvy = 0; dvz = 0;
    }

    protected void ChangeFrame(Action nextFrame)
    {
        ChangeFrame(nextFrame.Method);
    }

    public void ChangeFrame(int? nextFrame)
    {
        if (nextFrame.HasValue)
        {
            ChangeFrame(frames[nextFrame.Value]);
        }
    }

    protected void Timers()
    {
        waitFrame += Time.deltaTime % 60;
        if (!actionTriggered && waitFrame >= wait / 30)
        {
            ChangeFrame(next);
        }
    }

    protected void RepeatCountToFrame(Action action)
    {
        if (currentRepeat >= repeatCount)
        {
            currentRepeat = 0;
            repeatCount = 0;
            ChangeFrame(action);
        }
        else
        {
            currentRepeat++;
        }
    }

    protected void GetSprites()
    {
        Sprite[] spritesLocal = Resources.LoadAll<Sprite>(palettes[paletteIndex].Trim());
        foreach (Sprite spriteLocal in spritesLocal)
        {
            string[] nameValues = spriteLocal.name.Split("_");
            int spriteNumber = int.Parse(nameValues[nameValues.Length - 1]);
            int keyValue = int.Parse(nameValues[nameValues.Length - 2]) * 100;
            sprites.Add(keyValue + spriteNumber, spriteLocal);
        }
    }

    protected void Facing()
    {
        if (!facingRight)
        {
            transform.localScale = new Vector3(-MathF.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            facingRight = false;
        }
        else
        {
            transform.localScale = new Vector3(MathF.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            facingRight = true;
        }
    }

    protected void IfHit(Action action)
    {
        if (enableNextIfHit)
        {
            this.ChangeFrame(action);
        }
    }

    protected OpointEntity Opoint(float x, float y, float z, int oid, bool facingFront, int quantity, bool useSamePalette = false, bool cancellable = false, bool attachToOwner = false, bool useParentOwner = false)
    {
        return new()
        {
            x = x,
            y = y,
            z = z,
            facingFront = facingFront,
            quantity = quantity,
            useSamePalette = useSamePalette,
            oid = oid,
            cancellable = cancellable,
            attachToOwner = attachToOwner,
            useParentOwner = useParentOwner
        };
    }

    protected List<ObjController> SpawnOpoint(int index, OpointEntity opoint, List<ObjController> opointsControl = null)
    {
        if (opointsControl != null && opointsControl.Count > 0) {
            return opointsControl;
        }
        
        List<ObjController> result = new();
        if (execOpointOnceInFrame && opoints[index].Count > 0)
        {
            execOpointOnceInFrame = false;
            ObjController opointScript = opoints[index].Dequeue();
            opointScript.team = team;

            opointScript.facingRight = facingRight && opoint.facingFront;
            Debug.Log("AA:" + opointScript.facingRight);

            if (opoint.useSamePalette)
            {
                opointScript.paletteIndex = paletteIndex;
            }

            var yPos = transform.position.y + opoint.y;
            var zPos = transform.position.z + opoint.z;

            float xPos;
            if (facingRight)
            {
                xPos = transform.position.x + opoint.x;
            }
            else
            {
                xPos = transform.position.x - opoint.x;
            }

            opointScript.transform.position = new Vector3(xPos, yPos, zPos);
            if (opoint.attachToOwner)
            {
                opointScript.transform.parent = transform;
                opointScript.facingRight = true; //Quando é um child quem determina o lado é o Owner, e o facingRight true sempre mantém pro lado do owner
                opointScript.attachToOwner = opoint.attachToOwner;
            }
            else
            {
                opointScript.transform.parent = null;
                opointScript.facingRight = facingRight && opoint.facingFront;
            }

            opointScript.gameObject.SetActive(true);
            for (int i = 0; i < opointScript.gameObject.transform.childCount; i++)
            {
                var childGameObj = opointScript.gameObject.transform.GetChild(i).gameObject;
                if (!childGameObj.TryGetComponent<ObjController>(out _))
                {
                    childGameObj.SetActive(true);
                }
                var hitbox = opointScript.gameObject.transform.Find("Hitbox");
                if (hitbox != null)
                {
                    hitbox.gameObject.SetActive(false);
                }
            }

            opointScript.spriteRenderer.color = new Color(1, 1, 1, 0f);
            opointScript.summonAction = opointScript.frames[opoint.oid];

            if (opoint.cancellable)
            {
                cancellableOpoints.Add(opointScript);
            }

            if (opoint.useParentOwner)
            {
                opointScript.owner = owner;
            }
            else
            {
                opointScript.owner = this;
            }

            opointScript.Start();
            result.Add(opointScript);
            return result;
        }
        else
        {
            return opointsControl;
        }
    }

    public void SpawnHitOpoint(Vector3 opointPosition, ItrEffectEnum effect)
    {
        switch (effect)
        {
            case ItrEffectEnum.NORMAL:
                SpawnHit(opoints[100].Dequeue(), opointPosition);
                break;
            case ItrEffectEnum.BLOOD:
                SpawnHit(opoints[101].Dequeue(), opointPosition);
                break;
            case ItrEffectEnum.DEFENSE:
                SpawnHit(opoints[102].Dequeue(), opointPosition);
                break;
            case ItrEffectEnum.SLOW:
            case ItrEffectEnum.STUN:
            case ItrEffectEnum.IGNITE:
            case ItrEffectEnum.POISON:
            case ItrEffectEnum.ROOT:
            case ItrEffectEnum.CHARM:
            case ItrEffectEnum.FEAR:
            case ItrEffectEnum.TAUNT:
            case ItrEffectEnum.BLIND:
            case ItrEffectEnum.PARALYSIS:
            case ItrEffectEnum.FREEZE:
            case ItrEffectEnum.CONFUSE:
            case ItrEffectEnum.SILENCE:
            case ItrEffectEnum.NO_EFFECT:
            default:
                break;
        }
    }

    private void SpawnHit(ObjController gameObj, Vector3 opointPosition)
    {
        gameObj.transform.position = opointPosition + new Vector3(0, 0f, -0.09f);
        gameObj.gameObject.SetActive(true);
        for (int i = 0; i < gameObj.transform.childCount; i++)
        {
            gameObj.transform.GetChild(i).gameObject.SetActive(true);
        }
        gameObj.Start();
    }

    public void CancelOpoints()
    {
        foreach (var opoint in cancellableOpoints)
        {
            opoint.Delete();
        }
        cancellableOpoints.Clear();
    }

    public void Delete()
    {
        CancelOpoints();
        spriteRenderer.color = new Color(1, 1, 1, 0f);
        spriteRenderer.sprite = inv;
        repeatCount = 0;
        currentRepeat = 0;
        transform.localScale = originalLocalScale;
        transform.position = originLocalPosition;
        spriteRenderer.color = originalColor;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        if (ownerId == null)
        {
            originPool.Enqueue(this);
            gameObject.SetActive(false);
        }
        else
        {
            transform.parent = owner.gameObject.transform;
            originPool.Enqueue(this);
            gameObject.SetActive(false);
        }
    }

    public Queue<ObjController> EnrichOpoint(int poolObjectsQuantity, string objPath)
    {
        Queue<ObjController> framePoolObjects = new();
        GameObject gameObjectToPool = Resources.Load<GameObject>(objPath);

        for (int currentPool = 0; currentPool < poolObjectsQuantity; currentPool++)
        {
            GameObject gameObjectToPoolInstantiate;
            try
            {
                gameObjectToPoolInstantiate = GameObject.Instantiate<GameObject>(gameObjectToPool);
            }
            catch (Exception e)
            {
                Debug.LogError("[EnrichOpoint] Problem to instantiate " + objPath);
                throw e;
            }

            ObjController opointObjProcess = gameObjectToPoolInstantiate.GetComponent<ObjController>();
            opointObjProcess.ownerId = ownerId ?? id;
            opointObjProcess.owner = this;
            opointObjProcess.originPool = framePoolObjects;
            opointObjProcess.team = team;
            opointObjProcess.spriteRenderer.sprite = inv;
            opointObjProcess.stage = stage;

            opointObjProcess.transform.parent = transform;

            gameObjectToPoolInstantiate.SetActive(false);

            framePoolObjects.Enqueue(opointObjProcess);
        }

        return framePoolObjects;
    }

    protected Dictionary<int, MethodInfo> PopulateFrames(object target)
    {
        var result = new Dictionary<int, MethodInfo>();
        var methods = target.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(method => method.Name.Split("_").Length == 2 && Int32.TryParse(method.Name.Split("_")[1], out _)).ToList();
        foreach (var method in methods)
        {
            var frameNameAndNumber = method.Name.Split("_");
            result.Add(Int32.Parse(frameNameAndNumber[1]), method);
        }
        return result;
    }

    protected void Fadeout(float fadeout)
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - fadeout);
    }

    protected void Fadein(float fadeout)
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a + fadeout);
    }

    protected void ScaleDown(float propScalex, float propScaley)
    {
        var scaleX = 0f;
        if (transform.localScale.x > 0)
        {
            scaleX = transform.localScale.x - propScalex;
        }
        else if (transform.localScale.x < 0)
        {
            scaleX = transform.localScale.x + propScaley;
        }

        var scaleY = transform.localScale.y <= 0 ? 0 : transform.localScale.y - propScaley;
        transform.localScale = new Vector3(scaleX, scaleY, transform.localScale.z);
    }

    protected CharController FindNearestObject(List<CharController> objects)
    {
        CharController nearestObject = null;
        foreach (var obj in objects)
        {
            if (obj == null) continue;

            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if (distance < this.shortestDistance)
            {
                shortestDistance = distance;
                nearestObject = obj;
            }
        }

        return nearestObject;
    }
}