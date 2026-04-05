namespace SurveyBasket.Api.Helpers;

public static class EmailBodyBuilder
{
    public static async Task<string> GenerateEmailBody(string template, Dictionary<string, string> parameters)
    {
        var templatePash = $"{Directory.GetCurrentDirectory()}/Templates/{template}.html";
        var streamReader = new StreamReader(templatePash);
        var body = streamReader.ReadToEnd();
        streamReader.Close();

        foreach (var item in parameters)
            body = body.Replace(item.Key, item.Value);

        return body;
    }
}
