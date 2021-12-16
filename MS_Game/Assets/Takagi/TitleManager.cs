using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[������p
using System.Threading.Tasks;
public class TitleManager : MonoBehaviour
{
    public GameObject fade;//�C���X�y�N�^����Prefab������Canvas������
    public GameObject fadeCanvas;//���삷��Canvas�A�^�O�ŒT��

    // Start is called before the first frame update
    void Start()
    {
        if (!FadeManager.isFadeInstance)//isFadeInstance�͌�ŗp�ӂ���
        {
            Instantiate(fade);
        }

        Invoke("findFadeObject", 0.02f);//�N�����p��Canvas�̏�����������Ƒ҂�

    }

    public async void sceneChange()//�{�^������ȂǂŌĂяo��
    {
         await Task.Delay(100);//�Ó]����܂ő҂�
         SceneManager.LoadScene("Game_Takagi");//"�ړ���V�[����"�֑J��
    }

    //public async void sceneChange(string sceneName)//�{�^������ȂǂŌĂяo��
    //{
    //     fadeCanvas.GetComponent<FadeManager>().fadeOut();//�t�F�[�h�A�E�g�t���O�𗧂Ă�
    //     await Task.Delay(200);//�Ó]����܂ő҂�
    //     SceneManager.LoadScene(sceneName);//"�ړ���V�[����"�֑J��
    //}

}
