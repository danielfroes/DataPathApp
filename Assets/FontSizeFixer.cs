using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FontSizeFixer: MonoBehaviour
{
    private TextMeshProUGUI textUI;
    private void Start() {
        textUI = GetComponent<TextMeshProUGUI>();
        textUI.enableAutoSizing = false;

        if(gameObject.tag == "Dialogue")
        {
            textUI.text = "";
            print(textUI.fontSize);
        }
    }
}
