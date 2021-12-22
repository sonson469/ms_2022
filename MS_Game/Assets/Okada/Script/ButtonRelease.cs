using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static CGameObject;

public class ButtonRelease : MonoBehaviour
{
    private CGameObject m_CGameObj;

    [SerializeField] private GameObject[] m_NestButtonObject = new GameObject[(int)NestNumber.NESTMAX];
    private Button[] m_NestButton = new Button[(int)NestNumber.NESTMAX];
    [SerializeField] private bool[] m_NestActive = new bool[(int)NestNumber.NESTMAX];

    [SerializeField] private GameObject[] m_Zukan = new GameObject[(int)NestNumber.NESTMAX];

    private CGameTimeManager m_TimeManager;

    private void Start()
    {
        m_CGameObj = gameObject.GetComponent<CGameObject>();
        m_TimeManager = GetComponent<CGameTimeManager>();

        for (int i = 0; i < 40; i++)
        {
            m_Zukan[i].SetActive(true);
            m_NestButton[i] = m_NestButtonObject[i].gameObject.GetComponent<Button>();
            //m_NestActive[i] = true;
            m_NestButton[i].interactable = m_NestActive[i];
        }
    }
    private void Update()
    {
        //‰·‘Ñ‰ð•ú

        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.YATUDE] >= 1)
            m_NestActive[(int)NestNumber.HATUKANEZUMI] = true;

        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.KEYAKI] >= 1)
            m_NestActive[(int)NestNumber.AMAKAERU] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.HATUKANEZUMI].Count >= 1 && m_CGameObj.AnimalList[(int)AnimalNumber.AMAKAERU].Count >= 5)
            m_NestActive[(int)NestNumber.SHIMAHEBI] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.HATUKANEZUMI].Count >= 5 && m_CGameObj.AnimalList[(int)AnimalNumber.AMAKAERU].Count >= 1)
            m_NestActive[(int)NestNumber.RESSAPANDA] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.SHIMAHEBI].Count >= 5 && m_CGameObj.AnimalList[(int)AnimalNumber.RESSAPANDA].Count >= 1)
            m_NestActive[(int)NestNumber.NIHONNITATI] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.SHIMAHEBI].Count >= 1 && m_CGameObj.AnimalList[(int)AnimalNumber.RESSAPANDA].Count >= 5)
            m_NestActive[(int)NestNumber.YAMAINU] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.NIHONNITATI].Count >= 1 && m_CGameObj.AnimalList[(int)AnimalNumber.YAMAINU].Count >= 5)
            m_NestActive[(int)NestNumber.OOTAKA] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.NIHONNITATI].Count >= 5 && m_CGameObj.AnimalList[(int)AnimalNumber.YAMAINU].Count >= 1)
            m_NestActive[(int)NestNumber.HUKUROU] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.HATUKANEZUMI].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.SHIMAHEBI].Count >= 10
            && m_CGameObj.AnimalList[(int)AnimalNumber.NIHONNITATI].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.OOTAKA].Count >= 10)
            m_NestActive[(int)NestNumber.GURIZURI] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.HATUKANEZUMI].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.SHIMAHEBI].Count >= 10
            && m_CGameObj.AnimalList[(int)AnimalNumber.NIHONNITATI].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.OOTAKA].Count >= 10)
            m_NestActive[(int)NestNumber.TORA] = true;


        //”M‘Ñ‰ð•ú
        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.RATANNYASHI] >= 1)
            m_NestActive[(int)NestNumber.SYOUGARAGO] = true;

        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.KAPOKKU] >= 1)
            m_NestActive[(int)NestNumber.KAPIBARA] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.SYOUGARAGO].Count >= 1 && m_CGameObj.AnimalList[(int)AnimalNumber.KAPIBARA].Count >= 5)
            m_NestActive[(int)NestNumber.KOARA] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.SYOUGARAGO].Count >= 5 && m_CGameObj.AnimalList[(int)AnimalNumber.KAPIBARA].Count >= 1)
            m_NestActive[(int)NestNumber.WONBATTO] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.KOARA].Count >= 5 && m_CGameObj.AnimalList[(int)AnimalNumber.WONBATTO].Count >= 1)
            m_NestActive[(int)NestNumber.OOARIKUI] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.KOARA].Count >= 1 && m_CGameObj.AnimalList[(int)AnimalNumber.WONBATTO].Count >= 5)
            m_NestActive[(int)NestNumber.TASUMANIADEBIRU] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.OOARIKUI].Count >= 1 && m_CGameObj.AnimalList[(int)AnimalNumber.TASUMANIADEBIRU].Count >= 5)
            m_NestActive[(int)NestNumber.OOKOUMORI] = true;


        if (m_CGameObj.AnimalList[(int)AnimalNumber.OOARIKUI].Count >= 5 && m_CGameObj.AnimalList[(int)AnimalNumber.TASUMANIADEBIRU].Count >= 1)
            m_NestActive[(int)NestNumber.GORIRA] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.SYOUGARAGO].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.KOARA].Count >= 10
            && m_CGameObj.AnimalList[(int)AnimalNumber.OOARIKUI].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.OOKOUMORI].Count >= 10)
            m_NestActive[(int)NestNumber.WANI] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.KAPIBARA].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.WONBATTO].Count >= 10
            && m_CGameObj.AnimalList[(int)AnimalNumber.TASUMANIADEBIRU].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.GORIRA].Count >= 10)
            m_NestActive[(int)NestNumber.ZYAGA] = true;


        //Š£‘‡‘Ñ‰ð•ú
        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.SABOTEN] >= 1)
            m_NestActive[(int)NestNumber.HARINEZUMI] = true;

        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.NATUMEYASHI] >= 1)
            m_NestActive[(int)NestNumber.ARUMAZIRO] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.HARINEZUMI].Count >= 1 && m_CGameObj.AnimalList[(int)AnimalNumber.ARUMAZIRO].Count >= 5)
            m_NestActive[(int)NestNumber.RAKUDA] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.HARINEZUMI].Count >= 5 && m_CGameObj.AnimalList[(int)AnimalNumber.ARUMAZIRO].Count >= 1)
            m_NestActive[(int)NestNumber.SHIMAUMA] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.RAKUDA].Count >= 5 && m_CGameObj.AnimalList[(int)AnimalNumber.SHIMAUMA].Count >= 1)
            m_NestActive[(int)NestNumber.SABARU] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.RAKUDA].Count >= 1 && m_CGameObj.AnimalList[(int)AnimalNumber.SHIMAUMA].Count >= 5)
            m_NestActive[(int)NestNumber.ZYAKKARU] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.SABARU].Count >= 1 && m_CGameObj.AnimalList[(int)AnimalNumber.ZYAKKARU].Count >= 5)
            m_NestActive[(int)NestNumber.KABA] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.SABARU].Count >= 5 && m_CGameObj.AnimalList[(int)AnimalNumber.ZYAKKARU].Count >= 1)
            m_NestActive[(int)NestNumber.SAI] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.HARINEZUMI].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.RAKUDA].Count >= 10
            && m_CGameObj.AnimalList[(int)AnimalNumber.SABARU].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.KABA].Count >= 10)
            m_NestActive[(int)NestNumber.ZOU] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.ARUMAZIRO].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.SHIMAUMA].Count >= 10
            && m_CGameObj.AnimalList[(int)AnimalNumber.ZYAKKARU].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.SAI].Count >= 10)
            m_NestActive[(int)NestNumber.RAION] = true;


        //Š¦‘Ñ‰ð•ú
        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.MIZUGOKE] >= 1)
            m_NestActive[(int)NestNumber.PENGIN] = true;

        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.DAKEKANBA] >= 1)
            m_NestActive[(int)NestNumber.AZARASHI] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.PENGIN].Count >= 1 && m_CGameObj.AnimalList[(int)AnimalNumber.AZARASHI].Count >= 5)
            m_NestActive[(int)NestNumber.TONAKAI] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.PENGIN].Count >= 5 && m_CGameObj.AnimalList[(int)AnimalNumber.AZARASHI].Count >= 1)
            m_NestActive[(int)NestNumber.ZYAKOUUSHI] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.TONAKAI].Count >= 5 && m_CGameObj.AnimalList[(int)AnimalNumber.ZYAKOUUSHI].Count >= 1)
            m_NestActive[(int)NestNumber.HOKKYOKUKITUNE] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.TONAKAI].Count >= 1 && m_CGameObj.AnimalList[(int)AnimalNumber.ZYAKOUUSHI].Count >= 5)
            m_NestActive[(int)NestNumber.SHIROHUKUROU] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.HOKKYOKUKITUNE].Count >= 1 && m_CGameObj.AnimalList[(int)AnimalNumber.SHIROHUKUROU].Count >= 5)
            m_NestActive[(int)NestNumber.KUZURI] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.HOKKYOKUKITUNE].Count >= 5 && m_CGameObj.AnimalList[(int)AnimalNumber.SHIROHUKUROU].Count >= 1)
            m_NestActive[(int)NestNumber.TUNDORAOOKAMI] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.PENGIN].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.TONAKAI].Count >= 10
            && m_CGameObj.AnimalList[(int)AnimalNumber.HOKKYOKUKITUNE].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.KUZURI].Count >= 10)
            m_NestActive[(int)NestNumber.SEIUTI] = true;

        if (m_CGameObj.AnimalList[(int)AnimalNumber.AZARASHI].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.ZYAKOUUSHI].Count >= 10
            && m_CGameObj.AnimalList[(int)AnimalNumber.SHIROHUKUROU].Count >= 10 && m_CGameObj.AnimalList[(int)AnimalNumber.TUNDORAOOKAMI].Count >= 10)
            m_NestActive[(int)NestNumber.HOKKYOKUGUMA] = true;

        for (int i = 0; i < 40; i++)
        {
            if(m_NestActive[i])
            {
                m_Zukan[i].SetActive(false);
            }
        }

            for (int i = 0; i < 40; i++)
        {
            m_NestButton[i].interactable = m_NestActive[i];
        }
    }


}