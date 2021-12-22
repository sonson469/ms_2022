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

    // Start is called before the first frame update
    void Start()
    {
        m_FadeManager = fade.GetComponent<FadeManager>();

        hazimeru.SetActive(true);
        tyutoriaru.SetActive(false);
        nyugemu.SetActive(false);

    }

    public void hazimerubutton()
    {
        hazimeru.SetActive(false);
        tyutoriaru.SetActive(true);
        nyugemu.SetActive(true);
    }

    public async void sceneGameChange()//ボタン操作などで呼び出す
    {
        m_FadeManager.fadeOut();
        await Task.Delay(1000);//暗転するまで待つ
        SceneManager.LoadScene("Game");//"移動先シーン名"へ遷移
    }

    public async void sceneTutoChange()//ボタン操作などで呼び出す
    {
        m_FadeManager.fadeOut();
        await Task.Delay(1000);//暗転するまで待つ
        SceneManager.LoadScene("Tutorial");//"移動先シーン名"へ遷移
    }



    //public async void sceneChange(string sceneName)//ボタン操作などで呼び出す
    //{
    //     fadeCanvas.GetComponent<FadeManager>().fadeOut();//フェードアウトフラグを立てる
    //     await Task.Delay(200);//暗転するまで待つ
    //     SceneManager.LoadScene(sceneName);//"移動先シーン名"へ遷移
    //}

}
