using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TEXT
{
    None,
    ScreenSize,
    FieldSize,
}

public class UpdateText : MonoBehaviour
{
    public TEXT text = TEXT.None;
    public TMPro.TextMeshProUGUI output;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (text)
        {
            case TEXT.None: output.text = "output not defined";
                break;
            case TEXT.ScreenSize: output.text = "screenSize: " 
                    + DataStore.Instance.ScreenSize.ToString();
                break;
            case TEXT.FieldSize: output.text = "fieldSize: " 
                    + DataStore.Instance.FieldSize.ToString();
                break;
            default: output.text = "unused enum value";
                break;
        }
    }
}
