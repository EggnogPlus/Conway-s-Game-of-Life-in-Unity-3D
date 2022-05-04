using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customizeButton : MonoBehaviour
{
    public static bool GameIsCustomizing = false;
    
    public GameObject customizeWindowUI;
    public GameObject inputWindow;
    public GameObject confirmButton;
    


    public float clickRange = 5f;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && MyPauseMenu.GameIsPaused == false && customizeButton.GameIsCustomizing == false) //mouse1 to interact
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition); //sends a ray out from center of screen


            if (Physics.Raycast(ray, out hit, clickRange))
            {
                if (hit.collider.tag == "customizeButton")
                {
                    Debug.Log("custom button clicked");

                    //dont need to destory blocks here, already done                   

                    GameIsCustomizing = true;

                    customizeWindowUI.SetActive(true);
                    inputWindow.SetActive(true);
                    confirmButton.SetActive(true);
                    Time.timeScale = 0f;
                    
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            customizeWindowUI.SetActive(false);
            inputWindow.SetActive(false);
            confirmButton.SetActive(false);
            Time.timeScale = 1f;

            GameIsCustomizing = false;
        }

    }//end update

    public void CloseCustomize()
    {
        customizeWindowUI.SetActive(false);
        inputWindow.SetActive(false);
        confirmButton.SetActive(false);
        Time.timeScale = 1f;

        GameIsCustomizing = false;
    }




    //pause game
    //open two enter fields for width and length
    //this is where i will program a usable button






    //#############################################################################################

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    */
}
