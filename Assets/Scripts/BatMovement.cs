using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    float vPos = 0;
    // Start is called before the first frame update
    void Start()
    {
        DataStore.Instance.BatScale = transform.localScale; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            vPos += 3.5f * Time.deltaTime;
            if(vPos + (transform.localScale.y * 0.5f) > DataStore.Instance.TopEdge)
            {
                vPos = DataStore.Instance.TopEdge - (transform.localScale.y * 0.5f);
            }
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            vPos -= 3.5f * Time.deltaTime;
            if (vPos - (transform.localScale.y * 0.5f) < DataStore.Instance.BottomEdge)
            {
                vPos = DataStore.Instance.BottomEdge + (transform.localScale.y * 0.5f);
            }
        }
        transform.position = new Vector3(DataStore.Instance.HorizontalBatPos, vPos, 0);
        DataStore.Instance.VerticalBatPos = vPos;
    }
}
