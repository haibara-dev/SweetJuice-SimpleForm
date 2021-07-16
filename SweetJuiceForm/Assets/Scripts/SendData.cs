using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text.RegularExpressions;


public class SendData : MonoBehaviour
{
    public InputField _candidato;
    public InputField _nomeCompleto;
    public InputField _email;
    public InputField _dataNascimento;

    public static bool invalido;
    public static bool validado;

    public const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

    public const string BirthDatePattern = @"(((0|1)[0-9]|2[0-9]|3[0-1])/(0[1-9]|1[0-2])/((19|20)\d\d))$";


    public void BtnEnviar()
    {
        StartCoroutine(Enviar(_candidato.text, _nomeCompleto.text, _email.text, _dataNascimento.text));
    }

    IEnumerator Enviar(string candidato, string nome, string email, string nascimento)
    {
        WWWForm form = new WWWForm();

        if (Regex.IsMatch(email.ToString(), MatchEmailPattern) && Regex.IsMatch(nascimento.ToString(), BirthDatePattern))
        {
            form.AddField("candidate", candidato.ToString().ToLower());
            form.AddField("fullname", nome.ToString().ToLower());
            form.AddField("email", email.ToString().ToLower());
            form.AddField("birthdate", nascimento.ToString().ToLower());

            UnityWebRequest www = UnityWebRequest.Post("https://sweetbonus.com.br/sweet-juice/trainee-test/submit?candidate={SEU_PRIMEIRO_NOME}&fullname={NOME_COMPLETO_DO_FORMULARIO}&email={EMAIL_DO_FORMULARIO}&birthdate={DATA_NASCIMENTO_DO_FORMULARIO}", form);
            yield return www.SendWebRequest();

            validado = true;
        }
        else
        {
            invalido = true;
            Debug.Log("Informações não válidas");
        }

    }
}
