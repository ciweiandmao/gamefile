using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Score : MonoBehaviour

{
    public int score = 0;
    public static int GET = 0;
    public Text SocreText;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0.2 && Controller.IsStart)
        {

            if (Life.currentLife > 0)
            {
                score += GET * 100;
                GET = 0;
                SocreText.text = "Socre:" + score.ToString();
            }
        }
        else { SocreText.text = ""; }
    }


    
}
