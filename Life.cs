using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public float initialLife; // ��ʼ����ֵ
    public static float currentLife; // ��ǰ����ֵ
    public static bool IsSkilled = false;
    public GameObject Skill;         //������Ч
    public GameObject Death;         //������Ч 
    public Text lifeText;
    public static List<Enemy> AllEnemy = new List<Enemy>();
    void Start()
    {
        currentLife = initialLife;
    }

    void Update()
    {
        if (Time.timeScale > 0.2&&Controller.IsStart&&!Controller.TimePause)
        {
            lifeText.text = "Life: " + currentLife.ToString();
        }
        else { lifeText.text = ""; }
        // �������ֵ�Ƿ�С�ڵ���0���������ִ��Ч����������ײ��
        if (currentLife <= 0)
        {
            GameObject Dead = Instantiate(Death, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(Dead, 3);
            lifeText.text = "";
            Controller.End = true;
        }
        if (IsSkilled)
        {
            GameObject TeXiao = Instantiate(Skill, transform.position, transform.rotation);
            Destroy(TeXiao, 3);
            IsSkilled= false;
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    // ��������������ǵ��ˣ�Enemy1��Enemy6��
    //    if (other.CompareTag("Enemy"))
    //    {
    //        Enemy enemy = other.GetComponent<Enemy>();

    //        // �������Ƿ��Ѿ���������ײ��
    //        if (!touchingEnemies.Contains(enemy))
    //        {
    //            // ��¼�õ����Ѿ���������ײ��
    //            touchingEnemies.Add(enemy);
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    // ����뿪�������ǵ��ˣ�Enemy1��Enemy6��
    //    if (other.CompareTag("Enemy"))
    //    {
    //        Enemy enemy = other.GetComponent<Enemy>();

    //        // �Ƴ��뿪�ĵ���
    //        touchingEnemies.Remove(enemy);
    //    }
    //}


}
