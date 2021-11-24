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

    private CGameObject m_GameObjectScript;
    private Slider m_TimeMater;
    private Text m_DayText;
    private Text m_MoneyText;

    private int  m_TimeSpeed;

    private bool m_DayEnd;   //1“ú‚¨‚í‚è
    private int m_NestCount;   //“®•¨‚ğ¶¬‚µ‚½‘ƒ‚Ì”(MAX‚É‚È‚Á‚½‚ç‚P“ú‚¨‚í‚èˆ—)
    private int m_TreeCount;    //¶¬‚µ‚½–Ø‚Ì”(MAX‚É‚È‚Á‚½‚ç‚P“ú‚¨‚í‚èˆ—)

    // Start is called before the first frame update
    void Start()
    {
        m_GameObjectScript = this.gameObject.GetComponent<CGameObject>();

        m_TimeMater = m_TimeMaterObject.GetComponent<Slider>();
        m_DayText = m_DayTextObject.GetComponent<Text>();
        m_MoneyText = m_MoneyTextObject.GetComponent<Text>();

        m_TimeSpeed = 0;

        m_Money = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_DayEnd && m_NestCount >= m_GameObjectScript.AnimalNestList.Count && m_TreeCount >= m_GameObjectScript.TreeList.Count)
        {
            m_GameDay++;
            m_Money += 1000;
            m_GameTime = 0;
            m_DayEnd = false;
            m_NestCount = 0;
        }
        if(!m_DayEnd)
        {
            Progress(m_TimeSpeed);
        }
        //1“ú‚¨‚í‚è
        if (m_GameTime >= m_DayTime)
        {
            m_DayEnd = true;
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

    public int GetMoney()
    {
        return m_Money;
    }

    public void UseMoney(int cost)
    {
        m_Money -= cost;
    }

    public void AddNestCount()
    {
        m_NestCount++;
    }

    public void AddTreeCount()
    {
        m_TreeCount++;
    }

    public bool GetDayEnd()
    {
        return m_DayEnd;
    }
}
