using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance = null;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameController>();

                if (instance == null)
                {
                    GameObject backup = new GameObject();
                    backup.name = "Game Controller";
                    instance = backup.AddComponent<GameController>();
                    DontDestroyOnLoad(backup);
                }
            }

            return instance;
        }
    }

    [SerializeField]
    private CameraController _camera;
    [SerializeField]
    private PlayerController _player;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if (_camera == null)
        {
            _camera = FindObjectOfType<CameraController>();

            if (_camera == null)
            {
                Debug.LogError("Game Controller could not find a Camera Controller!");
            }
        }

        if (_player == null)
        {
            _player = FindObjectOfType<PlayerController>();

            if (_player == null)
            {
                Debug.LogError("Game Controller could not find a Player Controller!");
            }
        }
    }

    public void GameOver (bool fellOffTheLevel = false)
    {
        _camera.followPlayer = false;
        _player.Die(!fellOffTheLevel);
    }
}
