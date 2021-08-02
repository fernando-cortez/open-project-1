using MLAPI;
using MLAPI.NetworkVariable;
using UnityEngine;

public class LocalPlayer : NetworkBehaviour
{
	public static LocalPlayer Instance { get; private set; }

	public NetworkVariableVector2 MoveVector = new NetworkVariableVector2(new NetworkVariableSettings()
	{
		WritePermission = NetworkVariablePermission.OwnerOnly
	});

	public override void OnNetworkSpawn()
	{
		name = "Player" + OwnerClientId;

		if (!IsClient || !IsLocalPlayer)
		{
			return;
		}

		Instance = this;
	}
}
