using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherCarnivore : CAnimalCreate
{

    private CNestCount m_NestCountScript;

    // Start is called before the first frame update
    public new void Start()
    {
        m_NestScript = m_MyNest.gameObject.GetComponent<CNest>();
        m_NestCountScript = this.gameObject.GetComponent<CNestCount>();
        m_Manager = GameObject.FindWithTag("Manager");
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();
    }

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

        if (m_NestScript.GetClimate() == CNest.Climate.ONTAI)
        {
            //オオタカ、フクロウ
            if (m_NestScript.GetNestNum() == 7 || m_NestScript.GetNestNum() == 8)
            {
                for (int i = 0; i <= 5; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i];
                }
                Make(count);
            }
            //グリズリー、トラ
            else if (m_NestScript.GetNestNum() == 9 || m_NestScript.GetNestNum() == 10)
            {
                for (int i = 0; i <= 7; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i];
                }

                Make(count);
            }
        }
        else if (m_NestScript.GetClimate() == CNest.Climate.NETTAI)
        {

            //オオコオモリ
            if (m_NestScript.GetNestNum() == 7)
            {
                for (int i = 10; i <= 15; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i];
                }
                Make(count);
            }
            //ワニ、ジャガー
            else if (m_NestScript.GetNestNum() == 9 || m_NestScript.GetNestNum() == 10)
            {
                for (int i = 10; i <= 17; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i];
                }

                Make(count);
            }

        }
        else if (m_NestScript.GetClimate() == CNest.Climate.KANSOUTAI)
        {
            //ライオン
            if (m_NestScript.GetNestNum() == 10)
            {
                for (int i = 20; i <= 27; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i];
                }

                Make(count);
            }

        }
        else if (m_NestScript.GetClimate() == CNest.Climate.KANTAI)
        {
            //クズリ、ツンドラオオカミ
            if (m_NestScript.GetNestNum() == 7 || m_NestScript.GetNestNum() == 8)
            {
                for (int i = 30; i <= 35; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i];
                }

                Make(count);
            }
            //ホッキョクグマ
            else if (m_NestScript.GetNestNum() == 10)
            {
                for (int i = 30; i <= 37; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i];
                }

                Make(count);
            }
        }
    }

    private void Make(int count)
    {
        if (count >= 1)
        {
            CreateAnimal(m_NestScript.GetNestNumAll());
        }
    }

}
