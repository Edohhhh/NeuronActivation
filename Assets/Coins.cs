using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinAcquired;
    [SerializeField] TMPro.TextMeshProUGUI coinsCountText;
    public void add (int count)
    {
        coinAcquired += count;
        coinsCountText.text= "Coins:" + coinAcquired.ToString();
    }
}
