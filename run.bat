@echo off
echo Running Hospital Management System...
echo ====================================

REM Check if dotnet is installed
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo Error: .NET SDK is not installed or not in PATH
    echo Please install .NET 6.0 SDK or later
    exit /b 1
)

REM Run the application
dotnet run

REM Check if program ran successfully
if %errorlevel% equ 0 (
    echo.
    echo Program executed successfully!
) else (
    echo.
    echo Program execution failed with error code: %errorlevel%
    exit /b %errorlevel%
)
