using UnityEngine;

public class Magnet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();
        if(coin == null)
        {
            return;
        }
        coin.MagnetAttract(transform);
    }
}
