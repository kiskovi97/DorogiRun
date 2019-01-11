using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    [SerializeField]
    private Transform character;

    [SerializeField]
    private float sideFollowPercent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(character.position.x * sideFollowPercent, transform.position.y, transform.position.z);
    }
}
