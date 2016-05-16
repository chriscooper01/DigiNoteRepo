using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RegistrationProject
{
    public class Register
    {
        private string ancherContent;

        public static void RegisterApplication()
        {

            var classObject = new Register();
            Thread thread;
          
            if (String.IsNullOrEmpty(Anchor.Collect()))
            {
                thread = new Thread(new ThreadStart(classObject.DoRegistration));
            }else
            {
                thread = new Thread(new ThreadStart(classObject.DoOpenStatus));
            }
            thread.Start();

        }



        public void DoRegistration()
        {
            try
            {
                var wcf = new Registration.RegistrationClient();
                ancherContent = wcf.Register(SystemInformation.GetComputerName(), SystemInformation.GetIdentifyNumber(), SystemInformation.GetMachineUniqueId(), SystemInformation.GetUserName());
                Anchor.Create(ancherContent);
                wcf.Log(ancherContent, "RegistrationCreated");
            }
            catch(Exception e)
            {

            }
            
        }


        public void DoOpenStatus()
        {
            try
            {
                ancherContent = Anchor.Collect();
                if (!String.IsNullOrEmpty(ancherContent))
                {
                    var wcf = new Registration.RegistrationClient();
                    wcf.Log(ancherContent,"Openned");
                    Anchor.Create(ancherContent);
                }
                

            }
            catch
            {

            }

        }
    }
}
