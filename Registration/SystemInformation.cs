using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationProject
{
    public class SystemInformation
    {

        public static string GetUserName()
        {
            try
            {
                return Environment.UserName;
            }catch
            {

            }
            return "Not Collected";
        }
        public static string GetMachineUniqueId()
        {
            string uuid = "Not Collected";
            try
            {

                ManagementClass mc = new ManagementClass("Win32_ComputerSystemProduct");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    uuid = mo.Properties["UUID"].Value.ToString();
                    break;
                }
            }
            catch
            {

            }


            return uuid;
        }


        public static string GetIdentifyNumber()
        {
            string uuid = "Not Collected";

            try
            {
                ManagementClass mc = new ManagementClass("Win32_ComputerSystemProduct");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    uuid = mo.Properties["IdentifyingNumber"].Value.ToString();
                    break;
                }
            }
            catch
            {

            }



            return uuid;
        }

        public static string GetComputerName()
        {
            string uuid = "Not Collected";
            try
            {

                ManagementClass mc = new ManagementClass("Win32_ComputerSystemProduct");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    uuid = mo.Properties["Name"].Value.ToString();
                    break;
                }
            }
            catch
            {

            }


            return uuid;
        }
    }
}
