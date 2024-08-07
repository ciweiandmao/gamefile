using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackGlass : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool Yes=false;
    private void Awake()
    {
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Yes)
        {
            Vector3 explosionPosition =new Vector3(54.08f, -21.02f, 428.25f);
            foreach (Transform child in transform)
            {
                if (child.TryGetComponent<Rigidbody>(out Rigidbody childRigidbody))
                {
                    childRigidbody.AddExplosionForce(1000f, explosionPosition, 1000f);
                }
            }
            Yes= false;
        }
    }
}
