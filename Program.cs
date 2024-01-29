using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;

namespace IntunePackage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Caminho do utilitário intuneWinAppUtill.exe
            string intuneWinAppUtilPath = @"C:\software\IntuneWinAppUtil.exe";
            // Parâmetros do programa
            string sourceFolder = @"C:\software\Orca";
            string setupFile = "Orca.exe";
            string outputFolder = @"C:\software\intune";

            try
            {
                // Create a new PowerShell process
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    // Specify the script or commands you want to execute
                    string script = $"Start-Process -FilePath '{intuneWinAppUtilPath}' -ArgumentList '-c', '{sourceFolder}', '-s', '{setupFile}', '-o', '{outputFolder}', '-q' -Wait -WindowStyle Hidden";

                    // Add the script to the PowerShell process
                    PowerShellInstance.AddScript(script);

                    // Execute the script and collect the results
                    Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                    // Check for errors in the PowerShell script execution
                    if (PowerShellInstance.HadErrors)
                    {
                        // Handle errors
                        foreach (ErrorRecord error in PowerShellInstance.Streams.Error)
                        {
                            // Log or handle each error
                            Console.WriteLine($"PowerShell Error: {error.Exception.Message}");
                        }

                    }

                    // Process the output if needed
                    foreach (PSObject outputItem in PSOutput)
                    {
                        // Handle each output item
                    }
                }


            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Exception: {ex.Message}");

            }
        }   

    }
}