using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
using UnityEngine;
using System;


[Serializable]
public class PlayerInfo
{
    public int health;
    public int score;
    public string name;
}
