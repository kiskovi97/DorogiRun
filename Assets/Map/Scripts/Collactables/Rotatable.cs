using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    public float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), Time.deltaTime * speed, Space.World);
    }
}
