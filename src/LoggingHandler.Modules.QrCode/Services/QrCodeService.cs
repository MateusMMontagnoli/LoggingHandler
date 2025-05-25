using LoggingHandler.Modules.QrCode.Contracts;
using QRCoder;


namespace LoggingHandler.Modules.QrCode.Services;

class QrCodeService : IQrCodeService
{
    public QrCodeService()
    {
    }

    public string GenerateQrCode(string uri)
    {
        return Generate(uri);
    }

    public string GenerateQrCode(Uri uri)
    {
        return Generate(uri.ToString());
    }

    private string Generate(
        string link,
        int scale = 20)
    {
        using var generator = new QRCodeGenerator();
        var data = generator.CreateQrCode(link, QRCodeGenerator.ECCLevel.M);

        var qrCode = new PngByteQRCode(data);

        return Convert.ToBase64String(qrCode.GetGraphic(scale));
    }
}
