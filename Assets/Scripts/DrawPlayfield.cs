using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPlayfield : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer field;
    public SpriteRenderer border;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(
            DataStore.Instance.FieldSize.x, 
            DataStore.Instance.FieldSize.y, 
            0.1f);
        transform.position = new Vector3(0,0,0);

        field.transform.localScale = new Vector3(1, 1, 1);
        field.transform.position = new Vector3(0,0,0);

        border.transform.localScale = new Vector3(1.01f, 1.01f, 1.01f);
        border.transform.position = new Vector3(0, 0,0);
    }
}
