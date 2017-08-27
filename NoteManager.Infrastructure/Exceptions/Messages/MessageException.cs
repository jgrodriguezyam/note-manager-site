using NoteManager.Infrastructure.Resources;
namespace NoteManager.Infrastructure.Exceptions.Messages
{
    public static class MessageException
    {
        public static string NotFound = HomeText.RecordNotFound;
        public static string InvalidCredential = HomeText.InvalidCredentials;
        public static string UnauthorizedChangePassword = HomeText.YouDoNotHavePermissionsToChangeThePassword;
        public static string Conflict = HomeText.AConflictOccurred;
        public static string InvalidKey = HomeText.InvalidKey;
        public static string InvalidTimespan = HomeText.InvalidLapseOfTime;
        public static string InvalidSerial = HomeText.InvalidSerial;
        public static string InvalidDate = HomeText.InvalidDate;
        public static string AlreadyHasAddress = HomeText.AlreadyAssignedAddress;
        public static string IsZero = HomeText.ValueCanNotBeZero;
        public static string IsNotZero = HomeText.TheValueIsNotZero;
        public static string InvalidIdentifier = HomeText.ReferenceDoesNotExist;
        public static string AlreadyHasAccountStatementFile = HomeText.BankVouchersAlreadyExist;
        public static string AlreadyHasProofFile = HomeText.AReceiptAlreadyExists;
        public static string MailAlreadyExists = HomeText.RegisteredMailAlreadyExists;
        public static string SurveyIsAlreadyAssigned = HomeText.TheSurveyIsAlreadyAssigned;
        public static string UserNameAlreadyExists = HomeText.UserNameAlreadyExists;
        public static string InvalidFile = HomeText.NotAValidFile;
        public static string FileTooLarge = HomeText.TheFileIsTooLarge;
        public static string InvalidStatusChange = HomeText.CanNotChangeStatus;
        public static string AlreadyReferenced = "";
        public static string HaveUnpaidsCredits = HomeText.HaveUnpaidsCredits;
        public static string HavePendingSolicitudes = HomeText.HavePendingSolicitudes;
    }
}