using Unity.Multiplayer.Netcode;
using UnityEngine;

public class EnableBehavioursOnNetworkSpawn : NetworkBehaviour
{
	[SerializeField]
	Behaviour[] m_Behaviours;

	public override void OnNetworkSpawn()
	{
		if (!IsClient || !IsLocalPlayer)
		{
			return;
		}

		foreach (var behaviour in m_Behaviours)
		{
			behaviour.enabled = true;
		}
	}
}
