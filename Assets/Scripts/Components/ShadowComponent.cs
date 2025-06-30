using System;
using UnityEngine;

public class ShadowComponent : MonoBehaviour
{
    public SpriteRenderer shadowSpriteRenderer;
    public GameObject character;
    public SpriteRenderer charSpriteRenderer;
    public ObjController charObjeController;
    public LayerMask whatIsGround;
    public float shadowOffsetY = 0.1f;
    private Vector3 shadowFixedPosition;


    private void Awake()
    {
        whatIsGround = LayerMask.GetMask("Ground");
    }

    public void Start()
    {
        if (charObjeController.usedRotationZ != 0)
        {
            Debug.Log(transform.rotation.z);
            transform.Rotate(0f,0f, -charObjeController.usedRotationZ);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
    void Update()
    {
        shadowSpriteRenderer.sprite = charSpriteRenderer.sprite;
        shadowFixedPosition = new Vector3(character.transform.position.x, character.transform.position.y + shadowOffsetY, character.transform.position.z);

        RaycastHit hit;
        if (Physics.Raycast(shadowFixedPosition, Vector3.down, out hit, Mathf.Infinity, whatIsGround))
        {
            transform.position = new Vector3(character.transform.position.x, hit.point.y, character.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(character.transform.position.x, character.transform.position.y, character.transform.position.z);
        }
    }
}
