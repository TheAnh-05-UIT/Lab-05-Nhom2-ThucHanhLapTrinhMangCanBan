using System;
using System.Collections.Generic;
using System.Linq;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MailKit.Security;
using MimeKit;

public class EmailService : IDisposable
{
    private readonly ImapClient _imap = new ImapClient();
    private readonly SmtpClient _smtp = new SmtpClient();

    public string MyEmail { get; private set; }
    public void Login(string email, string appPass, string imapHost, int imapPort, string smtpHost, int smtpPort)
    {
        MyEmail = email;

        _imap.Connect(imapHost, imapPort, SecureSocketOptions.SslOnConnect);
        _imap.Authenticate(email, appPass);

        _smtp.Connect(smtpHost, smtpPort, SecureSocketOptions.SslOnConnect);
        _smtp.Authenticate(email, appPass);
    }
    public void Logout()
    {
        if (_imap.IsConnected) _imap.Disconnect(true);
        if (_smtp.IsConnected) _smtp.Disconnect(true);
    }

    public IList<IMessageSummary> LoadInbox(int takeLast = 30)
    {
        var inbox = _imap.Inbox;
        inbox.Open(FolderAccess.ReadOnly);
        var uids = inbox.Search(SearchQuery.All);
        int start = Math.Max(0, uids.Count - takeLast);
        var last = uids.Skip(start).ToList();
        var sums = inbox.Fetch(last,
            MessageSummaryItems.Envelope | MessageSummaryItems.InternalDate | MessageSummaryItems.UniqueId);

        return sums.Reverse().ToList();
    }
    public MimeMessage GetMessage(UniqueId uid)
    {
        if (!_imap.Inbox.IsOpen) _imap.Inbox.Open(FolderAccess.ReadOnly);
        return _imap.Inbox.GetMessage(uid);
    }
    public void Send(MimeMessage msg)
    {
        _smtp.Send(msg);
    }
    public void Dispose()
    {
        _imap.Dispose();
        _smtp.Dispose();
    }
}
