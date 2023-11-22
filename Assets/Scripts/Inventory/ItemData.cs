using System.Data.Common;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
    public class ItemData : ScriptableObject
    {
        public int id;
        public string itemName;
        public Sprite icon;
        public string description;
    }