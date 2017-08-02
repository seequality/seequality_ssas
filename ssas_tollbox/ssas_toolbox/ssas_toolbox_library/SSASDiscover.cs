using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AnalysisServices;
using System.IO;
using ssas_toolbox_library;

namespace ssas_toolbox_library
{
    public class SSASDiscover
    {
        public string OutputFolderPath { get; set; }
        public string SSASConnectionString { get; set; }
        public bool OverwriteOutputFile { get; set; }

        public void DatabaseState()
        {
            StringBuilder output = new StringBuilder();
            string currentFileName = "";

            if (!OverwriteOutputFile)
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            }
            else
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + ".txt";
            }

            Server server;

            try
            {

                server = new Server();
                server.Connect(SSASConnectionString);

                foreach (Database database in server.Databases)
                {
                    output.AppendLine("Discover server: " + SSASConnectionString + ", database: " + database.Name + ", state: " + database.State + ", last processed: " + database.LastProcessed);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

            File.WriteAllText(currentFileName, output.ToString());

        }

        public void DatabaseDimensionState()
        {
            StringBuilder output = new StringBuilder();
            string currentFileName = "";

            if (!OverwriteOutputFile)
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            }
            else
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + ".txt";
            }
            Server server;

            try
            {

                server = new Server();
                server.Connect(SSASConnectionString);

                foreach (Database database in server.Databases)
                {
                    foreach (Dimension dimension in database.Dimensions)
                    {
                        output.AppendLine("Discover server: " + SSASConnectionString + ", database: " + database.Name + ", dimension: " + dimension.Name + ", state: " + dimension.State + ", last processed: " + dimension.LastProcessed);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

            File.WriteAllText(currentFileName, output.ToString());

        }

        public void CubeState()
        {
            StringBuilder output = new StringBuilder();
            string currentFileName = "";

            if (!OverwriteOutputFile)
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            }
            else
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + ".txt";
            }
            Server server;

            try
            {

                server = new Server();
                server.Connect(SSASConnectionString);

                foreach (Database database in server.Databases)
                {
                    foreach (Cube cube in database.Cubes)
                    {
                        output.AppendLine("Discover server: " + SSASConnectionString + ", database: " + database.Name + ", cube: " + cube.Name + ", state: " + cube.State + ", last processed: " + cube.LastProcessed);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

            File.WriteAllText(currentFileName, output.ToString());

        }

        public void MeasureGroupState()
        {
            StringBuilder output = new StringBuilder();
            string currentFileName = "";

            if (!OverwriteOutputFile)
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            }
            else
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + ".txt";
            }
            Server server;

            try
            {

                server = new Server();
                server.Connect(SSASConnectionString);

                foreach (Database database in server.Databases)
                {
                    foreach (Cube cube in database.Cubes)
                    {
                        foreach (MeasureGroup measureGroup in cube.MeasureGroups)
                        {
                            output.AppendLine("Discover server: " + SSASConnectionString + ", database: " + database.Name + ", cube: " + cube.Name + ", measure group: " + measureGroup.Name + ", state: " + measureGroup.State + ", last processed: " + measureGroup.LastProcessed);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

            File.WriteAllText(currentFileName, output.ToString());

        }

        public void PartitionState()
        {
            StringBuilder output = new StringBuilder();
            string currentFileName = "";

            if (!OverwriteOutputFile)
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            }
            else
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + ".txt";
            }
            Server server;

            try
            {

                server = new Server();
                server.Connect(SSASConnectionString);

                foreach (Database database in server.Databases)
                {
                    foreach (Cube cube in database.Cubes)
                    {
                        foreach (MeasureGroup measureGroup in cube.MeasureGroups)
                        {
                            foreach (Partition partition in measureGroup.Partitions)
                            {
                                output.AppendLine("Discover server: " + SSASConnectionString + ", database: " + database.Name + ", cube: " + cube.Name + ", measure group: " + measureGroup.Name + ", partition: " + partition.Name + ", state: " + partition.State + ", last processed: " + partition.LastProcessed);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

            File.WriteAllText(currentFileName, output.ToString());

        }

        public void PartitionState(bool UnprocessedOnly)
        {
            StringBuilder output = new StringBuilder();
            string currentFileName = "";

            if (!OverwriteOutputFile)
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            }
            else
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + ".txt";
            }
            Server server;

            try
            {

                server = new Server();
                server.Connect(SSASConnectionString);

                foreach (Database database in server.Databases)
                {
                    foreach (Cube cube in database.Cubes)
                    {
                        foreach (MeasureGroup measureGroup in cube.MeasureGroups)
                        {
                            foreach (Partition partition in measureGroup.Partitions)
                            {
                                if (partition.State != AnalysisState.Processed)
                                {
                                    output.AppendLine("Discover server: " + SSASConnectionString + ", database: " + database.Name + ", cube: " + cube.Name + ", measure group: " + measureGroup.Name + ", partition: " + partition.Name + ", state: " + partition.State + ", last processed: " + partition.LastProcessed);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

            File.WriteAllText(currentFileName, output.ToString());

        }

        public void PartitionState(string DatabaseName, string CubeName, string MeasureGroupName)
        {
            StringBuilder output = new StringBuilder();
            string currentFileName = "";

            if (!OverwriteOutputFile)
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            }
            else
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + ".txt";
            }
            Server server;

            try
            {

                server = new Server();
                server.Connect(SSASConnectionString);

                Database database = server.Databases.GetByName(DatabaseName);
                Cube cube = database.Cubes.GetByName(CubeName);
                MeasureGroup measureGroup = cube.MeasureGroups.GetByName(MeasureGroupName);

                foreach (Partition partition in measureGroup.Partitions)
                {
                    output.AppendLine("Discover server: " + SSASConnectionString + ", database: " + database.Name + ", cube: " + cube.Name + ", measure group: " + measureGroup.Name + ", partition: " + partition.Name + ", state: " + partition.State + ", last processed: " + partition.LastProcessed);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

            File.WriteAllText(currentFileName, output.ToString());

        }

        public void RoleUsers()
        {
            StringBuilder output = new StringBuilder();
            string currentFileName = "";

            if (!OverwriteOutputFile)
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            }
            else
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + ".txt";
            }
            Server server;

            try
            {

                server = new Server();
                server.Connect(SSASConnectionString);

                foreach (Database database in server.Databases)
                {
                    foreach (Role role in database.Roles)
                    {
                        foreach (RoleMember roleMember in role.Members)
                        {
                            output.AppendLine("Discover server: " + SSASConnectionString + ", database: " + database.Name + ", role: " + role.Name + ", member: " + roleMember.Name);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

            File.WriteAllText(currentFileName, output.ToString());

        }
        public void RoleUsers(string DatabaseName, string RoleName)
        {
            StringBuilder output = new StringBuilder();
            string currentFileName = "";

            if (!OverwriteOutputFile)
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            }
            else
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + ".txt";
            }
            Server server;

            try
            {

                server = new Server();
                server.Connect(SSASConnectionString);

                Database database = server.Databases.GetByName(DatabaseName);
                Role role = database.Roles.GetByName(RoleName);

                foreach (RoleMember roleMember in role.Members)
                {
                    output.AppendLine("Discover server: " + SSASConnectionString + ", database: " + database.Name + ", role: " + role.Name + ", member: " + roleMember.Name);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

            File.WriteAllText(currentFileName, output.ToString());

        }

        public void RolePermissions()
        {
            StringBuilder output = new StringBuilder();
            string currentFileName = "";

            if (!OverwriteOutputFile)
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            }
            else
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + ".txt";
            }
            Server server;

            try
            {

                server = new Server();
                server.Connect(SSASConnectionString);

                foreach (Database database in server.Databases)
                {
                    foreach (Dimension dimension in database.Dimensions)
                    {
                        foreach (DimensionPermission dimensionPermission in dimension.DimensionPermissions)
                        {
                            foreach (AttributePermission atributePermission in dimensionPermission.AttributePermissions)
                            {
                                foreach (string allowedItem in HelperMethods.ParseMemberSetToList(atributePermission.AllowedSet))
                                {
                                    output.AppendLine("Discover server: " + SSASConnectionString + ", database: " + database.Name + ", dimension: " + dimension.Name + ", role: " + dimensionPermission.Role.Name + ", attribute: " + atributePermission.Attribute + ", allowed member set: " + allowedItem);
                                }
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

            File.WriteAllText(currentFileName, output.ToString());

        }

        public void RolePermissions(string DatabaseName, string RoleName)
        {
            StringBuilder output = new StringBuilder();
            string currentFileName = "";

            if (!OverwriteOutputFile)
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            }
            else
            {
                currentFileName = OutputFolderPath + "ssas_toolset_" + System.Reflection.MethodBase.GetCurrentMethod().Name + ".txt";
            }
            Server server;

            try
            {

                server = new Server();
                server.Connect(SSASConnectionString);

                Database database = server.Databases.GetByName(DatabaseName);

                foreach (Dimension dimension in database.Dimensions)
                {
                    foreach (DimensionPermission dimensionPermission in dimension.DimensionPermissions)
                    {
                        foreach (AttributePermission atributePermission in dimensionPermission.AttributePermissions)
                        {
                            foreach (string allowedItem in HelperMethods.ParseMemberSetToList(atributePermission.AllowedSet))
                            {
                                if (dimensionPermission.Role.Name.ToUpper() == RoleName.ToUpper())
                                {
                                    output.AppendLine("Discover server: " + SSASConnectionString + ", database: " + database.Name + ", dimension: " + dimension.Name + ", role: " + dimensionPermission.Role.Name + ", attribute: " + atributePermission.Attribute + ", allowed member set: " + allowedItem);
                                }
                            }
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

            File.WriteAllText(currentFileName, output.ToString());

        }
    }
}

