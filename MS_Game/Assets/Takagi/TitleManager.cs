using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン操作用
using System.Threading.Tasks;
public class TitleManager : MonoBehaviour
{
    public GameObject fade;//インスペクタからPrefab化したCanvasを入れる
    public FadeManager m_FadeManager;

    [SerializeField] GameObject hazimeru;
    [SerializeField] GameObject tyutoriaru;
    [SerializeField] GameObject nyugemu;

    private CAudio m_AudioScript;
    private AudioSource m_Audio;

    private bool m_Only = false;

    // Start is called before the first frame update
    void Start()
    {
        m_FadeManager = fade.GetComponent<FadeManager>();

        m_AudioScript = this.gameObject.GetComponent<CAudio>();
        m_Audio = this.gameObject.GetComponent<AudioSource>();

        hazimeru.SetActive(true);
        tyutoriaru.SetActive(false);
        nyugemu.SetActive(false);

    }

    public void hazimerubutton()
    {

        m_Audio.PlayOneShot(m_AudioScript.SEStart);

        hazimeru.SetActive(false);
        tyutoriaru.SetActive(true);
        nyugemu.SetActive(true);
    }

    public async void sceneGameChange()//ボタン操作などで呼び出す
    {
        if(!m_Only)
        {
            m_Audio.PlayOneShot(m_AudioScript.SEStart);

            m_Only = true;

            m_FadeManager.fadeOut();
            await Task.Delay(1000);//暗転するまで待つ
            SceneManager.LoadScene("Game");//"移動先シーン名"へ遷移
        }
    }

    public async void sceneTutoChange()//ボタン操作などで呼び出す
    {
        if (!m_Only)
        {

            m_Only = true;

            m_Audio.PlayOneShot(m_AudioScript.SEStart);

            m_FadeManager.fadeOut();
            await Task.Delay(1000);//暗転するまで待つ
            SceneManager.LoadScene("Tutorial");//"移動先シーン名"へ遷移
        }
    }



    //public async void sceneChange(string sceneName)//ボタン操作などで呼び出す
    //{
    //     fadeCanvas.GetComponent<FadeManager>().fadeOut();//フェードアウトフラグを立てる
    //     await Task.Delay(200);//暗転するまで待つ
    //     SceneManager.LoadScene(sceneName);//"移動先シーン名"へ遷移
    //}

}
