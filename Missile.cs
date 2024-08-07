using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float shotSpeed;
    public int damage;
    private Vector3 initialDirection;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        // 获取人物的朝向作为子弹的初始方向
        initialDirection = transform.forward;

        // 设置子弹的初始朝向
        transform.forward = initialDirection;


    }

    // Update is called once per frame
    void Update()
    {
        // 子弹的移动方向与初始方向一致
        transform.position += transform.forward * shotSpeed * Time.deltaTime;
        FindAndSetTargetDirection();


        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        distance = Vector3.Distance(transform.position, players[0].transform.position);
        if (distance > 200) { Destroy(gameObject); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }



    void FindAndSetTargetDirection()
    {
        if (Life.AllEnemy.Count > 0)
        {
            float minDistance = float.MaxValue;
            Transform targetEnemy = null;

            // 寻找最近的敌人
            foreach (Enemy enemy in Life.AllEnemy)
            {
                float distance = enemy.distance;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    targetEnemy = enemy.transform;
                }
            }

            // 将子弹水平方向旋转朝向最近的敌人
            if (targetEnemy != null)
            {
                Vector3 targetDirection = targetEnemy.position - transform.position;
                targetDirection.y = 0f; // 将y轴设为0，保持水平方向

                // 使用RotateTowards确保旋转速度不超过每秒180度
                Quaternion targetRotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(targetDirection),
                    360f * Time.deltaTime
                );

                transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
            }
        }
    }
}
