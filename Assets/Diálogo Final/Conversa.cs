using UnityEngine;

[CreateAssetMenu(fileName = "Novo Dialogo", menuName = "Dialogo/Conversa")]
public class Conversa : ScriptableObject
{
    public FalasDaConversa[] Falas;
}

[System.Serializable]
public class FalasDaConversa
{
    public Personagem Personagem;
    public int IdDaExpressao;

    [TextArea]
    public string[] TextoDasFalas;    
}
