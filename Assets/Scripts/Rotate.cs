using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int speed = 0;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 50) * speed * Time.deltaTime);
    }
}
