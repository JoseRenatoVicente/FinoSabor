@echo off

echo Remove database
dotnet ef database -s ../FinoSabor.Services.Api drop -f -c FinoSaborContext

echo remove Migrations folder
cd Migrations
del *.cs
cd ..

echo Create database
dotnet ef migrations add Init -c FinoSaborContext -s ../FinoSabor.Services.Api
dotnet ef database update -c FinoSaborContext -s ../FinoSabor.Services.Api

pause