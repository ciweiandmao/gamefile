using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateSelf : MonoBehaviour
{
    public float rotationSpeed; // ��ת�ٶȣ������� Unity �༭���е���

    // Update is called once per frame
    void Update()
    {

        // ��ת
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
