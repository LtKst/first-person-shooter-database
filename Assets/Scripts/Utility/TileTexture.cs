using UnityEngine;

public class TileTexture : MonoBehaviour
{
    [SerializeField]
    private Vector2 tiling = Vector2.one;
    private Renderer rend;
    
    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void Start()
    {
        rend.material.mainTextureScale = tiling;
    }
}
