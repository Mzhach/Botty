using System.Net.Http;

namespace Botty.Telegram.Tests.FluentAssertionExtensions
{
    public static class MultipartFormDataContentExtensions
    {
        public static MultipartFormDataContentAssertions Should(this MultipartFormDataContent instance) => new(instance);
    }
}
