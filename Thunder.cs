using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour

{
    // 是否正在进行打雷效果
    private bool isLightning = false;
    public float lightningDuration = 0.2f;
    private float lastLightningTime;
    public float lightningInterval = 0.02f;
    

    // Update is called once per frame
    void Update()
    {
        
        
        // 计算距离上次打雷的时间
        float timeSinceLastLightning = Time.time - lastLightningTime;

        // 如果不在打雷中且距离上次打雷的时间超过间隔时间
        if (!isLightning && timeSinceLastLightning >= lightningInterval)
        {
            int randomValue = Random.Range(1, 200);
            lastLightningTime = Time.time;

            // 判断是否取到 1，如果是则执行打雷效果
            if (randomValue == 1)
            {
                isLightning = true;
                
                GetComponent<Light>().intensity = 1f;
            }
        }
        if (isLightning) { 
            GetComponent<Light>().intensity -= 0.02f;
            if(GetComponent<Light>().intensity<=0f)
            {
                isLightning = false;
            }
        }
    }

   
}
