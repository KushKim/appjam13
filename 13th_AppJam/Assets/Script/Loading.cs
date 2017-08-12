using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private readonly float minimumTime = 1f;

    [SerializeField]
    private Transform targetTrans;

    [SerializeField]
    private Transform startTrans;

    [SerializeField]
    private Transform endTrans;

    private bool isDone = false;
    private float time = 0f;
    AsyncOperation asyncOperation;

    private void Start()
    {
        StartCoroutine(StartLoad(SceneChanger.Instance.SceneName));
    }

    private void Update()
    {
        time += Time.deltaTime;
        targetTrans.position = Vector3.Lerp(startTrans.position, endTrans.position, time);

        if (time >= minimumTime)
            asyncOperation.allowSceneActivation = true;
    }

    public IEnumerator StartLoad(string sceneName)
    {
        asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        if (!isDone)
        {
            isDone = true;

            while (asyncOperation.progress < 0.9f)
            {
                 targetTrans.position = Vector3.Lerp(startTrans.position, endTrans.position, asyncOperation.progress);   // asyncOperation.progress는 로딩 진척율 0~1

                yield return null;
            }
        }
    }
}