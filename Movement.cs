using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float runSpeed = 8f;
    public float rotationSpeed = 10f; // �����ת�ٶ�
    Rigidbody myRb;
    public static Animator myAnim;
    public static List<PowerPoint> AllPowerPoint = new List<PowerPoint>();
    public Transform shotPoint;   
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public static int MyPower = 0;      //����
    private bool isShooting = false;    //�������
    int AttackType=1;                   //��������
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
         // ע�⣺��C#�и���������Ҫ���� 'f' ��׺
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

                // ���������
                if (Input.GetMouseButtonDown(0))
                {
                    // �л����ɼ���״̬
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


                // ��ʼ�����ӵ�
                if (Input.GetButtonDown("Fire1"))
                {
                    isShooting = true;
                    InvokeRepeating("Shoot", 0f, 0.1f); // ÿ0.25�����һ��Shoot����
                }

                // ֹͣ�����ӵ�
                if (Input.GetButtonUp("Fire1"))
                {
                    isShooting = false;
                    CancelInvoke("Shoot"); // ȡ��InvokeRepeating����
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
            //��ͣ�ű� 
            if (Input.GetButtonDown("Cancel"))
            {
                if (Time.timeScale > 0.2)
                {
                    Time.timeScale = 0;
                    ESC.text = "��Ϸ�Ѿ���ͣ\n����ESC����";
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
            // ��ȡˮƽ�ʹ�ֱ�������
            float move1 = Input.GetAxisRaw("Horizontal");
            float move2 = Input.GetAxisRaw("Vertical");

            // ��ȡ���ˮƽ��תֵ
            float mouseX = Input.GetAxisRaw("Mouse X");

            // ��ȡ����ľֲ�ǰ����
            Vector3 forward = transform.forward;

            // �����ƶ�����
            Vector3 moveDirection = (forward * move2 + transform.right * move1).normalized;


            // ���ø�����ٶ� ��������
            myRb.velocity = new Vector3(moveDirection.x * runSpeed, -5, moveDirection.z * runSpeed);
            // ���ö������ٶ�
            // myAnim.SetFloat("Speed", Mathf.Abs(move1) + Mathf.Abs(move2));

            // ͨ�������ת����������泯����
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


