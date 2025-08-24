using TMPro;
using UnityEngine;

public class DamageCounterController : MonoBehaviour
{
    public TextMeshPro value;
    public float duration = 1.5f;
    
    private float _timer;
    private bool _isActive;
    private Color _color;
    
    void Awake()
    {
        value.text = "0";
        _color = value.color;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive) return;

        _timer += Time.deltaTime;
        
        float progress = _timer / duration;
        float alpha = Mathf.Lerp(1f, 0f, progress);

        value.color = new Color(_color.r, _color.g, _color.b, alpha);

        if (_timer >= duration)
        {
            gameObject.SetActive(false);
            _timer = 0f;
            _isActive = false;
            value.color = _color;
        }
    }

    public void Spawn(int injuryDamage, Vector3 ownerPosition, Vector3 contactPoint, bool ownerFacingRight)
    {
        value.text = injuryDamage.ToString();
        
        var xPos = ownerPosition.x + contactPoint.x;
        var yPos = ownerPosition.y + contactPoint.y + 0.5f;
        var zPos = ownerPosition.z + contactPoint.z;

        transform.position = new Vector3(xPos, yPos, zPos);
        
        float baseScaleX = Mathf.Abs(transform.localScale.x);
        transform.localScale = new Vector3(baseScaleX, transform.localScale.y, transform.localScale.z);

        gameObject.transform.parent = null;
        gameObject.SetActive(true);
        _timer = 0f;
        _isActive = true;
    }
}
