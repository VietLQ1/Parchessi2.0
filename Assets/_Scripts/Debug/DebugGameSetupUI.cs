using UnityEngine;
using UnityEngine.UI;


public class DebugGameSetupUI : MonoBehaviour
{


    [SerializeField] private Button _createController;
    [SerializeField] Button _startGame;
    
    // Start is called before the first frame update
    void Awake()
    {
        _createController.onClick.AddListener( () =>
        {
            GameManager.Instance.CreatePlayerController();
            Debug.Log("Create Controller");
            
        });
        
        _startGame.onClick.AddListener(() =>
        {
            GameManager.Instance.StartGameServerRPC();
            Debug.Log("Start Game");
            
        });
        
        GameManager.Instance.OnGameStart += DestroyThis;
    }
    
    
    void DestroyThis()
    {
        GameManager.Instance.OnGameStart -= DestroyThis;
        Destroy(this.gameObject);
    }

    
}
