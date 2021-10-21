using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;


public class GameSpeedManager : MonoBehaviour
{
    [SerializeField] private Text m_GameSpeedText;
    [SerializeField] private Text m_ElapsedTimeText;

    private int m_GameSpeedCount;
    private bool m_GameStop;
    private DateTime m_Date;
    private Calendar m_Calendar;
    // Start is called before the first frame update
    void Start()
    {
        m_Date = new DateTime(1, 1, 1);
        m_Calendar = CultureInfo.CurrentCulture.Calendar;
        m_GameSpeedCount = 1;
        StartCoroutine("AddDay");
    }

    // Update is called once per frame
    void Update()
    {
        m_GameSpeedText.text = m_GameSpeedCount.ToString() + "~";
        //m_ElapsedTimeText.text = m_Date.Year.ToString()+"”N"+m_Date.Month.ToString()+"ŒŽ";
        int weekNumber = m_Calendar.GetWeekOfYear(m_Date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday) - m_Calendar.GetWeekOfYear(new DateTime(m_Date.Year, m_Date.Month, 1), CalendarWeekRule.FirstDay, DayOfWeek.Sunday) + 1;
        //int isoWeekNumber = m_Calendar.GetWeekOfYear(m_Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday) - m_Calendar.GetWeekOfYear(new DateTime(m_Date.Year, m_Date.Month, 1), CalendarWeekRule.FirstDay, DayOfWeek.Monday) + 1;

        m_ElapsedTimeText.text = m_Date.Year.ToString() + "”N" + m_Date.Month.ToString() + "ŒŽ" + weekNumber.ToString() + "T";
    }

    public void ChangeGameSpeed()
    {
        ++m_GameSpeedCount;

        if (m_GameSpeedCount > 4)
        {
            m_GameSpeedCount = 1;
        }
        Time.timeScale = m_GameSpeedCount;
    }

    public void PauseGame()
    {
        m_GameStop = !m_GameStop;
        if (m_GameStop)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = m_GameSpeedCount;
        }
    }

    IEnumerator AddDay()
    {

        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            m_Date = m_Date.AddDays(1);
            Debug.Log(m_Date.ToString());
        }

    }
}
