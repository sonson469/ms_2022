using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraManager : MonoBehaviour
{
    [SerializeField]private float m_MoveSpeed;
    [SerializeField] private float m_ScrollSpeed;

    [SerializeField] private float m_ScrollMax, m_ScrollMin;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 moveForward = cameraForward * Input.GetAxisRaw("Vertical") + Camera.main.transform.right * Input.GetAxisRaw("Horizontal");

        transform.position += moveForward.normalized * m_MoveSpeed * Time.unscaledDeltaTime;

        if (Input.mouseScrollDelta.y > 0)
        {
            if(transform.position.y >= m_ScrollMin)
            {
                transform.position += transform.forward * Input.mouseScrollDelta.y * m_ScrollSpeed;
            }
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            if (transform.position.y <= m_ScrollMax)
            {
                transform.position += transform.forward * Input.mouseScrollDelta.y * m_ScrollSpeed;
            }
        }

    }
}
