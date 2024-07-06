using UnityEngine;

public class AmmoCreate : MonoBehaviour
{
    public float rotationSpeed = 180f;
    public int ammo = 10;

    void Update()
    {
        RotateAmmoReload();
    }

    private void RotateAmmoReload()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}