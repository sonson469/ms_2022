using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CReaper : MonoBehaviour
{

    private CGameObject m_ObjectScript;
    private GameObject m_Manager;

    [SerializeField] private GameObject m_DesObj;

    private List<GameObject> InReaperList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        m_Manager = GameObject.FindWithTag("Manager");
        m_ObjectScript = m_Manager.GetComponent<CGameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //撤去モード時は選択用の円柱がでてくる
        if (m_ObjectScript.GetMode() == CGameObject.ModeState.DES)
        {
            m_DesObj.SetActive(true);
        }
        else
        {
            m_DesObj.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_ObjectScript.GetMode() != CGameObject.ModeState.DES || m_ObjectScript.GetMode() != CGameObject.ModeState.INFOR)
        {
            if (other.gameObject.tag == "Tree")
            {
                InReaperList.Add(other.gameObject);
                CTree script = other.gameObject.GetComponent<CTree>();
                script.SetReaper(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (m_ObjectScript.GetMode() != CGameObject.ModeState.DES || m_ObjectScript.GetMode() != CGameObject.ModeState.INFOR)
        {
            if (other.gameObject.tag == "Tree")
            {
                InReaperList.Remove(other.gameObject);
                CTree script = other.gameObject.GetComponent<CTree>();
                script.SetReaper(false);
            }
        }
    }

    public void ResetList()   //オブジェクトを消すときリスト内の木の数をリセットさせる
    {
        for (int i = 0; i < InReaperList.Count; i++)
        {
            if (InReaperList[i].gameObject != null)
            {
                CTree script = InReaperList[i].gameObject.GetComponent<CTree>();
                script.SetReaper(false);
            }

        }
        InReaperList.Clear();
    }
}
