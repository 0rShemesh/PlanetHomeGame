using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class ResumeMenuManger : MonoBehaviour
{

    [SerializeField]
    Canvas canvas;


    float timescale = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        timescale = Time.timeScale;
    }
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    float counter = 0;
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && counter >1.3f)
        {
            OnMenu();
            counter = 0;
        }
        counter += Time.fixedDeltaTime;
    }


    bool menuOpen = false;
    void OnMenu()
    {
        menuOpen = !menuOpen;
        
        if(menuOpen == true)
        {
            openResumeMenu();
        }
        else if( menuOpen ==false)
        {
            closeResumeMenu();
        }


    }



    void openResumeMenu()
    {
        Time.timeScale = 0;
        canvas.gameObject.SetActive(true);

    }
    void closeResumeMenu()
    {
        Time.timeScale = this.timescale;
        canvas.gameObject.SetActive(false);
    }

    #region Button Methods
    public void ResumeToGame()
    {
        closeResumeMenu();
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }

    #endregion
}
