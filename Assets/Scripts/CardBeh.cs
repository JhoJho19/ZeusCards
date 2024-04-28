using System.Collections;
using UnityEngine;

class CardBeh : MonoBehaviour
{
    private bool isMove = false;
    private float offset;
    Vector3 startPos;
    int sortingLayerStart;
    [SerializeField] SpriteRenderer spriteRenderer;
    public int value;
    [SerializeField] Colors colors;
    [SerializeField] Sprite back;
    [SerializeField] Sprite face0;
    [SerializeField] Sprite face1;
    [SerializeField] Sprite face2;
    [SerializeField] Sprite face3;
    [SerializeField] Sprite face4;
    [SerializeField] Sprite face5;
    [SerializeField] bool isOpen;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] CircleCollider2D circleCollider;
    [SerializeField] CardBeh cartForOpen1;
    [SerializeField] CardBeh cartForOpen2;
    GameObject otherCard;

    private void Start()
    {
        sortingLayerStart = spriteRenderer.sortingOrder;
        startPos = transform.position;
        StartCheck();
    }

    private void StartCheck()
    {
        if (isOpen)
        { ValueCheck(); boxCollider.enabled = true; circleCollider.enabled = true; }
        else
        { spriteRenderer.sprite = back; boxCollider.enabled = false; circleCollider.enabled = false; }
    }

    IEnumerator OpenCards()
    {
        if ( cartForOpen1 != null )
        {
            Debug.Log("открываем карту 1");
            cartForOpen1.isOpen = true;
            cartForOpen1.StartCheck();
        }
        yield return null;
        if (cartForOpen2 != null)
        {
            Debug.Log("открываем карту 2");
            cartForOpen2.isOpen = true;
            cartForOpen2.StartCheck();
        }
        yield return null;
    }

    public void ValueCheck()
    {
        if (value == 1) 
        {
            if (face1 != null)
                spriteRenderer.sprite = face1;
        }
        else if (value == 2)
        {
            if (face2 != null)
                spriteRenderer.sprite = face2;
        }
        else if (value == 3)
        {
            if (face3 != null)
                spriteRenderer.sprite = face3;
        }
        else if (value == 4)
        {
            if (face4 != null)
                spriteRenderer.sprite = face4;
        }
        else if (value == 5)
        {
            if (face5 != null)
                spriteRenderer.sprite = face5;
        }
        else
        {
            if (face0 != null)
                spriteRenderer.sprite = face0;
        }
    }

    private void ValueMinus(int decreament)
    {
        value -= decreament;
        ValueCheck();
    }

    void OnMouseDown()
    {
        offset = Vector3.Distance(transform.position, Camera.main.transform.position);
        isMove = true;
        spriteRenderer.sortingOrder = 10;
    }

    private void OnMouseDrag()
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
        if (otherCard != null)
        {
            var otherCardBeh = otherCard.GetComponent<CardBeh>(); 
            if (otherCardBeh.colors != colors)
            {
                int othervalue = otherCardBeh.value;
                if (othervalue <= value)
                {
                    StartCoroutine(OpenCards());
                    StartCoroutine(otherCardBeh.OpenCards());
                    StartCoroutine(MergeLogic(othervalue));
                }
            }
        }
        isMove = false;
        transform.position = startPos;
        spriteRenderer.sortingOrder = sortingLayerStart;
    }

    IEnumerator MergeLogic(int othervalue)
    {
        startPos = otherCard.GetComponent<CardBeh>().startPos;
        yield return new WaitForSeconds(0.1f);
        value -= othervalue;
        yield return new WaitForSeconds(0.1f);
        ValueCheck();
        yield return new WaitForSeconds(0.1f);
        Destroy(otherCard);
        yield return new WaitForSeconds(0.1f);
        if (value <= 0)
        {
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Триггер ентер");
        otherCard = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Триггер аут");
        otherCard = null;
    }
}

public enum Colors 
{ 
    green,
    yellow,
    purple,
    blue,
    red
}