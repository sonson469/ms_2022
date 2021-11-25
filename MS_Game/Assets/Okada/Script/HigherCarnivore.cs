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

        m_MyObject = this.gameObject;

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
        int recount = 0;

        if (m_NestScript.GetNowZone() == m_NestScript.GetClimate())
        {
            if (m_NestScript.GetClimate() == CNest.Climate.ONTAI)
            {
                //�I�I�^�J�A�t�N���E
                if (m_NestScript.GetNestNum() == 7 || m_NestScript.GetNestNum() == 8)
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        count += m_NestCountScript.m_NestNameCount[i];
                    }
                    Make(count);
                    for (int i = 8; i <= 9; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i];
                    }
                    ReduceMyList(recount);
                }
                //�O���Y���[�A�g��
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

                //�I�I�R�I����
                if (m_NestScript.GetNestNum() == 7)
                {
                    for (int i = 10; i <= 15; i++)
                    {
                        count += m_NestCountScript.m_NestNameCount[i];
                    }
                    Make(count);
                    for (int i = 18; i <= 19; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i];
                    }
                    ReduceMyList(recount);
                }
                //���j�A�W���K�[
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
                //���C�I��
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
                //�N�Y���A�c���h���I�I�J�~
                if (m_NestScript.GetNestNum() == 7 || m_NestScript.GetNestNum() == 8)
                {
                    for (int i = 30; i <= 35; i++)
                    {
                        count += m_NestCountScript.m_NestNameCount[i];
                    }
                    Make(count);
                    for (int i = 38; i <= 39; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i];
                    }
                    ReduceMyList(recount);
                }
                //�z�b�L���N�O�}
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
    }

    private void Make(int count)
    {
        if (count >= 1)
        {
            CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(),1);
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
