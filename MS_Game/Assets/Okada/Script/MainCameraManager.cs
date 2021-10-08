using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraManager : MonoBehaviour
{
    private Vector3 m_Position;
    [SerializeField]private float m_MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        m_Position = new Vector3(Input.GetAxisRaw("Horizontal"),0.0f, Input.GetAxisRaw("Vertical"));
        m_Position = m_Position.normalized * m_MoveSpeed * Time.unscaledDeltaTime;
        transform.position += m_Position;
        transform.position += transform.forward * Input.mouseScrollDelta.y;
    }
}
