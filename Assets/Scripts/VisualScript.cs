using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualScript : MonoBehaviour
{
    private List<Component> components;
    private void Start()
    {
        components = new List<Component>();
        foreach (var child in gameObject.GetComponentsInChildren<Component>())
        {
            components.Add(child);
        }
    }

    public List<Component> GetAllComponents() {
        return components;
    }
}
