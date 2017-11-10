using System.Collections;
using UnityEngine;

public class WeaponDatabase : MonoBehaviour
{
    public IEnumerator QueryShot(Vector3 playerPosition, Vector3 hitPoint, string hitObjectName)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.LogWarning("User not connected to internet, can't query to database");
        }
        else
        {
            WWW request = new WWW("http://22084.hosts.ma-cloud.nl/GPR_DB.php?p_pos=" + playerPosition.ToString() + "&h_pos=" + hitPoint.ToString() + "&h_dist=" + Vector3.Distance(playerPosition, hitPoint).ToString() + "&h_obj=" + hitObjectName + "&p_id=" + SystemInfo.deviceUniqueIdentifier.GetHashCode());

            yield return request;
        }
    }
}
