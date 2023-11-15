using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BinarySave : MonoBehaviour
{
    // Start is called before the first frame update
    public string file_name = "SavingFile";
    public string folder_name = "SavingFolder"; 
    public PlayerInfo playerInfo; 

    public void SaveToFile(){
        if(!Directory.Exists(folder_name)){
            Directory.CreateDirectory(folder_name); 
        }

        BinaryFormatter formatter = new BinaryFormatter(); 
        FileStream save_file = File.Create(folder_name+"/"+file_name+".bin"); 
        formatter.Serialize(save_file, playerInfo); 
        save_file.Close(); 

        print(Directory.GetCurrentDirectory().ToString()); 
    }

    public void _LoadData(){
        BinaryFormatter formatter = new BinaryFormatter(); 
        FileStream save_file = File.Open(folder_name+"/"+file_name+".bin",FileMode.Open); 
        PlayerInfo playerInfo = (PlayerInfo)formatter.Deserialize(save_file);    
        print(playerInfo.health);
        print(playerInfo.score);
        print(playerInfo.name);
        save_file.Close();


    }

}
