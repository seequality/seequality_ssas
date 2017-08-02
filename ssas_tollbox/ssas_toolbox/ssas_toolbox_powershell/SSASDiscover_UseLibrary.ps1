#
# SSASDiscover_UseLibrary.ps1
#
[Reflection.Assembly]::LoadFile("C:\Users\sldr01\Documents\Visual Studio 2015\Projects\ssas_toolbox\ssas_toolbox_library\bin\Debug\ssas_toolbox_library.dll")

$OutputFolderPath = "C:\test\"
$SSASConnectionString = "Data source=localhost\sql2016;Database=AdventureWorksDW2014Multidimensional-EE"
$OverwriteOutputFile = "true"

$ssasDiscover = new-object ssas_toolbox_library.SSASDiscover
$ssasDiscover.OutputFolderPath = $OutputFolderPath
$ssasDiscover.SSASConnectionString = $SSASConnectionString
$ssasDiscover.OverwriteOutputFile = $OverwriteOutputFile


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
          '1' {$ssasDiscover.DatabaseState()} 
		  '2' {$ssasDiscover.DatabaseDimensionState()} 
		  '3' {$ssasDiscover.CubeState()} 
		  '4' {$ssasDiscover.MeasureGroupState()} 
		  '5a' {$ssasDiscover.PartitionState()} 
		  '5b' {$ssasDiscover.PartitionState("true")} 
		  '5c' {
					$databaseName = Read-Host "Type the database name: "
					$cubeName = Read-Host "Type the cube name: "
					$measureGroupName = Read-Host "Type the measure group name: "
					$ssasDiscover.PartitionState($databaseName, $cubeName, $measureGroupName)
			   } 
		  '6a' {RoleUsers} 
		  '6b' {
			  		$databaseName = Read-Host "Type the database name: "
					$roleName = Read-Host "Type the role name: "
					$ssasDiscover.RoleUsers($databaseName, $roleName)
			   } 
		  '7a' {RolePermissions} 
		  '7b' {
                    $databaseName = Read-Host "Type the database name: "
					$roleName = Read-Host "Type the role name: "
                    $ssasDiscover.RolePermissions($databaseName, $roleName)
               } 
		  '0' { return }
      }
      pause
 }
 until ($input -eq '0')
