using UnityEngine;

public class Underwater : MonoBehaviour
{
    private Transform water;
    private Transform player;

    public static bool playerUnderwater = false;

    private float yOffset = 0.5f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        water = GameObject.FindWithTag("Water").transform;
    }

    private void Update()
    {
        playerUnderwater = player.position.y < water.position.y - yOffset;
    }
}
