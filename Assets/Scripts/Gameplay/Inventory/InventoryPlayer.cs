using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPlayer : MonoBehaviour
{
    public Image[] slots;
    public Sprite emptySlotSprite;

    [Header("Seleção")]
    public Color corSelecionada = Color.yellow;
    public Color corNormal = Color.white;

    private int selectedIndex = 0;
    private List<GameObject> inventarioAtual = new List<GameObject>();

    void Update()
    {
        //Remover essa logica e utilizar a logica vinda do script PaddleInput - Por hora manter afins de teste
        if (Input.GetKeyDown(KeyCode.A)) MoverSelecaoEsquerda();
        if (Input.GetKeyDown(KeyCode.D)) MoverSelecaoDireita();
        if (Input.GetKeyDown(KeyCode.E)) UsarPowerUpSelecionado();
    }

    public void refreshUI(List<GameObject> inventory)
    {
        inventarioAtual = inventory; // guarda referência pra usar no Usar() e na seleção

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.Count)
            {
                SpriteRenderer sr = inventory[i].GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    slots[i].sprite = sr.sprite;
                }
            }
            else
            {
                slots[i].sprite = emptySlotSprite;
            }
        }

        AtualizarDestaque();
    }

    void AtualizarDestaque()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].color = (i == selectedIndex) ? corSelecionada : corNormal;
        }
    }

    void MoverSelecaoEsquerda()
    {
        if (inventarioAtual.Count == 0) return;

        selectedIndex--;
        if (selectedIndex < 0)
            selectedIndex = inventarioAtual.Count - 1;
        AtualizarDestaque();
    }

    void MoverSelecaoDireita()
    {
        if (inventarioAtual.Count == 0) return;

        selectedIndex++;
        if (selectedIndex >= inventarioAtual.Count)
            selectedIndex = 0;

        AtualizarDestaque();
    }

    void UsarPowerUpSelecionado()
    {
        if (inventarioAtual.Count == 0) return;

        GameObject powerUpEscolhido = inventarioAtual[selectedIndex];

        PowerUpBase powerUp = powerUpEscolhido.GetComponent<PowerUpBase>();
        if (powerUp != null)
        {
            powerUp.Ativar(powerUp.paddlePlayer);
        }

        inventarioAtual.RemoveAt(selectedIndex);

        if (selectedIndex >= inventarioAtual.Count)
            selectedIndex = Mathf.Max(0, inventarioAtual.Count - 1);

        refreshUI(inventarioAtual);
    }
}
