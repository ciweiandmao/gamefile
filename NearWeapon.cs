using UnityEngine;

public class NearWeapons : MonoBehaviour
{
    public float rotationSpeed = 180f; // ��ת�ٶ�
    public Transform target; // Ŀ�����

    void Update()
    {
        if (target != null)
        {
            // �������������ΪĿ�������
            transform.position = target.position;
        }
        // ������ת�Ƕ�
        float rotationAngle = rotationSpeed * Time.deltaTime;

        // ����������Ĵ�ֱ�������ת
        transform.Rotate(Vector3.up, rotationAngle);

    }
}
