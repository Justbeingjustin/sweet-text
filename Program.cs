using SweetTextV2.Services;
using Topshelf;
using Topshelf.Unity;
using Unity;

namespace SweetTextV2
{
    public class Program
    {/// <summary>
     /// The application will read a collection of strings from a .json file and periodically send a text messages. It uses Topshelf.Unity to construct a windows service that uses a Unity IoC container.
     /// </summary>
     /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<ILogsRepository, LogsRepository>();
            container.RegisterType<ISweetMessageService, SweetMessageService>();
            container.RegisterType<ITextMessageService, TextMessageService>();

            HostFactory.Run(c =>
            {
                c.UseUnityContainer(container);

                c.Service<TextMessageCoordinator>(s =>
                {
                    s.ConstructUsingUnityContainer();
                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });
            });
        }
    }
}
