using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ssas_toolbox_library;
using System.IO;

namespace ssas_toolbox_console
{
    class Program
    {
        static void Main(string[] args)
        {
            // get parameter values form app.config
            string SSASConnectionString = "";
            string OutputFolderPath = ConfigurationManager.AppSettings["OutputFolderPath"];
            bool OverwriteOutputFile = Convert.ToBoolean(ConfigurationManager.AppSettings["OverwriteOutputFile"]);

            string useConfig = "";
            string nSwitch = null;
            string databaseName = null;
            string cubeName = null;
            string measureGroupName = null;
            string roleName = null;
            string output = "";
            string currentFileName = "";
            string currentMethodName = "";
            bool error = false;

            Console.Write("Do you want to use the config file (y) or overwrite SSAS connection string (n)?: ");
            useConfig = Console.ReadLine();

            if (useConfig == "y")
            {
                SSASConnectionString = ConfigurationManager.AppSettings["SSASConnectionString"];
            }
            else if (useConfig == "n")
            {
                Console.Write("Provide the SSAS machine name and instance name ex: localhost\\myinstance: ");
                string instance = Console.ReadLine();
                Console.Write("Provide the SSAS database name: ");
                string database = Console.ReadLine();
                SSASConnectionString = "Data source=" + instance + ";Database=" + database;
            }
            else
            {
                SSASConnectionString = ConfigurationManager.AppSettings["SSASConnectionString"];
                Console.WriteLine("The input was not correct. The configuration file will be used.");
            }

            // Display menu
            Console.WriteLine("\n");
            Console.WriteLine("0.  Exit");
            Console.WriteLine("1.  Discover databases processing states");
            Console.WriteLine("2.  Discover dimensions processing states");
            Console.WriteLine("3.  Discover cubes processing states");
            Console.WriteLine("4.  Discover measure groups processing states");
            Console.WriteLine("5a. Discover partitions processing states");
            Console.WriteLine("5b. Discover partitions processing states - unprocessed only");
            Console.WriteLine("5c. Discover partitions processing states - specify database, cube and measure group name");
            Console.WriteLine("6a. Discover users in roles");
            Console.WriteLine("6b. Discover users in roles - specify database and role name");
            Console.WriteLine("7a. Discover roles permissions");
            Console.WriteLine("7b. Discover roles permissions - specify database and role name");


            // Initialize 
            SSASDiscover ssasDiscover = new SSASDiscover();
            ssasDiscover.OutputFolderPath = OutputFolderPath;
            ssasDiscover.SSASConnectionString = SSASConnectionString;
            ssasDiscover.OverwriteOutputFile = OverwriteOutputFile;
            
            do
            {

                error = false;
                Console.Write("\nType the option: ");
                nSwitch = Console.ReadLine();

                try
                {
                    switch (nSwitch)
                    {
                        case "0":
                            break;
                        case "1":
                            currentMethodName = "DatabaseState";
                            output = ssasDiscover.DatabaseState();
                            break;
                        case "2":
                            currentMethodName = "DatabaseDimensionState";
                            output = ssasDiscover.DatabaseDimensionState();
                            break;
                        case "3":
                            currentMethodName = "CubeState";
                            output = ssasDiscover.CubeState();
                            break;
                        case "4":
                            currentMethodName = "MeasureGroupState";
                            output = ssasDiscover.MeasureGroupState();
                            break;
                        case "5a":
                            currentMethodName = "PartitionState";
                            output = ssasDiscover.PartitionState();
                            break;
                        case "5b":
                            currentMethodName = "PartitionState";
                            output = ssasDiscover.PartitionState(true);
                            break;
                        case "5c":
                            currentMethodName = "PartitionState";
                            Console.Write("Type the database name: ");
                            databaseName = Console.ReadLine();
                            Console.Write("Type the cube name: ");
                            cubeName = Console.ReadLine();
                            Console.Write("Type the measure group name: ");
                            measureGroupName = Console.ReadLine();
                            output = ssasDiscover.PartitionState(databaseName, cubeName, measureGroupName);
                            break;
                        case "6a":
                            currentMethodName = "RoleUsers";
                            ssasDiscover.RoleUsers();
                            break;
                        case "6b":
                            currentMethodName = "RoleUsers";
                            Console.Write("Type the database name: ");
                            databaseName = Console.ReadLine();
                            Console.Write("Type the role name: ");
                            roleName = Console.ReadLine();
                            output = ssasDiscover.RoleUsers(databaseName, roleName);
                            break;
                        case "7a":
                            currentMethodName = "RolePermissions";
                            output = ssasDiscover.RolePermissions();
                            break;
                        case "7b":
                            currentMethodName = "RolePermissions";
                            Console.Write("Type the database name: ");
                            databaseName = Console.ReadLine();
                            Console.Write("Type the role name: ");
                            roleName = Console.ReadLine();
                            output = ssasDiscover.RolePermissions(databaseName, roleName);
                            break;

                        default:
                            Console.WriteLine("Not implemented");
                            error = true;
                            break;
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message + "\n\n\n" + exc.InnerException);
                    error = true;
                }

                if (!error)
                {
                    if (!OverwriteOutputFile)
                    {
                        currentFileName = OutputFolderPath + "ssas_toolset_" + currentMethodName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                    }
                    else
                    {
                        currentFileName = OutputFolderPath + "ssas_toolset_" + currentMethodName + ".txt";
                    }

                    File.WriteAllText(currentFileName, output.ToString());
                    Console.Write("Done, check log directories for details.\n");
                }

            } while (nSwitch != "0");

        }
    }
}
