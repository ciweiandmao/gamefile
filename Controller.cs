using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Image pic1;
    public Image pic2;
    public Image pic3;
    public Image ABOUT;
    public Text Plot;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject point5;
    public GameObject point6;
    public GameObject point7;
    public GameObject point8;
    public GameObject LM;
    public GameObject point9;
    public GameObject point10;
    public GameObject LMDead;
    public GameObject point11;

    public GameObject BrokenGrass1;
    public GameObject BrokenGrass2;

    public GameObject Light;
    public GameObject AllGlass;


    public Button start;
    public Button about;


    public static bool IsStart = false;
    public static bool Help=false;
    public static bool TimePause = false;
    public static bool End = false;

    public AudioSource sound;
    public AudioSource Game;
    public AudioSource Thunder;
    public AudioSource Pause;
    public AudioSource Explode;
    public AudioSource Ending;
    public AudioSource Broken;
    public AudioSource Breaking;
    public AudioSource LessLife;

    private float WarmingLife=1000f;

    public bool Pass0 = false;
    public bool Pass1 = true;
    public bool Pass2 = true;
    public bool Pass3 = true;
    public bool Pass4 = true;
    public bool Pass5 = true;
    public bool Pass6 = true;
    public bool Pass7 = true;
    public bool Pass8 = true;
    public bool Pass9 = true;
    public bool Pass10 = true;  

    public bool SongPlay = true;
    public bool Broken1 = true;
    public bool Broken2 = true;
    public bool Broken3 = true;


    float nowTime;




    private void Start()
    {
        float nowTime = Time.time;
        AllGlass.SetActive(false);
    }
    private void Update()
    {
        if (!IsStart && !End)
        {
            if (!Pass0)
            {
                BrokenGrass1.SetActive(false);
                BrokenGrass2.SetActive(false);

                
                pic2.GetComponent<Image>().enabled = false;
                pic3.GetComponent<Image>().enabled = false;
                ABOUT.GetComponent<Image>().enabled = false;
                start.GetComponent<Button>().gameObject.SetActive(false);
                about.GetComponent<Button>().gameObject.SetActive(false);
                Destroy(pic1, 5);
                if (pic1 == null)
                {
                    Pass0 = true;
                    Pass1 = false;
                    sound.Play();
                    pic2.GetComponent<Image>().enabled = true;
                }
            }
            if (!Pass1)
            {


                if (pic2 == null)
                {
                    Pass1 = true;
                    Pass2 = false;

                }
                else { Destroy(pic2, 4.8f); }


            }

            // 在 Start 中设置初始位置和旋转

            if (!Pass2)
            {
                nowTime = Time.time;
                Plot.text = "令和4年 10月4日 日暮";
                pic3.GetComponent<Image>().enabled = true;
                transform.position = point1.transform.position;
                transform.rotation = point1.transform.rotation;
                Pass2 = true;
                Pass3 = false;
            }
            if (!Pass3)
            {
                if (Time.time - nowTime > 4.2)
                {
                    Plot.text = "直到昨日夜里才觉察到异变，已然是太迟了";
                    nowTime = Time.time;
                }
                Pass3 = MoveCamera(point1.transform.position, point2.transform.position, point1.transform.rotation, 0.115f);
                Pass4 = !Pass3;
            }
            if (!Pass4)
            {
                nowTime = Time.time;
                Plot.text = "和往日的异变不同，幻想乡陷入了一片腥风血雨之中";
                transform.position = point3.transform.position;
                transform.rotation = point3.transform.rotation;
                Pass4 = true;
                Pass5 = false;
            }
            if (!Pass5)
            {
                if (Time.time - nowTime > 4.2)
                {
                    Plot.text = "月之民释放的狂气已经渗透进来，几乎所有人都变成了杀戮的机器";
                    nowTime = Time.time;
                }
                Pass5 = MoveCamera(point3.transform.position, point4.transform.position, point3.transform.rotation, 0.112f);
                Pass6 = !Pass5;
            }
            if (!Pass6)
            {
                nowTime = Time.time;
                Plot.text = "惨象使我目不忍视，阴谋使我耳不忍闻";
                transform.position = point5.transform.position;
                transform.rotation = point5.transform.rotation;
                Pass6 = true;
                Pass7 = false;
            }
            if (!Pass7)
            {
                if (Time.time - nowTime > 4.2)
                {
                    Plot.text = "一旦博丽大结界破碎，幻想乡将会彻底沦陷";
                    nowTime = Time.time;
                }
                Pass7 = MoveCamera(point5.transform.position, point6.transform.position, point5.transform.rotation, 0.15f);
                Pass8 = !Pass7;
            }
            if (!Pass8)
            {
                nowTime = Time.time;
                Plot.text = "幻想乡的未来，在此一战了！";
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                players[0].transform.position = LM.transform.position;
                players[0].transform.rotation = LM.transform.rotation;
                transform.position = point7.transform.position;
                transform.rotation = point7.transform.rotation;
                Pass8 = true;
                Pass9 = false;
            }
            if (!Pass9)
            {
                if (Time.time - nowTime > 4.2)
                {
                    Plot.text = "";
                    nowTime = 0f;
                }
                if (nowTime < 0.5f && pic3 != null)
                {
                    // 获取当前 anchoredPosition
                    Vector2 currentPosition = pic3.rectTransform.anchoredPosition;

                    // 计算新的 anchoredPosition
                    Vector2 newPosition = new Vector2(currentPosition.x, currentPosition.y - 20f * Time.deltaTime);

                    // 更新 anchoredPosition
                    pic3.rectTransform.anchoredPosition = newPosition;

                    Destroy(pic3, 6);
                }

                Pass9 = MoveCamera(point7.transform.position, point8.transform.position, point7.transform.rotation, 0.07f);
                Pass10 = !Pass9;
            }
            if (!Pass10)
            {
                start.GetComponent<Button>().gameObject.SetActive(true);
                about.GetComponent<Button>().gameObject.SetActive(true);
               Time.timeScale = 1;////////////////////////////////////////////////
                Pass10 = true;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                if (Help)
                {
                    ABOUT.GetComponent<Image>().enabled = false;
                    start.GetComponent<Button>().gameObject.SetActive(true);
                    about.GetComponent<Button>().gameObject.SetActive(true);
                    Help = false;
                }
            }
        }

        if(Life.currentLife< WarmingLife &&Life.currentLife>0&&!TimePause)
        {
            LessLife.Play();
            WarmingLife = -100f;
        }


        //暂停音乐
        if(Time.timeScale<0.2 && !TimePause)
        {
            Game.Pause();
            Thunder.Pause();
            Pause.Play();
            LessLife.Pause();
            TimePause = true;
        }
        //继续音乐
        if(Time.timeScale>0.2&&TimePause)
        {
            Game.UnPause();
            Thunder.UnPause();
            LessLife.UnPause();
            TimePause = false;
        }

        if (End)
        {
            if (IsStart)
            {
                Explode.Play();
                Game.Stop();
                LessLife.Stop();
                IsStart = false;
                nowTime = Time.time;
                Time.timeScale = 0.3f;
            }

            if (Time.time-nowTime>2)
            {
                if(Time.timeScale<0.4f)
                {
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("NearWeapon");
                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                    players[0].GetComponent<Animator>().SetTrigger("Dead");
                    players[0].GetComponent<Animator>().SetTrigger("Dead");
                    players[0].transform.position = LMDead.transform.position;
                    players[0].transform.rotation = LMDead.transform.rotation;
                    transform.position = point9.transform.position;
                    transform.rotation = point9.transform.rotation;
                }
                Time.timeScale = 1;
                if (Broken3) {
                    MoveCamera(point9.transform.position, point10.transform.position, point9.transform.rotation, 0.015f);
                }

            }
            if (Time.time - nowTime > 2 && SongPlay)
            {
                Ending.Play();
                SongPlay = false;
            }
            if (Time.time - nowTime > 23.9 && Broken1)
            {
                Broken.Play();
                BrokenGrass1.SetActive(true);
                Broken1 = false;
            }
            if (Time.time - nowTime > 28.4 && Broken2)
            {
                Broken.Play();
                BrokenGrass2.SetActive(true);
                Broken2 = false;
            }
            if (Time.time - nowTime > 37.5 && Broken3)
            {
                
                Light.GetComponent<Light>().intensity = 1f;
                Breaking.Play();
                Broken3 = false;
                transform.position = point11.transform.position;
                transform.rotation = point11.transform.rotation;
                AllGlass.SetActive(true);
                MoveCamera(point9.transform.position, point10.transform.position, point9.transform.rotation, 0);
                CrackGlass.Yes= true;


            }

        }




    }

    public bool MoveCamera(Vector3 start, Vector3 end, Quaternion rotation, float moveSpeed)
    {
        // 计算朝向和距离
        
        Vector3 direction = end - start;
        float distance = Vector3.Distance(transform.position, end);

        // 移动物体
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
     

        // 如果物体接近终点，处理停止移动逻辑
        if (distance < 0.2f)
        {
            return true;
        }
        else { return false; }
    }

    public void StartGame()
    {
        start.GetComponent<Button>().gameObject.SetActive(false);
        about.GetComponent<Button>().gameObject.SetActive(false);
        Movement.myAnim.SetFloat("Speed", 1);
        IsStart = true;
        sound.Stop();
        Game.Play();
        Thunder.Play();
    }
    public void About()
    {
        ABOUT.GetComponent<Image>().enabled = true;
        start.GetComponent<Button>().gameObject.SetActive(false);
        about.GetComponent<Button>().gameObject.SetActive(false);
        Help = true;
    }
}


   
