Remove-Item *.nupkg
nuget pack YNAB.Rest.nuspec
nuget push *.nupkg -Source https://api.nuget.org/v3/index.json