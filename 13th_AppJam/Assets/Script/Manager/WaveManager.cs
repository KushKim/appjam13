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

    public List<Transform> SpawnPoints;

    public GameObject Monsters;

    public int WaveNum;

    private void Start()
    {
        StartCoroutine(WaveTimeer());
    }

    IEnumerator Wave(int spawnMonsters)
    {
        for (int i = 0; i < spawnMonsters; i++)
        {
            GameObject obj = Instantiate(Enemy, Monsters.transform);
            obj.SetActive(true);
            obj.transform.position = SpawnPoints[i % SpawnPoints.Count].position;
            yield return new WaitForSeconds(0.5f);

        }
    }


    IEnumerator WaveTimeer()
    {
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(Wave(6 + i * 2));
            WaveNum += 1;
            yield return new WaitForSeconds(i * 15);
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
