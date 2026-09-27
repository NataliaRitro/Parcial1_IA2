using UnityEngine;

public class LimitManager : MonoBehaviour
{
    public static LimitManager instance;

    [Header("Límites del Escenario")]
    public float width = 25f;
    public float height = 25f;

    private void Awake()
    {
        instance = this;
    }

    public Vector3 ApplyBounds(Vector3 pos)
    {
        // Mathf.Clamp recorta el valor para que nunca supere tus variables
        pos.x = Mathf.Clamp(pos.x, -width, width);
        pos.z = Mathf.Clamp(pos.z, -height, height);

        return pos;
    }
}