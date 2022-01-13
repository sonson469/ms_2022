using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;//シーン操作用
using System.Threading.Tasks;


public class TutorialTextManager : MonoBehaviour
{

    private int m_CurrentNum = 0;
    int m_CurrentCharNum = 0;
    float m_TextInterval = 0;
    [SerializeField] private float m_ReadSpeed;
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

    private string[] m_TextData = {
        "ようこそ！​",
        "動物たちの理想郷を作り上げる為の人工大地​",
        "「ア・ニマ・ルー」へ​",
        "動物保全職員として​",
        "人の手を借りずに動物たちが暮らせる場所を",
        "​創造して貰います",
        "「ア・ニマ・ルー」でのサイクルを​説明します​",
        "動物は動物の巣を設置し、",
        "いくつかの条件を維持する事で増えていきます​",
        "動物の巣は​​",
        "生態系ブックに書かれた​",
        "条件を満たす事で解放されます​​",
        "それでは、生態系ブックを開きましょう​​",
        "初めにハツカネズミの巣を解放するため​",
        "ヤツデを植えてみましょう​​",
        "画面右上にある矢印で時間を操作する事が出来ます。​​",
        "時間を進めてみましょう​​",
        "おっと、すみません​​",
        "枯れてしまいました。​​",
        "樹木に合った気候でないと​植えた樹木は育ちません​​",
        "それでは、​​",
        "枯れてしまった低樹木を撤去し、​",
        "温帯の機械を設置しましょう​​",
        "再びヤツデを７つ植えてみましょう​​",
        "ヤツデが育ちハツカネズミの巣が解放されました​​",
        "それでは、​​",
        "解放されたハツカネズミの巣を​配置しましょう​​",
        "ハツカネズミが生まれました​​",
        "ハツカネズミを増やしましょう​​",
        "増える条件は​巣の上のアイコンで確認できます​​",
        "アイコンの樹木をメータが満タンになるまで付近に植えてください​​",
        "そうすると徐々に​動物が巣から増えていきます​​",
        "動物に関しては以上になります​​",
        "「ア・ニマ・ルー」を​創り上げるために​",
        "必要な​資金の調達について説明します​​",
        "左下に資金が表示されています​​",
        "樹木の設置などで資金を消費します​​",
        "資金を増やすには​​",
        "低樹木を育て刈り取り小屋で​刈り取る必要あります​​",
        "刈り取り小屋を設置しその範囲内に​低樹木を植えてみましょう​​",
        "低樹木の種類によって刈り取れる回数が決めっています​​",
        "上限を超えると消失します​​",
        "低樹木が育って刈り取られ​資金が増えましたね​​",
        "以上が資金の増やし方になります​​",
    };


    // Start is called before the first frame update
    void Start()
    {
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();
        m_ObjectMove = m_Manager.GetComponent<CObjectMove>();
        m_TutorialText.text = "";
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

        if (m_CurrentNum >= 44)
            button.SetActive(true);

        Debug.Log(m_CurrentNum);

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
        if (m_TextInterval >= m_ReadSpeed)
        {
            m_TutorialText.text += m_TextData[m_CurrentNum][m_CurrentCharNum];
            m_CurrentCharNum++;
            m_TextInterval = 0;
        }
        else
        {
            m_TextInterval += Time.deltaTime;
        };
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

