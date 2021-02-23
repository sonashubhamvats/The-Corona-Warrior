using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowScriptPlayer : MonoBehaviour
{
    public GameObject player;

    public bool followYtoo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos=transform.position;
        pos.x=player.transform.position.x;
        pos.y=player.transform.position.y;
        transform.position=pos;

    }
}
