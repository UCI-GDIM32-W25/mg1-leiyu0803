using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        _numSeedsLeft = _numSeeds;
        _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
    }

    private void Update()
    {
        _playerTransform.position += Vector3.right * Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        _playerTransform.position += Vector3.up * Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space)) {
            if(_numSeedsLeft > 0)
            {
                PlantSeed();
                _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
            }
        }

    }

    public void PlantSeed ()
    {
        GameObject plant = Instantiate(_plantPrefab);
        plant.transform.position = _playerTransform.position;
        _numSeedsLeft--;
        _numSeedsPlanted++;
    }
}
