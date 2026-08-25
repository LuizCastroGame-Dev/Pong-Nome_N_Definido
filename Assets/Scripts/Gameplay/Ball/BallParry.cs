using System.Collections;
using UnityEngine;

public class BallParry : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Parry and waiting seconds for parry")]
    public Vector2 parrySpeedBonus = new Vector2(2f, 0f);
    public float parryDuration = 4f;

    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    public void StopParry()
    {
        StopAllCoroutines();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        #region Parry
        if (collision.gameObject.CompareTag("Parry"))
        {
            StartCoroutine(Parry());
        }
        #endregion
    }

    #region Parry - Coroutine - logic
    IEnumerator Parry()
    {
        //Mexer com a logica do parry para melhor entendimento do script -- (A logica do script ta funcionando perfeitamente, mas está dificil sua leitura)
        if (rb.linearVelocityX < 0)
        {
            rb.linearVelocity += -parrySpeedBonus;
            yield return new WaitForSeconds(parryDuration);
            if (rb.linearVelocityX < 0)
            {
                rb.linearVelocity += parrySpeedBonus;
            }
            else
            {
                rb.linearVelocity += -parrySpeedBonus;
            }
        }
        else
        {
            rb.linearVelocity += parrySpeedBonus;
            yield return new WaitForSeconds(parryDuration);
            if (rb.linearVelocityX < 0)
            {
                rb.linearVelocity += parrySpeedBonus;
            }
            else
            {
                rb.linearVelocity += -parrySpeedBonus;
            }
        }
    }
    #endregion
}
