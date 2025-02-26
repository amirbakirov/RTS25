using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private GameObject _cantBuild;
    [SerializeField] private GameObject _canBuild;
    public Vector2Int Size;

    public void ShowBuildingAvailability(bool isAvailable)
    {
        if (isAvailable)
        {
            //_canBuild.SetActive(true);
            //_cantBuild.SetActive(false);
        }
        else
        {
            //_canBuild.SetActive(false);
           // _cantBuild.SetActive(true);
        }
    }

    public void Build()
    {
       // _canBuild.SetActive(false);
        //_cantBuild.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < Size.x; i++)
        {
            for (int j = 0; j < Size.y; j++)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawCube(transform.position + new Vector3(i, 0, j), new Vector3(1, .1f, 1));
            }
        }
    }
}
