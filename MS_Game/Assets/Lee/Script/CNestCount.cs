using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNestCount : MonoBehaviour
{

    public int[] m_NestNameCount = new int[(int)CGameObject.NestNumber.NESTMAX];

    [SerializeField] private AnimalNestData m_NestData;

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

        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HATUKANEZUMI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.HATUKANEZUMI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.AMAKAERU)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.AMAKAERU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAHEBI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.SHIMAHEBI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RESSAPANDA)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.RESSAPANDA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.NIHONNITATI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.NIHONNITATI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.YAMAINU)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.YAMAINU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOTAKA)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.OOTAKA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HUKUROU)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.HUKUROU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.GURIZURI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.GURIZURI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.TORA)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.TORA]++;
        }
        //---------------------------------------------------------------------------------
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SYOUGARAGO)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.SYOUGARAGO]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KAPIBARA)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.KAPIBARA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KOARA)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.KOARA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.WONBATTO)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.WONBATTO]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOARIKUI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.OOARIKUI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.TASUMANIADEBIRU)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.TASUMANIADEBIRU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.OOKOUMORI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.OOKOUMORI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.GORIRA)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.GORIRA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.WANI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.WANI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAGA)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.ZYAGA]++;
        }
        //-------------------------------------------------------------------------------------
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HARINEZUMI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.HARINEZUMI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ARUMAZIRO)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.ARUMAZIRO]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAKUDA)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.RAKUDA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIMAUMA)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.SHIMAUMA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SABARU)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.SABARU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKKARU)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.ZYAKKARU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KABA)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.KABA]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SAI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.SAI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZOU)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.ZOU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.RAION)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.RAION]++;
        }
        //--------------------------------------------------------------------------------
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.PENGIN)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.PENGIN]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.AZARASHI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.AZARASHI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.TONAKAI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.TONAKAI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.ZYAKOUUSHI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.ZYAKOUUSHI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUKITUNE)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.HOKKYOKUKITUNE]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SHIROHUKUROU)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.SHIROHUKUROU]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.KUZURI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.KUZURI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.TUNDORAOOKAMI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.TUNDORAOOKAMI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.SEIUTI)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.SEIUTI]++;
        }
        if (other.gameObject.tag == "n" + CGameObject.NestNumber.HOKKYOKUGUMA)
        {
            m_NestNameCount[(int)CGameObject.NestNumber.HOKKYOKUGUMA]++;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < (int)CGameObject.NestNumber.NESTMAX; i++)
        {
            if (other.gameObject.tag == "n" + m_NestData.sheets[0].list[i].Name)
            {
                m_NestNameCount[i]++;
            }
        }
    }
}
