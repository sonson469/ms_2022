using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PageMoves : MonoBehaviour
{
    [SerializeField] private PageManager MenuButton;
    [SerializeField] int PageNo;

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

        m_Audio.PlayOneShot(m_AudioScript.SEBookMekuru);

        MenuButton.page += PageNo;
        if (MenuButton.page < 1)
        {
            MenuButton.page = MenuButton.GetMaxPage();

        }
        else if (MenuButton.page > MenuButton.GetMaxPage())
        {
            MenuButton.page = 1;
        }
    }

    public void QuickClick()
    {
        MenuButton.page = PageNo;
    }
}