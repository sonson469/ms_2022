using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNettai : CAnimalCreate
{
    [SerializeField] private int[] m_TreeCount = new int[10];
    private CNestCount m_NestCountScript;

    // Start is called before the first frame update
    public new void Start()
    {
        m_NestScript = m_MyNest.gameObject.GetComponent<CNest>();
        m_Manager = GameObject.FindWithTag("Manager");
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();
        m_GameObjectScript = m_Manager.GetComponent<CGameObject>();
        m_NestCountScript = this.gameObject.GetComponent<CNestCount>();

        m_MyObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (m_TimeManager.GetDayEnd())
        {
            NestAnimal();
        }

    }

    public override void NestAnimal()
    {
        if (m_NestCountScript.GetPut() && m_NestScript.GetNowZone() == m_NestScript.GetClimate() && m_MyAnimalList.Count <= 10)
        {
            int count = 0;
            if (m_NestScript.GetNestNum() % 2 == 1)
            {
                for (int i = 11; i < m_NestScript.GetNestNum() + 10; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i - 1];
                }
            }
            else if (m_NestScript.GetNestNum() % 2 == 0)
            {
                for (int i = 11; i < (m_NestScript.GetNestNum() + 10) - 1; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i - 1];
                }
            }

            if (m_NestScript.GetNestNum() == 1 || m_NestScript.GetNestNum() == 2)
            {
                if (m_TreeCount[0] >= 7)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                }

                if (m_TreeCount[5] >= 7)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                }
            }
            else if (m_NestScript.GetNestNum() == 3 || m_NestScript.GetNestNum() == 4)
            {
                if (m_TreeCount[1] >= 6 && count >= 1)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                }

                if (m_TreeCount[6] >= 6)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                }
            }
            else if (m_NestScript.GetNestNum() == 5 || m_NestScript.GetNestNum() == 6)
            {
                if (m_TreeCount[2] >= 5 && count >= 1)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                }

                if (m_TreeCount[7] >= 5)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                }

            }
            else if (m_NestScript.GetNestNum() == 7 || m_NestScript.GetNestNum() == 8)
            {
                if (m_TreeCount[3] >= 4 && count >= 1)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                }

                if (m_TreeCount[8] >= 4)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                }
            }
            else if (m_NestScript.GetNestNum() == 9 || m_NestScript.GetNestNum() == 10)
            {
                if (m_TreeCount[4] >= 3 && count >= 1)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                }

                if (m_TreeCount[9] >= 3)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 2);
                }

            }
        }
    }

    public void TreeCount(int num)
    {
        m_TreeCount[num]++;
    }

    public void TreeMinus(int num)
    {
        m_TreeCount[num]--;
    }

    public void AddMyList(GameObject animal)
    {
        m_MyAnimalList.Add(animal);
        m_GameObjectScript.AnimalList[m_NestScript.GetNestNum() - 1].Add(animal);
    }
}