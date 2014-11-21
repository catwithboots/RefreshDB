using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace RefreshDB.WebAPI.Backend
{
    public class WSManHelper
    {
        public static void openRunspace(string uri, string schema, string username, string livePass, ref Runspace remoteRunspace)
        {
            try
            {
                System.Security.SecureString password = new System.Security.SecureString();
                foreach (char c in livePass.ToCharArray())
                {
                    password.AppendChar(c);
                }
                PSCredential psc = new PSCredential(username, password);
                WSManConnectionInfo rri = new WSManConnectionInfo(new Uri(uri), schema, psc);
                rri.AuthenticationMechanism = AuthenticationMechanism.Negotiate;
                rri.ProxyAuthentication = AuthenticationMechanism.Negotiate;
                remoteRunspace = RunspaceFactory.CreateRunspace(rri);
                remoteRunspace.Open();
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }

        }


    }
}