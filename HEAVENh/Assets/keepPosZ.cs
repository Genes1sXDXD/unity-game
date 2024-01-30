using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObjectAtZ1 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Set the object's position to (currentX, currentY, 1)
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
}

