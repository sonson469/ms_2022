using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAnimaInfo : MonoBehaviour
{

    public Text m_MyAnimalNumText;
    public Text m_HighNestText;

    public GameObject m_Canvas;

    private CNest m_NestScript;
    private GameObject MyNest;

    // Start is called before the first frame update
    void Start()
    {

        m_Canvas = this.gameObject.transform.GetChild(6).gameObject;

        m_Canvas.SetActive(false);

        GameObject obj = m_Canvas.gameObject.transform.GetChild(0).gameObject;

        m_MyAnimalNumText = obj.gameObject.transform.GetChild(3).gameObject.GetComponent<Text>();
        m_HighNestText = obj.gameObject.transform.GetChild(4).gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInformation(bool flag)
    {
        m_Canvas.SetActive(flag);
    }
}
