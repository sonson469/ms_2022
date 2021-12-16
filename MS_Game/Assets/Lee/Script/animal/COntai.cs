using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COntai : CAnimalCreate
{

    [SerializeField] private int[] m_TreeCount = new int[10];
    private CNestCount m_NestCountScript;

    [SerializeField] private GameObject m_DesObj;

    private GameObject canvas;
    private GameObject m_SliderObj1;
    private GameObject m_SliderObj2;
    private GameObject m_SliderObj3;

    [SerializeField] private Slider m_Slider1;
    [SerializeField] private Slider m_Slider2;
    [SerializeField] private Slider m_Slider3;

    private int count;


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

        canvas = this.gameObject.transform.GetChild(4).gameObject;
        m_SliderObj1 = canvas.gameObject.transform.GetChild(0).gameObject;
        m_SliderObj2 = canvas.gameObject.transform.GetChild(1).gameObject;
        m_SliderObj3 = canvas.gameObject.transform.GetChild(2).gameObject;
        m_Slider1 = m_SliderObj1.GetComponent<Slider>();
        m_Slider2 = m_SliderObj2.GetComponent<Slider>();
        m_Slider3 = m_SliderObj3.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (m_GameObjectScript.GetMode() == CGameObject.ModeState.DES)
        {
            m_DesObj.SetActive(true);
        }
        else
        {
            m_DesObj.SetActive(false);
        }

        if (m_TimeManager.GetDayEnd())
        {
            NestAnimal();
        }

        if (count >= 1)
        {
            m_Slider2.value = 1;
        }
        else
        {
            m_Slider2.value = 0;
        }

        if (m_NestCountScript.GetPut() && m_NestScript.GetNowZone() == m_NestScript.GetClimate() && m_MyAnimalList.Count <= m_MaxAnimal)
        {
            if (m_NestScript.GetNestNum() == 1 || m_NestScript.GetNestNum() == 2)
            {
                m_Slider2.value = 1;

                if (m_TreeCount[0] >= 7)
                {
                    m_Slider3.value = 1;
                }
                else
                {
                    m_Slider3.value = (float)m_TreeCount[0] / 7.0f;
                }

                if (m_TreeCount[5] >= 7)
                {
                    m_Slider1.value = 1;
                }
                else
                {
                    m_Slider1.value = (float)m_TreeCount[5] / 7.0f;
                }
            }
            else if (m_NestScript.GetNestNum() == 3 || m_NestScript.GetNestNum() == 4)
            {
                if (m_TreeCount[1] >= 6)
                {
                    m_Slider3.value = 1;
                }
                else
                {
                    m_Slider3.value = (float)m_TreeCount[1] / 6.0f;
                }

                if (m_TreeCount[6] >= 6)
                {
                    m_Slider1.value = 1;
                }
                else
                {
                    m_Slider1.value = (float)m_TreeCount[6] / 6.0f;
                }
            }
            else if (m_NestScript.GetNestNum() == 5 || m_NestScript.GetNestNum() == 6)
            {
                if (m_TreeCount[2] >= 5)
                {
                    m_Slider3.value = 1;
                }
                else
                {
                    m_Slider3.value = (float)m_TreeCount[2] / 5.0f;
                }

                if (m_TreeCount[7] >= 5)
                {
                    m_Slider1.value = 1;
                }
                else
                {
                    m_Slider1.value = (float)m_TreeCount[7] / 5.0f;
                }

            }
            else if (m_NestScript.GetNestNum() == 7 || m_NestScript.GetNestNum() == 8)
            {
                if (m_TreeCount[3] >= 4)
                {
                    m_Slider3.value = 1;
                }
                else
                {
                    m_Slider3.value = (float)m_TreeCount[3] / 4.0f;
                }

                if (m_TreeCount[8] >= 4)
                {
                    m_Slider1.value = 1;
                }
                else
                {
                    m_Slider1.value = (float)m_TreeCount[8] / 4.0f;
                }
            }
            else if (m_NestScript.GetNestNum() == 9 || m_NestScript.GetNestNum() == 10)
            {
                if (m_TreeCount[4] >= 3)
                {
                    m_Slider3.value = 1;
                }
                else
                {
                    m_Slider3.value = (float)m_TreeCount[4] / 3.0f;

                }

                if (m_TreeCount[9] >= 3)
                {
                    m_Slider1.value = 1;
                }
                else
                {
                    m_Slider1.value = (float)m_TreeCount[9] / 3.0f;
                }

            }

        }

    }

    public override void NestAnimal()
    {

        //------------------------------------------------------------------
        // ������ق�
        //------------------------------------------------------------------
        if (m_NestCountScript.GetPut() && m_NestScript.GetNowZone() == m_NestScript.GetClimate() && m_MyAnimalList.Count <= m_MaxAnimal)
        {
            count = 0;
            if (m_NestScript.GetNestNum() % 2 == 1)
            {
                for (int i = 1; i < m_NestScript.GetNestNum(); i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i - 1];
                }
            }
            else if (m_NestScript.GetNestNum() % 2 == 0)
            {
                for (int i = 1; i < m_NestScript.GetNestNum() - 1; i++)
                {
                    count += m_NestCountScript.m_NestNameCount[i - 1];
                }
            }

            if (m_NestScript.GetNestNum() == 1 || m_NestScript.GetNestNum() == 2)
            {
                if (m_TreeCount[0] >= 7)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                }

                if (m_TreeCount[5] >= 7)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                }
            }
            else if (m_NestScript.GetNestNum() == 3 || m_NestScript.GetNestNum() == 4)
            {
                
                if (m_TreeCount[1] >= 6 && count >= 1)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                }

                if (m_TreeCount[6] >= 6)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                }
            }
            else if (m_NestScript.GetNestNum() == 5 || m_NestScript.GetNestNum() == 6)
            {
                if (m_TreeCount[2] >= 5 && count >= 1)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                }

                if (m_TreeCount[7] >= 5)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                }

            }
            else if (m_NestScript.GetNestNum() == 7 || m_NestScript.GetNestNum() == 8)
            {
                if (m_TreeCount[3] >= 4 && count >= 1)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                }

                if (m_TreeCount[8] >= 4)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                }
            }
            else if (m_NestScript.GetNestNum() == 9 || m_NestScript.GetNestNum() == 10)
            {
                if (m_TreeCount[4] >= 3 && count >= 1)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                }

                if (m_TreeCount[9] >= 3)
                {
                    CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange(), 1);
                }

            }
        }

        //------------------------------------------------------------------
        // ����ق�
        //------------------------------------------------------------------
        int descount = 0;
        if (m_NestScript.GetNestNum() % 2 == 1)
        {
            for (int i = m_NestScript.GetNestNum() + 2; i <= 10; i++)
            {
                descount += m_NestCountScript.m_NestNameCount[i - 1];
            }
        }
        else if (m_NestScript.GetNestNum() % 2 == 0)
        {
            for (int i = m_NestScript.GetNestNum() + 1; i <= 10; i++)
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
        for(int i = 0; i < m_MyAnimalList.Count; i++)
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
