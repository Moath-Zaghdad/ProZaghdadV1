using ProZaghdadV1.Debugging;

namespace ProZaghdadV1
{
    public class ProZaghdadV1Consts
    {
        public const string LocalizationSourceName = "ProZaghdadV1";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "806cd099b82a40888fbfaecebfbd6535";
    }
}
