using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    float destroyTimer;
    private void Start()
    {
        destroyTimer = 2;
    }
    private void Update()
    {
        StartCoroutine(DestroyHead());
    }
    IEnumerator DestroyHead()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(this.gameObject);
    }
}
