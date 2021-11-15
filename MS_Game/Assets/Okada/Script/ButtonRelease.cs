using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CGameObject;

public class ButtonRelease : MonoBehaviour
{
    [SerializeField] private AnimalNestData m_NestData;
    private CGameObject m_CGameObj;

    [SerializeField] private GameObject[] m_NestButtonObject = new GameObject[(int)NestNumber.NESTMAX];
    private Button[] m_NestButton = new Button[(int)NestNumber.NESTMAX];
    [SerializeField] private bool[] m_NestActive = new bool[(int)NestNumber.NESTMAX];

    private void Start()
    {
        m_CGameObj = gameObject.GetComponent<CGameObject>();

        for (int i = 0; i < 40; i++)
        {
            m_NestButton[i] = m_NestButtonObject[i].gameObject.GetComponent<Button>();
            m_NestButton[i].interactable = m_NestActive[i];
        }
    }
    private void Update()
    {
        //‰·‘Ñ‰ð•ú
        //10–¢ŽÀ‘•
        if (m_CGameObj.m_TreeBigCount >= 1 && m_CGameObj.m_TreeSmallCount >= 1)
            m_NestActive[(int)NestNumber.HATUKANEZUMI] = true;

        if (m_CGameObj.m_TreeBigCount >= 5)
            m_NestActive[(int)NestNumber.AMAKAERU] = true;
        
        if (m_CGameObj.m_TreeSmallCount >= 5)
            m_NestActive[(int)NestNumber.SHIMAHEBI] = true;
        
        if (m_CGameObj.m_TreeBigCount >= 10)
            m_NestActive[(int)NestNumber.RESSAPANDA] = true;
        
        if (m_CGameObj.m_TreeSmallCount >= 10)
            m_NestActive[(int)NestNumber.NIHONNITATI] = true;
        
        if (m_CGameObj.m_TreeBigCount >= 30)
            m_NestActive[(int)NestNumber.YAMAINU] = true;
        
        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.SAKURA] >= 50)
            m_NestActive[(int)NestNumber.OOTAKA] = true;

        if (m_CGameObj.m_NestNameCount[(int)NestNumber.HATUKANEZUMI] >= 10)
            m_NestActive[(int)NestNumber.HUKUROU] = true;

        if (m_CGameObj.m_TreeBigCount >= 300 && m_CGameObj.m_TreeSmallCount >= 300)
            m_NestActive[(int)NestNumber.GURIZURI] = true;

        //”M‘Ñ‰ð•ú
        //7–¢ŽÀ‘•
        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.RATANNYASHI] >= 1)
            m_NestActive[(int)NestNumber.SYOUGARAGO] = true;

        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.KAPOKKU] >= 3
            && m_CGameObj.m_TreeNameCount[(int)TreeNumber.MAHOGANI] >= 3
            &&m_CGameObj.m_TreeNameCount[(int)TreeNumber.ASAIYASI] >= 3)
                m_NestActive[(int)NestNumber.KAPIBARA] = true;

        if (m_CGameObj.m_TreeBigCount >= 50)
            m_NestActive[(int)NestNumber.KOARA] = true;

        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.RATANNYASHI] >= 10
            && m_CGameObj.m_TreeNameCount[(int)TreeNumber.ASERORA] >= 10
            && m_CGameObj.m_TreeNameCount[(int)TreeNumber.SATOUKIBI] >= 10)
                m_NestActive[(int)NestNumber.WONBATTO] = true;

        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.KOHINOKI] >= 15
            && m_CGameObj.m_TreeNameCount[(int)TreeNumber.RAHURESHIA] >= 15)
            m_NestActive[(int)NestNumber.OOARIKUI] = true;

        if (m_CGameObj.m_NestNameCount[(int)NestNumber.WONBATTO] >= 3)
            m_NestActive[(int)NestNumber.TASUMANIADEBIRU] = true;


        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.KAPOKKU] >= 20
            && m_CGameObj.m_TreeNameCount[(int)TreeNumber.MAHOGANI] >= 20
            && m_CGameObj.m_TreeNameCount[(int)TreeNumber.ASAIYASI] >= 20
            && m_CGameObj.m_TreeNameCount[(int)TreeNumber.TOWARAN] >= 20
            && m_CGameObj.m_TreeNameCount[(int)TreeNumber.WOKINGUPAMU] >= 20)
                m_NestActive[(int)NestNumber.GORIRA] = true;

        if (m_CGameObj.m_NestNameCount[(int)NestNumber.GORIRA] >= 10)
            m_NestActive[(int)NestNumber.WANI] = true;

        if (m_CGameObj.m_NestNameCount[(int)NestNumber.WANI] >= 10)
            m_NestActive[(int)NestNumber.ZYAGA] = true;

        //Š£‘‡‘Ñ‰ð•ú
        //1E10–¢ŽÀ‘•
        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.SABOTEN] >= 5
            && m_CGameObj.m_TreeNameCount[(int)TreeNumber.ENOKOROGUSA] >= 5)
              m_NestActive[(int)NestNumber.ARUMAZIRO] = true;

        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.SABOTEN] >= 20)
            m_NestActive[(int)NestNumber.RAKUDA] = true;

        if (m_CGameObj.m_TreeSmallCount >= 100)
            m_NestActive[(int)NestNumber.SHIMAUMA] = true;

        if (m_CGameObj.m_NestNameCount[(int)NestNumber.HARINEZUMI] >= 3)
            m_NestActive[(int)NestNumber.SABARU] = true;

        if (m_CGameObj.m_NestNameCount[(int)NestNumber.ARUMAZIRO] >= 5)
            m_NestActive[(int)NestNumber.ZYAKKARU] = true;

        if (m_CGameObj.m_TreeBigCount >= 400 && m_CGameObj.m_TreeSmallCount >= 400)
            m_NestActive[(int)NestNumber.KABA] = true;

        if (m_CGameObj.m_TreeSmallCount >= 400)
            m_NestActive[(int)NestNumber.SAI] = true;

        if (m_CGameObj.m_TreeBigCount >= 500 && m_CGameObj.m_TreeSmallCount >= 500)
            m_NestActive[(int)NestNumber.ZOU] = true;



        //Š¦‘Ñ‰ð•ú
        //1E10–¢ŽÀ‘•
        if (m_CGameObj.m_NestNameCount[(int)NestNumber.PENGIN] >= 3)
            m_NestActive[(int)NestNumber.AZARASHI] = true;

        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.MIZUGOKE] >= 20)
            m_NestActive[(int)NestNumber.TONAKAI] = true;

        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.HISU] >= 15)
            m_NestActive[(int)NestNumber.ZYAKOUUSHI] = true;

        if (m_CGameObj.m_TreeBigCount >= 100)
            m_NestActive[(int)NestNumber.HOKKYOKUKITUNE] = true;

        if (m_CGameObj.m_TreeNameCount[(int)TreeNumber.DAKEMOMI] >= 30)
            m_NestActive[(int)NestNumber.SHIROHUKUROU] = true;

        if (m_CGameObj.m_NestNameCount[(int)NestNumber.TONAKAI] >= 10)
            m_NestActive[(int)NestNumber.KUZURI] = true;

        if (m_CGameObj.m_NestNameCount[(int)NestNumber.TONAKAI] >= 15
            && m_CGameObj.m_NestNameCount[(int)NestNumber.ZYAKOUUSHI] >= 15)
            m_NestActive[(int)NestNumber.TUNDORAOOKAMI] = true;

        if (m_CGameObj.m_NestNameCount[(int)NestNumber.PENGIN] >= 15
            && m_CGameObj.m_NestNameCount[(int)NestNumber.AZARASHI] >= 15)
            m_NestActive[(int)NestNumber.SEIUTI] = true;


        for (int i = 0; i < (int)NestNumber.NESTMAX; i++)
        {
            m_NestButton[i].interactable = m_NestActive[i];

        }
    }


}