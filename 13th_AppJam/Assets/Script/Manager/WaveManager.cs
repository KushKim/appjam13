using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    private static WaveManager instance = null;
    public static WaveManager Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("InGameManager").AddComponent<WaveManager>();
        }
    }

    public GameObject Enemy;

    public Vector3[] SpawnPoints;

    IEnumerator Wave(int spawnMonsters)
    {
        for (int i = 0; i < spawnMonsters; i++)
        {
            GameObject obj = Instantiate(Enemy);
            obj.transform.position = SpawnPoints[i % SpawnPoints.Length];
            yield return new WaitForSeconds(0.5f);

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(Wave(5));
        }
    }

    public void ActiveWave(int spawnMonsters)
    {
        StartCoroutine(Wave(spawnMonsters));
    }
}
