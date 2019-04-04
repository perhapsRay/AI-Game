using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{

    public GameObject TitleUI;

    void Start()
    {
        TitleUI.SetActive(true);
    }

    void Update()
    {

    }
    public void Begin()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Quit()
    {
        Application.Quit();
    }
}