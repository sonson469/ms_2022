using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CGameObject;

public class ButtonRe : MonoBehaviour
{
    [SerializeField] private AnimalNestData m_NestData;
    private CGameObject m_CGameObj;

    private GameObject[] m_NestButtonObject = new GameObject[(int)NestNumber.NESTMAX];
    private Button[] m_NestButton = new Button[(int)NestNumber.NESTMAX];
    private bool[] m_NestActive = new bool[(int)NestNumber.NESTMAX];

    private void Start()
    {
        m_CGameObj = gameObject.GetComponent<CGameObject>();

        for (int i = 0; i < (int)NestNumber.NESTMAX; i++)
        {
            m_NestButtonObject[i] = GameObject.Find(m_NestData.sheets[0].list[i].Name + "ƒ{ƒ^ƒ“");
            m_NestButton[i] = m_NestButtonObject[i].gameObject.GetComponent<Button>();

            m_NestButton[i].interactable = m_NestActive[i];

        }
    }
    private void Update()
    {
        if (m_CGameObj.m_TreeBigCount >= 1 && m_CGameObj.m_TreeSmallCount >= 1)
        {
            m_NestActive[(int)NestNumber.HARINEZUMI] = true;
        }
        if (m_CGameObj.m_TreeBigCount >= 5)
        {
            m_NestActive[(int)NestNumber.AMAKAERU] = true;
        }

        for (int i = 0; i < (int)NestNumber.NESTMAX; i++)
        {
            m_NestButton[i].interactable = m_NestActive[i];

        }

    }
}
