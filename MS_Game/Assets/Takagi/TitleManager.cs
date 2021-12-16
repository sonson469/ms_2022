using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン操作用
using System.Threading.Tasks;
public class TitleManager : MonoBehaviour
{
    public GameObject fade;//インスペクタからPrefab化したCanvasを入れる
    public FadeManager m_FadeManager;

    // Start is called before the first frame update
    void Start()
    {
        m_FadeManager = fade.GetComponent<FadeManager>();

    }

    public async void sceneChange()//ボタン操作などで呼び出す
    {
        m_FadeManager.fadeOut();
        await Task.Delay(1000);//暗転するまで待つ
        SceneManager.LoadScene("Game");//"移動先シーン名"へ遷移
    }

    //public async void sceneChange(string sceneName)//ボタン操作などで呼び出す
    //{
    //     fadeCanvas.GetComponent<FadeManager>().fadeOut();//フェードアウトフラグを立てる
    //     await Task.Delay(200);//暗転するまで待つ
    //     SceneManager.LoadScene(sceneName);//"移動先シーン名"へ遷移
    //}

}
