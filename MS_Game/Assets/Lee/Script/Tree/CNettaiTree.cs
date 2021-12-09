using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNettaiTree : MonoBehaviour
{
    [SerializeField] int m_Nettainum;
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
        if (m_GameObjectScript.GetMode() != CGameObject.ModeState.DES)
        {
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SYOUGARAGO)
            {
                InNestList.Add(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeCount(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KAPIBARA)
            {
                InNestList.Add(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeCount(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KOARA)
            {
                InNestList.Add(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeCount(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.WONBATTO)
            {
                InNestList.Add(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeCount(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOARIKUI)
            {
                InNestList.Add(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeCount(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TASUMANIADEBIRU)
            {
                InNestList.Add(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeCount(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOKOUMORI)
            {
                InNestList.Add(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeCount(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.GORIRA)
            {
                InNestList.Add(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeCount(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.WANI)
            {
                InNestList.Add(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeCount(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAGA)
            {
                InNestList.Add(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeCount(m_Nettainum);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (m_GameObjectScript.GetMode() != CGameObject.ModeState.DES)
        {
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SYOUGARAGO)
            {
                InNestList.Remove(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeMinus(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KAPIBARA)
            {
                InNestList.Remove(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeMinus(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KOARA)
            {
                InNestList.Remove(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeMinus(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.WONBATTO)
            {
                InNestList.Remove(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeMinus(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOARIKUI)
            {
                InNestList.Remove(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeMinus(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TASUMANIADEBIRU)
            {
                InNestList.Remove(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeMinus(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOKOUMORI)
            {
                InNestList.Remove(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeMinus(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.GORIRA)
            {
                InNestList.Remove(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeMinus(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.WANI)
            {
                InNestList.Remove(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeMinus(m_Nettainum);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAGA)
            {
                InNestList.Remove(other.gameObject);
                CNettai script = other.gameObject.GetComponent<CNettai>();
                script.TreeMinus(m_Nettainum);
            }
        }
    }
    public void ResetList()   //オブジェクトを消すときリスト内の木の数をリセットさせる
    {
        for (int i = 0; i < InNestList.Count; i++)
        {
            CNettai script = InNestList[i].GetComponent<CNettai > ();
            script.TreeMinus(m_Nettainum);
        }
        InNestList.Clear();
    }
}
