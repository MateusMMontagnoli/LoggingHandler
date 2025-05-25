namespace LoggingHandler.Modules.QrCode.Contracts;

public interface IQrCodeService
{
    public string GenerateQrCode(string uri);

    public string GenerateQrCode(Uri uri);
}
