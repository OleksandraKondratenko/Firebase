using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;

namespace TestFirebase
{
    internal class FirebaseAppSnippets
    {
        internal static void InitSdkWithServiceAccount()
        {
            // [START initialize_sdk_with_service_account]
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("private_key.json"),
            });
            // [END initialize_sdk_with_service_account]
        }

        internal static void InitSdkWithApplicationDefault()
        {
            // [START initialize_sdk_with_application_default]
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
            });
            // [END initialize_sdk_with_application_default]
        }

        internal static void InitSdkWithRefreshToken()
        {
            // [START initialize_sdk_with_refresh_token]
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("private_key.json"),
            });
            // [END initialize_sdk_with_refresh_token]
        }

        internal static void InitSdkWithDefaultConfig()
        {
            // [START initialize_sdk_with_default_config]
            FirebaseApp.Create();
            // [END initialize_sdk_with_default_config]
        }

        internal static void InitDefaultApp()
        {
            // [START access_services_default]
            // Initialize the default app
            var defaultApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
            });
            Console.WriteLine(defaultApp.Name); // "[DEFAULT]"

            // Retrieve services by passing the defaultApp variable...
            var defaultAuth = FirebaseAuth.GetAuth(defaultApp);

            // ... or use the equivalent shorthand notation
            defaultAuth = FirebaseAuth.DefaultInstance;
            // [END access_services_default]
        }

        internal static void InitCustomApp()
        {
            var defaultOptions = new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
            };
            var otherAppConfig = new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
            };

            // [START access_services_nondefault]
            // Initialize the default app
            var defaultApp = FirebaseApp.Create(defaultOptions);

            // Initialize another app with a different config
            var otherApp = FirebaseApp.Create(otherAppConfig, "other");

            Console.WriteLine(defaultApp.Name); // "[DEFAULT]"
            Console.WriteLine(otherApp.Name); // "other"

            // Use the shorthand notation to retrieve the default app's services
            var defaultAuth = FirebaseAuth.DefaultInstance;

            // Use the otherApp variable to retrieve the other app's services
            var otherAuth = FirebaseAuth.GetAuth(otherApp);
            // [END access_services_nondefault]
        }

        internal static void InitWithServiceAccountId()
        {
            // [START initialize_sdk_with_service_account_id]
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
                ServiceAccountId = "my-client-id@my-project-id.iam.gserviceaccount.com",
            });
            // [END initialize_sdk_with_service_account_id]
        }
    }
}
