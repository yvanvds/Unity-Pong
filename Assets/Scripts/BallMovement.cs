using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 1;

    Vector3 direction = new Vector3(1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        direction.x = Random.Range(0.5f, 1);
        direction.y = Random.Range(0.5f, 1);
       
        if(Random.Range(0, 1) < 0.5f) 
        {
            direction.y = -direction.y;
        }
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos += direction * Time.deltaTime * speed;

        if(pos.x + (transform.localScale.x * 0.5f) >= DataStore.Instance.RightEdge)
        {
            direction.x = -direction.x;
            //pos += direction;
        } else if (pos.x - (transform.localScale.x * 0.5f) <= DataStore.Instance.LeftEdge)
        {
            direction.x = -direction.x;
            //pos += direction;
        }

        if (pos.y + (transform.localScale.y * 0.5f) >= DataStore.Instance.TopEdge)
        {
            direction.y = -direction.y;
            //pos += direction;
        }
        else if (pos.y - (transform.localScale.y * 0.5f) <= DataStore.Instance.BottomEdge)
        {
            direction.y = -direction.y;
            //pos += direction;
        }

        transform.position = pos;
        float size = DataStore.Instance.FieldSize.x * 0.05f;
        transform.localScale = new Vector3(size, size, size);
    }
}
