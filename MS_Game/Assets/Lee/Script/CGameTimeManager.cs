using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameTimeManager : MonoBehaviour
{

    private float m_GameTime;   //�P���i�s����(�b)
    private int m_GameDay;      //��

    [SerializeField] private int m_Money;

    [Header("1���ɂ����鎞��(�b)")]
    [SerializeField] float m_DayTime = 60;

    [SerializeField] GameObject m_TimeMaterObject;
    [SerializeField] GameObject m_DayTextObject;
    [SerializeField] GameObject m_MoneyTextObject;

    private CGameObject m_GameObjectScript;
    private Slider m_TimeMater;
    private Text m_DayText;
    private Text m_MoneyText;

    private int  m_TimeSpeed;

    private bool m_DayEnd;   //1�������

    // Start is called before the first frame update
    void Start()
    {
        m_GameObjectScript = this.gameObject.GetComponent<CGameObject>();

        m_TimeMater = m_TimeMaterObject.GetComponent<Slider>();
        m_DayText = m_DayTextObject.GetComponent<Text>();
        m_MoneyText = m_MoneyTextObject.GetComponent<Text>();

        m_TimeSpeed = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(m_DayEnd)
        {
            m_GameDay++;
            //m_Money += 1000;
            m_GameTime = 0;
            m_DayEnd = false;
        }
        if(!m_DayEnd)
        {
            Progress(m_TimeSpeed);
        }
        //1�������
        if (m_GameTime >= m_DayTime)
        {
            m_DayEnd = true;
        }

        m_TimeMater.value = m_GameTime / m_DayTime;
        m_DayText.text = m_GameDay.ToString() + "����";
        m_MoneyText.text = "������ : " + m_Money.ToString() + "�~";
    }

    private void Progress(int num)
    {
        m_GameTime += num * Time.deltaTime;
    }

    public void SetTimeSpeed(int num)
    {
        m_TimeSpeed = num;
    }

    public int GetMoney()
    {
        return m_Money;
    }

    public void UseMoney(int cost)
    {
        m_Money -= cost;
    }
    public void AddMoney(int cost)
    {
        m_Money += cost;
    }
    public bool GetDayEnd()
    {
        return m_DayEnd;
    }

    public float GetGameDay()
    {
        return m_GameDay;
    }

    public int GetTimeSpeed()
    {
        return m_TimeSpeed;
    }
}
