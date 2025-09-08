using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuParalax : MonoBehaviour
{

    public SpriteRenderer _spriteRendererMainMenu;

    private Vector2 startSize;

    [SerializeField] private float speed;

    private float widht;

    private void Start()
    {

        startSize = new Vector2(_spriteRendererMainMenu.size.x, _spriteRendererMainMenu.size.y);

    }

    private void Update()
    {
        _spriteRendererMainMenu.size = new Vector2(_spriteRendererMainMenu.size.x + speed * Time.deltaTime, _spriteRendererMainMenu.size.y);

        if (_spriteRendererMainMenu.size.x >= 48)
        {
            _spriteRendererMainMenu.size = startSize;
        }
    }
}
