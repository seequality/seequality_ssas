using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ssas_toolbox_library;

namespace ssas_toolbox_console
{
    class Program
    {
        static void Main(string[] args)
        {
            // get parameter values form app.config
            string SSASConnectionString = ConfigurationManager.AppSettings["SSASConnectionString"];
            string OutputFolderPath = ConfigurationManager.AppSettings["OutputFolderPath"];
            bool OverwriteOutputFile = Convert.ToBoolean(ConfigurationManager.AppSettings["OverwriteOutputFile"]);

            string nSwitch = null;
            string databaseName = null;
            string cubeName = null;
            string measureGroupName = null;
            string roleName = null;

            // Display menu
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

                Console.Write("\nType the option: ");
                nSwitch = Console.ReadLine();

                switch (nSwitch)
                {
                    case "0":
                        break;
                    case "1":
                        ssasDiscover.DatabaseState();
                        Console.Write("Done, check log directories for details.\n");
                        break;
                    case "2":
                        ssasDiscover.DatabaseDimensionState();
                        Console.Write("Done, check log directories for details.\n");
                        break;
                    case "3":
                        ssasDiscover.CubeState();
                        Console.Write("Done, check log directories for details.\n");
                        break;
                    case "4":
                        ssasDiscover.MeasureGroupState();
                        Console.Write("Done, check log directories for details.\n");
                        break;
                    case "5a":
                        ssasDiscover.PartitionState();
                        Console.Write("Done, check log directories for details.\n");
                        break;
                    case "5b":
                        ssasDiscover.PartitionState(true);
                        Console.Write("Done, check log directories for details.\n");
                        break;
                    case "5c":
                        Console.Write("Type the database name: ");
                        databaseName = Console.ReadLine();
                        Console.Write("Type the cube name: ");
                        cubeName = Console.ReadLine();
                        Console.Write("Type the measure group name: ");
                        measureGroupName = Console.ReadLine();
                        ssasDiscover.PartitionState(databaseName, cubeName, measureGroupName);
                        Console.Write("Done, check log directories for details.\n");
                        break;
                    case "6a":
                        ssasDiscover.RoleUsers();
                        Console.Write("Done, check log directories for details.\n");
                        break;
                    case "6b":
                        Console.Write("Type the database name: ");
                        databaseName = Console.ReadLine();
                        Console.Write("Type the role name: ");
                        roleName = Console.ReadLine();
                        ssasDiscover.RoleUsers(databaseName, roleName);
                        Console.Write("Done, check log directories for details.\n");
                        break;
                    case "7a":
                        ssasDiscover.RolePermissions();
                        Console.Write("Done, check log directories for details.\n");
                        break;
                    case "7b":
                        Console.Write("Type the database name: ");
                        databaseName = Console.ReadLine();
                        Console.Write("Type the role name: ");
                        roleName = Console.ReadLine();
                        ssasDiscover.RolePermissions(databaseName, roleName);
                        Console.Write("Done, check log directories for details.\n");
                        break;

                    default:
                        Console.WriteLine("Not implemented");
                        break;
                }

            } while (nSwitch != "0");

        }
    }
}
