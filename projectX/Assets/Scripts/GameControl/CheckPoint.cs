using UnityEngine;

public class CheckPoint : MonoBehaviour{

    public GameControl gameControl;
    public int index;

    private void OnTriggerEnter(Collider other){
        if (other.gameObject == Global.player) gameControl.setCheckPoint(index);
    }
}
