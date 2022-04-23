using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customizeButton : MonoBehaviour
{
    public GameObject widthWindow;
    public GameObject heightWindow;
    public GameObject confirmButton;

    public float clickRange = 5f;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && MyPauseMenu.GameIsPaused == false) //mouse1 to interact
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition); //sends a ray out from center of screen


            if (Physics.Raycast(ray, out hit, clickRange))
            {
                if (hit.collider.tag == "customizeButton")
                {
                    Debug.Log("custom button clicked");

                    widthWindow.SetActive(true);
                    heightWindow.SetActive(true);
                    confirmButton.SetActive(true);

                    

                }
            }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            widthWindow.SetActive(false);
            heightWindow.SetActive(false);
            confirmButton.SetActive(false);
        }

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
