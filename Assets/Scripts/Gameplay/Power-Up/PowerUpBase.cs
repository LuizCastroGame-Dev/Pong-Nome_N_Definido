using TMPro;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    private SpriteRenderer SR;

    public Sprite powerUpSprite;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.sprite = powerUpSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ApplyEffect(collision.gameObject);
            Destroy(gameObject);
        }
    }

    protected abstract void ApplyEffect(GameObject target);
}