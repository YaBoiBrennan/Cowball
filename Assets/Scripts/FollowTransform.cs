using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public GameObject followObject;
    public Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newTransform = new Vector3(followObject.transform.position.x + offset.x, followObject.transform.position.y + offset.y, this.transform.position.z);
        this.transform.position = newTransform;
    }
}
