using TMPro;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    private SpriteRenderer SR;

    public Sprite powerUpSprite;

    public GameObject paddlePlayer;
    private PaddleInventory paddleInventory;

    private InventoryPlayer inventoryPlayer;
    public GameObject inventoryPaddlePlayer;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.sprite = powerUpSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {

            paddleInventory = paddlePlayer.GetComponent<PaddleInventory>();
            inventoryPlayer = inventoryPaddlePlayer.GetComponent<InventoryPlayer>();


            if (paddleInventory != null)
            {
                paddleInventory.playerInventory.Add(this.gameObject);
                inventoryPlayer.refreshUI(paddleInventory.playerInventory);
            }

            gameObject.SetActive(false);
        }
    }

    public void Ativar(GameObject target)
    {
        ApplyEffect(target);
    }

    protected abstract void ApplyEffect(GameObject target);
}