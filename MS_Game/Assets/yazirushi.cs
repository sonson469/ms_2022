using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yazirushi : MonoBehaviour
{

    private float m_NowPosi;

    // Start is called before the first frame update
    void Start()
    {
        m_NowPosi = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, m_NowPosi + Mathf.PingPong(Time.time, 0.3f), transform.position.z);
    }
}
