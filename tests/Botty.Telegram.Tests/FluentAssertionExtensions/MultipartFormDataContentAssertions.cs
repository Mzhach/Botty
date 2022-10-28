using Botty.Telegram.Serialization;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Botty.Telegram.Tests.FluentAssertionExtensions
{
    public class MultipartFormDataContentAssertions
        : ReferenceTypeAssertions<MultipartFormDataContent, MultipartFormDataContentAssertions>
    {
        protected override string Identifier => "multipartFormDataContent";

        public MultipartFormDataContentAssertions(MultipartFormDataContent subject) : base(subject)
        {
        }

        public async Task<AndConstraint<MultipartFormDataContentAssertions>> ContainAsync(string name, string expected)
        {
            NotBeNull();

            Execute.Assertion
                .ForCondition(!string.IsNullOrEmpty(name))
                .FailWith("You should specify form data name")
                .Then
                .ForCondition(expected != null)
                .FailWith("You should specify expected value");

            var httpContent = GetHttpContent(name);

            Execute.Assertion
                .ForCondition(httpContent != null)
                .FailWith("Expected to contain {0} content but it wasn't found", name);

            var contentAsString = await httpContent!.ReadAsStringAsync();

            Execute.Assertion
                .ForCondition(contentAsString == expected)
                .FailWith("Expected {0}, but found {1}", expected, contentAsString);

            return new(this);
        }

        public AndConstraint<MultipartFormDataContentAssertions> NotContain(string name)
        {
            NotBeNull();

            Execute.Assertion
                .ForCondition(!string.IsNullOrEmpty(name))
                .FailWith("You should specify form data name");

            var httpContent = GetHttpContent(name);

            Execute.Assertion
                .ForCondition(httpContent is null)
                .FailWith("Expected to not contain {0} content but it was found", name);

            return new(this);
        }

        public async Task<AndConstraint<MultipartFormDataContentAssertions>> ContainAsync<T>(string name, T expected)
        {
            NotBeNull();

            Execute.Assertion
                .ForCondition(!string.IsNullOrEmpty(name))
                .FailWith("You should specify form data name")
                .Then
                .ForCondition(expected != null)
                .FailWith("You should specify expected value");

            var httpContent = GetHttpContent(name);

            Execute.Assertion
                .ForCondition(httpContent != null)
                .FailWith("Expected to contain {0} content but it wasn't found", name);

            var contentAsString = await httpContent!.ReadAsStringAsync();
            var expectedContent = TelegramBotClientSerializer.Serialize(expected);

            Execute.Assertion
                .ForCondition(contentAsString == expectedContent)
                .FailWith("Expected {0}, but found {1}", expected, contentAsString);

            return new(this);
        }

        public async Task<AndConstraint<MultipartFormDataContentAssertions>> ContainFileAsync(string name, string filename, Stream expected)
        {
            NotBeNull();

            Execute.Assertion
                .ForCondition(!string.IsNullOrEmpty(name))
                .FailWith("You should specify form data name")
                .Then
                .ForCondition(!string.IsNullOrEmpty(filename))
                .FailWith("You should specify file name")
                .Then
                .ForCondition(expected != null)
                .FailWith("You should specify expected stream");

            var httpContent = GetHttpContent(name);

            Execute.Assertion
                .ForCondition(httpContent != null)
                .FailWith("Expected to contain {0} content but it wasn't found", name)
                .Then
                .ForCondition(httpContent!.Headers?.ContentDisposition != null)
                .FailWith("Expected to contain content with ContentDisposition header")
                .Then
                .Given(() => httpContent!.Headers!.ContentDisposition!)
                .ForCondition(x => x.FileName == filename)
                .FailWith("Expected to contain {0} content with {1} file name", name, filename);

            var contentAsString = await httpContent!.ReadAsStringAsync();

            expected!.Position = 0;
            using var exptectedStreamReader = new StreamReader(expected, Encoding.UTF8);
            var exptectedAsString = exptectedStreamReader.ReadToEnd();

            Execute.Assertion
                .ForCondition(contentAsString == exptectedAsString)
                .FailWith("Expected {0}, but found {1}", exptectedAsString, contentAsString);

            return new(this);
        }

        private HttpContent? GetHttpContent(string name)
            => Subject
                .SingleOrDefault(
                    x => x.Headers?.ContentDisposition != null
                        && x.Headers.ContentDisposition.Name == name);
    }
}
