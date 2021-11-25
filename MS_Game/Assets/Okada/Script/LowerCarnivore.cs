using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerCarnivore : CAnimalCreate
{

    [SerializeField] private CNestCount m_NestCountScript;

    // Start is called before the first frame update
    public new void Start()
    {
        m_NestScript = m_MyNest.gameObject.GetComponent<CNest>();
        m_NestCountScript = this.gameObject.GetComponent<CNestCount>();
        m_Manager = GameObject.FindWithTag("Manager");
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();

        m_MyObject = this.gameObject;
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

        int count = 0;
        int recount = 0;
        if (m_NestScript.GetNowZone() == m_NestScript.GetClimate())
        {
            if (m_NestScript.GetClimate() == CNest.Climate.ONTAI)
            {
                //シマヘビ
                if (m_NestScript.GetNestNum() == 3)
                {
                    for (int i = 0; i <= 1; i++)
                    {
                        count += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    Make(count);
                    for (int i = 4; i <= 9; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }
                //ニホンイタチ、ヤマイヌ
                else if (m_NestScript.GetNestNum() == 5 || m_NestScript.GetNestNum() == 6)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        count += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    Make(count);
                    for (int i = 6; i <= 9; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }
            }
            else if (m_NestScript.GetClimate() == CNest.Climate.NETTAI)
            {

                //タスマニアデビル
                if (m_NestScript.GetNestNum() == 6)
                {
                    for (int i = 10; i <= 13; i++)
                    {
                        count += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    Make(count);
                    for (int i = 16; i <= 19; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }

            }
            else if (m_NestScript.GetClimate() == CNest.Climate.KANSOUTAI)
            {
                //サーバル、ジャッカル
                if (m_NestScript.GetNestNum() == 5 || m_NestScript.GetNestNum() == 6)
                {
                    for (int i = 20; i <= 23; i++)
                    {
                        count += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    Make(count);
                    for (int i = 26; i <= 29; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }

            }
            else if (m_NestScript.GetClimate() == CNest.Climate.KANTAI)
            {
                //ホッキョクキツネ、シロフクロウ
                if (m_NestScript.GetNestNum() == 5 || m_NestScript.GetNestNum() == 6)
                {
                    for (int i = 30; i <= 33; i++)
                    {
                        count += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    Make(count);
                    for (int i = 36; i <= 39; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }
            }
        }
    }

    private void Make(int count)
    {
        if (count >= 1)
        {
            CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(),3);
            CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(),3);
        }
    }

    public void ReduceMyList(int count)
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
