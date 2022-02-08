using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour
{
    TextMeshProUGUI waveCounterText;

    private void Awake()
    {
        waveCounterText = GetComponent<TextMeshProUGUI>();
    }


    public void CountWave(int thisWave)
    {
        waveCounterText.text = "Wave: " + thisWave;
    }

}
