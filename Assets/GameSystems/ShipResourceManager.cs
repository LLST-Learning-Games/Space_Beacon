using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipResourceManager : MonoBehaviour
{
    [SerializeField] private List<ShipResourceSystem> _resources = new List<ShipResourceSystem>();
    
    public ShipResourceSystem GetResourceByName(string name) => _resources.First(x => x.ResourceName == name);

}
