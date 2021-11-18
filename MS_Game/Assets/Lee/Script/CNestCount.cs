using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNestCount : MonoBehaviour
{

    public int[] m_NestNameCount = new int[(int)CGameObject.NestNumber.NESTMAX];
    public int[] m_NewNestNameCount = new int[(int)CGameObject.NestNumber.NESTMAX];

    [SerializeField] private AnimalNestData m_NestData;

    private GameObject m_Manager;
    private CButtonClick m_ButtonScript;
    private CObjectMove m_ObjMoveScript;

    // Start is called before the first frame update
    void Start()
    {
        m_Manager = GameObject.FindWithTag("Manager");
        m_ButtonScript = m_Manager.GetComponent<CButtonClick>();
        m_ObjMoveScript = m_Manager.GetComponent<CObjectMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_ButtonScript.GetNestBreake())
        {
            for(int i = 0; i < (int)CGameObject.NestNumber.NESTMAX;i++)
            {
                m_NewNestNameCount[i] = 0;
            }
            m_ButtonScript.SetNestBreake(false);
        }
        if(m_ObjMoveScript.GetOnOjb())
        {
            for (int i = 0; i < (int)CGameObject.NestNumber.NESTMAX; i++)
            {
                m_NestNameCount[i] = m_NestNameCount[i] + m_NewNestNameCount[i];
                m_NewNestNameCount[i] = 0;
            }
            m_ObjMoveScript.SetOnObj(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HATUKANEZUMI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.HATUKANEZUMI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.AMAKAERU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.AMAKAERU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAHEBI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SHIMAHEBI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RESSAPANDA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.RESSAPANDA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.NIHONNITATI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.NIHONNITATI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.YAMAINU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.YAMAINU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOTAKA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.OOTAKA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HUKUROU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.HUKUROU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.GURIZURI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.GURIZURI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.TORA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.TORA]++;
        }
        //---------------------------------------------------------------------------------
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SYOUGARAGO)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SYOUGARAGO]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KAPIBARA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.KAPIBARA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KOARA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.KOARA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.WONBATTO)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.WONBATTO]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOARIKUI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.OOARIKUI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.TASUMANIADEBIRU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.TASUMANIADEBIRU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOKOUMORI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.OOKOUMORI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.GORIRA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.GORIRA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.WANI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.WANI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAGA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.ZYAGA]++;
        }
        //-------------------------------------------------------------------------------------
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HARINEZUMI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.HARINEZUMI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ARUMAZIRO)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.ARUMAZIRO]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAKUDA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.RAKUDA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAUMA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SHIMAUMA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SABARU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SABARU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKKARU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.ZYAKKARU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KABA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.KABA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SAI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SAI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZOU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.ZOU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAION)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.RAION]++;
        }
        //--------------------------------------------------------------------------------
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.PENGIN)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.PENGIN]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.AZARASHI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.AZARASHI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.TONAKAI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.TONAKAI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKOUUSHI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.ZYAKOUUSHI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUKITUNE)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.HOKKYOKUKITUNE]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIROHUKUROU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SHIROHUKUROU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KUZURI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.KUZURI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.TUNDORAOOKAMI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.TUNDORAOOKAMI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SEIUTI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SEIUTI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUGUMA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.HOKKYOKUGUMA]++;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HATUKANEZUMI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.HATUKANEZUMI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.AMAKAERU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.AMAKAERU]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAHEBI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SHIMAHEBI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RESSAPANDA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.RESSAPANDA]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.NIHONNITATI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.NIHONNITATI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.YAMAINU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.YAMAINU]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOTAKA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.OOTAKA]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HUKUROU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.HUKUROU]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.GURIZURI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.GURIZURI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.TORA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.TORA]--;
        }
        //---------------------------------------------------------------------------------
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SYOUGARAGO)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SYOUGARAGO]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KAPIBARA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.KAPIBARA]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KOARA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.KOARA]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.WONBATTO)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.WONBATTO]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOARIKUI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.OOARIKUI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.TASUMANIADEBIRU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.TASUMANIADEBIRU]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOKOUMORI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.OOKOUMORI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.GORIRA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.GORIRA]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.WANI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.WANI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAGA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.ZYAGA]--;
        }
        //-------------------------------------------------------------------------------------
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HARINEZUMI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.HARINEZUMI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ARUMAZIRO)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.ARUMAZIRO]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAKUDA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.RAKUDA]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAUMA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SHIMAUMA]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SABARU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SABARU]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKKARU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.ZYAKKARU]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KABA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.KABA]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SAI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SAI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZOU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.ZOU]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAION)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.RAION]--;
        }
        //--------------------------------------------------------------------------------
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.PENGIN)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.PENGIN]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.AZARASHI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.AZARASHI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.TONAKAI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.TONAKAI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKOUUSHI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.ZYAKOUUSHI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUKITUNE)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.HOKKYOKUKITUNE]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIROHUKUROU)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SHIROHUKUROU]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KUZURI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.KUZURI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.TUNDORAOOKAMI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.TUNDORAOOKAMI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SEIUTI)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.SEIUTI]--;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUGUMA)
        {
            m_NewNestNameCount[(int)CGameObject.NestNumber.HOKKYOKUGUMA]--;
        }
    }
}
