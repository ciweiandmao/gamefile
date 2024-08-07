using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class PowerPoint : MonoBehaviour
{
    //场上的P点是否被召唤；
    public bool calling = false;
    public float distance;

    public AudioSource GetPoint;



    // Start is called before the first frame update
    void Start()
    {
        Movement.AllPowerPoint.Add(this);
        StartCoroutine(WaitAndExecute());
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        distance = Vector3.Distance(transform.position, players[0].transform.position);
        if (distance <= 2)
        {
            GetPoint.Play();
            if(Movement.AllPowerPoint.Contains(this))
            {
                Movement.MyPower++;
            }
            Movement.AllPowerPoint.Remove(this);
            Destroy(gameObject,0.1f);
            
        }
        if (calling)
        {
            transform.position += transform.forward * 100 * Time.deltaTime;
            FindDirection();
        }


    }


    IEnumerator WaitAndExecute()
    {
        yield return new WaitForSeconds(20f); // 等待20秒
        Destroy(gameObject);
        Movement.AllPowerPoint.Remove(this);
    }


    void FindDirection()
    {

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        transform.LookAt(players[0].transform.position);
        

    }
}


