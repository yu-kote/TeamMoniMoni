using UnityEngine;
using System.Collections;

public class LayerController : MonoBehaviour
{

    public enum Layer
    {
        FLOOR,
        WALL,
        OBJECT,
        EVENT,
        LAYER_MAX,
    }

    static public string layernumToString(int i)
    {
        switch (i)
        {
            case (int)Layer.FLOOR:
                return "Floor";
            case (int)Layer.WALL:
                return "Wall";
            case (int)Layer.OBJECT:
                return "Object";
            case (int)Layer.EVENT:
                return "Event";
        }
        return null;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
