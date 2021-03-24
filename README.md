# Hangman.API

This is a simple hangman game project to complete an university school.

## How to run the api

 - First you gonna need the [SDK](https://dotnet.microsoft.com/download/dotnet/5.0) to run dotnet 5
   - If you want to just run the api, you can install the ASP.NET core runtime found in the same SDK's link
 - After the installation, you need to restore the nuget packages and build the solution executing the following commands
   - `dotnet restore`
   - `dotnet build`
- To run the API, just execute the following command
   - `dotnet run`

## Endpoints usage

This API have swagger for documentation and you can access it through here [Swagger UI](https://localhost:5001/swagger/index.html)
/start is to start the game, it will generate the word and return the class object as a JSON
/test is to test the letter of the word. Body example:

    {
    	"Word":  "_______",
    	"Letter":  "a",
    } 
