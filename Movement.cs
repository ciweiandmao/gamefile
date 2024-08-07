using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float runSpeed = 8f;
    public float rotationSpeed = 10f; // 鼠标旋转速度
    Rigidbody myRb;
    public static Animator myAnim;
    public static List<PowerPoint> AllPowerPoint = new List<PowerPoint>();
    public Transform shotPoint;   
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public static int MyPower = 0;      //灵力
    private bool isShooting = false;    //正在射击
    int AttackType=1;                   //攻击类型
    public Text Power;
    public Text ESC;
    public static float SkillDistance =50f;




    public AudioSource Attack;
    public AudioSource MySkill;




    void Start()
    {
        

        myRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 newPosition = transform.position;
        if (!Controller.End) { newPosition.y = 0.4f; }
         // 注意：在C#中浮点数后需要加上 'f' 后缀
        transform.position = newPosition;
        if(!Controller.IsStart)
        {
            isShooting = false;
            CancelInvoke("Shoot");

            myAnim.SetTrigger("NoForward");
            myAnim.SetTrigger("NoBackward");
            myAnim.SetTrigger("NoLeft");
            myAnim.SetTrigger("NoRight");
            Power.text = "";
        }

        if (Controller.IsStart)
        {
            
            if (Time.timeScale > 0.2)
            {

                // 检测鼠标左键
                if (Input.GetMouseButtonDown(0))
                {
                    // 切换鼠标可见性状态
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }



                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    AttackType = 1;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    AttackType = 2;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    AttackType = 3;
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (MyPower >= 10)
                    {
                        MyPower -= 10;
                        foreach (PowerPoint power in AllPowerPoint)
                        {
                            power.calling = true;
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (MyPower >= 100)
                    {
                        MyPower -= 100;
                        MySkill.Play();
                        foreach (Enemy enemy in Life.AllEnemy)
                        {
                            if (enemy.distance < SkillDistance)
                                enemy.Die = 1;
                        }
                        Life.IsSkilled = true;
                    }
                }


                // 开始生成子弹
                if (Input.GetButtonDown("Fire1"))
                {
                    isShooting = true;
                    InvokeRepeating("Shoot", 0f, 0.1f); // 每0.25秒调用一次Shoot方法
                }

                // 停止生成子弹
                if (Input.GetButtonUp("Fire1"))
                {
                    isShooting = false;
                    CancelInvoke("Shoot"); // 取消InvokeRepeating调用
                }

                if (Input.GetKey(KeyCode.W))
                {
                    myAnim.SetTrigger("Forward");
                }
                if (Input.GetKey(KeyCode.S))
                {
                    myAnim.SetTrigger("Backward");
                }
                if (Input.GetKey(KeyCode.A))
                {
                    myAnim.SetTrigger("Left");
                }
                if (Input.GetKey(KeyCode.D))
                {
                    myAnim.SetTrigger("Right");
                }


                if (!Input.GetKey(KeyCode.W))
                {
                    myAnim.SetTrigger("NoForward");
                }
                if (!Input.GetKey(KeyCode.S))
                {
                    myAnim.SetTrigger("NoBackward");
                }
                if (!Input.GetKey(KeyCode.A))
                {
                    myAnim.SetTrigger("NoLeft");
                }
                if (!Input.GetKey(KeyCode.D))
                {
                    myAnim.SetTrigger("NoRight");
                }
            }
            //暂停脚本 
            if (Input.GetButtonDown("Cancel"))
            {
                if (Time.timeScale > 0.2)
                {
                    Time.timeScale = 0;
                    ESC.text = "游戏已经暂停\n按下ESC继续";
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Time.timeScale = 1;
                    ESC.text = "";
                }

            }

            if (Time.timeScale > 0.2)
            {
                Power.text = "Power:" + MyPower.ToString();
            }
            else { Power.text = ""; }



        }


    }

    void FixedUpdate()
    {
        if (Controller.IsStart)
        {
            // 获取水平和垂直轴的输入
            float move1 = Input.GetAxisRaw("Horizontal");
            float move2 = Input.GetAxisRaw("Vertical");

            // 获取鼠标水平旋转值
            float mouseX = Input.GetAxisRaw("Mouse X");

            // 获取人物的局部前方向
            Vector3 forward = transform.forward;

            // 计算移动方向
            Vector3 moveDirection = (forward * move2 + transform.right * move1).normalized;


            // 设置刚体的速度 附加重力
            myRb.velocity = new Vector3(moveDirection.x * runSpeed, -5, moveDirection.z * runSpeed);
            // 设置动画的速度
            // myAnim.SetFloat("Speed", Mathf.Abs(move1) + Mathf.Abs(move2));

            // 通过鼠标旋转调整人物的面朝方向
            transform.Rotate(Vector3.up, mouseX * rotationSpeed);
        }
        else { myRb.velocity = new Vector3( 0, -5, 0); }
    }

    void Shoot()
    {
        Attack.Play();
        switch (AttackType)
        {
            case 1:
                Instantiate(bullet1, shotPoint.position, shotPoint.rotation);
                break;
            case 2:
                Instantiate(bullet2, shotPoint.position, shotPoint.rotation);
                break;
            case 3:
                Instantiate(bullet3, shotPoint.position, shotPoint.rotation);
                break;
            default:
                break;
        }
    }

}


