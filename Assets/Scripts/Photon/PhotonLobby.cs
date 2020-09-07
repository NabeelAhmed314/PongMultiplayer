using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{

    static PhotonLobby lobby;
    public GameObject battleButton;
    public GameObject cancelButton;
    private void Awake()
    {
        lobby = this; //creates singleton,lives within main menu scene.
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // connects to master photon server.
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to Photon Master Server");
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true); // player is now connected to server , enables battle button to allow join a game.
    } 

    public void OnBattleButtonClicked()
    {
        Debug.Log("Battle Button Was Clicked");
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join random game but failed. There must be no open games available. " + message);
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Trying to create room");
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = (byte) MultiplayerSettings.multiplayerSettings.maxPlayers
        };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("We Are in a Room! Yeah");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create random game but failed. There must be game with same name. " + message);
        CreateRoom();    
    }

    public void OnCancelButtonClicked()
    {
        Debug.Log("Cancel Button Was Clicked");
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

}
