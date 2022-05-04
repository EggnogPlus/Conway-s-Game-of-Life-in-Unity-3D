using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicksText : MonoBehaviour
{
    public int Ticks;
    
    public Text tickText;

    // Start is called before the first frame update
    void Start()
    {
        Ticks = 0;
        tickText.text = Ticks.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ticks++;
            
            tickText.text = Ticks.ToString();
        }

        if(GridCreator.resetGrid == true)
        {
            Ticks = 0;
            GridCreator.resetGrid = false;
        }
    }
}
