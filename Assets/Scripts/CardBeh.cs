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
    [SerializeField] GameObject dependentCard1;
    [SerializeField] GameObject dependentCard2;
    [SerializeField] GameObject hint;
    GameObject otherCard;
    MovesCounter movesCounter;
    AudioManager audioManager;

    private void Start()
    {
        sortingLayerStart = spriteRenderer.sortingOrder;
        startPos = transform.position;
        StartCheck();
        movesCounter = FindObjectOfType<MovesCounter>();
    }

    public void StartCheck()
    {
        if (isOpen)
        { ValueCheck(); boxCollider.enabled = true; circleCollider.enabled = true; }
        else
        { spriteRenderer.sprite = back; boxCollider.enabled = false; circleCollider.enabled = false; }
    }

    private void FixedUpdate()
    {
        if (dependentCard1 == null && dependentCard2 == null)
        {
            isOpen = true;
            StartCheck();
        }
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

    void OnMouseDown()
    {
        offset = Vector3.Distance(transform.position, Camera.main.transform.position);
        isMove = true;
        spriteRenderer.sortingOrder = 11;
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
            if (otherCardBeh != null)
            {
                {
                    if (otherCardBeh.colors != colors)
                    {
                        StartCoroutine(MergeLogic(otherCardBeh));
                        movesCounter.MovesCounterMinus();
                    }
                    else
                    {
                        ComebackCard();
                    }
                }
            }
            else
            {
                ComebackCard();
            }
        }
        else
        {
            ComebackCard();
        }
    }

    private void ComebackCard()
    {
        isMove = false;
        transform.position = startPos;
        spriteRenderer.sortingOrder = sortingLayerStart;
    }

    IEnumerator MergeLogic(CardBeh otherCardBeh)
    {
        if(hint != null)
        { Destroy(hint); }

        if (audioManager == null)
        { 
            audioManager = FindObjectOfType<AudioManager>();
            audioManager.PlayThunderSound();
        }

        otherCardBeh.value -= value;
        yield return new WaitForSeconds(0.1f);
        otherCardBeh.ValueCheck();
        yield return new WaitForSeconds(0.1f);
        if (otherCardBeh.value <= 0)
        {
            StartCoroutine(MoveAndDestroy(otherCardBeh.gameObject));
            yield return new WaitForSeconds(0.16f);
        }
        StartCoroutine(MoveAndDestroy(gameObject));
        yield return new WaitForSeconds(0.16f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            otherCard = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        otherCard = null;
    }

    public void Open()
    {
        isOpen = true;
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

public enum Colors 
{ 
    green,
    yellow,
    purple,
    blue,
    red
}