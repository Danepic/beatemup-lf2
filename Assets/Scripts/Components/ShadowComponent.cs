using UnityEngine;

public class ShadowComponent : MonoBehaviour
{
    public SpriteRenderer shadowSpriteRenderer;
    public GameObject character;
    private SpriteRenderer charSpriteRenderer;
    private LayerMask whatIsGround;
    public float shadowOffsetY = 0.1f;
    private Vector3 shadowFixedPosition;


    void Start()
    {
        whatIsGround = LayerMask.GetMask("Ground");
        charSpriteRenderer = character.GetComponent<SpriteRenderer>();
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
