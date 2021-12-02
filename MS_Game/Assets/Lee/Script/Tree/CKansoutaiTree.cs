using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKansoutaiTree : MonoBehaviour
{
    [SerializeField] int m_Kansoutai;
    private List<GameObject> InNestList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HARINEZUMI)
        {
            InNestList.Add(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeCount(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ARUMAZIRO)
        {
            InNestList.Add(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeCount(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAKUDA)
        {
            InNestList.Add(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeCount(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAUMA)
        {
            InNestList.Add(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeCount(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SABARU)
        {
            InNestList.Add(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeCount(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKKARU)
        {
            InNestList.Add(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeCount(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KABA)
        {
            InNestList.Add(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeCount(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SAI)
        {
            InNestList.Add(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeCount(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZOU)
        {
            InNestList.Add(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeCount(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAION)
        {
            InNestList.Add(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeCount(m_Kansoutai);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HARINEZUMI)
        {
            InNestList.Remove(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeMinus(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ARUMAZIRO)
        {
            InNestList.Remove(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeMinus(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAKUDA)
        {
            InNestList.Remove(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeMinus(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAUMA)
        {
            InNestList.Remove(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeMinus(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SABARU)
        {
            InNestList.Remove(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeMinus(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKKARU)
        {
            InNestList.Remove(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeMinus(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KABA)
        {
            InNestList.Remove(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeMinus(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SAI)
        {
            InNestList.Remove(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeMinus(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZOU)
        {
            InNestList.Remove(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeMinus(m_Kansoutai);
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAION)
        {
            InNestList.Remove(other.gameObject);
            CKansoutai script = other.gameObject.GetComponent<CKansoutai>();
            script.TreeMinus(m_Kansoutai);
        }
    }
    public void ResetList()   //オブジェクトを消すときリスト内の木の数をリセットさせる
    {
        for (int i = 0; i < InNestList.Count; i++)
        {
            CKansoutai script = InNestList[i].GetComponent<CKansoutai>();
            script.TreeMinus(m_Kansoutai);
        }
        InNestList.Clear();
    }
}
