using System.Collections;
using UnityEngine;

public class CircleDestroyer : MonoBehaviour
{
    [SerializeField] Sprite destroyerSprite;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] MovesCounter movesCounter;
    [SerializeField] GameObject hint;
    Vector3 startPos;
    private bool isMove = false;
    private float offset;
    GameObject objectToDestroy;

    private void Start()
    {
        startPos = transform.position;
    }

    void OnMouseDown()
    {
        spriteRenderer.sprite = destroyerSprite;
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
        if (objectToDestroy != null)
        {
            if (hint != null)
            { Destroy(hint); }
            FindObjectOfType<AudioManager>().PlayThunderSound();
            StartCoroutine(MoveAndDestroy(objectToDestroy));
            movesCounter.MovesCounterMinus();
            movesCounter.MovesCounterMinus();
        }

        spriteRenderer.sprite = null;
        isMove = false;
        transform.position = startPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectToDestroy = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectToDestroy = null;
    }

    IEnumerator MoveAndDestroy(GameObject objectToDestroy)
    {
        for (int i = 11; i <= 15; i++)
        {
            objectToDestroy.transform.position = new Vector3(transform.position.x, transform.position.y + i, transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(objectToDestroy);
    }
}
