using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameManager;

public class Counter : MonoBehaviour
{
    TextMeshProUGUI counterText;
    private void Awake()
    {
        GameManager.Instance.CountdownCounter = this;
    }
    private void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();
       
    }

    internal IEnumerator StartCountdown()
    {
        // Example countdown logic
        int countdownTime = 3;
        while (countdownTime > 0)
        {
            counterText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1);
            countdownTime--;
        }
        counterText.text = "Go!";
        Invoke("DestroySelf",1f);
        GameManager.Instance.ChangeState(GameState.Playing);
    }

   void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
