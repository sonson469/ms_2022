using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameTimeManager : MonoBehaviour
{

    private float m_GameTime;   //‚P“úisŠÔ(•b)
    private int m_GameDay;      //“ú

    private int m_Money;

    [Header("1“ú‚É‚©‚©‚éŠÔ(•b)")]
    [SerializeField] float m_DayTime = 60;

    [SerializeField] GameObject m_TimeMaterObject;
    [SerializeField] GameObject m_DayTextObject;
    [SerializeField] GameObject m_MoneyTextObject;
    private Slider m_TimeMater;
    private Text m_DayText;
    private Text m_MoneyText;

    private int  m_TimeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        m_TimeMater = m_TimeMaterObject.GetComponent<Slider>();
        m_DayText = m_DayTextObject.GetComponent<Text>();
        m_MoneyText = m_MoneyTextObject.GetComponent<Text>();

        m_TimeSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Progress(m_TimeSpeed);

        if (m_GameTime >= m_DayTime)
        {
            m_GameDay++;
            m_Money += 1000;
            m_GameTime = 0;
        }

        m_TimeMater.value = m_GameTime / m_DayTime;
        m_DayText.text = m_GameDay.ToString() + "“ú–Ú";
        m_MoneyText.text = "Š‹à : " + m_Money.ToString() + "‰~";
    }

    private void Progress(int num)
    {
        m_GameTime += num * Time.deltaTime;
    }

    public void SetTimeSpeed(int num)
    {
        m_TimeSpeed = num;
    }
}
