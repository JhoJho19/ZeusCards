using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField] CardBeh cardBeh;
    //[SerializeField] GameObject dependentCard1;
    //[SerializeField] GameObject dependentCard2;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    isCheckStart = false;
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    cardBehCollision = collision.GetComponent<CardBeh>();
    //    isCheckStart = true;
    //}

    //private void Update()
    //{
    //    if (isCheckStart) 
    //    {
    //        if (cardBehCollision != null)
    //        {
    //            if (cardBehCollision.cartForOpen1 == cardBeh || cardBehCollision.cartForOpen2 == cardBeh)
    //            {
    //                if (dependentCard1 == null && dependentCard2 == null)
    //                {
    //                    cardBeh.Open();
    //                    cardBeh.StartCheck();
    //                }
    //            }
    //        }
    //    }
    //}
}
