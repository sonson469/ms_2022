using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerHerbivore : CAnimalCreate
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
        if(m_TimeManager.GetDayEnd())
        {
            NestAnimal();
        }
    }

    public override void NestAnimal()
    {
        int recount = 0;

        if (m_NestScript.GetNowZone() == m_NestScript.GetClimate())
        {
            if (m_NestScript.GetTreeBig() + m_NestScript.GetTreeSmall() >= 3 && m_MyAnimalList.Count <= 10)
            {
                CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 4);
                CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 4);
                CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 4);
            }
            else if (m_NestScript.GetTreeBig() + m_NestScript.GetTreeSmall() >= 1 && m_MyAnimalList.Count <= 10)
            {
                CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 4);
            }

            if (m_NestScript.GetClimate() == CNest.Climate.ONTAI)
            {
                //�n�c�J�l�Y�~�A�A�}�J�G��
                if (m_NestScript.GetNestNum() == 1 || m_NestScript.GetNestNum() == 2)
                {
                    for (int i = 2; i <= 9; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }
                //���b�T�[�p���_
                else if (m_NestScript.GetNestNum() == 4)
                {

                    for (int i = 4; i <= 9; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }
            }
            else if (m_NestScript.GetClimate() == CNest.Climate.NETTAI)
            {
                //�V���E�K���S�A�J�s�o��
                if (m_NestScript.GetNestNum() == 1 || m_NestScript.GetNestNum() == 2)
                {
                    for (int i = 12; i <= 19; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }
                //�R�A���A�E�H���o�b�g
                else if (m_NestScript.GetNestNum() == 3 || m_NestScript.GetNestNum() == 4)
                {
                    for (int i = 14; i <= 19; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }
                //�I�I�A���N�C
                else if (m_NestScript.GetNestNum() == 5)
                {
                    for (int i = 16; i <= 19; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }

            }
            else if (m_NestScript.GetClimate() == CNest.Climate.KANSOUTAI)
            {
                //�n���l�Y�~�A�A���}�W��
                if (m_NestScript.GetNestNum() == 1 || m_NestScript.GetNestNum() == 2)
                {
                    for (int i = 22; i <= 29; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }
                //���N�_�A�V�}�E�}
                else if (m_NestScript.GetNestNum() == 3 || m_NestScript.GetNestNum() == 4)
                {
                    for (int i = 24; i <= 29; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }

            }
            else if (m_NestScript.GetClimate() == CNest.Climate.KANTAI)
            {
                //�y���M���A�A�U���V
                if (m_NestScript.GetNestNum() == 1 || m_NestScript.GetNestNum() == 2)
                {
                    for (int i = 32; i <= 39; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }
                //�g�i�J�C�A�W���R�E�E�V
                else if (m_NestScript.GetNestNum() == 3 || m_NestScript.GetNestNum() == 4)
                {
                    for (int i = 34; i <= 39; i++)
                    {
                        recount += m_NestCountScript.m_NestNameCount[i]/2;
                    }
                    ReduceMyList(recount);
                }
            }
        }
    }

    public void ReduceMyList(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            if(m_MyAnimalList.Count >= 1)
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
