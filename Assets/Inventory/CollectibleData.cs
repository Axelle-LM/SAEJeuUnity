using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Collectible Data")]
public class CollectibleData : ScriptableObject //Pas de notation hongroise sur des scriptable objects
{
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    public GameObject model;
}
