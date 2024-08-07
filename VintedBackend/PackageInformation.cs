using VintedBackend.Enums;

namespace VintedBackend
{
    public static class PackageInformation
    {
        public record PackageInfo(Provider Provider, Size Size, decimal Price);

        private static List<PackageInfo> _package =
        [
            new PackageInfo(Provider.LP, Size.S, 1.50m),
            new PackageInfo(Provider.LP, Size.M, 4.90m),
            new PackageInfo(Provider.LP, Size.L, 6.90m),
            new PackageInfo(Provider.MR, Size.S, 2),
            new PackageInfo(Provider.MR, Size.M, 3),
            new PackageInfo(Provider.MR, Size.L, 4),
        ];

        public static List<PackageInfo> Packages
        {
            get
            {
                return _package;
            }
        }
    }
}
