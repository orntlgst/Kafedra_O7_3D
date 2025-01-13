using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        Vector3 newPos = target.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }
}
