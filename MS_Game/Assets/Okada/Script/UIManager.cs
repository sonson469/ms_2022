using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas[] m_Canvas;
    [SerializeField] private Canvas m_ObjCanvas;

    [SerializeField] private int m_DispCount;


    // Start is called before the first frame update
    void Start()
    {
        m_DispCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_DispCount);
    }

    public void DispUI()
    {
        if (++ m_DispCount % 2 == 0)
        {
            m_ObjCanvas.gameObject.SetActive(true);
        }
        else
        {
            m_ObjCanvas.gameObject.SetActive(false);
        }
    }

    public void DispObjUI()
    {
        m_ObjCanvas.gameObject.SetActive(!m_ObjCanvas.gameObject.activeSelf);
    }

}
