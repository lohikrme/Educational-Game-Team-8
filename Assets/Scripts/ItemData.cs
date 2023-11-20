using System.Data.Common;
using UnityEngine;
    
    [CreateAssetMenu]
    public class ItemData : ScriptableObject
    {
        public string id;
        public string itemName;
        public GameObject prefab;
        public Sprite icon;
        public string description;
    }