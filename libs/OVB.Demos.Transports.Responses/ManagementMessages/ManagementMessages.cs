using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OVB.Demos.Transports.Responses.ManagementMessages;

public sealed class ManagementMessages<TEntity>
{
    private string EntityIdentifier { get; init; }
    private IDictionary<string, IDictionary<string, ErrorMessage>> Messages { get; init; }

    public ManagementMessages()
    {
        EntityIdentifier = nameof(TEntity);
        Messages = new Dictionary<string, IDictionary<string, ErrorMessage>>();    
    }

    public void AddMessage(string code, string language, TypeMessage typeMessage, string message)
    {
        const string Exists = "This message for this code and language exists.";

        var errorCodeMessageExists = Messages.ContainsKey(code);
        if (errorCodeMessageExists == true)
            if (Messages[code].ContainsKey(language))
                throw new Exception(Exists);
       
        if(errorCodeMessageExists == false)
            Messages.Add(code, new Dictionary<string, ErrorMessage>());

        Messages[code].Add(language, new ErrorMessage(typeMessage, message, code));
    }

    public ErrorMessage GetErrorMessageByLanguage(string code, string language)
    {
        const string Error = "This message for this code and language not exists.";

        var errorCodeMessageExists = Messages.ContainsKey(code);
        if (errorCodeMessageExists == false)
            throw new Exception(Error);

        var languageMessageExists = Messages[code].ContainsKey(language);
        if (languageMessageExists == false)
            throw new Exception(Error);

        return Messages[code][language];
    }
}
