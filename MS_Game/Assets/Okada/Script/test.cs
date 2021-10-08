using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(pos.x + Mathf.PingPong(Time.time, 5), pos.y, pos.z);
    }
}
