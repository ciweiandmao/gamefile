using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMake : MonoBehaviour
{
    public GameObject[] enemies = new GameObject[6];// 敌人的预制体
    public static float Rate = 1f; // 初始 Rate 值
    private int choose;


    void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    IEnumerator GenerateEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(10 / Rate); // 等待一定时间间隔
            if (Controller.IsStart)
            {
               

                // 生成随机 x 坐标
                float randomX = Random.Range(-100f, 180f);
                Vector3 spawnPosition = new Vector3(randomX, 5f, 11f);

                choose = Random.Range(0, 6);

                // 生成敌人
                Instantiate(enemies[choose], spawnPosition, Quaternion.identity);

                // 更新 T 的值
                Rate += 0.1f;

                Movement.SkillDistance = 50f - (30f - 30f / Rate);
            }
        }
    }
}
