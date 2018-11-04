using System.Collections.Generic;
using UnityEngine;

public class Doable : MonoBehaviour{

	/// <summary>
	/// a list of senders. helpful when waiting for one signal from each sender
	/// </summary>
	public List<GameObject> senders= new List<GameObject>();
	protected List<GameObject> signaledFrom = new List<GameObject>();

	/// <summary>
	/// add a sender
	/// </summary>
	/// <param name="sender">signal sender</param>
	/// <returns>sender is already in senders</returns>
	public bool addSender(GameObject sender){
		if (senders.Contains(sender)) return false;
		senders.Add(sender);
		return true;
	}

	/// <summary>
	/// interface for a object that can do stuff when signaled
	/// </summary>
	/// <param name="sender">signal sender</param>
	/// <returns>signal is processed</returns>
	public bool signal(GameObject sender){
		if (!signaledFrom.Contains(sender)){
			signaledFrom.Add(sender);
		}
		if (senders.Count > 0 && senders.Count != signaledFrom.Count) return false;
		signaledFrom.Clear();
		action();
		return true;
	}

	public virtual void action(){
		throw new System.NotImplementedException();
	}
}
