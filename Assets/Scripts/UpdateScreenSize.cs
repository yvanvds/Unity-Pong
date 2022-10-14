using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScreenSize : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        DataStore.Instance.SetScreenSize(new Vector2(Screen.width, Screen.height), cam);
    }
}
