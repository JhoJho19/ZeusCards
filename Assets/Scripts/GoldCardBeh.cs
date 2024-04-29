using System.Collections;
using UnityEngine;

public class GoldCardBeh : MonoBehaviour
{
    [SerializeField] GameObject dependentObj1;
    [SerializeField] GameObject dependentObj2;
    [SerializeField] MovesCounter movesCounter;
    bool rewardStart;

    private void FixedUpdate()
    {
        if (dependentObj1 == null && dependentObj2 == null && !rewardStart)
        {
            rewardStart = true;
            movesCounter.MovesCounterPlus();
            StartCoroutine(MoveAndDestroy());
        }
    }

    IEnumerator MoveAndDestroy()
    {
        for (int i = 11; i <= 50; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + i, transform.position.z);
            yield return new WaitForSeconds(0.01f); 
        }
        Destroy(gameObject);
    }
}
