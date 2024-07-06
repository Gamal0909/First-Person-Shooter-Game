using UnityEngine;

public class GetHealth : MonoBehaviour
{
    public float rotationSpeed = 180f;
    public int healthPlus = 20;

    void Update()
    {
        RotateHealthReload();
    }

    private void RotateHealthReload()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}