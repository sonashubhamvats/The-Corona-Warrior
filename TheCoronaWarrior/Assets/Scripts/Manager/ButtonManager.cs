using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public GameObject pause_panel,congrats_panel;
    public static ButtonManager instance;
    private void Awake()
    {
        MakeInstance();
    }
    void MakeInstance()
    {
        if(instance==null)
        {
            instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!congrats_panel.activeInHierarchy)
            {
                pause_panel.SetActive(true);

            }
            Time.timeScale=0f;
        }    
    }
    public void Resume()
    {
        Time.timeScale=1f;
        pause_panel.gameObject.SetActive(false);
    }
    public void Reload()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("LevelScene");
    }
    public void Back()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("MainMenu");
    }
}
