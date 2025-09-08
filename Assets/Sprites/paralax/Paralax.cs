using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer;

    private Vector2 startSize;

    [SerializeField]private float speed;

    private float widht;

    private void Start()
    {

        startSize = new Vector2(_spriteRenderer.size.x , _spriteRenderer.size.y);

    }

    private void Update()
    {
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x + ((PlayerManager.instance.accelerationXvelocity.x / 6f) * Time.deltaTime + speed) * Time.deltaTime , _spriteRenderer.size.y);

        if(_spriteRenderer.size.x >= 48)
        {
            _spriteRenderer.size = startSize;
        }
    }

}
