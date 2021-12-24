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

    public async void sceneGameChange()//�{�^������ȂǂŌĂяo��
    {
        if(!m_Only)
        {
            m_Audio.PlayOneShot(m_AudioScript.SEStart);

            m_Only = true;

            m_FadeManager.fadeOut();
            await Task.Delay(1000);//�Ó]����܂ő҂�
            SceneManager.LoadScene("Game");//"�ړ���V�[����"�֑J��
        }
    }

    public async void sceneTutoChange()//�{�^������ȂǂŌĂяo��
    {
        if (!m_Only)
        {

            m_Only = true;

            m_Audio.PlayOneShot(m_AudioScript.SEStart);

            m_FadeManager.fadeOut();
            await Task.Delay(1000);//�Ó]����܂ő҂�
            SceneManager.LoadScene("Tutorial");//"�ړ���V�[����"�֑J��
        }
    }



    //public async void sceneChange(string sceneName)//�{�^������ȂǂŌĂяo��
    //{
    //     fadeCanvas.GetComponent<FadeManager>().fadeOut();//�t�F�[�h�A�E�g�t���O�𗧂Ă�
    //     await Task.Delay(200);//�Ó]����܂ő҂�
    //     SceneManager.LoadScene(sceneName);//"�ړ���V�[����"�֑J��
    //}

}
