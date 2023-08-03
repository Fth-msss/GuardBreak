using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform Target;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + Target.forward);
    }
}
