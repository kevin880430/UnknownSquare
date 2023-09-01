using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public  class PlayerData 
{
    public Vector3 Location { get; set; }
    public int Health { get; set; }
    public int Mass { get; set; }
    public Vector3 Size { get; set; }
    public int Shape { get; set; }
    public string Stage;
}
