using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COntaiTree : MonoBehaviour
{
    [SerializeField] int m_Ontainum;
    [SerializeField] private List<GameObject> InNestList = new List<GameObject>();

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
        if (m_GameObjectScript.GetMode() != CGameObject.ModeState.DES || m_GameObjectScript.GetMode() != CGameObject.ModeState.INFOR)
        {
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HATUKANEZUMI)
            {
                InNestList.Add(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeCount(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.AMAKAERU)
            {
                InNestList.Add(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeCount(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAHEBI)
            {
                InNestList.Add(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeCount(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.RESSAPANDA)
            {
                InNestList.Add(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeCount(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.NIHONNITATI)
            {
                InNestList.Add(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeCount(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.YAMAINU)
            {
                InNestList.Add(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeCount(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOTAKA)
            {
                InNestList.Add(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeCount(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HUKUROU)
            {
                InNestList.Add(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeCount(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.GURIZURI)
            {
                InNestList.Add(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeCount(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TORA)
            {
                InNestList.Add(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeCount(m_Ontainum);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (m_GameObjectScript.GetMode() != CGameObject.ModeState.DES || m_GameObjectScript.GetMode() != CGameObject.ModeState.INFOR)
        {
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HATUKANEZUMI)
            {
                InNestList.Remove(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeMinus(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.AMAKAERU)
            {
                InNestList.Remove(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeMinus(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAHEBI)
            {
                InNestList.Remove(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeMinus(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.RESSAPANDA)
            {
                InNestList.Remove(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeMinus(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.NIHONNITATI)
            {
                InNestList.Remove(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeMinus(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.YAMAINU)
            {
                InNestList.Remove(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeMinus(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOTAKA)
            {
                InNestList.Remove(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeMinus(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HUKUROU)
            {
                InNestList.Remove(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeMinus(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.GURIZURI)
            {
                InNestList.Remove(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeMinus(m_Ontainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TORA)
            {
                InNestList.Remove(other.gameObject);
                COntai script = other.gameObject.GetComponent<COntai>();
                script.TreeMinus(m_Ontainum);
            }
        }
    }

    public void ResetList()   //オブジェクトを消すときリスト内の木の数をリセットさせる
    {
        for (int i = 0; i < InNestList.Count; i++)
        {
            if (InNestList[i].gameObject != null)
            {
                COntai script = InNestList[i].GetComponent<COntai>();
                script.TreeMinus(m_Ontainum);
            }
            
        }
        InNestList.Clear();
    }
}
