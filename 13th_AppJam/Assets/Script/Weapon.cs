using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject Attack;
    public GameObject WeakponChanger;

    public Vector3 Scale;
    public float time;

    public float AttackDelayTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonClicked(Transform target)
    {
        StartCoroutine(Button(target));
    }

    public void AttackButtonClick(Transform target)
    {
        if (target.GetChild(0).GetComponent<Image>().fillAmount == 0)
        {
            StartCoroutine(Button(target));

            target.GetChild(0).GetComponent<Image>().fillAmount = 1;
            StartCoroutine(Delay(target.GetChild(0).GetComponent<Image>()));
        }
    }


    IEnumerator Button(Transform target)
    {
        StartCoroutine(Tween.TweenTransform.LocalScale(target, Scale, time));
        yield return new WaitForSeconds(time);
        StartCoroutine(Tween.TweenTransform.LocalScale(target, new Vector3(1, 1, 1), time));
    }


    IEnumerator Delay(Image delayimg)
    {
        while (delayimg.fillAmount > 0)
        {
            delayimg.fillAmount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
