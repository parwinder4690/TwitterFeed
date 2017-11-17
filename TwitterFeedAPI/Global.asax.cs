using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Reflection;
using System.Web.Http;
using Tweetinvi;


namespace TwitterFeedAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            

            RegisterBuilder();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            //start feed server that will get twitter time line and store in cache
            startFeedServer();
        }

        public void RegisterBuilder()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

         
            builder.RegisterType<FeedCacheManager>().As<IFeedCacheManager>();
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

           
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        public void startFeedServer()
        {
            String consumerKey = "PNLbcUJAeNC1p4VnW76lyziwA";
            String consumerSecret = "gb0FHgfj7z0RvJONX55eDZ4eS3LLu2o9kq6HvOEFrfI3OmBI4h";
            String accessToken = "3230857845-3I5wrs35aGRkfaHQaD0L1PFeADVmISjaSFqoPwS";
            String accessTokenSecret = "TS3hBN5brz3piHfczCRy9UWwIE5UvEabVdl3DDRLgQSOQ";

            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);

            IFeedCacheManager feedCacheManager = new FeedCacheManager();
            ITwitterFeedProxy feedProxy = new TwitterFeedProxy();
            FeederServer feederServer = new FeederServer(feedCacheManager, feedProxy);
            feederServer.feedStart();
        }
    }
}
