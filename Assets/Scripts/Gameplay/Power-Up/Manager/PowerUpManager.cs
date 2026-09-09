using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [Header("Listas")]
    public List<GameObject> powerUps;
    public List<Transform> SpawnPoints;

    public float spawnTime = 20f;

    private bool onPowerUp;
    private GameObject objectInstantiate;

    private void Update()
    {
        SpawnPowerUp();
    }

    public void SpawnPowerUp()
    {
        if (!onPowerUp)
        {
            if (objectInstantiate != null)
            {
                Debug.Log("Power-up em tela: " + objectInstantiate);
                return;
            }
            else
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

            objectInstantiate = Instantiate(powerUpAleatorio, spawnPointAleatorio.position, spawnPointAleatorio.rotation);

            onPowerUp = false;
        }
    }
}
