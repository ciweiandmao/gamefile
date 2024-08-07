using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateSelf : MonoBehaviour
{
    public float rotationSpeed; // 自转速度，可以在 Unity 编辑器中调整

    // Update is called once per frame
    void Update()
    {

        // 自转
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
