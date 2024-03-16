using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Collectible Data")]
public class CollectibleData : ScriptableObject
{
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    public GameObject model;
}
