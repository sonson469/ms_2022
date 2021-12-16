using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン操作用
using System.Threading.Tasks;
public class TitleManager : MonoBehaviour
{
    public GameObject fade;//インスペクタからPrefab化したCanvasを入れる
    public GameObject fadeCanvas;//操作するCanvas、タグで探す

    // Start is called before the first frame update
    void Start()
    {
        if (!FadeManager.isFadeInstance)//isFadeInstanceは後で用意する
        {
            Instantiate(fade);
        }

        Invoke("findFadeObject", 0.02f);//起動時用にCanvasの召喚をちょっと待つ

    }

    public async void sceneChange()//ボタン操作などで呼び出す
    {
         await Task.Delay(100);//暗転するまで待つ
         SceneManager.LoadScene("Game_Takagi");//"移動先シーン名"へ遷移
    }

    //public async void sceneChange(string sceneName)//ボタン操作などで呼び出す
    //{
    //     fadeCanvas.GetComponent<FadeManager>().fadeOut();//フェードアウトフラグを立てる
    //     await Task.Delay(200);//暗転するまで待つ
    //     SceneManager.LoadScene(sceneName);//"移動先シーン名"へ遷移
    //}

}
