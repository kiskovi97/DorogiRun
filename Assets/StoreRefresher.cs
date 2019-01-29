using UnityEngine;

public class StoreRefresher : MonoBehaviour
{
    public delegate void Refresh();

    public event Refresh refresh;

    public void RefreshStore()
    {
        refresh();
    }
}
