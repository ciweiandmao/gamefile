using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shotSpeed;
    public int damage;
    private Vector3 initialDirection;
    public bool NearBullet;
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
        transform.position += initialDirection * shotSpeed * Time.deltaTime;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        distance = Vector3.Distance(transform.position, players[0].transform.position);
        if (distance > 200) { Destroy(gameObject); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            if (!NearBullet)
            {
                Destroy(gameObject);
            }
        }
    }

    
}
