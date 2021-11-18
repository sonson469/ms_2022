using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherHerbivore : CAnimalCreate
{

    private CNestCount m_NestCountScript;
    // Start is called before the first frame update
    public new void Start()
    {
        m_NestScript = m_MyNest.gameObject.GetComponent<CNest>();
        m_Manager = GameObject.FindWithTag("Manager");
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();
        m_MyObject = this.gameObject;
        m_NestCountScript = this.gameObject.GetComponent<CNestCount>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TimeManager.GetDayEnd())
        {
            NestAnimal();
            m_TimeManager.AddNestCount();
        }
    }

    public override void NestAnimal()
    {

        int recount = 0;

        if (m_NestScript.GetTreeBig() + m_NestScript.GetTreeSmall() >= 5)
        {
            CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(),2);
            CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(),2);
            CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(),2);
        }
        else if (m_NestScript.GetTreeBig() + m_NestScript.GetTreeSmall() >= 3)
        {
            CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(),2);
        }

        if (m_NestScript.GetClimate() == CNest.Climate.ONTAI)
        {
        }
        else if (m_NestScript.GetClimate() == CNest.Climate.NETTAI)
        {

            //ゴリラ
            if (m_NestScript.GetNestNum() == 8)
            {
               
                for (int i = 18; i <= 19; i++)
                {
                    recount += m_NestCountScript.m_NestNameCount[i];
                }
                ReduceMyList(recount);
            }

        }
        else if (m_NestScript.GetClimate() == CNest.Climate.KANSOUTAI)
        {
            //カバ、サイ
            if (m_NestScript.GetNestNum() == 7 || m_NestScript.GetNestNum() == 8)
            {
                for (int i = 28; i <= 29; i++)
                {
                    recount += m_NestCountScript.m_NestNameCount[i];
                }
                ReduceMyList(recount);
            }

        }
        else if (m_NestScript.GetClimate() == CNest.Climate.KANTAI)
        {
            
        }
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

    public void AddMyList(GameObject animal)
    {
        m_MyAnimalList.Add(animal);
    }
}
