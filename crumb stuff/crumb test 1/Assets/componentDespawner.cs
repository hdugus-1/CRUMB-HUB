using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class componentDespawner : MonoBehaviour
{

    public List <GameObject> componentsList;
    public List <bool> componentActive;
    public upgradeTrigger UpgradeZone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void DespawnCollected(GameObject hyperComponent)
    {
        componentActive[componentsList.IndexOf(hyperComponent)] = false;

    }
}
