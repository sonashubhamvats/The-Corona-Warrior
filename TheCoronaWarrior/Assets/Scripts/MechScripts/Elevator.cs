using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum order
{
    first,second
}
public class Elevator : MonoBehaviour
{
    public order type;
    public Transform spawnPoint;
    public Image message;
    public bool _in;

    public float speed;
    public bool up;


    public GameObject DisallowJumpimg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            if(_in)
            {
                up=true;
                if(type==order.first)
                {
                    AutoSpawnSave.instance.ChangeToSp2();
                }
                else
                {
                    AutoSpawnSave.instance.ChangeToSp3();

                }
            }
        }
        if(up)
        {
            if(transform.parent.position.y<spawnPoint.position.y)
            {

                transform.parent.Translate(Vector2.up*Time.deltaTime*speed);
                DisallowJumpimg.GetComponent<BoxCollider2D>().enabled=true;
            }
            else
            {
                DisallowJumpimg.GetComponent<BoxCollider2D>().enabled=false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            if(!up)
            {
                message.gameObject.SetActive(true);
                _in=true;

            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
        {
            message.gameObject.SetActive(false);
            _in=false;
        }
    }
}
