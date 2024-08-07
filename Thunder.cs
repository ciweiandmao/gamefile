using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour

{
    // �Ƿ����ڽ��д���Ч��
    private bool isLightning = false;
    public float lightningDuration = 0.2f;
    private float lastLightningTime;
    public float lightningInterval = 0.02f;
    

    // Update is called once per frame
    void Update()
    {
        
        
        // ��������ϴδ��׵�ʱ��
        float timeSinceLastLightning = Time.time - lastLightningTime;

        // ������ڴ������Ҿ����ϴδ��׵�ʱ�䳬�����ʱ��
        if (!isLightning && timeSinceLastLightning >= lightningInterval)
        {
            int randomValue = Random.Range(1, 200);
            lastLightningTime = Time.time;

            // �ж��Ƿ�ȡ�� 1���������ִ�д���Ч��
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
