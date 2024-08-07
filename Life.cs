using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public float initialLife; // 初始生命值
    public static float currentLife; // 当前生命值
    public static bool IsSkilled = false;
    public GameObject Skill;         //技能特效
    public GameObject Death;         //死亡特效 
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
        // 检查生命值是否小于等于0，如果是则执行效果并销毁碰撞箱
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
    //    // 如果碰到的物体是敌人（Enemy1到Enemy6）
    //    if (other.CompareTag("Enemy"))
    //    {
    //        Enemy enemy = other.GetComponent<Enemy>();

    //        // 检查敌人是否已经触碰到碰撞箱
    //        if (!touchingEnemies.Contains(enemy))
    //        {
    //            // 记录该敌人已经触碰到碰撞箱
    //            touchingEnemies.Add(enemy);
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    // 如果离开的物体是敌人（Enemy1到Enemy6）
    //    if (other.CompareTag("Enemy"))
    //    {
    //        Enemy enemy = other.GetComponent<Enemy>();

    //        // 移除离开的敌人
    //        touchingEnemies.Remove(enemy);
    //    }
    //}


}
