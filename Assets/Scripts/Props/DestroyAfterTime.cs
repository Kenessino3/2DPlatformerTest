using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float lifeTime = 4f;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
