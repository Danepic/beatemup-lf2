using UnityEngine;
using UnityEngine.UI;

public class BarsController : MonoBehaviour
{
    public CharController target; 
    public Transform hpImage;
    public Transform hpMask;
    public Transform mpImage;
    public Transform mpMask;
    
    private float _hpFillMaxLimit;
    private float _mpFillMaxLimit;

    void Awake()
    {
        _hpFillMaxLimit = hpImage.localScale.x;
        _mpFillMaxLimit = mpImage.localScale.x;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (target.facingRight)
        {
            transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);
        }
        
        float hpPercentage = Mathf.Clamp01((float)target.currentHp / target.totalHp);
        float mpPercentage = Mathf.Clamp01((float)target.currentMp / target.totalMp);

        hpImage.localScale = new Vector3(_hpFillMaxLimit * hpPercentage, hpImage.localScale.y, hpImage.localScale.z);
        mpImage.localScale = new Vector3(_mpFillMaxLimit * mpPercentage, mpImage.localScale.y, mpImage.localScale.z);

        hpMask.localScale = hpImage.localScale;
        mpMask.localScale = mpImage.localScale;
    }
}
