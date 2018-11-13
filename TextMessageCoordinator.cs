using SweetTextV2.Services;
using System;
using System.Configuration;
using System.Timers;

namespace SweetTextV2
{
    public class TextMessageCoordinator
    {
        private Timer _timer;
        private readonly ILogsRepository _logsRepository;
        private readonly ITextMessageService _textMessageService;
        private readonly ISweetMessageService _sweetMessageService;

        public TextMessageCoordinator(ILogsRepository logsRepostiory, ISweetMessageService sweetMessageService,
            ITextMessageService textMessageService)
        {
            _logsRepository = logsRepostiory;
            _sweetMessageService = sweetMessageService;
            _textMessageService = textMessageService;
        }

        public bool Start()
        {
            _timer = new Timer();
            _timer.Elapsed += new ElapsedEventHandler(SendSweetTextMessage);
            _timer.Interval = Convert.ToDouble(ConfigurationManager.AppSettings["TimeUntilNextSentMessageInMS"]);
            _timer.Enabled = true;
            return true;
        }

        public bool Stop()
        {
            _timer.Enabled = false;
            return true;
        }

        private void SendSweetTextMessage(object sender, ElapsedEventArgs e)
        {
            try
            {
                _timer.Enabled = false;
                _textMessageService.SendTextMessage(_sweetMessageService.GetNextMessage());
            }
            catch (Exception ex)
            {
                _logsRepository.LogMessage("Failed to send message: " + ex.ToString());
            }
            finally
            {
                _timer.Enabled = true;
            }
        }
    }
}