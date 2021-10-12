using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedManager : MonoBehaviour
{
    [SerializeField] private Text m_GameSpeedText;
    [SerializeField] private Text m_ElapsedTimeText;

    private int m_GameSpeedCount;
    private bool m_GameStop;

    // Start is called before the first frame update
    void Start()
    {
        m_GameSpeedCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        m_GameSpeedText.text = m_GameSpeedCount.ToString() + "~";
        m_ElapsedTimeText.text = Time.time.ToString();
    }

    public void ChangeGameSpeed()
    {
        ++m_GameSpeedCount;

        if (m_GameSpeedCount >4)
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
}
