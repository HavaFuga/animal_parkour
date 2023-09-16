using UnityEngine;

public class LoadCharacters : MonoBehaviour
{
    [SerializeField] private GameObject[] _character;
    

    private void Start()
    {
        _character[PersistentDataManager.SelectedCharacter].SetActive(true);
    }
}
