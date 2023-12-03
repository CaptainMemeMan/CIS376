using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class CoinManager : MonoBehaviour
{
    public int count;
    public TMP_Text Ctext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ctext.text = "Coins Collected: " + count.ToString();
    }
}
