using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] private float timeToExplosion;
    [SerializeField] private float _radius;
    [SerializeField] private float _power;
    private float currentTime;
    private bool isExplosion;

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > timeToExplosion)
        {
            if (!isExplosion)
            {
                isExplosion = true;
                Explosion();
            }
        }
    }

    void Explosion()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, _radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(_power, explosionPos, _radius, 3.0F, ForceMode.Impulse);
        }
    }
}
