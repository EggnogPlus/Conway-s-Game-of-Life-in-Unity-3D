using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help_Button : MonoBehaviour
{
    public float clickRange = 5f;

    public GameObject textBackground;
    
    
    public Text text;
    IEnumerator ShowMessageHelp(string message)
    {
        float timeToShow = 15;

        //showing the text
        text.enabled = true;
        text.text = message;
        textBackground.SetActive(true);
        


        //waitin for specified seconds (timeToShow float i made above)
        yield return new WaitForSecondsRealtime(timeToShow);

        //now hide the text after timetoshow is up
        text.enabled = false;
        text.text = "";
        textBackground.SetActive(false);



    }
    void Start()
    {
        text.enabled = false; //start with text disabled
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && MyPauseMenu.GameIsPaused == false && customizeButton.GameIsCustomizing == false) //mouse1 to interact
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition); //sends a ray out from center of screen


            if (Physics.Raycast(ray, out hit, clickRange))
            {
                if (hit.collider.tag == "helpButton")
                {
                    Debug.Log("help button clicked"); //debug log to show raycast works

                    StartCoroutine(ShowMessageHelp("Hello! And Welcome to my game," + 
                        " This is Conways Game of Life recreated in Unity using 3d objects." +
                        " You must thow the cube on the ground against the cubes in the grid above. - " +
                        " Press [e] to pickup cube when looking at it - " +
                        " press [right click] to throw cube against wall - " +
                        " Use [w, a, s, d] to move - " +
                        " press [space] to jump - " +
                        " Press [q] to run/tick the GOL rules once - " +
                        " This game attempts to simulate life using simplified math logic:" +
                        " if an Alive cube (indicated by it being blue) has 0-1 alive neighbours around it, it dies - " +
                        " If an Alive cube has 2-3 alive nighbours around it, it survives - " +
                        " and if An Alive cube has equal or more than 4 neighbours around it, it dies - " +
                        " lastly, if a Dead cell (indicated by it being white) has exactly 3 alive neighbours, it turns into an Alive cell - " +
                        " Left click pink button to create and adjust the grid and it's size, and please...Enjoy my Game! :)")); //message
                }
            }

        }


    }
}
