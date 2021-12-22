using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[������p
using System.Threading.Tasks;
public class TitleManager : MonoBehaviour
{
    public GameObject fade;//�C���X�y�N�^����Prefab������Canvas������
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

    public async void sceneGameChange()//�{�^������ȂǂŌĂяo��
    {
        m_FadeManager.fadeOut();
        await Task.Delay(1000);//�Ó]����܂ő҂�
        SceneManager.LoadScene("Game");//"�ړ���V�[����"�֑J��
    }

    public async void sceneTutoChange()//�{�^������ȂǂŌĂяo��
    {
        m_FadeManager.fadeOut();
        await Task.Delay(1000);//�Ó]����܂ő҂�
        SceneManager.LoadScene("Tutorial");//"�ړ���V�[����"�֑J��
    }



    //public async void sceneChange(string sceneName)//�{�^������ȂǂŌĂяo��
    //{
    //     fadeCanvas.GetComponent<FadeManager>().fadeOut();//�t�F�[�h�A�E�g�t���O�𗧂Ă�
    //     await Task.Delay(200);//�Ó]����܂ő҂�
    //     SceneManager.LoadScene(sceneName);//"�ړ���V�[����"�֑J��
    //}

}
