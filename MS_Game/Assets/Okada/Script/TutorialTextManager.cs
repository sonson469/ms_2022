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

    // Start is called before the first frame update
    void Start()
    {
        m_TutorialText.text = "";
        StartCoroutine("LoadText");
    }


    // Update is called once per frame
    void Update()
    {
        ControlText();
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

        yield return new WaitForSeconds(3);
    }

    void ControlText()
    {
        if (m_CurrentCharNum < m_TextData[m_CurrentNum].Length)
            DisplayText();
        else
            NextText();
        
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

    private void NextText()
    {
        if (m_TextInterval == 0)
        {
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
            m_TextInterval = m_ReadSpeed;
        }
        else m_TextInterval--;

    }

    private void OnClick()
    {
        if (m_TextInterval == 0)
        {
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
            m_TextInterval = m_ReadSpeed;
        }
        else m_TextInterval--;
    }
   
}

