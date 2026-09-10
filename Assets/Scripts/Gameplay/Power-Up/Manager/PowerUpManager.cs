using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class PowerUpManager : MonoBehaviour
{
    [Header("Listas")]
    public List<GameObject> powerUps;
    public List<Transform> SpawnPoints;

    [Header("Spawn config")]
    public float spawnTime = 20f;
    public GameObject paddlePlayer;

    //Spawn Control
    private bool onPowerUp;
    private bool onPowerExisting;
    private List<GameObject> objectInstantiate = new List<GameObject>();
    private PaddleInventory paddleInventory;

    private void Update()
    {
        SpawnPowerUp();
    }

    public void SpawnPowerUp()
    {
        paddleInventory = paddlePlayer.GetComponent<PaddleInventory>();

        if (!onPowerUp)
        {
            onPowerExisting = false;

            foreach (GameObject powerUp in objectInstantiate)
            {
                
                if (powerUp != null && powerUp.activeInHierarchy)
                {
                    onPowerExisting = true;
                    break; 
                }
            }

            if (!onPowerExisting && paddleInventory.playerInventory.Count < 3)
            {
                StartCoroutine(PowerUpLogic());
            }
        }
    }

    IEnumerator PowerUpLogic()
    {
        if (powerUps.Count > 0)
        {
            onPowerUp = true;

            yield return new WaitForSeconds(spawnTime);

            int indiceAleatorioPowerUps = UnityEngine.Random.Range(0, powerUps.Count);
            GameObject powerUpAleatorio = powerUps[indiceAleatorioPowerUps];
            Debug.Log("PowerUp escolhido: " + powerUpAleatorio);

            int indiceAleatorioSpawnPoints = UnityEngine.Random.Range(0, SpawnPoints.Count);
            Transform spawnPointAleatorio = SpawnPoints[indiceAleatorioSpawnPoints];
            Debug.Log("Spawn Point escolhido: " + spawnPointAleatorio);

            objectInstantiate.Add(Instantiate(powerUpAleatorio, spawnPointAleatorio.position, spawnPointAleatorio.rotation));

            onPowerUp = false;
        }
    }
}
