using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureBook_Active : MonoBehaviour
{
    public GameObject PictureBook;
    public GameObject MenuButton;

    private CAudio m_AudioScript;
    private AudioSource m_Audio;
    private GameObject m_Manager;

    private void Start()
    {
        m_Manager = GameObject.FindWithTag("Manager");
        m_AudioScript = m_Manager.gameObject.GetComponent<CAudio>();
        m_Audio = m_Manager.gameObject.GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        m_Audio.PlayOneShot(m_AudioScript.SEBookOpen);
        PictureBook.SetActive(true);
        MenuButton.SetActive(true);
    }

    public void OffClick()
    {
        m_Audio.PlayOneShot(m_AudioScript.SEBookOpen);
        PictureBook.SetActive(false);
        MenuButton.SetActive(false);
    }
}
