using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    [SerializeField]
    private Transform character;

    [SerializeField]
    private float sideFollowPercent;

    [SerializeField]
    private float jumpFollowPercent;

    private float yPosition;

    private void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(character.position.x * sideFollowPercent, yPosition + character.position.y * jumpFollowPercent, transform.position.z);
    }
}
