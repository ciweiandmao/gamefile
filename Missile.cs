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
        // ��ȡ����ĳ�����Ϊ�ӵ��ĳ�ʼ����
        initialDirection = transform.forward;

        // �����ӵ��ĳ�ʼ����
        transform.forward = initialDirection;


    }

    // Update is called once per frame
    void Update()
    {
        // �ӵ����ƶ��������ʼ����һ��
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

            // Ѱ������ĵ���
            foreach (Enemy enemy in Life.AllEnemy)
            {
                float distance = enemy.distance;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    targetEnemy = enemy.transform;
                }
            }

            // ���ӵ�ˮƽ������ת��������ĵ���
            if (targetEnemy != null)
            {
                Vector3 targetDirection = targetEnemy.position - transform.position;
                targetDirection.y = 0f; // ��y����Ϊ0������ˮƽ����

                // ʹ��RotateTowardsȷ����ת�ٶȲ�����ÿ��180��
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
