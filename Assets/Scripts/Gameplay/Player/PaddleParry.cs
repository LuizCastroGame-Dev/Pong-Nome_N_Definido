using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class PaddleParry : MonoBehaviour
{
    [Header("Managers")]
    public PaddleInput paddleInput;
    public GameObject parry;

    [Header("Parry Configuration")]
    public float parryDuration = 0.5f;
    public float parryCooldown = 4f;

    private bool isParry = false;

    private void Start()
    {
        parry.SetActive(false);
    }

    void Update()
    {
        ParryPaddle();
    }

    public void ParryPaddle()
    {
        bool input = paddleInput.InputParry();

        if (input == true)
        {
            if (!isParry)
            {
                isParry = true;
                StartCoroutine(Parry());
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
