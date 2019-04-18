using Limilabs.Client.IMAP;
using Limilabs.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLib.Modules
{
    public enum MailServerKind
    {
        IMAP,
        POP3
    }
    public class MailModule:IDisposable
    {
        public static string RecvMail(MailServerKind _MSK = MailServerKind.POP3)
        {
            using (Imap imap = new Imap())
            {
                imap.Connect("imap.server.com");
                imap.UseBestLogin("user", "password");
                imap.SelectInbox();
                List<long> uids = imap.Search(Flag.Unseen);
                foreach (long uid in uids)
                {
                    IMail email = new MailBuilder().CreateFromEml(imap.GetMessageByUID(uid));
                    Console.WriteLine(email.Subject);
                }
                imap.Close();
                return null;
            }
        }
        public static string SendMail()
        {
            return null;
        }
        public void Dispose()
        {
            GC.Collect();
        }
    }
}
