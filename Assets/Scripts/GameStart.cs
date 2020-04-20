using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    public TextMeshProUGUI counterText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGameAfterTime());
    }

    private IEnumerator StartGameAfterTime()
    {
        Time.timeScale = 0;
        counterText.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        counterText.text = "2";
        yield return new WaitForSecondsRealtime(1f);
        counterText.text = "1";
        yield return new WaitForSecondsRealtime(1f);
        counterText.text = "GO!";
        yield return new WaitForSecondsRealtime(0.5f);
        counterText.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
}
