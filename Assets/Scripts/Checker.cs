using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField] CardBeh cardBeh;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("�������");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("�����");
        CardBeh cardBehCollision = collision.GetComponent<CardBeh>();
        if (cardBehCollision != null)
        {
            if (cardBehCollision.cartForOpen1 == cardBeh || cardBehCollision.cartForOpen2 == cardBeh)
                cardBeh.Open();
        }
    }
}
