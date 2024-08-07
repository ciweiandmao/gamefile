using UnityEngine;

public class NearWeapons : MonoBehaviour
{
    public float rotationSpeed = 180f; // 自转速度
    public Transform target; // 目标对象

    void Update()
    {
        if (target != null)
        {
            // 设置物体的坐标为目标的坐标
            transform.position = target.position;
        }
        // 计算自转角度
        float rotationAngle = rotationSpeed * Time.deltaTime;

        // 绕物体自身的垂直轴进行自转
        transform.Rotate(Vector3.up, rotationAngle);

    }
}
