using UnityEngine;

public class CircleDestroyer : MonoBehaviour
{
    Vector3 startPos;
    private bool isMove = false;
    private float offset;

    private void Start()
    {
        startPos = transform.position;
    }

    void OnMouseDown()
    {
        offset = Vector3.Distance(transform.position, Camera.main.transform.position);
        isMove = true;
    }

    void OnMouseDrag()
    {
        if (isMove)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 rayPoint = ray.GetPoint(offset);
            transform.position = rayPoint;
        }
    }

    void OnMouseUp()
    {
        isMove = false;
        transform.position = startPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.ToString());
    }
}
