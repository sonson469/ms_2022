using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TutorialTextManager : MonoBehaviour
{
    private List<string> m_TextData = new List<string>();
    private int m_CurrentNum = 0;
    int m_CurrentCharNum = 0;
    float m_TextInterval = 0;
    [SerializeField] private int m_ReadSpeed;
    [SerializeField] private Text m_TutorialText;
    public Button[] m_ObjButton;
    private int count = 0;
    [SerializeField] GameObject m_Manager;
    private CGameTimeManager m_TimeManager;
    private CObjectMove m_ObjectMove;


    // Start is called before the first frame update
    void Start()
    {
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();
        m_ObjectMove = m_Manager.GetComponent<CObjectMove>();
        m_TutorialText.text = "";
        StartCoroutine("LoadText");

    }


    // Update is called once per frame
    void Update()
    {
        ControlText();

        if (m_CurrentNum == 16 && m_TimeManager.GetGameDay() >= 3)
        {
            m_TimeManager.SetTimeSpeed(0);
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
            count++;
        }


        if (m_CurrentNum == 23 && m_TimeManager.GetGameDay() >= 5)
        {
            m_TimeManager.SetTimeSpeed(0);
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
            count++;
        }

        if (m_CurrentNum == 26 && m_TimeManager.GetGameDay() >= 6)
        {
            m_TimeManager.SetTimeSpeed(0);
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
            count++;

        }

        if(m_CurrentNum==39 && m_TimeManager.GetGameDay() >= 7)
        {
            m_TimeManager.SetTimeSpeed(0);
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
            count++;
        }
        if(m_CurrentNum == 14 && m_ObjectMove.m_IsYatudeFlag == true)
        {
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
            count++;
        }
        if (m_CurrentNum == 22 && m_ObjectMove.m_IsmachineFlag == true)
        {
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
            count++;
        }


    }

    private IEnumerator LoadText()
    {
        enabled = false;
        string m_FileName = "Assets/Okada/TutorialText.txt";

        // àÍçsÇ∏Ç¬ì«Ç›çûÇﬁ
        using (var fs = new StreamReader(m_FileName, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            while (fs.Peek() != -1)
            {
                m_TextData.Add(fs.ReadLine());
            }
            enabled = true;
        };

        yield return new WaitForSeconds(1);
    }

    void ControlText()
    {
        if (m_CurrentCharNum < m_TextData[m_CurrentNum].Length)
            DisplayText();
        //else
        //    NextText();

    }

    void DisplayText()
    {
        if (m_TextInterval == 0)
        {
            m_TutorialText.text += m_TextData[m_CurrentNum][m_CurrentCharNum];
            m_CurrentCharNum++;
            m_TextInterval = m_ReadSpeed;
        }
        else m_TextInterval--;
    }

    public void OnClick()
    {
        if (m_CurrentNum == 12 || m_CurrentNum == 14 || m_CurrentNum == 16 || m_CurrentNum == 22 || m_CurrentNum == 23 || m_CurrentNum == 26 || m_CurrentNum == 39)
        {
            m_ObjButton[count].interactable = true;
            return;
        }
        m_TutorialText.text = m_TextData[m_CurrentNum] + "\n";
        m_CurrentNum++;
        Debug.Log(m_CurrentNum);
        m_CurrentCharNum = 0;
    }

    public void OnNext(int num)
    {
        if (num == 0 && m_CurrentNum == 12)
        {
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
            count++;
        }
    }
}

