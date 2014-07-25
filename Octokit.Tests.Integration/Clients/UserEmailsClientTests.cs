﻿using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Octokit.Tests.Integration.Clients
{
    public class UserEmailsClientTests
    {
        [IntegrationTest]
        public async Task CanGetEmail()
        {
            var github = new GitHubClient(new ProductHeaderValue("OctokitTests"))
            {
                Credentials = Helper.Credentials
            };

            var emails = await github.User.Email.GetAll();
            Assert.NotEmpty(emails);
        }

        const string testEmailAddress = "hahaha-not-a-real-email@foo.com";

        [IntegrationTest]
        public async Task CanAddAndDeleteEmail()
        {
            var github = new GitHubClient(new ProductHeaderValue("OctokitTests"))
            {
                Credentials = Helper.Credentials
            };

            await github.User.Email.Add(testEmailAddress);

            var emails = await github.User.Email.GetAll();
            Assert.Contains(testEmailAddress, emails.Select(x => x.Email));

            await github.User.Email.Delete(testEmailAddress);

            emails = await github.User.Email.GetAll();
            Assert.DoesNotContain(testEmailAddress, emails.Select(x => x.Email));
        }
    }
}
