using System;
using System.Collections;
using UnityEngine;

public class EnemyPaddleParry : MonoBehaviour
{
    public GameObject parry;

    [Header("Parry Configuration")]
    public float parryDuration = 0.5f;
    public float parryCooldown = 4f;

    [Range(0, 100)]
    public float parryIntencite = 40f;

    private bool isParry;

    private void Start()
    {
        parry.SetActive(false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            float sort = UnityEngine.Random.Range(0f, 100f);

            if (sort <= parryIntencite)
            {
                if (!isParry)
                {
                    isParry = true;
                    StartCoroutine(Parry());
                }
            }
        }
    }

    IEnumerator Parry()
    {
        parry.SetActive(true);
        yield return new WaitForSeconds(parryDuration);
        parry.SetActive(false);
        StartCoroutine(ParryCooldown());
    }

    IEnumerator ParryCooldown()
    {
        yield return new WaitForSeconds(parryCooldown);
        isParry = false;
    }
}
