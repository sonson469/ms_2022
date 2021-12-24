using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;//シーン操作用
using System.Threading.Tasks;


public class TutorialTextManager : MonoBehaviour
{
    private List<string> m_TextData = new List<string>();
    private int m_CurrentNum = 0;
    int m_CurrentCharNum = 0;
    float m_TextInterval = 0;
    [SerializeField] private int m_ReadSpeed;
    [SerializeField] private Text m_TutorialText;
    public Button[] m_ObjButton;
    [SerializeField] GameObject m_Manager;
    private CGameTimeManager m_TimeManager;
    private CObjectMove m_ObjectMove;

    private CAudio m_AudioScript;
    private AudioSource m_Audio;

    public GameObject fade;//インスペクタからPrefab化したCanvasを入れる
    public FadeManager m_FadeManager;

    public GameObject button;

    [SerializeField] private GameObject m_Yazirushi;

    private bool next = false;

    // Start is called before the first frame update
    void Start()
    {
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();
        m_ObjectMove = m_Manager.GetComponent<CObjectMove>();
        m_TutorialText.text = "";
        StartCoroutine("LoadText");
        m_FadeManager = fade.GetComponent<FadeManager>();

        m_AudioScript = m_Manager.gameObject.GetComponent<CAudio>();
        m_Audio = m_Manager.gameObject.GetComponent<AudioSource>();

        m_Yazirushi.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (m_CurrentNum <= 43)
        {
            ControlText();
        }
        if (m_CurrentNum == 12)
        {

            m_ObjButton[0].interactable = true;
        }
        if (m_CurrentNum == 12 && next)
        {
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
        }
        if (m_CurrentNum == 14)
        {
            m_ObjButton[1].interactable = true;
        }

        if (m_CurrentNum == 14 && m_ObjectMove.m_IsYatudeFlag)
        {
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
        }
        if (m_CurrentNum == 16)
        {
            m_ObjButton[2].interactable = true;
        }

        if (m_CurrentNum == 16 && m_TimeManager.GetGameDay() >= 3)
        {
            m_ObjectMove.m_IsYatudeFlag = false;
            m_TimeManager.SetTimeSpeed(0);
            m_ObjButton[2].interactable = false;
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
        }
        if (m_CurrentNum == 22)
        {
            m_ObjButton[3].interactable = true;
            m_Yazirushi.SetActive(true);
        }
        if (m_CurrentNum == 22 && m_ObjectMove.m_IsmachineFlag == true)
        {
            m_Yazirushi.SetActive(false);
            m_ObjButton[2].interactable = true;
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
            m_ObjectMove.m_IsmachineFlag = false;
        }

        if (m_CurrentNum == 23 && m_TimeManager.GetGameDay() >= 5)
        {
            m_TimeManager.SetTimeSpeed(0);
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
        }

        if (m_CurrentNum == 23 && m_ObjectMove.m_IsYatudeFlag == true)
        {
            m_TimeManager.SetTimeSpeed(4);
        }
        if (m_CurrentNum == 26)
        {
            m_ObjButton[4].interactable = true;
        }

        if (m_CurrentNum == 26 && m_TimeManager.GetGameDay() >= 6)
        {
            m_ObjButton[2].interactable = false;
            m_TimeManager.SetTimeSpeed(0);
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";

        }
        if (m_CurrentNum == 26 && m_ObjectMove.m_IsNezumiFlag == true)
        {
            m_ObjButton[2].interactable = true;
            m_TimeManager.SetTimeSpeed(4);
        }
        if (m_CurrentNum == 39)
        {
            m_ObjButton[5].interactable = true;

        }
        if (m_CurrentNum == 39 && m_ObjectMove.m_IsmachineFlag == true)
        {
            m_ObjButton[2].interactable = true;
            m_TimeManager.SetTimeSpeed(4);

        }
        if (m_CurrentNum == 39 && m_TimeManager.GetGameDay() >= 7)
        {
            m_CurrentNum++;
            m_CurrentCharNum = 0;
            m_TutorialText.text = "";
        }

        if (m_CurrentNum >=44)
            button.SetActive(true);

        Debug.Log(m_CurrentNum);

    }

    private IEnumerator LoadText()
    {
        enabled = false;
        string m_FileName = "Assets/Okada/TutorialText.txt";

        // 一行ずつ読み込む
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
        if (m_CurrentNum == 12 || m_CurrentNum == 14 || m_CurrentNum == 16 || m_CurrentNum == 22 || m_CurrentNum == 23 || m_CurrentNum == 26 || m_CurrentNum == 39 || m_CurrentNum > 44)
            return;

        m_TutorialText.text = m_TextData[m_CurrentNum] + "\n";
        m_CurrentNum++;
        Debug.Log(m_CurrentNum);
        m_CurrentCharNum = 0;
    }

    public void OnNext()
    {
        next = true;
    }

    public async void sceneGameChange()//ボタン操作などで呼び出す
    {

        m_Audio.PlayOneShot(m_AudioScript.SEStart);

        m_FadeManager.fadeOut();
        await Task.Delay(1000);//暗転するまで待つ
        SceneManager.LoadScene("Game");//"移動先シーン名"へ遷移
    }
}

