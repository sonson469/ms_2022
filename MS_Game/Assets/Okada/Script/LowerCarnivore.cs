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

        if (m_NestScript.GetClimate() == CNest.Climate.ONTAI)
        {
            //�V�}�w�r
            if (m_NestScript.GetNestNum() == 3)
            {
                for(int i = 0; i <= 1; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i];
                }
                Make(count);
            }
            //�j�z���C�^�`�A���}�C�k
            else if (m_NestScript.GetNestNum() == 5 || m_NestScript.GetNestNum() == 6)
            {
                for (int i = 0; i <= 3; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i];
                }

                Make(count);
            }
        }
        else if (m_NestScript.GetClimate() == CNest.Climate.NETTAI)
        {

            //�^�X�}�j�A�f�r��
            if (m_NestScript.GetNestNum() == 6)
            {
                for (int i = 10; i <= 13; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i];
                }
                Make(count);
            }

        }
        else if (m_NestScript.GetClimate() == CNest.Climate.KANSOUTAI)
        {
            //�T�[�o���A�W���b�J��
            if (m_NestScript.GetNestNum() == 5 || m_NestScript.GetNestNum() == 6)
            {
                for (int i = 20; i <= 23; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i];
                }

                Make(count);
            }

        }
        else if (m_NestScript.GetClimate() == CNest.Climate.KANTAI)
        {
            //�z�b�L���N�L�c�l�A�V���t�N���E
            if (m_NestScript.GetNestNum() == 5 || m_NestScript.GetNestNum() == 6)
            {
                for (int i = 30; i <= 33; i++)
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
            CreateAnimal(m_NestScript.GetNestNumAll());
        }
    }

}
