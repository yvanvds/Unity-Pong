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
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos += direction * Time.deltaTime * speed;

        CheckBatCollision(pos);
        CheckWallCollision(pos);
 
        transform.position = pos;
        float size = DataStore.Instance.FieldSize.x * 0.05f;
        transform.localScale = new Vector3(size, size, size);
    }

    private void reset()
    {
        transform.position = new Vector3(
            DataStore.Instance.HorizontalBatPos + 0.1f,
            0,
            0
        );
        direction.x = Random.Range(0.5f, 1);
        direction.y = Random.Range(0.5f, 1);

        if (Random.Range(0, 1) < 0.5f)
        {
            direction.y = -direction.y;
        }
        direction.Normalize();
    }

    void CheckWallCollision(Vector3 pos)
    {
        if (pos.x + (transform.localScale.x * 0.5f) >= DataStore.Instance.RightEdge)
        {
            direction.x = -direction.x;
        }
        else if (pos.x - (transform.localScale.x * 0.5f) <= DataStore.Instance.LeftEdge)
        {
            direction.x = -direction.x;
        }

        if (pos.y + (transform.localScale.y * 0.5f) >= DataStore.Instance.TopEdge)
        {
            direction.y = -direction.y;
        }
        else if (pos.y - (transform.localScale.y * 0.5f) <= DataStore.Instance.BottomEdge)
        {
            direction.y = -direction.y;
        }
    }

    void CheckBatCollision(Vector3 pos)
    {
        if(pos.x - (transform.localScale.x * 0.5f) < DataStore.Instance.HorizontalBatPos)
        {
            if(pos.y - (transform.localScale.y * 0.5f) > 
                DataStore.Instance.VerticalBatPos + 
                (DataStore.Instance.BatScale.y * 0.5f)) {
                return;
            }
            if (pos.y + (transform.localScale.y * 0.5f) <
                DataStore.Instance.VerticalBatPos -
                (DataStore.Instance.BatScale.y * 0.5f)) {
                return;
            }
            direction.x = -direction.x;
        }
    }
}
