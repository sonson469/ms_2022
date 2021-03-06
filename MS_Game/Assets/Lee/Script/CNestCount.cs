using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNestCount : MonoBehaviour
{

    public int[] m_NestNameCount = new int[(int)CGameObject.NestNumber.NESTMAX];
    public int[] m_NewNestNameCount = new int[(int)CGameObject.NestNumber.NESTMAX];

    [SerializeField] private List<GameObject> InNestList = new List<GameObject>();

    [SerializeField] private AnimalNestData m_NestData;

    private bool m_Put = false;

    private GameObject MyNest;
    private CNest m_NestScript;

    private GameObject m_Manager;
    private CGameObject m_GameObjectScript;


    // Start is called before the first frame update
    void Start()
    {
        MyNest = this.gameObject.transform.GetChild(0).gameObject;
        m_NestScript = MyNest.GetComponent<CNest>();

        m_Manager = GameObject.FindWithTag("Manager");
        m_GameObjectScript = m_Manager.GetComponent<CGameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPut()
    {
        m_Put = true;
    }
    public bool GetPut()
    {
        return m_Put;
    }

    public GameObject GetNest()
    {
        return MyNest;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (m_GameObjectScript.GetMode() == CGameObject.ModeState.NORMAL || m_GameObjectScript.GetMode() == CGameObject.ModeState.OBJMOVE)
        {
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HATUKANEZUMI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.HATUKANEZUMI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.AMAKAERU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.AMAKAERU]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAHEBI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SHIMAHEBI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.RESSAPANDA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.RESSAPANDA]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.NIHONNITATI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.NIHONNITATI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.YAMAINU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.YAMAINU]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOTAKA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.OOTAKA]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HUKUROU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.HUKUROU]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.GURIZURI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.GURIZURI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TORA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.TORA]++;
                InNestList.Add(other.gameObject);
            }
            //---------------------------------------------------------------------------------
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SYOUGARAGO)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SYOUGARAGO]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KAPIBARA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.KAPIBARA]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KOARA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.KOARA]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.WONBATTO)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.WONBATTO]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOARIKUI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.OOARIKUI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TASUMANIADEBIRU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.TASUMANIADEBIRU]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOKOUMORI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.OOKOUMORI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.GORIRA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.GORIRA]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.WANI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.WANI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAGA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.ZYAGA]++;
                InNestList.Add(other.gameObject);
            }
            //-------------------------------------------------------------------------------------
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HARINEZUMI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.HARINEZUMI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ARUMAZIRO)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.ARUMAZIRO]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAKUDA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.RAKUDA]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAUMA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SHIMAUMA]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SABARU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SABARU]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKKARU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.ZYAKKARU]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KABA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.KABA]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SAI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SAI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZOU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.ZOU]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAION)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.RAION]++;
                InNestList.Add(other.gameObject);
            }
            //--------------------------------------------------------------------------------
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.PENGIN)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.PENGIN]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.AZARASHI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.AZARASHI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TONAKAI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.TONAKAI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKOUUSHI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.ZYAKOUUSHI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUKITUNE)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.HOKKYOKUKITUNE]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIROHUKUROU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SHIROHUKUROU]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KUZURI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.KUZURI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TUNDORAOOKAMI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.TUNDORAOOKAMI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SEIUTI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SEIUTI]++;
                InNestList.Add(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUGUMA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.HOKKYOKUGUMA]++;
                InNestList.Add(other.gameObject);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (m_GameObjectScript.GetMode() == CGameObject.ModeState.NORMAL || m_GameObjectScript.GetMode() == CGameObject.ModeState.OBJMOVE)
        {
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HATUKANEZUMI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.HATUKANEZUMI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.AMAKAERU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.AMAKAERU]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAHEBI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SHIMAHEBI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.RESSAPANDA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.RESSAPANDA]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.NIHONNITATI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.NIHONNITATI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.YAMAINU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.YAMAINU]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOTAKA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.OOTAKA]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HUKUROU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.HUKUROU]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.GURIZURI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.GURIZURI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TORA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.TORA]--;
                InNestList.Remove(other.gameObject);
            }
            //---------------------------------------------------------------------------------
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SYOUGARAGO)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SYOUGARAGO]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KAPIBARA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.KAPIBARA]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KOARA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.KOARA]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.WONBATTO)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.WONBATTO]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOARIKUI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.OOARIKUI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TASUMANIADEBIRU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.TASUMANIADEBIRU]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOKOUMORI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.OOKOUMORI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.GORIRA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.GORIRA]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.WANI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.WANI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAGA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.ZYAGA]--;
                InNestList.Remove(other.gameObject);
            }
            //-------------------------------------------------------------------------------------
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HARINEZUMI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.HARINEZUMI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ARUMAZIRO)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.ARUMAZIRO]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAKUDA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.RAKUDA]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAUMA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SHIMAUMA]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SABARU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SABARU]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKKARU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.ZYAKKARU]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KABA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.KABA]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SAI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SAI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZOU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.ZOU]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAION)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.RAION]--;
                InNestList.Remove(other.gameObject);
            }
            //--------------------------------------------------------------------------------
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.PENGIN)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.PENGIN]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.AZARASHI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.AZARASHI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TONAKAI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.TONAKAI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKOUUSHI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.ZYAKOUUSHI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUKITUNE)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.HOKKYOKUKITUNE]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIROHUKUROU)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SHIROHUKUROU]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.KUZURI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.KUZURI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.TUNDORAOOKAMI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.TUNDORAOOKAMI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.SEIUTI)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.SEIUTI]--;
                InNestList.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUGUMA)
            {
                m_NestNameCount[(int)CGameObject.NestNumber.HOKKYOKUGUMA]--;
                InNestList.Remove(other.gameObject);
            }
        }
    }

    public void NestMinus(int num,GameObject obj)
    {
        m_NestNameCount[num - 1]--;
        InNestList.Remove(obj);
    }

    public void ResetList()   //?I?u?W?F?N?g?????????????X?g???????????????Z?b?g??????
    {
        for (int i = 0; i < InNestList.Count; i++)
        {
            CNestCount script = InNestList[i].GetComponent<CNestCount>();
            script.NestMinus(m_NestScript.GetNestNumAll(),this.gameObject);
        }
        InNestList.Clear();
    }
}
