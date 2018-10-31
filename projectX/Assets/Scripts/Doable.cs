using System.Collections.Generic;
using UnityEngine;

public class Doable : MonoBehaviour{

	/// <summary>
	/// a list of senders. helpful when waiting for one signal from each sender
	/// </summary>
	public List<GameObject> senders;

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
	public virtual bool signal(GameObject sender){
		return true;
	}
}
