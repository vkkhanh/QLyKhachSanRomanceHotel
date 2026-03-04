using QRCoder;
using System;

namespace RomanceHotel.Utils
{
    public static class QrHelper
    {
        // QR payload: ROMANCEHD|HD0123
        public static byte[] GenerateInvoiceQrPngBytes(string maHD)
        {
            if (string.IsNullOrWhiteSpace(maHD))
                throw new ArgumentException("maHD is null/empty");

            string payload = $"ROMANCEHD|{maHD}";

            using (var qrGen = new QRCodeGenerator())
            using (var qrData = qrGen.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q))
            {
                var qrCode = new PngByteQRCode(qrData);
                return qrCode.GetGraphic(12); // độ nét
            }
        }
    }
}
