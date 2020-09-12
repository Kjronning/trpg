using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TacticsMove
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            findSelectableTiles();
            CheckMouse();
        }
        else
        {
           Move();
        }
    }

    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit))
            {
                return;
            }

            if (!hit.collider.tag.Equals("Tile"))
            {
                return;
            }

            Tile t = hit.collider.GetComponent<Tile>();
            if (!t.selectable)
            {
                return;
            }
            MoveToTile(t);
        }
    }
    
}
