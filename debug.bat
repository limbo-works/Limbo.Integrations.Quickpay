@echo off
dotnet build src/Limbo.Integrations.Quickpay --configuration Debug /t:rebuild /t:pack -p:BuildTools=1 -p:PackageOutputPath=c:/nuget