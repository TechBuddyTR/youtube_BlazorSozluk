using Blazored.LocalStorage;
using System.Security.Claims;

namespace BlazorSozluk.WebApp.Infrastructure.Extensions;

public static class LocalStorageExtension
{
    public const string TokenName = "token";
    public const string UserName = "username";
    public const string UserId = "userid";



    public static bool IsUserLoggedIn(this ISyncLocalStorageService localStorageService)
    {
        return !string.IsNullOrEmpty(GetToken(localStorageService));
    }

    public static string GetUserName(this ISyncLocalStorageService localStorageService)
    {
        return localStorageService.GetItem<string>(UserName);
    }

    public static async Task<string> GetUserName(this ILocalStorageService localStorageService)
    {
        return await localStorageService.GetItemAsync<string>(UserName);
    }

    public static void SetUsername(this ISyncLocalStorageService localStorageService, string value)
    {
        localStorageService.SetItem(UserName, value);
    }

    public static async Task SetUsername(this ILocalStorageService localStorageService, string value)
    {
        await localStorageService.SetItemAsync(UserName, value);
    }


    public static Guid GetUserId(this ISyncLocalStorageService localStorageService)
    {
        return localStorageService.GetItem<Guid>(UserId);
    }

    public static void SetUserId(this ISyncLocalStorageService localStorageService, Guid id)
    {
        localStorageService.SetItem(UserId, id);
    }

    public static async Task SetUserId(this ILocalStorageService localStorageService, Guid id)
    {
        await localStorageService.SetItemAsync(UserId, id);
    }

    public static async Task<Guid> GetUserId(this ILocalStorageService localStorageService)
    {
        return await localStorageService.GetItemAsync<Guid>(UserId);
    }


    public static string GetToken(this ISyncLocalStorageService localStorageService)
    {
        var token = localStorageService.GetItem<string>(TokenName);

        //// TODO
        //if (string.IsNullOrEmpty(token))
        //    token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImI1OGRhN2U2LTdjOWItNDU2NS1iZDRhLTAyZTkzZWIzMmE4OCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6IkFibHVjODVAeWFob28uY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkV2aW4uQ2FwYW5vZ2x1IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZ2l2ZW5uYW1lIjoiRGlsYXJhIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3VybmFtZSI6IsOWemvDtmsgIiwibmJmIjoxNjQ4OTA2NTM3LCJleHAiOjE2NDk3NzA1Mzd9.5ofws5_TiKeeEXG4zTZK0BNAJvwYui4vQmF1WCVRQXs";

        return token;
    }

    public static async Task<string> GetToken(this ILocalStorageService localStorageService)
    {
        var token = await localStorageService.GetItemAsync<string>(TokenName);

        // TODO
        //if (string.IsNullOrEmpty(token))
        //    token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImI1OGRhN2U2LTdjOWItNDU2NS1iZDRhLTAyZTkzZWIzMmE4OCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6IkFibHVjODVAeWFob28uY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkV2aW4uQ2FwYW5vZ2x1IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZ2l2ZW5uYW1lIjoiRGlsYXJhIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3VybmFtZSI6IsOWemvDtmsgIiwibmJmIjoxNjQ4OTA2NTM3LCJleHAiOjE2NDk3NzA1Mzd9.5ofws5_TiKeeEXG4zTZK0BNAJvwYui4vQmF1WCVRQXs";

        return token;
    }

    public static void SetToken(this ISyncLocalStorageService localStorageService, string value)
    {
        localStorageService.SetItem(TokenName, value);
    }

    public static async Task SetToken(this ILocalStorageService localStorageService, string value)
    {
        await localStorageService.SetItemAsync(TokenName, value);
    }

}
