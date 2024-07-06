using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    public float deceleration = 5f;
    public float mass = 3f;

    private Vector3 intensity;
    private CharacterController character;

    void Start()
    {
        intensity = Vector3.zero;
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (intensity.magnitude > 0.2f)
        {
            character.Move(intensity * Time.deltaTime);
        }

        intensity = Vector3.Lerp(intensity, Vector3.zero, deceleration * Time.deltaTime);
    }

    public void AddForce(Vector3 direction, float force)
    {
        intensity += direction.normalized * force / mass;
    }
}