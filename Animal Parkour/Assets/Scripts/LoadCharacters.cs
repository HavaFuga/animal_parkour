using UnityEngine;

public class LoadCharacters : MonoBehaviour
{
    [SerializeField] private GameObject[] _characterPrefabs;
    

    private void Start()
    {
        int id = PersistentDataManager.SelectedCharacter;
        GameObject prefab = _characterPrefabs[id];
        prefab.SetActive(true);
    }
}
