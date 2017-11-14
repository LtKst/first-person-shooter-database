using UnityEngine;

public class UnderwaterComponent : MonoBehaviour
{
    [SerializeField]
    private MonoBehaviour[] components;

    private void Update()
    {
        for (int i = 0; i < components.Length; i++)
        {
            bool enabled = Underwater.playerUnderwater;

            components[i].enabled = enabled;
        }
    }
}
