using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks {
    [SerializeField] private TMP_InputField roomNameInputField;
    [SerializeField] private TMP_Text roomName;
    [SerializeField] private TMP_Text errorText;

    private void Init() {
        Debug.Log("Connecting To Master");
        PhotonNetwork.ConnectUsingSettings();   // Server Connect; Loading
    }

    private void Start() {
        Init();
    }

    public override void OnConnectedToMaster() {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {
        Debug.Log("Joined Lobby");
        // Title Menu ON
        MenuManager.instance.OpenMenu("Title");
    }
    
    public void CreateRoom() {
        if (!string.IsNullOrEmpty(roomNameInputField.text)) {
            PhotonNetwork.CreateRoom(roomNameInputField.text);
            MenuManager.instance.OpenMenu("Loading");
        }
        else {
            return;
        }
    }

    public override void OnJoinedRoom() {
        Debug.Log("Room Joined");
        MenuManager.instance.OpenMenu("Room");
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message) {
       errorText.text = "(" + returnCode + ") Room Creation Failed: " + message;
        MenuManager.instance.OpenMenu("Error");
    }

    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();
        MenuManager.instance.OpenMenu("Loading");
    }

    public override void OnLeftRoom() {
        Debug.Log("Room Left");
        MenuManager.instance.OpenMenu("Title");
    }


}
