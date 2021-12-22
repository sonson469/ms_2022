using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKantaiTree : MonoBehaviour
{
    [SerializeField] int m_Kantainum;
    private List<GameObject> InNestList = new List<GameObject>();

    private GameObject m_Manager;
    private CGameObject m_GameObjectScript;

    // Start is called before the first frame update
    void Start()
    {
        m_Manager = GameObject.FindWithTag("Manager");
        m_GameObjectScript = m_Manager.GetComponent<CGameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_GameObjectScript.GetMode() == CGameObject.ModeState.NORMAL || m_GameObjectScript.GetMode() == CGameObject.ModeState.OBJMOVE)
        {
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.PENGIN)
            {
                InNestList.Add(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeCount(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.AZARASHI)
            {
                InNestList.Add(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeCount(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TONAKAI)
            {
                InNestList.Add(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeCount(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKOUUSHI)
            {
                InNestList.Add(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeCount(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUKITUNE)
            {
                InNestList.Add(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeCount(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIROHUKUROU)
            {
                InNestList.Add(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeCount(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KUZURI)
            {
                InNestList.Add(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeCount(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TUNDORAOOKAMI)
            {
                InNestList.Add(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeCount(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SEIUTI)
            {
                InNestList.Add(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeCount(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUGUMA)
            {
                InNestList.Add(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeCount(m_Kantainum);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (m_GameObjectScript.GetMode() == CGameObject.ModeState.NORMAL || m_GameObjectScript.GetMode() == CGameObject.ModeState.OBJMOVE)
        {
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.PENGIN)
            {
                InNestList.Remove(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeMinus(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.AZARASHI)
            {
                InNestList.Remove(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeMinus(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TONAKAI)
            {
                InNestList.Remove(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeMinus(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKOUUSHI)
            {
                InNestList.Remove(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeMinus(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUKITUNE)
            {
                InNestList.Remove(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeMinus(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIROHUKUROU)
            {
                InNestList.Remove(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeMinus(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KUZURI)
            {
                InNestList.Remove(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeMinus(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TUNDORAOOKAMI)
            {
                InNestList.Remove(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeMinus(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SEIUTI)
            {
                InNestList.Remove(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeMinus(m_Kantainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUGUMA)
            {
                InNestList.Remove(other.gameObject);
                CKantai script = other.gameObject.GetComponent<CKantai>();
                script.TreeMinus(m_Kantainum);
            }
        }
    }
    public void ResetList()   //オブジェクトを消すときリスト内の木の数をリセットさせる
    {
        for (int i = 0; i < InNestList.Count; i++)
        {
            if (InNestList[i].gameObject != null)
            {
                CKantai script = InNestList[i].GetComponent<CKantai>();
                script.TreeMinus(m_Kantainum);
            }
        }
        InNestList.Clear();
    }
}
