using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameTimeManager : MonoBehaviour
{

    private float m_GameTime;   //ÇPì˙êiçséûä‘(ïb)
    private int m_GameDay = 1;      //ì˙

    [SerializeField] private int m_Money;

    [Header("1ì˙Ç…Ç©Ç©ÇÈéûä‘(ïb)")]
    [SerializeField] float m_DayTime;

    [SerializeField] GameObject m_TimeMaterObject;
    [SerializeField] GameObject m_DayTextObject;
    [SerializeField] GameObject m_MoneyTextObject;

    private CGameObject m_GameObjectScript;
    private Slider m_TimeMater;
    private Text m_DayText;
    private Text m_MoneyText;

    private int  m_TimeSpeed;

    private bool m_DayEnd;   //1ì˙Ç®ÇÌÇË

    [SerializeField] private Light m_Light;

    [SerializeField] private Button[] m_TimeButton = new Button[4];
    [SerializeField] private Color m_TimeButtonSelectColor = new Color(0, 0, 0, 0);

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
        m_Light.transform.Rotate(new Vector3(18*m_TimeSpeed,0, 0)*Time.deltaTime, Space.World);

        if (m_DayEnd)
        {
            m_GameDay++;
            m_Money += 50;
            m_GameTime = 0;
            m_DayEnd = false;
        }
        if(!m_DayEnd)
        {
            Progress(m_TimeSpeed);
        }
        //1ì˙Ç®ÇÌÇË
        if (m_GameTime >= m_DayTime)
        {
            m_DayEnd = true;
        }

        m_TimeMater.value = m_GameTime / m_DayTime;
        m_DayText.text = m_GameDay.ToString() + "ì˙ñ⁄";
        m_MoneyText.text = m_Money.ToString() + "G";

        for (int i = 0; i < 3; i++)
        {
            if (i == m_TimeSpeed)
            {
                m_TimeButton[i].image.color = m_TimeButtonSelectColor;
            }
            else
            {
                m_TimeButton[i].image.color = new Color(1, 1, 1, 1);
            }
        }

        if(m_TimeSpeed == 4)
        {
            m_TimeButton[3].image.color = m_TimeButtonSelectColor;
        }
        else
        {
            m_TimeButton[3].image.color = new Color(1, 1, 1, 1);
        }
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
