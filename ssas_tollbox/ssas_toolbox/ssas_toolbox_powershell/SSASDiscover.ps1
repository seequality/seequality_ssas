#
# SSASDiscover.ps1
#
[System.reflection.Assembly]::LoadWithPartialName("Microsoft.AnalysisServices")  

$OutputFolderPath = "C:\test\"
$SSASConnectionString = "Data source=localhost\sql2016;Database=AdventureWorksDW2014Multidimensional-EE"
$OverwriteOutputFile = "true"

function DatabaseState()
{
	$server = new-Object Microsoft.AnalysisServices.Server
	$currentFileName = ""

	if (!$OverwriteOutputFile -ieq "true")
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0] + ((Get-Date -format s) -replace "-", "" -replace "T", "" -replace ":","") + ".txt";
	}
	else
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0]  + ".txt";
	}

	$server.Connect($SSASConnectionString) 

	$output = New-Object -TypeName "System.Text.StringBuilder";

	Foreach ($database in $server.Databases)
	{
		  $output.AppendLine("Discover server: " + $SSASConnectionString + ", database: " + $database.Name + ", state: " + $database.State + ", last processed: " + $database.LastProcessed);
	}

	$output.ToString() | Out-File -filepath $currentFileName
}

function DatabaseDimensionState()
{
	$server = new-Object Microsoft.AnalysisServices.Server
	$currentFileName = ""

	if (!$OverwriteOutputFile -ieq "true")
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0] + ((Get-Date -format s) -replace "-", "" -replace "T", "" -replace ":","") + ".txt";
	}
	else
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0]  + ".txt";
	}

	$server.Connect($SSASConnectionString) 

	$output = New-Object -TypeName "System.Text.StringBuilder";

    foreach ($database in $server.Databases)
    {
        foreach ($dimension in $database.Dimensions)
        {
            $output.AppendLine("Discover server: " + $SSASConnectionString + ", database: " + $database.Name + ", dimension: " + $dimension.Name + ", state: " + $dimension.State + ", last processed: " + $dimension.LastProcessed);
        }
    }

	$output.ToString() | Out-File -filepath $currentFileName
}

function CubeState()
{
	$server = new-Object Microsoft.AnalysisServices.Server
	$currentFileName = ""

	if (!$OverwriteOutputFile -ieq "true")
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0] + ((Get-Date -format s) -replace "-", "" -replace "T", "" -replace ":","") + ".txt";
	}
	else
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0]  + ".txt";
	}

	$server.Connect($SSASConnectionString) 

	$output = New-Object -TypeName "System.Text.StringBuilder";

    foreach ($database in $server.Databases)
    {
        foreach ($cube in $database.Cubes)
        {
            $output.AppendLine("Discover server: " + $SSASConnectionString + ", database: " + $database.Name + ", cube: " + $cube.Name + ", state: " + $cube.State + ", last processed: " + $cube.LastProcessed);
        }
    }

	$output.ToString() | Out-File -filepath $currentFileName
}

function MeasureGroupState()
{
	$server = new-Object Microsoft.AnalysisServices.Server
	$currentFileName = ""

	if (!$OverwriteOutputFile -ieq "true")
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0] + ((Get-Date -format s) -replace "-", "" -replace "T", "" -replace ":","") + ".txt";
	}
	else
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0]  + ".txt";
	}

	$server.Connect($SSASConnectionString) 

	$output = New-Object -TypeName "System.Text.StringBuilder";

    foreach ($database in $server.Databases)
    {
        foreach ($cube in $database.Cubes)
        {
            foreach ($measureGroup in $cube.MeasureGroups)
            {
                $output.AppendLine("Discover server: " + $SSASConnectionString + ", database: " + $database.Name + ", cube: " + $cube.Name + ", measure group: " + $measureGroup.Name + ", state: " + $measureGroup.State + ", last processed: " + $measureGroup.LastProcessed);
            }
        }
    }

	$output.ToString() | Out-File -filepath $currentFileName
}

function PartitionState()
{
	$server = new-Object Microsoft.AnalysisServices.Server
	$currentFileName = ""

	if (!$OverwriteOutputFile -ieq "true")
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0] + ((Get-Date -format s) -replace "-", "" -replace "T", "" -replace ":","") + ".txt";
	}
	else
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0]  + ".txt";
	}

	$server.Connect($SSASConnectionString) 

	$output = New-Object -TypeName "System.Text.StringBuilder";

    foreach ($database in $server.Databases)
    {
        foreach ($cube in $database.Cubes)
        {
            foreach ($measureGroup in $cube.MeasureGroups)
            {
                foreach ($partition in $measureGroup.Partitions)
                {
                    $output.AppendLine("Discover server: " + $SSASConnectionString + ", database: " + $database.Name + ", cube: " + $cube.Name + ", measure group: " + $measureGroup.Name + ", partition: " + $partition.Name + ", state: " + $partition.State + ", last processed: " + $partition.LastProcessed);
                }
            }
        }
    }

	$output.ToString() | Out-File -filepath $currentFileName
}


function PartitionState_UnprocessedOnly($UnprocessedOnly)
{
	$server = new-Object Microsoft.AnalysisServices.Server
	$currentFileName = ""

	if (!$OverwriteOutputFile -ieq "true")
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0] + ((Get-Date -format s) -replace "-", "" -replace "T", "" -replace ":","") + ".txt";
	}
	else
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0]  + ".txt";
	}

	$server.Connect($SSASConnectionString) 

	$output = New-Object -TypeName "System.Text.StringBuilder";


    foreach ($database in $server.Databases)
    {
        foreach ($cube in $database.Cubes)
        {
            foreach ($measureGroup in $cube.MeasureGroups)
            {
                foreach ($partition in $measureGroup.Partitions)
                {
                    if (!($partition.State -ieq "Processed"))
                    {
						$partition.State
                        $output.AppendLine("Discover server: " + $SSASConnectionString + ", database: " + $database.Name + ", cube: " + $cube.Name + ", measure group: " + $measureGroup.Name + ", partition: " + $partition.Name + ", state: " + $partition.State + ", last processed: " + $partition.LastProcessed);
                    }
                }
            }
        }
    }

	$output.ToString() | Out-File -filepath $currentFileName
}


function PartitionState_Specify($DatabaseName, $CubeName, $MeasureGroupName)
{
	$server = new-Object Microsoft.AnalysisServices.Server
	$currentFileName = ""

	if (!$OverwriteOutputFile -ieq "true")
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0] + ((Get-Date -format s) -replace "-", "" -replace "T", "" -replace ":","") + ".txt";
	}
	else
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0]  + ".txt";
	}

	$server.Connect($SSASConnectionString) 

	$output = New-Object -TypeName "System.Text.StringBuilder";

    $database = $server.Databases.GetByName($DatabaseName);
    $cube = $database.Cubes.GetByName($CubeName);
    $measureGroup = $cube.MeasureGroups.GetByName($MeasureGroupName);

    foreach ($partition in $measureGroup.Partitions)
    {
        $output.AppendLine("Discover server: " + $SSASConnectionString + ", database: " + $database.Name + ", cube: " + $cube.Name + ", measure group: " + $measureGroup.Name + ", partition: " + $partition.Name + ", state: " + $partition.State + ", last processed: " + $partition.LastProcessed);
    }

	$output.ToString() | Out-File -filepath $currentFileName
}



function RoleUsers()
{
	$server = new-Object Microsoft.AnalysisServices.Server
	$currentFileName = ""

	if (!$OverwriteOutputFile -ieq "true")
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0] + ((Get-Date -format s) -replace "-", "" -replace "T", "" -replace ":","") + ".txt";
	}
	else
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0]  + ".txt";
	}

	$server.Connect($SSASConnectionString) 

	$output = New-Object -TypeName "System.Text.StringBuilder";

    foreach ($database in $server.Databases)
    {
        foreach ($role in $database.Roles)
        {
            foreach ($roleMember in $role.Members)
            {
                $output.AppendLine("Discover server: " + $SSASConnectionString + ", database: " + $database.Name + ", role: " + $role.Name + ", member: " + $roleMember.Name);
            }
        }
    }

	$output.ToString() | Out-File -filepath $currentFileName
}



function RoleUsers_Specify($DatabaseName, $RoleName)
{
	$server = new-Object Microsoft.AnalysisServices.Server
	$currentFileName = ""

	if (!$OverwriteOutputFile -ieq "true")
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0] + ((Get-Date -format s) -replace "-", "" -replace "T", "" -replace ":","") + ".txt";
	}
	else
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0]  + ".txt";
	}

	$server.Connect($SSASConnectionString) 

	$output = New-Object -TypeName "System.Text.StringBuilder";

    $database = $server.Databases.GetByName($DatabaseName);
    $role = $database.Roles.GetByName($RoleName);

    foreach ($roleMember in $role.Members)
    {
        $output.AppendLine("Discover server: " + $SSASConnectionString + ", database: " + $database.Name + ", role: " + $role.Name + ", member: " + $roleMember.Name);
    }

	$output.ToString() | Out-File -filepath $currentFileName
}


function RolePermissions()
{
	$server = new-Object Microsoft.AnalysisServices.Server
	$currentFileName = ""

	if (!$OverwriteOutputFile -ieq "true")
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0] + ((Get-Date -format s) -replace "-", "" -replace "T", "" -replace ":","") + ".txt";
	}
	else
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0]  + ".txt";
	}

	$server.Connect($SSASConnectionString) 

	$output = New-Object -TypeName "System.Text.StringBuilder";

    foreach ($database in $server.Databases)
    {
        foreach ($dimension in $database.Dimensions)
        {
            foreach ($dimensionPermission in $dimension.DimensionPermissions)
            {
                foreach ($atributePermission in $dimensionPermission.AttributePermissions)
                {
                    foreach ($allowedItem in $atributePermission.AllowedSet.TrimStart("{").TrimEnd("}").Split(','))
                    {
                        $output.AppendLine("Discover server: " + $SSASConnectionString + ", database: " + $database.Name + ", dimension: " + $dimension.Name + ", role: " + $dimensionPermission.Role.Name + ", attribute: " + $atributePermission.Attribute + ", allowed member set: " + $allowedItem.Trim());
                    }
                }
            }
        }
    }

	$output.ToString() | Out-File -filepath $currentFileName
}


function RolePermissions_Specify($DatabaseName, $RoleName)
{
	$server = new-Object Microsoft.AnalysisServices.Server
	$currentFileName = ""

	if (!$OverwriteOutputFile -ieq "true")
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0] + ((Get-Date -format s) -replace "-", "" -replace "T", "" -replace ":","") + ".txt";
	}
	else
	{
		$currentFileName = $OutputFolderPath + "ssas_toolset_" + $MyInvocation.MyCommand.Name.Split('_')[0]  + ".txt";
	}

	$server.Connect($SSASConnectionString) 

	$output = New-Object -TypeName "System.Text.StringBuilder";

    $database = $server.Databases.GetByName($DatabaseName);

    foreach ($dimension in $database.Dimensions)
    {
        foreach ($dimensionPermission in $dimension.DimensionPermissions)
        {
            foreach ($atributePermission in $dimensionPermission.AttributePermissions)
            {
                foreach ($allowedItem in $atributePermission.AllowedSet.TrimStart("{").TrimEnd("}").Split(','))
                {
					   if ($dimensionPermission.Role.Name.ToUpper() -ieq $RoleName.ToUpper())
                       {
							$output.AppendLine("Discover server: " + $SSASConnectionString + ", database: " + $database.Name + ", dimension: " + $dimension.Name + ", role: " + $dimensionPermission.Role.Name + ", attribute: " + $atributePermission.Attribute + ", allowed member set: " + $allowedItem.Trim());
					   }
				}
            }
        }
    }
    

	$output.ToString() | Out-File -filepath $currentFileName
}

Write-Host "0.  Exit"
Write-Host "1.  Discover databases processing states"
Write-Host "2.  Discover dimensions processing states"
Write-Host "3.  Discover cubes processing states"
Write-Host "4.  Discover measure groups processing states"
Write-Host "5a. Discover partitions processing states"
Write-Host "5b. Discover partitions processing states - unprocessed only"
Write-Host "5c. Discover partitions processing states - specify database, cube and measure group name"
Write-Host "6a. Discover users in roles"
Write-Host "6b. Discover users in roles - specify database and role name"
Write-Host "7a. Discover roles permissions"
Write-Host "7b. Discover roles permissions - specify database and role name"

$databaseName = ""
$cubeName = ""
$measureGroupName = ""
$roleName = ""

do
{
      $input = Read-Host "Type the option: "
      switch ($input)
      {
          '1' {DatabaseState} 
		  '2' {DatabaseDimensionState} 
		  '3' {CubeState} 
		  '4' {MeasureGroupState} 
		  '5a' {PartitionState} 
		  '5b' {PartitionState_UnprocessedOnly -UnprocessedOnly true} 
		  '5c' {
					$databaseName = Read-Host "Type the database name: "
					$cubeName = Read-Host "Type the cube name: "
					$measureGroupName = Read-Host "Type the measure group name: "
					PartitionState_Specify -DatabaseName $databaseName -CubeName $cubeName -MeasureGroupName $measureGroupName
			   } 
		  '6a' {RoleUsers} 
		  '6b' {
			  		$databaseName = Read-Host "Type the database name: "
					$roleName = Read-Host "Type the role name: "
					RoleUsers_Specify -DatabaseName $databaseName -RoleName $roleName
			   } 
		  '7a' {RolePermissions} 
		  '7b' {
                    $databaseName = Read-Host "Type the database name: "
					$roleName = Read-Host "Type the role name: "
                    RolePermissions_Specify -DatabaseName $databaseName -RoleName $roleName
               } 
		  '0' { return }
      }
      pause
 }
 until ($input -eq '0')
