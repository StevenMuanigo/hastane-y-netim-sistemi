@echo off
echo Building Hospital Management System...
echo ======================================

REM Check if dotnet is installed
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo Error: .NET SDK is not installed or not in PATH
    echo Please install .NET 6.0 SDK or later
    exit /b 1
)

REM Restore dependencies
echo Restoring dependencies...
dotnet restore
if %errorlevel% neq 0 (
    echo Error restoring dependencies
    exit /b %errorlevel%
)

REM Build the project
echo Building project...
dotnet build --no-restore
if %errorlevel% neq 0 (
    echo Error building project
    exit /b %errorlevel%
)

echo.
echo Build successful!
echo.
echo To run the application, execute: dotnet run
echo Or use the run.bat script
