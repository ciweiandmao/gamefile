using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMake : MonoBehaviour
{
    public GameObject[] enemies = new GameObject[6];// ���˵�Ԥ����
    public static float Rate = 1f; // ��ʼ Rate ֵ
    private int choose;


    void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    IEnumerator GenerateEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(10 / Rate); // �ȴ�һ��ʱ����
            if (Controller.IsStart)
            {
               

                // ������� x ����
                float randomX = Random.Range(-100f, 180f);
                Vector3 spawnPosition = new Vector3(randomX, 5f, 11f);

                choose = Random.Range(0, 6);

                // ���ɵ���
                Instantiate(enemies[choose], spawnPosition, Quaternion.identity);

                // ���� T ��ֵ
                Rate += 0.1f;

                Movement.SkillDistance = 50f - (30f - 30f / Rate);
            }
        }
    }
}
