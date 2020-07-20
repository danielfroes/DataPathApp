using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 *  FontSizeFixer:
 *  Responsability: Disables auto size after the calculation of the font size.
 *                 -> It is necessary using a dummy text to the 
 *
 */
public class FontSizeFixer: MonoBehaviour
{
    private TextMeshProUGUI textUI;
    private void Start() {

        textUI = GetComponent<TextMeshProUGUI>();
        //forces the calculation of the autosize  
        textUI.ForceMeshUpdate();
        //disable auto sizing for performance reasons a
        textUI.enableAutoSizing = false;
        //if the gameObject is dialogue, reset its text;
        if(gameObject.tag == "Dialogue")
        {
            textUI.SetText("");
        }
    }

}
