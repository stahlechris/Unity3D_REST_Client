using UnityEngine.Networking;
public class BypassCertificate : CertificateHandler
{
    //i made this to work bc with https requests i was getting "Unknown Error"
    //this was bc i am using a self signed cert on local host and unity doesn't know how to get past that
    //this simply reads the certificate and validates it no matter what 
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}
