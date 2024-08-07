using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;


public class Enemy : MonoBehaviour
{
    public float EnemySpeed;
    public int damage;
    public float curentHealth;
    public int EnemyType;
    public GameObject Deatheffect;
    public GameObject target;
    public GameObject PowerPoint;
    public float distance;
    public int Die=2;
    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        curentHealth = EnemyType*500;
        Life.AllEnemy.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

        if (Die==0) { TakeDamage(501);Die = 2; }
        distance=Vector3.Distance(transform.position, target.transform.position);
        if (distance <= 4)
        {
            myAnim.SetTrigger("Attack");
            Life.currentLife -= damage * Time.deltaTime;
        }
        if (target != null)
        {
            transform.LookAt(target.transform.position);
        }

        // 沿着前进方向移动
        transform.Translate(Vector3.forward * EnemySpeed * Time.deltaTime);
        if (Die == 1) { Die--; }









    }



    public void TakeDamage(int damageAmount)
    {
        curentHealth -= damageAmount;
        if (curentHealth <= 0)
        {
            GameObject Dead = Instantiate(Deatheffect, transform.position, transform.rotation);
            for (; EnemyType>0; EnemyType--)
            {
                Instantiate(PowerPoint, transform.position, transform.rotation);
            }
            Destroy(gameObject);
            Life.AllEnemy.Remove(this);
            Score.GET++;
            Destroy(Dead, 3);

        }
    }


}
