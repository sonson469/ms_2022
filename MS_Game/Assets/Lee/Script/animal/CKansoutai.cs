using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKansoutai : CAnimalCreate
{
    [SerializeField] private int[] m_TreeCount = new int[10];
    private CNestCount m_NestCountScript;

    [SerializeField] private GameObject m_DesObj;

    // Start is called before the first frame update
    public new void Start()
    {
        m_NestScript = m_MyNest.gameObject.GetComponent<CNest>();
        m_Manager = GameObject.FindWithTag("Manager");
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();
        m_GameObjectScript = m_Manager.GetComponent<CGameObject>();
        m_NestCountScript = this.gameObject.GetComponent<CNestCount>();

        m_DesObj = this.gameObject.transform.GetChild(2).gameObject;

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

        //------------------------------------------------------------------
        // ������ق�
        //------------------------------------------------------------------
        if (m_NestCountScript.GetPut() && m_NestScript.GetNowZone() == m_NestScript.GetClimate() && m_MyAnimalList.Count <= m_MaxAnimal)
        {
            int count = 0;
            if (m_NestScript.GetNestNum() % 2 == 1)
            {
                for (int i = 21; i < m_NestScript.GetNestNum() + 20; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i - 1];
                }
            }
            else if (m_NestScript.GetNestNum() % 2 == 0)
            {
                for (int i = 21; i < (m_NestScript.GetNestNum() + 20) - 1; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i - 1];
                }
            }

            if (m_NestScript.GetNestNum() == 1 || m_NestScript.GetNestNum() == 2)
            {
                if (m_TreeCount[0] >= 7)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                }

                if (m_TreeCount[5] >= 7)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                }
            }
            else if (m_NestScript.GetNestNum() == 3 || m_NestScript.GetNestNum() == 4)
            {
                if (m_TreeCount[1] >= 6 && count >= 1)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                }

                if (m_TreeCount[6] >= 6)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                }
            }
            else if (m_NestScript.GetNestNum() == 5 || m_NestScript.GetNestNum() == 6)
            {
                if (m_TreeCount[2] >= 5 && count >= 1)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                }

                if (m_TreeCount[7] >= 5)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                }

            }
            else if (m_NestScript.GetNestNum() == 7 || m_NestScript.GetNestNum() == 8)
            {
                if (m_TreeCount[3] >= 4 && count >= 1)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                }

                if (m_TreeCount[8] >= 4)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                }
            }
            else if (m_NestScript.GetNestNum() == 9 || m_NestScript.GetNestNum() == 10)
            {
                if (m_TreeCount[4] >= 3 && count >= 1)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                }

                if (m_TreeCount[9] >= 3)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 3);
                }

            }
        }

        //------------------------------------------------------------------
        // ����ق�
        //------------------------------------------------------------------
        int descount = 0;
        if (m_NestScript.GetNestNum() % 2 == 1)
        {
            for (int i = m_NestScript.GetNestNum() + 22; i <= 30; i++)
            {
                descount += m_NestCountScript.m_NestNameCount[i - 1];
            }
        }
        else if (m_NestScript.GetNestNum() % 2 == 0)
        {
            for (int i = m_NestScript.GetNestNum() + 21; i <= 30; i++)
            {
                descount += m_NestCountScript.m_NestNameCount[i - 1];
            }
        }

        ReduceMyList(descount);
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

    private void ReduceMyList(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            if (m_MyAnimalList.Count >= 1)
            {
                Destroy(m_MyAnimalList[m_MyAnimalList.Count - 1]);
                m_MyAnimalList.RemoveAt(m_MyAnimalList.Count - 1);
            }
        }
    }

    public void DesAnimal()
    {
        for (int i = 0; i < m_MyAnimalList.Count; i++)
        {
            Destroy(m_MyAnimalList[i]);
        }
        m_MyAnimalList.Clear();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ONTAI")
        {
            m_NestScript.SetNowZone(CNest.Climate.ONTAI);
        }
        else if (other.gameObject.tag == "NETTAI")
        {
            m_NestScript.SetNowZone(CNest.Climate.NETTAI);
        }
        else if (other.gameObject.tag == "KANSOUTAI")
        {
            m_NestScript.SetNowZone(CNest.Climate.KANSOUTAI);
        }
        else if (other.gameObject.tag == "KANTAI")
        {
            m_NestScript.SetNowZone(CNest.Climate.KANTAI);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Machine")
        {
            m_NestScript.SetNowZone(CNest.Climate.NONE);
        }
    }
}
