using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum_Script : MonoBehaviour
{
    private PhysicMaterial vacuumMaterial;
    private Dictionary<string, PhysicMaterial> dictionaryPhysicMaterials;

    // Start is called before the first frame update
    void Start()
    {
        vacuumMaterial = new PhysicMaterial();
        vacuumMaterial.dynamicFriction = 0;
        vacuumMaterial.staticFriction = 0;

        dictionaryPhysicMaterials = new Dictionary<string, PhysicMaterial>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.useGravity = false;

        if (!dictionaryPhysicMaterials.ContainsKey(other.name))
            dictionaryPhysicMaterials[other.name] = other.material;

        other.material = vacuumMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        other.attachedRigidbody.useGravity = true;

        if (dictionaryPhysicMaterials.ContainsKey(other.name))
            other.material = dictionaryPhysicMaterials[other.name];
    }
}
