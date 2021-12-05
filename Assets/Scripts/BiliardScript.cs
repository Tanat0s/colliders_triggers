using UnityEngine;

public class BiliardScript : MonoBehaviour
{
    [SerializeField] private float timeToHit;
    [SerializeField] private float powerHit;
    private float currentTime;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0.0f;
        rigidbody = GetComponent<Rigidbody>();
    }

    bool isHit;
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > timeToHit)
        {
            if (!isHit)
            {
                isHit = true;
                rigidbody.AddForce(new Vector3(0, 0, powerHit), ForceMode.Impulse);
            }
        }
    }
}
