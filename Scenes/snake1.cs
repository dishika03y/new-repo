using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake1 : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List <Transform>_segments;
    public Transform segmentPrefab ;
    private void Start (){
        _segments = new List <Transform>();
        _segments.Add(this.transform);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
            {
            _direction = Vector2.right;
        }
    }
    private void FixedUpdate()
    {
        this.transform.position = new Vector3(
          Mathf.Round(this.transform.position.x) + _direction.x,
          Mathf.Round(this.transform.position.y) + _direction.y,
          0.0f
        );
    }
    private void Grow(){
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "food")
        {
            Grow();
        }
    }


    


}
