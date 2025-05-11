using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    public Vector3 direction;
    public float maxDistance;
    public LayerMask whatIsGround;
    public SpriteRenderer spriteRenderer;

    void Start()
    {

    }

    void Update()
    {
    }

    // void OnDrawGizmos()
    // {
    //     RaycastHit raycastHit;
    //
    //     bool isHit;
    //     // isHit = Physics.BoxCast(transform.position, transform.localScale * 0.5f, direction, out raycastHit, transform.rotation, maxDistance);
    //     // if (isHit)
    //     // {
    //     //     Gizmos.color = Color.red;
    //     //     Gizmos.DrawWireCube(transform.position + (direction * 0.5f), new Vector3(spriteRenderer.sprite.bounds.size.x, spriteRenderer.sprite.bounds.size.y, 0.22f));
    //     // }
    //     // else
    //     // {
    //     //     Gizmos.color = Color.blue;
    //     //     Gizmos.DrawWireCube(transform.position + (direction * 0.5f), new Vector3(spriteRenderer.sprite.bounds.size.x, spriteRenderer.sprite.bounds.size.y, 0.22f));
    //     // }
    //
    //     Collider[] hitColliders = Physics.OverlapBox(transform.position, new Vector3(spriteRenderer.sprite.bounds.size.x, 0.22f, 0.22f) / 2, Quaternion.identity, whatIsGround);
    //
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawWireCube(transform.position, new Vector3(spriteRenderer.sprite.bounds.size.x, 0.22f, 0.22f));
    //
    //     if (hitColliders.Length > 0)
    //     {
    //         //Output all of the collider names
    //         Debug.Log("Hit : " + hitColliders[0]);
    //         isHit = true;
    //     }
    //     else
    //     {
    //         isHit = false;
    //     }
    //     Debug.Log(isHit);
    // }
    
    
    
    private void OnDrawGizmos()
    {
        var col = GetComponent<BoxCollider>();
        if (col != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(col.center, col.size);
        }
    }
}
