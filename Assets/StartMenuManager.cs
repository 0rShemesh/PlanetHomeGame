using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField]
    public DataHandler data;
    [SerializeField]
    ResumeMenuManger rmenuManger;
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        DontDestroyOnLoad(data);
        DontDestroyOnLoad(rmenuManger);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/map_scene");
    }
}
