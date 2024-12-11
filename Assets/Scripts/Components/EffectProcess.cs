using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectProcess : ObjProcess
{
    // Update is called once per frame
    void Update()
    {
        this.Timers();
        this.SpawnOpoint();
        this.StateHandle();
    }

    private void StateHandle()
    {
        switch (currentFrame.properties.state)
        {
            case Enums.StateFrameEnum.FADE_OUT_SCALE_DOWN:
                var scaleX = 0f;
                if (transform.localScale.x > 0) {
                    scaleX = transform.localScale.x - currentFrame.properties.scalex.Value;
                } else if (transform.localScale.x < 0) { 
                    scaleX = transform.localScale.x + currentFrame.properties.scalex.Value;
                }

                var scaleY = transform.localScale.y <= 0 ? 0 : transform.localScale.y - currentFrame.properties.scaley.Value;

                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - currentFrame.properties.fadeout.Value);
                transform.localScale = new Vector3(scaleX, scaleY, transform.localScale.z);
                break;
        }
    }
}
